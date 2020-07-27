using System;
using System.Collections.Generic;
using System.Text;

namespace _01._GreenVsRed
{
    public class Cell
    {
        public string State { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Cell(string state, int x, int y)
        {
            this.State = state;
            this.X = x;
            this.Y = y;
        }
        public void Mutate()
        {
            if(this.State == "1")
            {
                this.State = "0";
            }
            else
            {
                this.State = "1";
            }
        }

       
    }
}
