using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOfIslands
{
    class Program
    {
        //Given a 2d grid map of '1's (land) and '0's (water),
        //count the number if islands.
        //An island is surrounded by water and is formed by
        //connecting adjacent lands horizontally or vertically.
        //You may assume all four edges of the grid are surrounded
        //by water.

        static void Main(string[] args)
        {
            char[,] input = new char[4, 5] {
                { '1','1','1','0','1' },
                { '1','1','0','1','0' },
                { '1','1','0','0','0' },
                { '0','0','0','1','1' }
                };

            int numOfIslands = FindNumberOfIslands(input);

            Console.WriteLine("Number of islands: " + numOfIslands);
        }

        private static int FindNumberOfIslands(char[,] input)
        {
            int count = 0;
            int columns = input.GetLength(1);
            int rows = input.GetLength(0);

            //loop through the grid
            //if I see a '1' increment count
            //then search all other surrounding elements
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    if(input[i,j] == '1')
                    {
                        count++;
                        BreadthFirstSearch(input, i, j);
                    }
                }
            }

            return count;            
        }

        private static void BreadthFirstSearch(char[,] input, int i, int j)
        {
            int columns = input.GetLength(1);
            int rows = input.GetLength(0);

            //define the exit clause as
            //off the grid or seeing '0'
            if (i < 0 || i >= rows || j < 0 || j >= columns || input[i, j] == '0')
                return;

            //turn the '1' into a '0'
            input[i, j] = '0';

            //Do recursive search on all other surrounding
            //elements until all '1's in this island are '0's
            BreadthFirstSearch(input, i + 1, j);
            BreadthFirstSearch(input, i - 1, j);
            BreadthFirstSearch(input, i, j + 1);
            BreadthFirstSearch(input, i, j - 1);
        }
    }
}
