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
            int[] arr1 = {1,1,2};
            int[] arr2 = { -5, -2, 10, -3, 7 };
            var result = BackTracking.Permute(arr1);



            Console.WriteLine(result);
            //foreach(var i in result) Console.Write(i +",");
            Console.WriteLine();
        }
    }
}
