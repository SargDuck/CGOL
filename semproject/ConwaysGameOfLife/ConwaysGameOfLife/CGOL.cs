// imports of used libraries
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Security.AccessControl;
using System.Windows.Forms;
using System.IO;


// Namespace and CGOLForm class 
namespace ConwaysGameOfLife {
    public partial class CGOLForm : Form {

        // All variables to be used in this code
        private int rows = 85;
        private int cols = 175;
        private bool[,] currentGen;
        private bool[,] nextGen;
        private Stack<bool[,]> history;
        private Timer timer;
        private readonly int cellSize = 10;
        private Color cellColor = Color.Black;
        private Color newBornCellColor = Color.Black;
        private Color backgroundColor = Color.White;
        private bool[,] bornCells;
        private int gens = 0;
        private int newCells = 0;
        private int deadCells = 0;
        private bool showGridLines = true;
        private bool loopingGrid = false;
        private enum Pattern
        {
            None,
            Block,
            Beehive,
            Loaf,
            Boat,
            Tub,

            Blinker,
            Toad,
            Beacon,
            Pulsar,
            PentaDecathlon,

            Glider,
            LWSS,
            MWSS,
            HWSS
        }
        private Pattern selectedPattern = Pattern.None;

        // Constructor to initialize the form
        public CGOLForm() {
            InitializeComponent();
            InitializeGame();
        }

        // initialize all variables that need initialization and starts the timer
        private void InitializeGame() {
            currentGen = new bool[rows, cols];
            nextGen = new bool[rows, cols];
            bornCells = new bool[rows, cols];
            history = new Stack<bool[,]>();
            timer = new Timer
            {
                Interval = 250
            };
            timer.Tick += Timer_Tick;
            gens = 0;
            newCells = 0;
            deadCells = 0;
            UpdateGridUIpicBoxSize();
        }

        // Sets the Grid UI winform picture box sizes based on our rows and cols' dimensions
        private void UpdateGridUIpicBoxSize() {
            gridUIpicBox.Size = new Size(cols * cellSize, rows * cellSize);
        }

        // Event handler for our timer ticks which updates the gens and UI
        private void Timer_Tick(object sender, EventArgs e) {
            UpdateGen();
            gridUIpicBox.Invalidate();
            UpdateStats();
        }

        // Updates the current gen based on the game's rules
        private void UpdateGen() {
            // pushes a copy of the currentGen 2d array into the history stack
            history.Push((bool[,])currentGen.Clone());
            // clears the bornCells array
            Array.Clear(bornCells, 0, bornCells.Length);

            int newBornCells = 0;
            int diedCells = 0;

            // Loops through the whole grid
            for (int y = 0; y < rows; y++) {
                for (int x = 0; x < cols; x++) {
                    // and follows the standard rules of Conway's Game of Life:
                    int aliveNeighbors = CountAliveNeighbors(x, y);
                    if (currentGen[y, x]) {
                        // If any ALIVE cell has 2 or 3 alive neighbors, it remains alive. Otherwise, it dies
                        nextGen[y, x] = aliveNeighbors == 2 || aliveNeighbors == 3;
                        if (!nextGen[y, x]) {
                            diedCells++;
                        }
                    }
                    else {
                        // If any dead cell has exactly 3 alive neighbors, it becomes alive
                        if (aliveNeighbors == 3) {
                            nextGen[y, x] = true;
                            bornCells[y, x] = true;
                            newBornCells++;
                        }
                        // If none of the conditions are met, the cell remains dead
                        else {
                            nextGen[y, x] = false;
                        }
                    }
                }
            }

            (currentGen, nextGen) = (nextGen, currentGen);

            gens++;
            newCells = newBornCells;
            deadCells = diedCells;

        }

