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
            int[] arr = {1,2,3,4,5,6,7,8,9,10};
            int[] arr1 = {7};
            int k = 3;

            int m = 1;
            int n = 2;

            int[][] obstacleGrid = new int[m][];
            for (int i = 0; i < m; i++)
            {
                obstacleGrid[i] = new int[] { 0, 0 };
            }
            var res = BinarySearch.ShipWithDays(arr,5);


            Console.WriteLine(res);
            //foreach(var i in result) Console.Write(i +",");
            //int s = 9 / 2;
            Console.WriteLine();

           
        }
    }
}
