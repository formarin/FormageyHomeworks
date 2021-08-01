using System;

namespace Formagey_HomeWork_02
{
    class Program
    {
        static void Main(string[] args)
        {
            var polygon1 = new PolygonClass { NumberOfSides = 4, LengthOfSides = 3 };
            var polygon2 = new PolygonClass { NumberOfSides = 4, LengthOfSides = 4 };

            var polygon3 = new PolygonStruct { NumberOfSides = 4, LengthOfSides = 3 };
            var polygon4 = new PolygonStruct { NumberOfSides = 4, LengthOfSides = 4 };

            polygon1 = GetSquareForNewPoligon(polygon1);
            GetSquareForSamePoligon(polygon2);

            polygon3 = GetSquareForNewPoligon(polygon3);
            GetSquareForSamePoligon(ref polygon4);
        }
        public static PolygonClass GetSquareForNewPoligon(PolygonClass polygon)
        {
            var newPolygon = new PolygonClass();

            newPolygon.NumberOfSides = polygon.NumberOfSides;
            newPolygon.LengthOfSides = polygon.LengthOfSides;
            newPolygon.Square = (newPolygon.NumberOfSides * newPolygon.LengthOfSides * newPolygon.LengthOfSides)
            / (4 * Math.Tan(Math.PI / newPolygon.NumberOfSides));

            return newPolygon;
        }
        public static void GetSquareForSamePoligon(PolygonClass polygon)
        {
            polygon.Square = (polygon.NumberOfSides * polygon.LengthOfSides * polygon.LengthOfSides)
                / (4 * Math.Tan(Math.PI / polygon.NumberOfSides));
        }
        public static PolygonStruct GetSquareForNewPoligon(PolygonStruct polygon)
        {
            var newPolygon = new PolygonStruct();

            newPolygon.NumberOfSides = polygon.NumberOfSides;
            newPolygon.LengthOfSides = polygon.LengthOfSides;
            newPolygon.Square = (newPolygon.NumberOfSides * newPolygon.LengthOfSides * newPolygon.LengthOfSides)
            / (4 * Math.Tan(Math.PI / newPolygon.NumberOfSides));

            return newPolygon;
        }
        public static void GetSquareForSamePoligon(ref PolygonStruct polygon)
        {
            polygon.Square = (polygon.NumberOfSides * polygon.LengthOfSides * polygon.LengthOfSides)
                / (4 * Math.Tan(Math.PI / polygon.NumberOfSides));
        }
    }
}