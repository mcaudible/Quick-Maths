using System;

namespace GameOfLife
{
    public class Game
    {
        public int xAxis { get; set; }

        public int yAxis { get; set; }

        public int Generations { get; set; }

        private IGrid gameBoard;
        public Game(int x, int y, int generations, IGrid grid)
        {
            Generations = generations;
            xAxis = x;
            yAxis = y;
            gameBoard = grid;
        }

        public void start()
        {
            if (gameBoard != null)
            {
                gameBoard.GenerateGrid(this);
            }
        }

    }
}
