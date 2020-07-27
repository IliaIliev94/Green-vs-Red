using System;
using System.Linq;

namespace _01._GreenVsRed
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Cell[,] cells = new Cell[size[0], size[1]];
            for(int i = 0; i < size[0]; i++)
            {
                string characters = Console.ReadLine();
                for(int j = 0; j < size[1]; j++)
                {
                    cells[i, j] = new Cell(characters[j].ToString(), i, j);
                }
            }
            int[] coordinates = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            try
            {
                Board board = new Board(size[0], size[1], coordinates[0], coordinates[1], coordinates[2], cells);
                Console.WriteLine(board.GreenCountTimes());
            }
            catch(Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }
        }
    }
}
