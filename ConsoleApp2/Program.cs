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
            //            int[] arr1 =  {2,1,100,3};
            //            int[] arr2 = {-5,-2,10,-3,7};
            //            string[] s = new string[] { "FooBar", "FooBarTest", "FootBall","FrameBuffer","ForceFeedBack"};
            //            //var result = SlidingWindow.MinOperations(nums);
            //            var result = TwoPointer.CanTransform("LR",
            //"RL");



            //            Console.WriteLine(result);
            //            //foreach(var i in result) Console.Write(i +",");
            //            Console.WriteLine();
            int[] array = { 4, 1, 3, 2, 4, 6 };

            Console.WriteLine("Original array: " + string.Join(", ", array));

            TwoPointer.BottomUpMergeSort(array);

            Console.WriteLine("Sorted array: " + string.Join(", ", array));
        }
    }
}
