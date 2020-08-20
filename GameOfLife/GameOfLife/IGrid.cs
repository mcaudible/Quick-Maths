namespace GameOfLife
{
    public interface IGrid
    {
        void GenerateGrid(Game game);

        int[,] InitiateBoard(int xAxis, int yAxis);
        void Display(int [,] grid);
    }
}