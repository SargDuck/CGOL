namespace ConwaysGameOfLife
{
    partial class CGOLForm
    {

        // Defines all components
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox gridUIpicBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TextBox gridSizeRowsTextBox;
        private System.Windows.Forms.TextBox gridSizeColsTextBox;
        private System.Windows.Forms.Label gridSizeLabel;
        private System.Windows.Forms.Button forwardButton;
        private System.Windows.Forms.Button backwardButton;
        private System.Windows.Forms.Button backgroundColorButton;
        private System.Windows.Forms.Button cellColorButton;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.TextBox intervalTextBox;
        private System.Windows.Forms.Label intervalLabel;
        private System.Windows.Forms.Label gridLabel;
        private System.Windows.Forms.Button newBornCellColorButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button randomizeButton;
        private System.Windows.Forms.TextBox randomizePercentageTextBox;
        private System.Windows.Forms.CheckBox gridLinesCheckBox;
        private System.Windows.Forms.Label generationsLabel;
        private System.Windows.Forms.Label liveCellsLabel;
        private System.Windows.Forms.Label newCellsLabel;
        private System.Windows.Forms.Label deadCellsLabel;
        private System.Windows.Forms.CheckBox loopingGridCheckBox;
        private System.Windows.Forms.Panel gridPanel;
        private System.Windows.Forms.ComboBox patternComboBox;
        private System.Windows.Forms.Label gridDimensionLabel;
        private System.Windows.Forms.Label fillLabel;
        private System.Windows.Forms.Label templatePatternsLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Initializes all components
        private void InitializeComponent()
        {
            this.gridUIpicBox = new System.Windows.Forms.PictureBox();
            this.startButton = new System.Windows.Forms.Button();
            this.gridSizeRowsTextBox = new System.Windows.Forms.TextBox();
            this.gridSizeColsTextBox = new System.Windows.Forms.TextBox();
            this.gridSizeLabel = new System.Windows.Forms.Label();
            this.forwardButton = new System.Windows.Forms.Button();
            this.backwardButton = new System.Windows.Forms.Button();
            this.backgroundColorButton = new System.Windows.Forms.Button();
            this.cellColorButton = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.intervalTextBox = new System.Windows.Forms.TextBox();
            this.intervalLabel = new System.Windows.Forms.Label();
            this.gridLabel = new System.Windows.Forms.Label();
            this.newBornCellColorButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.randomizeButton = new System.Windows.Forms.Button();
            this.randomizePercentageTextBox = new System.Windows.Forms.TextBox();
            this.gridLinesCheckBox = new System.Windows.Forms.CheckBox();
            this.generationsLabel = new System.Windows.Forms.Label();
            this.liveCellsLabel = new System.Windows.Forms.Label();
            this.newCellsLabel = new System.Windows.Forms.Label();
            this.deadCellsLabel = new System.Windows.Forms.Label();
            this.loopingGridCheckBox = new System.Windows.Forms.CheckBox();
            this.gridPanel = new System.Windows.Forms.Panel();
            this.patternComboBox = new System.Windows.Forms.ComboBox();
            this.gridDimensionLabel = new System.Windows.Forms.Label();
            this.fillLabel = new System.Windows.Forms.Label();
            this.templatePatternsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridUIpicBox)).BeginInit();
            this.gridPanel.SuspendLayout();
            this.SuspendLayout();
            
            // Grid UI pictureBox
            this.gridUIpicBox.Location = new System.Drawing.Point(0, 0);
            this.gridUIpicBox.Name = "gridUIpicBox";
            this.gridUIpicBox.Size = new System.Drawing.Size(2333, 1046);
            this.gridUIpicBox.TabIndex = 0;
            this.gridUIpicBox.TabStop = false;
            this.gridUIpicBox.Paint += new System.Windows.Forms.PaintEventHandler(this.GridUIpicBox_Paint);
            this.gridUIpicBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GridUIpicBox_MouseClick);
            
            // Start buttons 
            this.startButton.Location = new System.Drawing.Point(13, 13);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(100, 28);
            this.startButton.Text = "Start";
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);

            // grid Size Rows TextBox 
            this.gridSizeRowsTextBox.Location = new System.Drawing.Point(106, 52);
            this.gridSizeRowsTextBox.Name = "gridSizeRowsTextBox";
            this.gridSizeRowsTextBox.Size = new System.Drawing.Size(39, 22);
            this.gridSizeRowsTextBox.Text = "85";
            this.gridSizeRowsTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GridSizeTextBox_KeyPress);

            // Grid Size Cols TextBox 
            this.gridSizeColsTextBox.Location = new System.Drawing.Point(153, 52);
            this.gridSizeColsTextBox.Name = "gridSizeTextBoxCols";
            this.gridSizeColsTextBox.Size = new System.Drawing.Size(39, 22);
            this.gridSizeColsTextBox.Text = "175";
            this.gridSizeColsTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GridSizeTextBox_KeyPress);

            // gridSize Label
            this.gridSizeLabel.Location = new System.Drawing.Point(141, 55);
            this.gridSizeLabel.Name = "gridSizeLabel";
            this.gridSizeLabel.Size = new System.Drawing.Size(13, 16);
            this.gridSizeLabel.Text = "x";
            
            // forward Button
            this.forwardButton.Location = new System.Drawing.Point(54, 49);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(33, 28);
            this.forwardButton.Text = ">";
            this.forwardButton.Click += new System.EventHandler(this.ForwardButton_Click);
            
            // backward Button
            this.backwardButton.Location = new System.Drawing.Point(13, 49);
            this.backwardButton.Name = "backwardButton";
            this.backwardButton.Size = new System.Drawing.Size(33, 28);
            this.backwardButton.Text = "<";
            this.backwardButton.Click += new System.EventHandler(this.BackwardButton_Click);
           
            // background Color Button
            this.backgroundColorButton.Location = new System.Drawing.Point(553, 13);
            this.backgroundColorButton.Name = "backgroundColorButton";
            this.backgroundColorButton.Size = new System.Drawing.Size(100, 28);
            this.backgroundColorButton.Text = "BG Color";
            this.backgroundColorButton.Click += new System.EventHandler(this.BackgroundColorButton_Click);
            
            // cell Color Button
            this.cellColorButton.Location = new System.Drawing.Point(553, 49);
            this.cellColorButton.Name = "cellColorButton";
            this.cellColorButton.Size = new System.Drawing.Size(100, 28);
            this.cellColorButton.Text = "Cell Color";
            this.cellColorButton.Click += new System.EventHandler(this.CellColorButton_Click);
            
            // interval TextBox
            this.intervalTextBox.Location = new System.Drawing.Point(445, 16);
            this.intervalTextBox.Name = "intervalTextBox";
            this.intervalTextBox.Size = new System.Drawing.Size(65, 22);
            this.intervalTextBox.Text = "250";
            this.intervalTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntervalTextBox_KeyPress);
            
            // interval Label
            this.intervalLabel.Location = new System.Drawing.Point(508, 22);
            this.intervalLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.intervalLabel.Name = "intervalLabel";
            this.intervalLabel.Size = new System.Drawing.Size(25, 16);
            this.intervalLabel.Text = "ms";
            this.intervalLabel.AutoSize = true;

            // grid Label
            this.gridLabel.Location = new System.Drawing.Point(642, 485);
            this.gridLabel.Name = "gridLabel";
            this.gridLabel.Size = new System.Drawing.Size(106, 16);
            this.gridLabel.Text = "Grid Dimensions";
            
            // newBorn Cell ColorButton
            this.newBornCellColorButton.Location = new System.Drawing.Point(553, 85);
            this.newBornCellColorButton.Name = "newBornCellColorButton";
            this.newBornCellColorButton.Size = new System.Drawing.Size(133, 28);
            this.newBornCellColorButton.Text = "New Cell Color";
            this.newBornCellColorButton.Click += new System.EventHandler(this.NewBornCellColorButton_Click);
             
            // reset Button
            this.resetButton.Location = new System.Drawing.Point(121, 13);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(100, 28);
            this.resetButton.Text = "Reset";
            this.resetButton.Click += new System.EventHandler(this.ResetButton_Click);
            
            // save Button
            this.saveButton.Location = new System.Drawing.Point(229, 13);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 28);
            this.saveButton.Text = "Save";
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
             
            // load Button
            this.loadButton.Location = new System.Drawing.Point(337, 13);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(100, 28);
            this.loadButton.Text = "Load";
            this.loadButton.Click += new System.EventHandler(this.LoadButton_Click);
            
            // randomize Button
            this.randomizeButton.Location = new System.Drawing.Point(821, 16);
            this.randomizeButton.Name = "randomizeButton";
            this.randomizeButton.Size = new System.Drawing.Size(100, 28);
            this.randomizeButton.Text = "Randomize";
            this.randomizeButton.Click += new System.EventHandler(this.RandomizeButton_Click);
            
            // randomize Percentage TextBox
            this.randomizePercentageTextBox.Location = new System.Drawing.Point(714, 16);
            this.randomizePercentageTextBox.Name = "randomizePercentageTextBox";
            this.randomizePercentageTextBox.Size = new System.Drawing.Size(65, 22);
            this.randomizePercentageTextBox.Text = "20";
            
            // grid Lines CheckBox
            this.gridLinesCheckBox.Checked = true;
            this.gridLinesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gridLinesCheckBox.Location = new System.Drawing.Point(327, 54);
            this.gridLinesCheckBox.Name = "gridLinesCheckBox";
            this.gridLinesCheckBox.Size = new System.Drawing.Size(89, 20);
            this.gridLinesCheckBox.Text = "Grid Lines";
            this.gridLinesCheckBox.AutoSize = true;
            this.gridLinesCheckBox.CheckedChanged += new System.EventHandler(this.GridLinesCheckBox_CheckedChanged);
            
            // generations Label
            this.generationsLabel.Location = new System.Drawing.Point(711, 42);
            this.generationsLabel.Name = "generationsLabel";
            this.generationsLabel.Size = new System.Drawing.Size(83, 16);
            this.generationsLabel.Text = "Generations:";
            this.generationsLabel.AutoSize = true;

            // live Cells Label
            this.liveCellsLabel.Location = new System.Drawing.Point(711, 58);
            this.liveCellsLabel.Name = "liveCellsLabel";
            this.liveCellsLabel.Size = new System.Drawing.Size(68, 16);
            this.liveCellsLabel.Text = "Live Cells:";
            this.liveCellsLabel.AutoSize = true;

            // new Cells Label
            this.newCellsLabel.Location = new System.Drawing.Point(711, 74);
            this.newCellsLabel.Name = "newCellsLabel";
            this.newCellsLabel.Size = new System.Drawing.Size(70, 16);
            this.newCellsLabel.Text = "New Cells:";
            this.newCellsLabel.AutoSize = true;

            // dead Cells Label
            this.deadCellsLabel.Location = new System.Drawing.Point(711, 90);
            this.deadCellsLabel.Name = "deadCellsLabel";
            this.deadCellsLabel.Size = new System.Drawing.Size(77, 16);
            this.deadCellsLabel.Text = "Dead Cells:";
            this.deadCellsLabel.AutoSize = true;


            // looping Grid CheckBox
            this.loopingGridCheckBox.Location = new System.Drawing.Point(327, 81);
            this.loopingGridCheckBox.Name = "loopingGridCheckBox";
            this.loopingGridCheckBox.Size = new System.Drawing.Size(106, 20);
            this.loopingGridCheckBox.Text = "Looping Grid";
            this.loopingGridCheckBox.AutoSize = true;
            this.loopingGridCheckBox.CheckedChanged += new System.EventHandler(this.LoopingGridCheckBox_CheckedChanged);
            
            // grid Panel
            this.gridPanel.Controls.Add(this.gridUIpicBox);
            this.gridPanel.Location = new System.Drawing.Point(16, 135);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(2347, 1108);
            
            // pattern ComboBox
            this.patternComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.patternComboBox.Items.AddRange(new object[] {
            "None",
            "Block",
            "Beehive",
            "Loaf",
            "Boat",
            "Tub",
            "Blinker",
            "Toad",
            "Beacon",
            "Pulsar",
            "Pentadecathlon",
            "Glider",
            "LWSS",
            "MWSS",
            "HWSS"});
            this.patternComboBox.Location = new System.Drawing.Point(13, 101);
            this.patternComboBox.Name = "patternComboBox";
            this.patternComboBox.Size = new System.Drawing.Size(199, 24);
            this.patternComboBox.SelectedIndexChanged += new System.EventHandler(this.PatternComboBox_SelectedIndexChanged);
            
            // grid Dimension Label
            this.gridDimensionLabel.Location = new System.Drawing.Point(189, 55);
            this.gridDimensionLabel.Name = "gridDimension";
            this.gridDimensionLabel.Size = new System.Drawing.Size(99, 16);
            this.gridDimensionLabel.AutoSize = true;
            this.gridDimensionLabel.Text = "Grid Dimension";
             
            // fill Label
            this.fillLabel.Location = new System.Drawing.Point(780, 22);
            this.fillLabel.Name = "fill";
            this.fillLabel.Size = new System.Drawing.Size(34, 16);
            this.fillLabel.AutoSize = true;

            this.fillLabel.Text = "% fill";

            // Template Patterns Label
            this.templatePatternsLabel.Location = new System.Drawing.Point(10, 81);
            this.templatePatternsLabel.Name = "templatePatterns";
            this.templatePatternsLabel.Size = new System.Drawing.Size(120, 16);
            this.templatePatternsLabel.Text = "Template Patterns:";
            this.templatePatternsLabel.AutoSize = true;

            // CGOLForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2560, 1329);
            this.Controls.Add(this.templatePatternsLabel);
            this.Controls.Add(this.fillLabel);
            this.Controls.Add(this.gridDimensionLabel);
            this.Controls.Add(this.patternComboBox);
            this.Controls.Add(this.gridPanel);
            this.Controls.Add(this.loopingGridCheckBox);
            this.Controls.Add(this.deadCellsLabel);
            this.Controls.Add(this.newCellsLabel);
            this.Controls.Add(this.liveCellsLabel);
            this.Controls.Add(this.generationsLabel);
            this.Controls.Add(this.gridLinesCheckBox);
            this.Controls.Add(this.randomizePercentageTextBox);
            this.Controls.Add(this.randomizeButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.newBornCellColorButton);
            this.Controls.Add(this.intervalLabel);
            this.Controls.Add(this.gridLabel);
            this.Controls.Add(this.intervalTextBox);
            this.Controls.Add(this.cellColorButton);
            this.Controls.Add(this.backgroundColorButton);
            this.Controls.Add(this.backwardButton);
            this.Controls.Add(this.forwardButton);
            this.Controls.Add(this.gridSizeLabel);
            this.Controls.Add(this.gridSizeColsTextBox);
            this.Controls.Add(this.gridSizeRowsTextBox);
            this.Controls.Add(this.startButton);
            this.Name = "CGOLForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Conway\'s Game of Life";
            ((System.ComponentModel.ISupportInitialize)(this.gridUIpicBox)).EndInit();
            this.gridPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        
    }
}
