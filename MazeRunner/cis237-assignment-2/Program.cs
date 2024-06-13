// Ryan VanderVeen
// CIS 237
// 09/30/2022

using System;
using System.Net.Http;

namespace cis237_assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Starting Coordinates.
            const int X_START = 1;
            const int Y_START = 1;


            // Maze with orbs
            char[,] maze1 =
            {
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            { '#', '.', '.', '.', '#', '@', '.', '.', '.', '.', '.', '#' },
            { '#', '.', '#', '.', '#', '.', '#', '#', '#', '#', '.', '#' },
            { '#', '#', '#', '.', '#', '.', '.', '.', '.', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '#', '#', '#', '.', '#', '.', '#' },
            { '#', '#', '#', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '@', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '#', '.', '#', '.', '#', '.', '.', '.', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '.', '.', '#', '#', '#', '.', '#' },
            { '#', '#', '#', '#', '#', '#', '.', '#', '@', '#', '.', '.' },
            { '#', '@', '.', '.', '.', '.', '.', '#', '.', '.', '.', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
            };


            // Create a new instance of a mazeSolver class
            MazeSolver mazeSolver = new MazeSolver();

            // Create the second maze by transposing the first maze
            char[,] maze2 = transposeMaze(maze1);

            // Solve the original maze.
            mazeSolver.SolveMaze(maze1, X_START, Y_START);

            Console.Clear();
            Console.WriteLine("The 1st maze has been completed!");
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Starting 2nd maze...");
            System.Threading.Thread.Sleep(5000);
            Console.Clear();


            // Solve the transposed maze.
            mazeSolver.SolveMaze(maze2, X_START, Y_START);

            Console.Clear();
            Console.WriteLine("The 2nd maze has been completed!");
            System.Threading.Thread.Sleep(5000);
        }

        /// <summary>
        /// This method takes a 2 dimensional array and transposes the values stored in it, then returns a new maze
        /// </summary>
        /// <param name="mazeToTranspose"></param>
        /// <returns>newMaze array</returns>
        static char[,] transposeMaze(char[,] mazeToTranspose)
        {
            // Initializing the newMaze array
            char[,] newMaze = new char[12, 12];

            // For each column, and row, flipping which variable they are assigned to (column to Row, Row to column)
            for (int c = 0; c < mazeToTranspose.GetLength(0); c++)
                for (int r = 0; r < mazeToTranspose.GetLength(1); r++)
                    newMaze[c, r] = mazeToTranspose[r, c];

            // Returning the transposed maze
            return newMaze;
        }
    }
}
