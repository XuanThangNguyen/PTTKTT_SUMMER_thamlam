using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class TravelingSalesmanProblem
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string[] cities = { "a", "b", "c", "d" };
            double[,] distances = {
                {0, 5, 7.08, 16.55},
                {5, 0, 5, 11.7},
                {7.08, 5, 0, 14},
                {16.55, 11.7, 14, 0}
            };

            TSP tsp = new TSP(cities, distances);
            tsp.FindOptimalPath();

            Console.Write("\nMa trận đường đi : \n");
            for (int i = 0; i < distances.GetLength(0); i++)
            {
                for (int j = 0; j < distances.GetLength(1); j++)
                {
                    Console.Write(distances[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
    class TSP
    {
        private int numberOfCities;
        private string[] cities;
        private double[,] distances;
        private List<string> optimalPath;
        private double minDistance = double.MaxValue;

        public TSP(string[] cities, double[,] distances)
        {
            this.numberOfCities = cities.Length;
            this.cities = cities;
            this.distances = distances;
            this.optimalPath = new List<string>();
        }

        public void FindOptimalPath()
        {
            List<int> unvisited = new List<int>();
            for (int i = 1; i < numberOfCities; i++)
            {
                unvisited.Add(i);
            }

            FindNextCity(0, unvisited, 0, new List<string> { cities[0] });

            Console.Write("Đường đi tối ưu: ");
            foreach (string city in optimalPath)
            {
                Console.Write(city + " -> ");
            }
            Console.WriteLine(cities[0]);
            Console.WriteLine("Tổng khoảng cách: " + minDistance);
        }

        private void FindNextCity(int currentCity, List<int> unvisited, double currentDistance, List<string> currentPath)
        {
            if (unvisited.Count == 0)
            {
                if (currentDistance + distances[currentCity, 0] < minDistance)
                {
                    minDistance = currentDistance + distances[currentCity, 0];
                    optimalPath = new List<string>(currentPath);
                }
                return;
            }

            foreach (int cityIndex in unvisited)
            {
                List<int> newUnvisited = new List<int>(unvisited);
                newUnvisited.Remove(cityIndex);

                List<string> newPath = new List<string>(currentPath);
                newPath.Add(cities[cityIndex]);

                FindNextCity(cityIndex, newUnvisited, currentDistance + distances[currentCity, cityIndex], newPath);
            }
        }
    }
}
