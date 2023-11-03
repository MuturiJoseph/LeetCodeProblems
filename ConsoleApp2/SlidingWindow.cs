using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public static class SlidingWindow
    {
        public static int CountVowelSbstrings(string word)
        {
            return AtMostCountVowels(word, 5) - AtMostCountVowels(word, 4);
        }
        public static int AtMostCountVowels(string s,int k)
        {
            int r = 0, l = 0, n = s.Length, ans = 0;
            var dictionary = new Dictionary<char, int>();
            for(;r < n; r++)
            {
                if (!IsVowel(s[r]))
                {
                    l++;
                    dictionary.Clear();
                    continue;
                }
                if (!dictionary.ContainsKey(s[r])) dictionary.Add(s[r],0);
                dictionary[s[r]]++;
                while(dictionary.Count > k)
                {
                    if (--dictionary[s[l]] == 0) dictionary.Remove(s[l]);
                    l++;
                }
                ans += r - l + 1;
            }
            return ans;
        }
        private static bool IsVowel(char c)
        {
            return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
        }
        public static int NumberOfSubarray2P(int[] nums,int k)
        {
            //2,2,2,2,1,2,2,1,2,2,2  k=2 output = 16  //1,1,2,1,1 k = 3,output 2
            //Here we can traverse the array and check if count of odd numbers is greater than k
            //if it is we mark the index of i where it is initially then shrink the window by incrementing i
            //here we can use two pointers ci for count of odd numbers in current subarray and 
            //cj for the count of odd numbers upto the current position of j
            int i = 0, j = 0,n = nums.Length,ci = 0,cj = 0,prev = 0,ans = 0;
            //for(;j < n; j++)
            //{
            //    if (nums[j] % 2 != 0) cj++;
            //    if(ci <= cj - k)
            //    {
            //        prev = i;
            //        while(ci <= cj - k)
            //        {
            //            if (nums[i++] % 2 != 0) ci++;
            //        }
            //    }
            //    ans += i - prev;
            //}
            
            //using 1 pointer cj
            for(;j < n; j++)
            {
                int cn = nums[j] % 2;
                cj += cn;
                if (cn != 0 && cj >= k)
                {
                    prev = i;
                    while (nums[i] % 2 == 0) i++;
                    ++i;
                }
                if (cj >= k) ans += i - prev;
            }
            return ans;
        }
        public static int NumberOfSubarrays(int[] nums,int k)
        {
            //2,2,2,2,1,2,2,1,2,2,2  k=2 output = 16  //1,1,2,1,1 k = 3,output 2
            //we can use prefix state,two pointer or atmost
            //prefix state
            int l = 0, r = 0, n = nums.Length, distinct = 0, ans = 0,cnt = 0;
            var m = new Dictionary<int, int> { { 0,-1} };
            for(;r < n;++r)
            {
                if (nums[r] % 2 != 0) cnt++;
                if (!m.ContainsKey(cnt)) m.Add(cnt,r);
                if (cnt - k >= 0) ans += m[cnt - k + 1] - m[cnt - k];
            }
            return ans;
        }
        public static int SubarrayWithKDistinc(int[] nums, int k)
        {
            return AtMost(nums, k) - AtMost(nums, k - 1);
        }
        private static int AtMost(int[] nums, int k)
        {
            int l = 0, r = 0, n = nums.Length, distinct= 0,ans = 0;
            var m = new Dictionary<int, int>();
            for(;r < n; ++r)
            {
                if (!m.ContainsKey(nums[r])) m.Add(nums[r], 0);
                if(++m[nums[r]] == 1) distinct++;
                while(distinct > k)
                {
                    if (--m[nums[l++]] == 0) distinct--;
                }
                ans += r - l + 1;
            }
            return ans;
        }
        public static int SubarrayWithKDistinct(int[] nums, int K)
        {
            int l = 0,r = 0,n = nums.Length,k = 0,ans = 0;
            var m = new Dictionary<int,int>();
            while(r < n)
            {
                m[nums[r] - '0'] = r;
                r++;
                while(m.Count > K)
                {
                    int d = nums[l++] - '0';
                    if (m[d] < l) m.Remove(d);
                }
                if(m.Count == K)
                {
                    k = Math.Max(l, k);
                    while (m[nums[k] - '0'] != k) ++k;
                    ans += k - l + 1;
                }
            }
            return ans;
        }

        public static int NumSubarrayWithSumAtMost(int[] nums, int goal)
        {
            return AtMostNumSubarrayWithSum(nums,goal) - AtMostNumSubarrayWithSum(nums,goal - 1);
        }
        public static int AtMostNumSubarrayWithSum(int[] nums, int goal)
        {
            //10101
            //use last index were the sum occured
            //00000
            int r = 0, l = 0, n = nums.Length, sum = 0, ans = 0;
            //Dictionary<int, int> dictionary = new Dictionary<int, int> { { 0, -1 } };
            //in this approach we cannot use the for loop beacuase we will only get the length of the window by r-l+1 meaning
            //if goal is -1 and sum is 0 ans will be incremented by 1  which should not be the case when r == l
            //we should use the while loop and increment r inside the loop this allows us to get length of window by taking r - l
            // therefore when r == l and sum > goal 1 will not be added to answer
            //for (; r < n; r++)
            //{
            //    sum += nums[r];
            //    while(l < r && sum > goal)
            //    {
            //        sum -= nums[l++];
            //    }
            //    ans += r - l + 1;
            //}
            while(r < n)
            {
                sum += nums[r++];

                while (l < r && sum > goal)
                {
                    sum -= nums[l++];
                }

                ans += r - l;
            }
            return ans;
        }
        public static int NumSubarrayWithSumLastIndex(int[] nums, int goal)
        {
            //10101
            //use last index were the sum occured
            //00000
            int r = 0, l = 0, n = nums.Length, sum = 0, ans = 0;
            Dictionary<int, int> dictionary = new Dictionary<int, int> { { 0, -1 } };
            for (; r < n; r++)
            {
                sum += nums[r];
                if (!dictionary.ContainsKey(sum)) dictionary.Add(sum, r);
                if (goal == 0) ans += r - dictionary[sum];
                else if (sum - goal >= 0) ans += dictionary[sum - goal + 1] - dictionary[sum - goal];
            }
             return ans;
        }
        public static int NumSubarrayWithSum(int[] nums,int goal)
        { 
            //10101
            //use sum count
            //00000
            int r = 0,l = 0,n = nums.Length,sum = 0,ans = 0;
            Dictionary<int,int> dictionary = new Dictionary<int, int> { {0,1} };
            for(;r < n; r++)
            {
                //Prefix state map
                sum += nums[r];
                if(!dictionary.ContainsKey(sum)) dictionary.Add(sum, 0);

                //int diff = sum - goal;
                ans += dictionary.FirstOrDefault(kv => kv.Key == sum - goal).Value;
                dictionary[sum]++;
            }
            return ans;
        }
        public static int MaxConsecutiveAnswers(string answerKey, int k)
        {
            return Math.Max(MaxConsecutiveAnswers(answerKey,'T',k), MaxConsecutiveAnswers(answerKey, 'F', k));
        }

        //This is the private method which calculates the maximum of T and F based on the arguments it is given
        private static int MaxConsecutiveAnswers(string answerKey,Char c,int k)
        {
            int r = 0,l = 0,n = answerKey.Length,cnt = 0,ans = 0;
            for(;r < n; r++)
            {
                if(c == answerKey[r]) cnt++;

                while(cnt > k)
                {
                    if (answerKey[l] == c) cnt--;//this makes sure that an element that is not needed is romoved from the window
                    l++;
                }
                ans = Math.Max(ans,r - l + 1);
            }
            return ans;
        }
        public static int MinOperations(int[] nums)
        {
            //first Approach
            //[1,2,3,5,6]  ...Approach ..> let r point to the first element that is out of bound i.e r>=[l]+n therefore // r < [l] + n
            int r = 0, l = 0, n = nums.Length, ans = 0;
            nums.Distinct().ToArray();
            int m = nums.Length;
            //for(;l < m; l++)
            //{
            //    while(r < m && nums[r] < nums[l] + n) r++;
            //    ans = Math.Min(ans, n - r + l);
            //}
            //return ans;

            //we can solve this using the shrinkable approach
            //let `i` point to the first element that is in range -- `A[i] + N > A[j]`
            //we calculate the longest subarray which meets the conditions given then subtract that length from the length of the initial array
            //before the duplicates are removed
            //state nums[r]+n  //invalid state [r] >= nums[l]+n
            //for(;r < m; r++)
            //{
            //    while (nums[r] >= nums[l] + n) l++;
            //    ans = Math.Max(ans,r - l + 1);
            //}
            //return n - ans;

            //Non-Shrinkable method
            //here We use r to represent the length of array after duplicates are remove,here we can use r or m at end of for loop
            //then we subtract r from n to know the number of dupicates in the initial array
            //then we add l which counts the number of elements which are >=nums[l] + n
            for (;r < m; r++)
            {
                if (nums[r] >= nums[l] + n) l++;
            }
            return n - r + l;
        }
        public static int MaximumUniqueSubarray(int[] nums)
        {
            // 4 2 4 5 6
            // l   r
            //we can also dictionary here to store value and index    
            int l = 0, r = 0,n = nums.Length,ans = 0,currentSum = 0;
            HashSet<int> visited = new HashSet<int>();
            for(;r < n; r++)
            {
                while (visited.Contains(nums[r]))
                {
                    if (nums[l] == nums[r]) visited.Remove(nums[r]);
                    currentSum -= nums[l];
                    l++;
                }
                currentSum += nums[r];
                visited.Add(nums[r]);
                ans = Math.Max(ans, currentSum);
            }

            return ans;
        }
        public static int EqualSubstring(string s,string t,int maxCost)
        {
            int r = 0,l = 0,n = s.Length,ans = 0,cnt = 0;
            
            for(;r < n; r++)
            {
                cnt += Math.Abs(s[r] - t[r]);
                while(cnt > maxCost)
                {
                    cnt -= Math.Abs(s[l] - t[l]);
                    l++;
                }
                ans = Math.Max(ans,r - l + 1);
            }

            return ans;
        }
        public static int LongestOnes(int[] nums,int k)
        {
            int r = 0,l = 0,n = nums.Length,cnt = 0,ans = 0;

            //<..Non-Shrinkable..>
            for (;r < n; ++r)
            {
                if (nums[r] == 0) cnt++;
                if(cnt > k)
                {
                    if (nums[l] == 0) cnt--;
                    l++;
                }
            }
            return r - l;

            //<..Shrinkable..>
            //for (; r < n; ++r)
            //{
            //    if (nums[r] == 0) cnt++;
            //    while (cnt > k)
            //    {
            //        if (nums[l] == 0) cnt--;
            //        l++;
            //    }
            //    ans = Math.Max(ans, r - l + 1);
            //}
            //return ans;
        }
        public static int CharacterReplacement(string s, int k)
        {
            //non-shrinkable
            //r-l represents the elements in the window so if we can find the maximum character in the window we can get the state
            //if we have the count of the maximum character in the window we can - it from the number of chars in the window
            //state r-l-maximum occuring char
            //invalid state ,,state r-l-maximum occuring char > k
            int l = 0, r = 0, n = s.Length, ans = 0;
            int[] cnt = new int[26];

            while (r < n)
            {
                cnt[s[r] - 'A']++;
                r++;
                while (r - l - cnt.Max() > k) cnt[s[l++] - 'A']--;
                ans = Math.Max(ans, r - l);
            }
            return ans;
        }

        public static int ProductSubArrayLessThan(int[] nums, int k)
        {
            //shrinkable
            //window[l,r] contains r-l+1 valid elements
            //if l > r+1 then the window is empty
            //in the inner loop check if l<=r
            //[10,5,2,6] k=100,answer = 8,state=product,invalid (product >= k)

            int l = 0, r = 0, n = nums.Length, product = 1, ans = 0;
            for (; r < n; r++)
            {
                product *= nums[r];
                while (l <= r && product >= k) product /= nums[l++];
                ans += r - l + 1;
            }
            return ans;
        }

        public static int LengthOfTheLongestSubstring(string s)
        {
            //shrinkable
            int[] arr = new int[128];
            int l = 0, r = 0, len = s.Length, ans = 0, dup = 0;
            //for(;r < len; ++r)
            //{
            //    ++arr[s[r]];
            //    while (arr[s[r]] > 1)
            //    {
            //        arr[s[l]]--;
            //        l++;
            //    }
            //    ans = Math.Max(ans, r - l + 1);
            //    //ans = Math.Max(ans,r - l + 1);
            //}
            //return ans;


            //non-shrinkable method must be very careful handlng it,especially when the left and decreasing the dup
            for (; r < len; ++r)
            {
                arr[s[r]]++;
                if (arr[s[r]] == 2)
                {
                    //arr[s[r]]--;
                    dup++;
                }
                if (dup > 0)
                {
                    if (--arr[s[l++]] == 1) dup--;
                    //arr[s[l]]--;
                    //l++;
                    //dup--;
                }
            }
            return r - l;
        }

        public static int LongestSubarray(int[] nums)
        {
            //shrinkable approach
            int left = 0, right = 0, ans = 0, cnt = 0, len = nums.Length;
            //for(;right < len; ++right)
            //{
            //    if (nums[right] == 0) cnt += 1;
            //    while(cnt > 1)
            //    {
            //        cnt -= 1;
            //        left++;
            //    }
            //    ans = Math.Max(ans, right - left); //size of the window is right - left + 1 but we use right - left because we must delete 1 element
            //}
            //return ans;

            //non-shrinkable approach
            for (; right < len; ++right)
            {
                if (nums[right] == 0) cnt += 1;
                if (cnt > 1)
                {
                    if (nums[left++] == 0) cnt -= 1;
                    //cnt -= 1;
                    //left ++;
                }
            }
            //we -1 because we must delete one element from the window
            return right - left - 1;
        }
    }
}
