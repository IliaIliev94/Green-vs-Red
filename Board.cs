using System;
using System.Collections.Generic;
using System.Text;

namespace _01._GreenVsRed
{
    public class Board
    {
        private int height;
        private int width;
        private Cell[,] cells;
        public int N { get; set; }
        public int Coordinate1 { get; set; }
        public int Coordinate2 { get; set; }
        public int Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if(height > 1000)
                {
                    throw new ArgumentException("Invalid input");
                }
                this.height = value;
            }
        }
        public int Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if(width > height)
                {
                    throw new ArgumentException("Invalid input");
                }
                this.width = value;
            }
        }
        public Board(int height, int width, int coordinate1, int coordinate2, int n, Cell[,] cells)
        {
            this.Height = height;
            this.Width = width;
            this.cells = cells;
            this.Coordinate1 = coordinate1;
            this.Coordinate2 = coordinate2;
            this.N = n;
        }


        // Returns the amount of times the given cell was green from Generation Zero to Generation N and calls the update funcion
        public int GreenCountTimes()
        {
            int count = 0;
            for (int i = 0; i <= this.N; i++)
            {
                if (this.cells[Coordinate2, Coordinate1].State == "1")
                {
                    count++;
                }
                this.Update();
            }
            return count;
        }

        /* Changes the grid according to the 4 rules by calling the IsValid function to check if a cell should be changed
         and changes it if it does */
        private void Update()
        {
            Cell[,] result = new Cell[this.Height, this.Width];
            for (int i = 0; i < this.Height; i++)
            {
                for (int j = 0; j < this.Width; j++)
                {
                    result[i, j] = new Cell(this.cells[i, j].State, this.cells[i, j].X, this.cells[i, j].Y);
                    if (IsValid(result[i, j]))
                    {
                        result[i, j].Mutate();
                    }
                }
            }
            this.cells = result;
        }

        //Checks if a cell fulfills the conditions to be changed by calling the CellsCount function
        private bool IsValid(Cell cell)
        {
            int count = CellsCount(cell);
            if(cell.State == "0")
            {
                if(count == 3 || count == 6)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if(count == 2 || count == 3 || count == 6)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        // Checks how many green cells there are next to the cell.
        private int CellsCount(Cell cell)
        {
            int count = 0;
            for(int i = Math.Max(0, cell.X - 1); i <= Math.Min(this.cells.GetLength(0) -1, cell.X + 1); i++)
            {
                for(int j = Math.Max(0, cell.Y - 1); j <= Math.Min(this.cells.GetLength(1) - 1, cell.Y + 1); j++)
                {
                    if((i != cell.X || j != cell.Y) && cells[i, j].State == "1")
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        

        
    }
}
