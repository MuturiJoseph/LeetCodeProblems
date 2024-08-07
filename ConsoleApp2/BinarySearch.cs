﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class BinarySearch
    {
        public static int sqr(int x)
        {
            if ((x < 2))
            {
                return x;
            }
            int left = 0, right = x;
            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (mid * mid > x)
                {
                    right = mid;
                }
                else left = mid + 1;
            }
            return left - 1;
        }
        //1011 Capacity to ship packages within D days
        public static int ShipWithDays(int[] weights, int d)
        {
            //Here we need to  create a condition function 
            //such as an API which checks if it given a certain capacity if it is possible to 
            //ship all packages in D days
            bool feasible(int capacity)  //similar to API function which returns true or false
            {
                int days = 1, total = 0;

                foreach (int x in weights)
                {
                    total += x;
                    if (total > capacity)
                    {
                        days++;
                        total = x;
                        if (days > d) return false;
                    }
                }
                return true;
            }

            int left = weights.Max(x => x), right = weights.Sum();

            //Binary Search
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (feasible(mid))
                {
                    right = mid;
                }
                else left = mid + 1;
            }
            return left;
        }
        public static int NthUglyNumber(int n, int a, int b, int c)
        {
            long ab = LCM(a, b);
            long ac = LCM(a, c);
            long bc = LCM(b, c);
            long abc = LCM(a, bc);

            bool Enough(long number)
            {
                long count = number / a + number / b + number / c
                            - number / ab - number / ac - number / bc
                            + number / abc;
                return count >= n;
            }

            long left = 1, right = 2000000000;
            while (left < right)
            {
                long mid = left + (right - left) / 2;
                if (Enough(mid))
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return (int)left;
        }

        private static long LCM(long x, long y)
        {
            return x * y / GCD(x, y);
        }

        private static long GCD(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}