        // Counts the number of alive neighbors of a cell at x & y.
        private int CountAliveNeighbors(int x, int y) {
            int c = 0;
            for (int yOffset = -1; yOffset <= 1; yOffset++) {
                for (int xOffset = -1; xOffset <= 1; xOffset++) {
                    if (xOffset == 0 && yOffset == 0) 
                        continue;
                    int xOffsetCoords = x + xOffset;
                    int yOffsetCoords = y + yOffset;
                    if (loopingGrid) {
                        if (xOffsetCoords < 0) xOffsetCoords = cols - 1;
                        if (yOffsetCoords < 0) yOffsetCoords = rows - 1;
                        if (xOffsetCoords >= cols) xOffsetCoords = 0;
                        if (yOffsetCoords >= rows) yOffsetCoords = 0;
                        if (currentGen[yOffsetCoords, xOffsetCoords]) c++;
                    }
                    if (!loopingGrid && xOffsetCoords >= 0 && xOffsetCoords < cols && yOffsetCoords >= 0 && yOffsetCoords < rows) {
                        if (currentGen[yOffsetCoords, xOffsetCoords]) 
                            c++;
                    }
                }
            }
            return c;
        }

        // Paints the grid, cells, and grid lines on the "GridUIpicBox"
        private void GridUIpicBox_Paint(object sender, PaintEventArgs e) {
            // Defines the graphics object used for drawing
            Graphics g = e.Graphics;
            // Sets the background color
            g.Clear(backgroundColor);
            for (int y = 0; y < rows; y++) {
                for (int x = 0; x < cols; x++) {
                    // Creates a rectange object at x & y with a size determined by the cell size (10) 
                    Rectangle cell = new Rectangle(x*cellSize, y*cellSize, cellSize, cellSize);
                    // Colors the cell with the selected colors
                    if (currentGen[y, x]) {
                        if (bornCells[y, x]) {
                            g.FillRectangle(new SolidBrush(newBornCellColor), cell);
                        }
                        else {
                            g.FillRectangle(new SolidBrush(cellColor), cell);
                        }
                    }
                    // Colors the grid if the user wants the grid lines shown
                    if (showGridLines) {
                        g.DrawRectangle(Pens.Gray, cell);
                    }
                }
            }

            // Creates a thick black pen to draw the outermost border lines
            Pen thickPen = new Pen(Color.Black, 2);
            // Colors the top, right, bottom, and left border lines respectively
            g.DrawLine(thickPen, 0, 0, cols * cellSize, 0);
            g.DrawLine(thickPen, cols * cellSize, 0, cols * cellSize, rows * cellSize);
            g.DrawLine(thickPen, 0, rows * cellSize, cols * cellSize, rows * cellSize);
            g.DrawLine(thickPen, 0, 0, 0, rows * cellSize);
            
        }

        // Handles the mouse clicks that toggle cells or place patterns
        private void GridUIpicBox_MouseClick(object sender, MouseEventArgs e) {
            // Finds the cell that was clicked using the mouse coords and cellsize
            int x = e.X / cellSize;
            int y = e.Y / cellSize;

            // Checks if the coords are in a valid grid range
            if (x >= 0 && y >= 0 && x < cols && y < rows) {
                // If a pattern is selected, calls the pattern's function to place the pattern with the x & y being the topleft corner
                if (selectedPattern != Pattern.None) {
                    PlacePattern(x, y);
                }
                // Otherwise, places a cell
                else {
                    currentGen[y, x] = !currentGen[y, x];
                }
                // Updates the grid UI and statistics panel
                gridUIpicBox.Invalidate();
                UpdateStats();
            }
        }

