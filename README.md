# Conway's Game of Life C# Program

This program enables you to run Conway’s Game of Life with various features such as saving and loading custom patterns, adjusting dimensions, changing colors, and more. Please refer to the user guide below for detailed instructions.

## Dev documentation:

Available inside the CGOL.cs and CGOL.Designer.cs files.

## User Guide:

To start the applications, simply download the files and go to ConwaysGameOfLife/ConwaysGameOfLife/bin/Release and launch the ConwaysGameOfLife.exe file

### Start and Stop Button:
- **Function:** Starts or stops the simulation.
- **Usage:** Click to toggle the simulation on or off.

### Reset Button:
- **Function:** Empties the grid and resets the statistics panel.
- **Usage:** Click to reset while the simulation is paused.

### Save and Load Buttons:
- **Save Button:**
  - **Function:** Saves the current grid state as a “*.life” file.
  - **Usage:** Click to save and name the file.
- **Load Button:**
  - **Function:** Loads a saved “*.life” file to restore the grid state.
  - **Usage:** Click to browse and select a “*.life” file.

### Milliseconds Textbox:
- **Function:** Sets the simulation speed.
- **Usage:** Enter an integer value to specify the delay between generations in milliseconds.

### BG Color, Cell Color, and New Cell Color Buttons:
- **BG Color Button:**
  - **Function:** Changes the background color of the grid.
  - **Usage:** Click to choose a color.
- **Cell Color Button:**
  - **Function:** Changes the color of live cells.
  - **Usage:** Click to choose a color.
- **New Cell Color Button:**
  - **Function:** Changes the color of newborn cells (cells born in the current generation).
  - **Usage:** Click to choose a color.

### Fill Percentage Textbox and Randomize Button:
- **Fill Percentage Textbox:**
  - **Function:** Sets the percentage of the grid to be filled with live cells when randomizing.
  - **Usage:** Enter an integer from 0 to 100.
- **Randomize Button:**
  - **Function:** Fills the grid randomly based on the specified fill percentage.
  - **Usage:** Click to apply the random fill.

### Statistics Panel:
- **Function:** Displays simulation statistics.
- **Details Displayed:**
  - Current generation
  - Number of alive cells
  - Number of dead cells
  - Number of newborn cells

### "<" and ">" Buttons:
- **Back Button ("<"):**
  - **Function:** Moves the simulation one generation backward.
  - **Usage:** Click to step back.
- **Forward Button (">"):**
  - **Function:** Moves the simulation one generation forward.
  - **Usage:** Click to step forward.

### Grid Dimension Textboxes:
- **Function:** Sets custom grid dimensions.
- **Usage:** Enter values for width (x) and height (y) within the range "0 < x < 85" and "0 < y < 175".

### Grid Lines Checkbox:
- **Function:** Toggles grid lines between cells.
- **Usage:** Check or uncheck to enable or disable grid lines.

### Looping Grid Checkbox:
- **Function:** Toggles the looping grid feature.
- **Usage:** Check to enable looping (outer cells connect to the opposite side), uncheck to disable (outer cells treat out-of-bounds as dead).

### Template Patterns Dropdown Box:
- **Function:** Inserts predefined patterns into the grid.
- **Usage:** Select a pattern from the dropdown, then click on the grid where you want the top-left corner of the pattern to appear.
