// Ryan VanderVeen
// CIS 237
// 09/30/2022

using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace cis237_assignment_2
{

    class MazeSolver
    {
        // class level variables to be used within the recursive method to keep track of orbs and exit criteria
        int orbs = 0;
        bool foundExit = false;


        /// <summary>
        /// Helper method to setup variables for the Recursive method. 
        /// Calling the mazeTraversal recursive method, passing the maze array, x/y start positions.
        /// </summary>
        public void SolveMaze(char[,] maze, int xStart, int yStart)
        {
            // Start with removing the orbs and getting it to work without the orbs
            mazeTraversal(maze, yStart, xStart);

            // Resetting class level variables
            orbs = 0;
            foundExit = false;
        }


        /// <summary>
        /// Recursive method. Documentation for each step is outlined in the method itself. 
        /// General outline: 
        /// 1. check current position for an orb, add if found
        /// 2. check if the end has been reached
        ///     2.a. if so, check if all 4 orbs have been collected
        ///         2.a.a. Exit has been found. Place X at end, change foundExit to true so program can end
        ///     2.b. if not, keep placing - and return to previous method call as to not continue checking other directions
        /// 3. Check if we are still within the confines of the maze and we are not clear to leave (orbs are not collected)
        ///     3.a. Move in valid directions. Prior to all orbs collected: (. or @), after orbs collected (+ or - or .)
        ///     3.b. If none of the directions worked, place - prior to orbs collected. Place O after all orbs collected.
        /// </summary>
        private void mazeTraversal(char[,] maze, int currentY, int currentX)
        {
            // 1. check current position for an orb. Add + 1 to orbs if so
            if (maze[currentY, currentX] == '@')
            {
                this.orbs += 1;
            }


            // 2. Checking to see if we have reached the end
            if (currentY == maze.GetLength(0) - 1 || currentX == maze.GetLength(1) - 1)
            {
                // if all orbs collected, mark spot with X and foundExit is true and program can stop recursing
                if (this.orbs == 4)
                {   
                    // foundExit = true signifies that we have reached the end of the maze AND all orbs have been collected
                    this.foundExit = true;

                    // Printing X at the current valid spot
                    maze[currentY, currentX] = 'X';
                    printMaze(maze);
                    // delay
                    System.Threading.Thread.Sleep(400);

                    // Clearing console
                    Console.Clear();
                }

                // if we have reached the end of the maze but all orbs have not been found, place - and return to the previous recursive call
                else
                {
                    // Printing O at the current valid spot
                    maze[currentY, currentX] = '-';
                    printMaze(maze);
                    // delay
                    System.Threading.Thread.Sleep(400);

                    // Clearing console
                    Console.Clear();

                    return;
                }
            }

            // 3. if we haven't reached the end of the maze, AND all orbs have not been collected, start checking each direction.
            if (currentY < maze.GetLength(0) - 1 && currentX < maze.GetLength(1) - 1 && this.foundExit == false)
            {
                // marking X in valid spots after all orbs are collected
                if (this.orbs == 4)
                {
                    maze[currentY, currentX] = 'X';
                    printMaze(maze);

                    // delay
                    System.Threading.Thread.Sleep(400);

                    // Clearing console
                    Console.Clear();
                }

                // marking + in valid spots before orbs are collected
                if (this.orbs != 4)
                {
                    maze[currentY, currentX] = '+';
                    printMaze(maze);

                    // delay
                    System.Threading.Thread.Sleep(400);

                    // Clearing console
                    Console.Clear();
                }


                // Before we have reached the end of the maze
                // Prior to all orbs collected: if left is a valid spot (. or @) move in that direction
                // After all orbs collected: if left is a valid spot (+ or - or .) move in that direction
                if (
                    (this.foundExit == false && (maze[currentY, currentX - 1] == '.' || maze[currentY, currentX - 1] == '@'))
                    || (this.foundExit == false && this.orbs == 4 && (maze[currentY, currentX - 1] == '+' || maze[currentY, currentX - 1] == '-' || maze[currentY, currentX - 1] == '.'))
                   )
                {
                    mazeTraversal(maze, currentY, currentX - 1); // Moving left one space
                }

                // Before we have reached the end of the maze
                // Prior to all orbs collected: if down is a valid spot (. or @) move in that direction
                // After all orbs collected: if down is a valid spot (+ or - or .) move in that direction
                if (
                    (this.foundExit == false && (maze[currentY + 1, currentX] == '.' || maze[currentY + 1, currentX] == '@'))
                    || (this.foundExit == false && this.orbs == 4 && (maze[currentY + 1, currentX] == '+' || maze[currentY + 1, currentX] == '-' || maze[currentY + 1, currentX] == '.'))
                   )
                {
                    mazeTraversal(maze, currentY + 1, currentX); // Moving down one space
                }

                // Before we have reached the end of the maze
                // Prior to all orbs collected: if right is a valid spot (. or @) move in that direction
                // After all orbs collected: if right is a valid spot (+ or - or .) move in that direction
                if (
                    (this.foundExit == false && (maze[currentY, currentX + 1] == '.' || maze[currentY, currentX + 1] == '@'))
                    || (this.foundExit == false && this.orbs == 4 && (maze[currentY, currentX + 1] == '+' || maze[currentY, currentX + 1] == '-' || maze[currentY, currentX + 1] == '.'))
                   )
                {
                    mazeTraversal(maze, currentY, currentX + 1); // Moving right one space
                }


                // Before we have reached the end of the maze
                // Prior to all orbs collected: if up is a valid spot (. or @) move in that direction
                // After all orbs collected: if up is a valid spot (+ or - or .) move in that direction
                if (
                    (this.foundExit == false && (maze[currentY - 1, currentX] == '.' || maze[currentY - 1, currentX] == '@'))
                    || (this.foundExit == false && this.orbs == 4 && (maze[currentY - 1, currentX] == '+' || maze[currentY - 1, currentX] == '-' || maze[currentY - 1, currentX] == '.'))
                   )
                {
                    mazeTraversal(maze, currentY - 1, currentX); // Moving up one space
                }


                // if none of the directions worked, and we have collected all orbs, placing an O
                if (this.foundExit == false && this.orbs == 4)
                {
                    maze[currentY, currentX] = 'O';
                    printMaze(maze);

                    // delay
                    System.Threading.Thread.Sleep(400);

                    // Clearing console
                    Console.Clear();
                }

                // if none of the directions worked, and we have NOT collected all orbs, placing a -
                if (this.foundExit == false && this.orbs != 4)
                {
                    maze[currentY, currentX] = '-';
                    printMaze(maze);
                    // delay
                    System.Threading.Thread.Sleep(400);

                    // Clearing console
                    Console.Clear();
                }
            }
        }


        /// <summary>
        /// Taking the 2 dimentional array, cycling through each Row and Column and printing each character of the array. 
        /// Once a row has been completed, Console.Writeline to move to the next row.
        /// </summary>
        /// <param name="maze"></param>
        private void printMaze(char[,] maze)
        {
            //string printedArray = "";

            // for each row of the 2d array
            for (int y = 0; y < maze.GetLength(0); y++)
            {
                // for each column of the 2d array
                for (int x = 0; x < maze.GetLength(1); x++)
                {
                    // calling the characterColor method to update the character color 
                    characterColor(maze[y,x]);

                    // printing the character in tdadadadhe x,y coordinate
                    Console.Write(maze[y,x]);

                    // resetting the console to gray for non affected characters
                    Console.ForegroundColor = ConsoleColor.Gray;

                }

                // moving to the next row in the 2d array
                Console.WriteLine();
            }
        }

        /// <summary>
        /// This method takes the current position in the 2d array (character) and updates the console color for that value accordingly
        /// </summary>
        /// <param name="character"></param>
        private void characterColor(char character)
        {
            if (character == '+' || character == 'X')
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            if (character == '-' || character == 'O')
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            if (character == '@')
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
        }

    }
}
