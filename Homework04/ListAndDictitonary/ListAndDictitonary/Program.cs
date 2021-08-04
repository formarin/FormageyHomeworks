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
            var figuresDictionary = new Dictionary<Figure, int>();

            Stopwatch stopwatchL = new Stopwatch();
            Stopwatch stopwatchD = new Stopwatch();
            TimeSpan listSearchTime, dictionarySearchTime;

            for (i = 1, j = 0; i <= 10000; i++, j += 4)
            {
                var circle = new Figure() { SideCount = 1, SideLength = i };
                var triangle = new Figure() { SideCount = 3, SideLength = i };
                var square = new Figure() { SideCount = 4, SideLength = i };
                var pentagon = new Figure() { SideCount = 5, SideLength = i };

                figuresList.AddRange(new Figure[] { circle, triangle, square, pentagon });

                figuresDictionary.Add(circle, j);
                figuresDictionary.Add(triangle, j + 1);
                figuresDictionary.Add(square, j + 2);
                figuresDictionary.Add(pentagon, j + 3);
            }

            for (i = 0; i < 10000; i++)
            {
                stopwatchL.Start();
                var checkList = figuresList.Contains(new Figure() { SideCount = 1, SideLength = 500000 });
                stopwatchL.Stop();

                stopwatchD.Start();
                var checkDict = figuresDictionary.ContainsKey(new Figure() { SideCount = 1, SideLength = 500000 });
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
