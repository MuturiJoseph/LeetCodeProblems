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
            int[] arr1 = { 2, 2, 2, 2, 2 };
            var result = DynamicProgramming.FindNumberOfLIS(arr1);



            Console.WriteLine(result);
            //foreach(var i in result) Console.Write(i +",");
            Console.WriteLine();
        }
    }
}
