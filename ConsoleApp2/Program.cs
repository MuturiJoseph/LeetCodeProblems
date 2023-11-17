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
            int[] nums =  { 4,2,0,3,2,5 };
            //var result = SlidingWindow.MinOperations(nums);
            var result = TwoPointer.Trap(nums);

            Console.WriteLine(result);
        }
    }
}
