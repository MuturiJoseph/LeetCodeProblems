using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {1, 3, 2, 2, 2, 3, 4, 3, 1, 4, 5, 34, 32, 5, 33, 2, 33, 43, 76, 89, 9, 7, 6, 4, 2, 5, 7, 89, 7, 64, 5, 6, 4, 12};
            int k = 3;

            int m = 1;
            int n = 2;

            int[] arr1 = { 2,2,2,2,4,4,4};
            int[][] obstacleGrid = new int[m][];
            for (int i = 0; i < m; i++)
            {
                obstacleGrid[i] = new int[] { 0, 0 };
            }
            var res = DynamicProgramming.RemoveBoxesRec(arr);


            Console.WriteLine(res);
            //foreach(var i in result) Console.Write(i +",");
            Console.WriteLine();

            
        }
    }
}
