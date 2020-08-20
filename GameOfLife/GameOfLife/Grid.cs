using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace GameOfLife
{
    internal class Grid : IGrid
    {
        public int xAxis { get; set; }

        public int yAxis { get; set; }

        public void GenerateGrid(Game game)
        {
            xAxis = game.xAxis;
            yAxis = game.yAxis;

            int[,] grid = new int[xAxis,yAxis];

            grid = InitiateBoard(xAxis,yAxis); //Initiate first grid

            //iterate through generations
            for (var i = 0; i < game.Generations; i++)
            {
                Console.WriteLine($"Gen {i+1}");
                Display(grid);
                grid = NextGeneration(grid);
            }
        }

        //Creates next generation of the cells. 
        public int[,] NextGeneration(int[,] grid)
        {
            int[,] next = new int[xAxis, yAxis];
            //neighbour check
            for (int x = 1; x < xAxis - 1; x++)
            {
                for (int y = 1; y < yAxis - 1; y++)
                {
                    int neighbours = 0;

                    //Adding all states together for surrounding 3x3 grid
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            neighbours += grid[x + i, y + j];
                        }
                    }

                    //subtract cell's current state
                    neighbours -= grid[x, y]; ;

                    //Apply rules
                    if (grid[x, y] == 1 && neighbours < 2)
                    {
                        next[x, y] = 0;
                    }
                    else if (grid[x, y] == 1 && neighbours > 3)
                    {
                        next[x, y] = 0;
                    }
                    else if (grid[x, y] == 0 && neighbours == 3)
                    {
                        next[x, y] = 1;
                    }
                    else
                    {
                        next[x, y] = grid[x, y]; 
                    }
                }
            }
            return next;
        }

        //Generates initial board
        public int[,] InitiateBoard(int xAxis, int yAxis)
        {
            int[,] initialBoard = new int[xAxis,yAxis];

            for (int i = 0; i < xAxis; i++)
            {
                for (int j = 0; j < yAxis; j++)
                {
                    initialBoard[i, j] = RandomNumberGenerator.GetInt32(0, 2);
                }
            }
            return initialBoard;
        }

        //Display grids
        public void Display(int[,] grid)
        {
            var output = new StringBuilder();
            for (int i = 0; i < xAxis; i++)
            {
                for (int j = 0; j < yAxis; j++)
                {
                    if (grid[i, j] == 1)
                    {
                        output.Append("*");
                    }
                    else
                    {
                        output.Append("-");
                    }
                    
                }
                output.Append("\n");
            }

            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(output.ToString());
            Thread.Sleep(500);
        }
    }
}
