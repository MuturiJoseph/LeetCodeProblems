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
            //420325
            // 0,1,0,2,1,0,1,3,2,1,2,1
            //1,2,1,1,1
            int[] nums =  {6,7,8,4,5,4,6,7,10,9,8,7};
            //var result = SlidingWindow.MinOperations(nums);
            var result = TwoPointer.LongestMountain(nums);


            Console.WriteLine(result);
            //foreach(var i in result) Console.Write(i);
            Console.WriteLine();
        }
    }
}
