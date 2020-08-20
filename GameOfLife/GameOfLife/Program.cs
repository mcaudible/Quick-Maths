using System;
using System.Threading;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Conwat's Game of Life\n\nPress any key to start the sim?");

            Console.WriteLine("Please enter desired number of rows: ");
            int rows = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter desired number of columns");
            int columns = int.Parse(Console.ReadLine());
            Console.WriteLine("How many generations would you like?");
            var generations = int.Parse(Console.ReadLine());

            Console.WriteLine("Sim is starting");
            Thread.Sleep(3000);

            var grid = new Grid();

            var game = new Game(rows, columns, generations, grid);

            Console.Clear();
            
            game.start();

            Console.Clear();
            Console.WriteLine("Sim complete, press any key to close.");
            Console.ReadKey();
        }
    }
}