        // Places the selected pattern on the grid at a specific location
        private void PlacePattern(int startX, int startY) {
            switch (selectedPattern) {
                case Pattern.Glider:
                    AddGlider(startX, startY);
                    break;
                case Pattern.Blinker:
                    AddBlinker(startX, startY);
                    break;
                case Pattern.Pulsar:
                    AddPulsar(startX, startY);
                    break;
                case Pattern.Block:
                    AddBlock(startX, startY);
                    break;
                case Pattern.Beehive:
                    AddBeehive(startX, startY);
                    break;
                case Pattern.Loaf:
                    AddLoaf(startX, startY);
                    break;
                case Pattern.Boat:
                    AddBoat(startX, startY);
                    break;
                case Pattern.Tub:
                    AddTub(startX, startY);
                    break;
                case Pattern.Beacon:
                    AddBeacon(startX, startY);
                    break;
                case Pattern.Toad:
                    AddToad(startX, startY);
                    break;
                case Pattern.PentaDecathlon:
                    AddPentaDecathlon(startX, startY);
                    break;
                case Pattern.LWSS:
                    AddLWSS(startX, startY);
                    break;
                case Pattern.MWSS:
                    AddMWSS(startX, startY);
                    break;
                case Pattern.HWSS:
                    AddHWSS(startX, startY);
                    break;
            }
        }

        // Handles starting and stopping the timer
        private void StartButton_Click(object sender, EventArgs e) {
            // Stops the timer if it's on and vice versa
            if (timer.Enabled) {
                timer.Stop();
                startButton.Text = "Start";
            }
            else {
                timer.Start();
                startButton.Text = "Stop";
            }
        }

        // Handles advancing the current gen by one step
        private void ForwardButton_Click(object sender, EventArgs e) {
            // Updates the gen, grid UI, and statistics panel
            UpdateGen();
            gridUIpicBox.Invalidate();
            UpdateStats();
        }

        // Handles going back the current gen by one step using the history stack
        private void BackwardButton_Click(object sender, EventArgs e) {
            // uses the history stack to copy the previous generations
            // A history stack is needed since Conway's Game of Life can't be reversed intuitively due to its rules.
            if (history.Count > 0) {
                currentGen = history.Pop();
                gridUIpicBox.Invalidate();
                gens--;
                UpdateStats();
            }
        }

        // Handles what happens when the user presses enter on the grid dimension text boxes
        private void GridSizeTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            // checks if the user pressed "enter"
            if (e.KeyChar == (char)Keys.Enter) {
                // checks if the user entered valid numbers into dimension boxes
                if (int.TryParse(gridSizeRowsTextBox.Text, out int newRows) && int.TryParse(gridSizeColsTextBox.Text, out int newCols)) {
                    // if so, the update the grid
                    rows = newRows;
                    cols = newCols;
                    InitializeGame();
                    gridUIpicBox.Invalidate();
                }
            }
        }

