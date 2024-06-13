# MazeRunner
# Assignment 2 - Recursion to solve a maze

## Author
Ryan VanderVeen


## Description

Creating a program that will traverse a 12 x 12 (2D array) maze looking for orbs that are placed in the maze. Once all of the orbs have been found, the program must continue traversing the maze and find a successful path from the last collected orb to an exit. 

Each spot in the maze is represented by either a '#', '.', or '@'. The #'s represent the walls of the maze, the dots represent paths through the maze, and the @'s represent the orbs that must be collected. Moves can be made only up, down, left, or right (not diagonally), one spot at a time, and only over paths / orbs (not into or across a wall).

The exit will be any spot that is on the outside of the array. As the program attempts to collect all the orbs, it will place the character '+' in each spot along the path. If a dead end is reached, the program will replace the '+' with a '-'. Once all orbs have been collected, it will place the character 'X' in each spot along the path. If a dead end is reached, the program will replace the X’s with 'O'.

The output of the program is the maze configuration after each move. This assume that each maze has a path from its starting point to its exit point. If there is no exit, the program will arrive at the starting spot again.

In addition to solving the maze as is, this program will also solve a transposition of the maze. There is a method stub in the main program for transposing the 2D array. This method is just that, a stub. This program is be able to solve both of them without any issue.

In this program, recursion is used to solve this problem.
