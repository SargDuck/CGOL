# Conway's Game of Life C# Program
This program allows you to run Conway’s Game of Life with various useful features such as saving and loading custom patterns, adjusting dimensions, changing colors, and more all mentioned in the user guide below.
## User Guide:
### - Start and Stop Button:
This button starts and stops the simulation as you please.
### - Reset Button:
This button empties the grid and resets the statistics panel. It only works when the simulation is paused.
### - Save and Load Buttons:
The save button allows you to save the current grid state as a “*.life” file that you can name. The load button takes in any “*.life” and loads the grid state saved in that file. The file is a simple file with a x*y grid of 0s (dead cells) and 1s (alive cells) and can be edited manually using any text editor.
### - Milliseconds textbox:
This textbox allows you to input any integer you would like the simulation to run in milliseconds.
### - BG Color, Cell Color, and New Cell Color Button:
These buttons allow you to pick any color you would like to color the grid background, live cells, and newborn cells (cells born in the current generation you are viewing).
### - Fill Percentage textbox and Randomize button:
The Fill Percentage Textbox allows you to enter any integer from 0 to 100 that will determine what percent of the grid will be filled when the randomize button is clicked.
### - Statistics Panel:
This panel displays statistics including current generation, alive cells, dead cells, and newborn cells.
### - "<" & ">" buttons:
These back and forward buttons allow you to go back and forth through the generations manually step by step.
### - "x"*"y" Grid Dimension:
These two textboxes allow you to set a custom grid dimension ranging from "0 < x < 85" & "0 < y < 175".
### - Grid Lines checkbox:
This checkbox allows you to disable and enable the grid lines present between each cell.
### - Looping Grid checkbox:
This checkbox allows you to disable and enable the "Looping Grid" feature. This feature allows the outermost cells of the grid to loop back to the opposing cells on the other side of the grid and treat these cells as neighbors. When turned off, the outermost cells treat the out-of-bound cells as permanently dead.
### - Template Patterns dropdown box:
This dropdown box allows you to select any of the 14 patterns you would to place. Simply select the pattern and click the cell on the grid where you would like the top-left corner of the pattern to be.
