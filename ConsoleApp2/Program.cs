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
            int[] arr = { 5, 6, 7, 8, 8, 9, 2, 3, 5, 6, 7, 8, 9, 5, 4, 2, 12, 4, 6, 4, 2, 5, 6 };
            int k = 3;

            int m = 1;
            int n = 2;

            int[] arr1 = { 6, 2, 4 };
            int[][] obstacleGrid = new int[m][];
            for (int i = 0; i < m; i++)
            {
                obstacleGrid[i] = new int[] { 0, 0 };
            }
            var res = DynamicProgramming.LargestRectangleArea(arr);


            Console.WriteLine(res);
            //foreach(var i in result) Console.Write(i +",");
            Console.WriteLine();
        }
    }
}
