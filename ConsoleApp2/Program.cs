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
            //1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0
            //0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1
            //1,2,3,5,6
            int[] nums =  { 2, 2, 2, 1, 2, 2, 1, 2, 2, 2 };
            //var result = SlidingWindow.MinOperations(nums);
            var result = SlidingWindow.CountVowelSbstrings("aeiouu");
            Console.WriteLine(result);
        }


    }
}