        // Handles what happens when the user presses enter on the interval text box
        private void IntervalTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            // checks if the user pressed "enter"
            if (e.KeyChar == (char)Keys.Enter) {
                // checks if the user entered a valid number into the interval box
                if (int.TryParse(intervalTextBox.Text, out int newInterval)) {
                    // if so, update the timer interval
                    timer.Interval = newInterval;
                }
            }
        }

        // Handles the bg coloring
        private void BackgroundColorButton_Click(object sender, EventArgs e) {
            // if the user clicked "OK"
            if (colorDialog.ShowDialog() == DialogResult.OK) {
                // updates the background color
                backgroundColor = colorDialog.Color;
                gridUIpicBox.Invalidate();
            }
        }

        // Handles the cell coloring
        private void CellColorButton_Click(object sender, EventArgs e) {
            if (colorDialog.ShowDialog() == DialogResult.OK) {
                cellColor = colorDialog.Color;
                gridUIpicBox.Invalidate();
            }
        }

        // Handles the new cells coloring
        private void NewBornCellColorButton_Click(object sender, EventArgs e) {
            if (colorDialog.ShowDialog() == DialogResult.OK) {
                newBornCellColor = colorDialog.Color;
                gridUIpicBox.Invalidate();
            }
        }

        // Handles the chosen pattern in the drop down box
        private void PatternComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            selectedPattern = (Pattern)patternComboBox.SelectedIndex;
        }

        // Handles the reset button
        private void ResetButton_Click(object sender, EventArgs e) {
            // Resets the grid only when the timer is stopped
            if (!timer.Enabled) {
                InitializeGame();
                gridUIpicBox.Invalidate();
                UpdateStats();
            }

        }

        // Handles how the file is saved when the save button is clicked
        private void SaveButton_Click(object sender, EventArgs e) {
            // This creates an instance of "SaveFileDialog" which lets us specify the name and location of the file
            SaveFileDialog saveFileDialog = new SaveFileDialog {
                // This saves our files with the ".life" extension
                Filter = "Life Files|*.life"
            };
            // Checks if the user clicked the "save" button
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                // A "StreamWriter" instance is created associated with the file we created
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName)) {
                    // Loops through the grid and writes 1 if the cell is filled and 0 otherwise.
                    for (int y = 0; y < rows; y++) {
                        for (int x = 0; x < cols; x++) {
                            writer.Write(currentGen[y, x] ? '1' : '0');
                        }
                        writer.WriteLine();
                    }
                }
            }
        }

        // Handles how the file is loaded when the load button is clicked
        private void LoadButton_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog {
                Filter = "Life Files|*.life"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                using (StreamReader reader = new StreamReader(openFileDialog.FileName)) {
                    for (int y = 0; y < rows; y++) {
                        string line = reader.ReadLine();
                        for (int x = 0; x < cols; x++) {
                            // Works the same way until we reach
                            // if the x,y contains 1, sets the cell at x,y to true
                            currentGen[y, x] = line[x] == '1';
                        }
                    }
                }
                gridUIpicBox.Invalidate();
                UpdateStats();
            }
        }

        // Handles what happens when the randomize button is clicked
        private void RandomizeButton_Click(object sender, EventArgs e) {
            // Creates an instance of the "random" class
            Random rand = new Random();
            // Sets the percent threshold to what the user defined in the percent text box
            int percentage = int.Parse(randomizePercentageTextBox.Text);

            // Loops through the grid
            for (int y = 0; y < rows; y++) {
                for (int x = 0; x < cols; x++) {
                    // and generates a number between 0 and 99 and compares it with the threshold
                    currentGen[y, x] = rand.Next(100) < percentage;
                }
            }
            gridUIpicBox.Invalidate();
            UpdateStats();
        }

        // Handles what happens when the grid lines check box is checked
        private void GridLinesCheckBox_CheckedChanged(object sender, EventArgs e) {
            showGridLines = gridLinesCheckBox.Checked;
            gridUIpicBox.Invalidate();
        }

        // Handles what happens when the looping grid check box is checked
        private void LoopingGridCheckBox_CheckedChanged(object sender, EventArgs e) {
            loopingGrid = loopingGridCheckBox.Checked;
            gridUIpicBox.Invalidate();
        }

        // Updates the statistics panel
        private void UpdateStats() {
            generationsLabel.Text = $"Generations: {gens}";
            liveCellsLabel.Text = $"Live Cells: {CountLiveCells()}";
            newCellsLabel.Text = $"New Cells: {newCells}";
            deadCellsLabel.Text = $"Dead Cells: {deadCells}";
        }

        // Counts the live cells in the grid
        private int CountLiveCells() {
            int liveCells = 0;
            for (int y = 0; y < rows; y++) {
                for (int x = 0; x < cols; x++) {
                    if (currentGen[y, x]) 
                        liveCells++;
                }
            }
            return liveCells;
        }

        private void AddGlider(int startX, int startY) {
            if (startX < cols - 2 && startY < rows - 2) {
                currentGen[startY, startX + 1] = true;
                currentGen[startY + 1, startX + 2] = true;
                currentGen[startY + 2, startX] = true;
                currentGen[startY + 2, startX + 1] = true;
                currentGen[startY + 2, startX + 2] = true;
            }
        }

        // All add pattern functions follow one of 2 formulas
        // directly settings the cells
        // or defining the offset and setting the cells through the offset
        private void AddBlinker(int startX, int startY) {
            if (startX < cols - 1 && startY < rows - 1) {
                currentGen[startY, startX] = true;
                currentGen[startY, startX + 1] = true;
                currentGen[startY, startX + 2] = true;
            }
        }

        private void AddPulsar(int startX, int startY) {
            if (startX >= 0 && startX + 12 < cols && startY >= 0 && startY + 12 < rows) {
                int[][] offsets = {
                    new int[] { 2, 0 }, new int[] { 3, 0 }, new int[] { 4, 0 }, new int[] {8,0}, new int[] {9,0},new int[] {10,0},
                    new int[] { 2, 12 }, new int[] { 3, 12 }, new int[] { 4, 12 }, new int[] {8,12}, new int[] {9,12},new int[] {10,12},
                    new int[] { 0, 2 }, new int[] { 0, 3 }, new int[] { 0, 4 }, new int[] {0,8}, new int[] {0,9},new int[] {0,10},
                    new int[] { 12, 2 }, new int[] { 12, 3 }, new int[] { 12, 4 }, new int[] {12,8}, new int[] {12,9},new int[] {12,10},
                    new int[] { 5, 2 }, new int[] { 5, 3 }, new int[] { 5, 4 }, new int[] { 5, 8 }, new int[] { 5, 9 }, new int[] { 5, 10 },
                    new int[] { 7, 2 }, new int[] { 7, 3 }, new int[] { 7, 4 }, new int[] { 7, 8 }, new int[] { 7, 9 }, new int[] { 7, 10 },
                    new int[] { 2, 5 }, new int[] { 3, 5 }, new int[] { 4, 5 }, new int[] { 8, 5 }, new int[] { 9, 5 }, new int[] { 10, 5 },
                    new int[] { 2, 7 }, new int[] { 3, 7 }, new int[] { 4, 7 }, new int[] { 8, 7 }, new int[] { 9, 7 }, new int[] { 10, 7 },
                };
                foreach (var offset in offsets) {
                    currentGen[startY + offset[1], startX + offset[0]] = true;
                }
            }
        }

        private void AddBlock(int startX, int startY) {
            if (startX < cols - 1 && startY < rows - 1) {
                currentGen[startY, startX] = true;
                currentGen[startY, startX + 1] = true;
                currentGen[startY + 1, startX] = true;
                currentGen[startY + 1, startX + 1] = true;
            }
        }

        private void AddBeehive(int startX, int startY) {
            if (startX < cols - 2 && startY < rows - 1) {
                currentGen[startY, startX + 1] = true;
                currentGen[startY, startX + 2] = true;
                currentGen[startY + 1, startX] = true;
                currentGen[startY + 1, startX + 3] = true;
                currentGen[startY + 2, startX + 1] = true;
                currentGen[startY + 2, startX + 2] = true;
            }
        }

        private void AddLoaf(int startX, int startY) {
            if (startX < cols - 2 && startY < rows - 2) {
                currentGen[startY, startX + 1] = true;
                currentGen[startY, startX + 2] = true;
                currentGen[startY + 1, startX] = true;
                currentGen[startY + 1, startX + 3] = true;
                currentGen[startY + 2, startX + 1] = true;
                currentGen[startY + 2, startX + 3] = true;
                currentGen[startY + 3, startX + 2] = true;
            }
        }

        private void AddBoat(int startX, int startY) {
            if (startX < cols - 2 && startY < rows - 1) {
                currentGen[startY, startX] = true;
                currentGen[startY, startX + 1] = true;
                currentGen[startY + 1, startX] = true;
                currentGen[startY + 1, startX + 2] = true;
                currentGen[startY + 2, startX + 1] = true;
            }
        }

        private void AddTub(int startX, int startY) {
            if (startX < cols - 1 && startY < rows - 1) {
                currentGen[startY, startX + 1] = true;
                currentGen[startY + 1, startX] = true;
                currentGen[startY + 1, startX + 2] = true;
                currentGen[startY + 2, startX + 1] = true;
            }
        }

        private void AddBeacon(int startX, int startY) {
            if (startX < cols - 3 && startY < rows - 3) {
                currentGen[startY, startX] = true;
                currentGen[startY, startX + 1] = true;
                currentGen[startY + 1, startX] = true;
                currentGen[startY + 1, startX + 1] = true;
                currentGen[startY + 2, startX + 2] = true;
                currentGen[startY + 2, startX + 3] = true;
                currentGen[startY + 3, startX + 2] = true;
                currentGen[startY + 3, startX + 3] = true;
            }
        }

        private void AddToad(int startX, int startY) {
            if (startX < cols - 3 && startY < rows - 1) {
                currentGen[startY, startX + 1] = true;
                currentGen[startY, startX + 2] = true;
                currentGen[startY, startX + 3] = true;
                currentGen[startY + 1, startX] = true;
                currentGen[startY + 1, startX + 1] = true;
                currentGen[startY + 1, startX + 2] = true;
            }
        }

        private void AddPentaDecathlon(int startX, int startY) {
            if (startX < cols - 3 && startY < rows - 11) {
                int[][] offsets = {
                    new int[] { 1, 0 }, new int[] { 1, 1 }, new int[] { 0, 2 }, new int[] { 2, 2 }, new int[] { 1, 3 }, new int[] { 1, 4 }, new int[] { 1, 5 }, new int[] { 1, 6 }, new int[] { 1, 9 }, new int[] { 1, 8 }, new int[] { 0, 7}, new int[] { 2, 7 },
                };
                foreach (var offset in offsets) {
                    currentGen[startY + offset[1], startX + offset[0]] = true;
                }
            }
        }

        private void AddLWSS(int startX, int startY) {
            if (startX < cols - 4 && startY < rows - 3) {
                int[][] offsets = {
                    new int[] { 1, 0 }, new int[] { 4, 0 }, new int[] { 0, 1 }, new int[] { 0, 2 }, new int[] { 4, 2 }, new int[] { 0, 3 }, new int[] { 1, 3 }, new int[] { 2, 3 }, new int[] { 3, 3 }
                };
                foreach (var offset in offsets) {
                    currentGen[startY + offset[1], startX + offset[0]] = true;
                }
            }
        }

        private void AddMWSS(int startX, int startY) {
            if (startX < cols - 6 && startY < rows - 4) {
                int[][] offsets = {
                    new int[] { 3, 0 }, new int[] { 1, 1 }, new int[] { 5, 1 }, new int[] { 5, 3 }, new int[] { 0, 2 }, new int[] { 0, 2 }, new int[] { 0, 3 }, new int[] { 0, 4 }, new int[] { 1, 4 }, new int[] { 2, 4 }, new int[] { 3, 4 }, new int[] { 4, 4 }
                };
                foreach (var offset in offsets) {
                    currentGen[startY + offset[1], startX + offset[0]] = true;
                }
            }
        }

        private void AddHWSS(int startX, int startY) {
            if (startX < cols - 6 && startY < rows - 3) {
                int[][] offsets = {
                    new int[] { 3, 0 }, new int[] { 4, 0 }, new int[] { 1, 1 }, new int[] { 6, 1 }, new int[] { 0, 2 }, new int[] { 0, 2 }, new int[] { 0, 3 }, new int[] { 6, 3 }, new int[] { 0, 4 }, new int[] { 1, 4 }, new int[] { 2, 4 }, new int[] { 3, 4 }, new int[] { 4, 4 }, new int[] { 5, 4 }
                };

                foreach (var offset in offsets) {
                    currentGen[startY + offset[1], startX + offset[0]] = true;
                }
            }
        }

    }
}
