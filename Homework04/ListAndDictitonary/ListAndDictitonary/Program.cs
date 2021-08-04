using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ListAndDictitonary
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j;
            var figure = new Figure();
            var figuresList = new List<Figure>();
            var figuresDictionary = new Dictionary<int, Figure>();

            Stopwatch stopwatchL = new Stopwatch();
            Stopwatch stopwatchD = new Stopwatch();
            TimeSpan listSearchTime, dictionarySearchTime;

            for (i = 1, j = 0; i <= 1000000; i++, j += 4)
            {
                var circle = new Figure() { SideCount = 1, SideLength = i };
                var triangle = new Figure() { SideCount = 3, SideLength = i };
                var square = new Figure() { SideCount = 4, SideLength = i };
                var pentagon = new Figure() { SideCount = 5, SideLength = i };

                figuresList.AddRange(new Figure[] { circle, triangle, square, pentagon });

                figuresDictionary.Add(j, circle);
                figuresDictionary.Add(j + 1, triangle);
                figuresDictionary.Add(j + 2, square);
                figuresDictionary.Add(j + 3, pentagon);
            }

            for (i = 0; i < 1000000; i++)
            {
                stopwatchL.Start();
                var circlesL = figuresList.Where(figures => figures.SideCount == 1);
                stopwatchL.Stop();

                stopwatchD.Start();
                var circlesD = figuresDictionary.Where(figures => figures.Value.SideCount == 1);
                stopwatchD.Stop();
            }

            listSearchTime = stopwatchL.Elapsed / i;
            dictionarySearchTime = stopwatchD.Elapsed / i;

            Console.WriteLine($"Time for search in the list:         {listSearchTime}" +
                            $"\nTime for search in the dictionary:   {dictionarySearchTime}\n");

            Console.ReadKey();
        }
    }
}
