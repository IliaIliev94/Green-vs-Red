# Green-vs-Red

This is my solution to the Green vs Red challange.

The Program class is the main class which recieves user input and instantiates the other classes(Cell and Board).

The Cell class represents the 0s (red color) and 1s (green color) for the task and it contains an X and Y coordinate propery as well as a mutate method
which changes its status from red to green and vice verca.

The Board class contains an array of green and red cells, as well as:

- A GreenCountTimes() method, which returns the number of times a cell has been green from generation 0 to generation N.
