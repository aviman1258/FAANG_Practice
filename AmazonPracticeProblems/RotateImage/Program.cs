using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotateImage
{
    class Program
    {
        //rotate the image 90 degrees clockwise
        static void Main(string[] args)
        {
            int[,] img = new int[3, 3]{ 
                { 1, 2, 3},
                { 4, 5, 6},
                { 7, 8, 9} 
            };

            img = RotateImage(img);

            int N = img.GetLength(0);

            for (int i = 0; i < N; i++)
            {
                for(int j = 0; j < N; j++)
                {
                    Console.Write(img[i, j] + " ");
                }
                Console.Write("\n");
            }
            
        }

        private static int[,] RotateImage(int[,] img)
        {
            int N = img.GetLength(0);
            
            //Step 1 - Transpose Matrix
            //Turn rows into columns
            //swap(array[i][j], array[j][i];

            img = Transpose(img, N);

            //Step 2 - Flip Horizontally
            //Row by row traversal
            //swap(array[i][j], array[i][N-1-j])

            img = FlipHorizontal(img, N);

            return img;
        }

        private static int[,] FlipHorizontal(int[,] img, int N)
        {
            //going row by row
            for (int i = 0; i < N; i++)
            {
                //going to up to halfway point of column
                //so we dont reswap elements
                for(int j = 0; j < (N / 2); j++)
                {
                    int temp = img[i, j];
                    //the length of the array minus j
                    //as J gets larger we match the 
                    //amt we need to take off for the
                    //other end.
                    img[i, j] = img[i, N - 1 - j];
                    img[i, N - 1 - j] = temp;
                }
            }

            return img;
        }

        private static int[,] Transpose(int[,] img, int N)
        {
            for(int i = 0; i < N; i++)
            {
                //start j at i so that we are not
                //repeating the transpose operation
                //on already transposed elements
                for(int j = i; j < N; j++)
                {
                    int temp = img[i, j];
                    img[i, j] = img[j, i];
                    img[j, i] = temp;
                }
            }

            return img;
        }
    }
}
