using System;

namespace Serialization
{
    [Serializable]
    public class Figure
    {
        public int SideCount { get; set; }
        public double SideLength { get; set; }
        private string PrivateData { get; set; }

        public Figure() { }

        public Figure(int sideCount, double sideLength)
        {
            SideCount = sideCount;
            SideLength = sideLength;
        }

        public void Display(Figure figure)
        {
            Console.WriteLine($"SideCount = {SideCount}, SideLength = {SideLength}");
        }
    }
}
