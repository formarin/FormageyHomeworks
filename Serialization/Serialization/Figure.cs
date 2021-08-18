using System;

namespace Serialization
{
    [Serializable]
    public class Figure
    {
        public int SideCount { get; set; }
        public double SideLength { get; set; }
        public Figure InsertedFigure { get; set; }

        public Figure() { }
    }
}
