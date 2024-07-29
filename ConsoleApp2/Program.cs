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
            var res = BinarySearch.NthUglyNumber(5,2,3,5);
            //var res = Safsolution("aaAbcCABBcCAAdDb");
            //var res = DynamicProgramming.FindNumberOfLIS(arr);

            Console.WriteLine(res);
            //foreach(var i in result) Console.Write(i +",");
            //int s = 9 / 2;
            Console.WriteLine();

           
        }
        static int Safsolution(string letters)
        {
            //This code i have prioritized running time
            //more than space complexity
            //use foreach for better performance
            Dictionary<string,int> dict = new Dictionary<string,int>();
            int count = 0;
            for (int i = 0;i<letters.Length;i++)
            {
                string s = letters[i].ToString();
                if (letters[i] > 96)
                {
                    string toCheck = s.ToUpper();
                    if (dict.ContainsKey(toCheck)){
                        if (dict[toCheck] != -1)
                        {
                            count--;
                            dict[toCheck] = -1;
                        }
                    }
                    if(!dict.ContainsKey(s)) dict.Add(s,1);
                }
                else
                {
                    string toCheck = s.ToLower();
                    if (dict.ContainsKey(toCheck))
                    {
                        if (dict[toCheck] != -1)
                        {
                            count++;
                            dict[toCheck] = -1;
                        }
                    }
                    if (!dict.ContainsKey(s)) dict.Add(s, 1);
                }
            }
            return count;
        }
        static int safTest(int[] p, int[] s)
        {
            int n = p.Length;
            var combined = new (int, int)[n];
            for (int j = 0; j < n; j++)
            {
                combined[j] = (p[j], s[j]);
            }
            var sorted = combined.OrderBy(x => x.Item1).ToArray();

            int i = 0;
            for (; i < n;)
            {
                int j = i + 1;
                while (sorted[i].Item1 != 0 && j < n)
                {
                    int diff = sorted[j].Item2 - sorted[j].Item1;
                    if (diff >= sorted[i].Item1)
                    {
                        sorted[j].Item1 += sorted[i].Item1;
                        sorted[i].Item1 = 0;
                        i++;
                    }
                    else
                    {
                        sorted[j].Item1 += diff;
                        sorted[i].Item1 -= diff;
                    }
                    j++;
                }
                if (j == n) break;
            }
            return n - i;
        }
    }
}
