using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public static class BackTracking
    {
        public static IList<IList<int>> Permute(int[] nums)
        {
            HashSet<int> index = new HashSet<int>();
            IList<IList<int>> ans = new List<IList<int>>();
            List<int> visited = new List<int>();
            Permute(ans,visited,nums,new bool[nums.Length]);
            return ans;
        }
        private static void Permute(IList<IList<int>> list,List<int> set, int[] nums, bool[] used)
        {
            if (set.Count == nums.Length)
            {
                list.Add(new List<int>(set));
                return;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (used[i] || i > 0 && nums[i] == nums[i - 1] && !used[i - 1]) continue;
                used[i] = true;
                set.Add(nums[i]);
                Permute(list, set, nums, used);
                used[i] = false;
                set.RemoveAt(set.Count - 1);
            }
        }
        public static IList<IList<int>> Subsets(int[] nums)
        {
            int n = nums.Length;
            IList<IList<int>> subsets = new List<IList<int>>();
            Backtracking(subsets,new List<int>(),n,0,nums,0);
            return subsets;
        } 
        private static void Backtracking(IList<IList<int>> subset,List<int> set,int n,int start, int[] nums,int countRecursionDepth)
        {
            if(start == n)
            {
                subset.Add(new List<int>(set));
                return;
            }
            //include an element
            set.Add(nums[start]);
            Backtracking(subset,set,n,start+1,nums,countRecursionDepth+1);

            //do not include element
            set.RemoveAt(set.Count - 1);
            Backtracking(subset, set, n, start + 1, nums, countRecursionDepth+1);
        }

        public static IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            int n = nums.Length;
            IList<IList<int>> subsets = new List<IList<int>>();
            Array.Sort(nums);
            BacktrackingWithDup(subsets, new List<int>(),0, nums);
            return subsets;
        }
        private static void BacktrackingWithDup(IList<IList<int>> subset,List<int> set,int start, int[] nums)
        {
            subset.Add(new List<int>(set));
            for(int i = start; i < nums.Length; i++)
            {
                if (i > start && nums[i - 1] == nums[i]) continue;
                set.Add(nums[i]);
                BacktrackingWithDup(subset, set,i+1,nums);
                set.RemoveAt(set.Count-1);
            }
        }
    }
}
