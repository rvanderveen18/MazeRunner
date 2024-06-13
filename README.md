# MazeRunner
# Assignment 2 - Recursion to solve a maze

## Author
Ryan VanderVeen


## Description

You must write a program that will traverse a 12 x 12 maze looking for orbs that are placed in the maze. Once all of the orbs have been found, the program must continue traversing the maze and find a successful path from the last collected orb to an exit. You are given a hard coded maze in the program class, as well as some starting coordinates.

Each spot in the maze is represented by either a '#', '.', or '@'. The #'s represent the walls of the maze, the dots represent paths through the maze, and the @'s represent the orbs that must be collected. Moves can be made only up, down, left, or right (not diagonally), one spot at a time, and only over paths / orbs (not into or across a wall).

The exit will be any spot that is on the outside of the array. As your program attempts to collect all the orbs, it will place the character '+' in each spot along the path. If a dead end is reached, your program should replace the '+' with a '-'. Once all orbs have been collected, it should place the character 'X' in each spot along the path. If a dead end is reached, your program should replace the X’s with 'O'.

The output of your program is the maze configuration after each move. In your testing, you may assume that each maze has a path from its starting point to its exit point. If there is no exit, you will arrive at the starting spot again.

In addition to solving the maze as is, I want you to also solve the transposition of the maze. There is a method stub in the main program for transposing the 2D array. This method is just that, a stub. You need to fill out the code to make that transpose method work. The program is already setup to solve both the original maze, and the transposed maze. Your program should be able to solve both of them without any issue.

You are required to use recursion to solve this problem.
