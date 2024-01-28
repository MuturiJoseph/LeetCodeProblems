using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp2
{
        public class ListNode
        {
            public ListNode next;
            public int val;
            public ListNode(int val = 0,ListNode next = null)
            {
                this.next = next;
                this.val = val;
            } 
        }
    public class Node
    {
        //141 linkedlist cycle
        public bool HasCycle(ListNode head)
        {
            ListNode tortoise = head;
            ListNode hare = head;
            while (hare != null && hare.next != null)
            {
                hare = hare.next.next;
                tortoise = tortoise.next;

                if (hare == tortoise) return true;
            }
            return false;
        }
        //142 linkedlist cycle ii
        public ListNode HasCycleII(ListNode head)
        {
            ListNode tortoise = head;
            ListNode hare = head;
            while (hare != null && hare.next != null)
            {
                hare = hare.next.next;
                tortoise = tortoise.next;

                if (hare == tortoise) break;
            }
            if (hare == null && hare.next == null) return null;
            while (tortoise != head)
            {
                tortoise = tortoise.next;
                head = head.next;
            }
            return tortoise;
        }
        //61 rotate list
        public ListNode RotateList(ListNode head,int k)
        {
            if(head == null) return null;
            int len = 1;
            ListNode tail = head;
            while(tail.next != null)
            {
                tail = tail.next;
                len++;
            }
            k %= len;
            ListNode curr = head;
            int i = 0;
            while(i < k)
            {
                curr = curr.next;
                i++;
            }
            ListNode dummy = curr.next;
            curr.next = null;
            tail.next = head;

            return dummy;
        }
        //143 Reorder list
        //1 2 4 7 5 9 6 input
        //1 6 2 9 4 5 7 answer   2 lists are joined 1 2 4 7 and (5 9 6) <--- reverse this --> 6 9 5
        public void ReOrderList(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;
            //find the mid point of the list
            while(fast != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            //Reverse the right end of mid
            ListNode prev = null, curr = slow.next;
            while(curr != null)
            {
                ListNode nxt = curr.next;
                curr.next = prev;
                prev = curr;
                curr = nxt;
            }
            slow.next = null;

            //Join the two Lists
            ListNode head1 = head, head2 = prev;
            while(head1 != null)
            {
                ListNode temp = head1.next;
                head1.next = head2;
                head1 = head2;
                head2 = temp;
            }
        }
        public ListNode Partition(ListNode head,int x)
        {
            ListNode dummy = new ListNode(0);
            ListNode dummy2 = new ListNode(0);
            ListNode list1 = dummy;
            ListNode list2 = dummy2;
            while(head != null)
            {
                if(head.val < x)
                {
                    list1.next = head;
                    list1 = head;
                }
                else
                {
                    list2.next = head;
                    list2 = head;
                }
                head = head.next;
            }
            list1.next = dummy2.next;
            list2.next = null;
            return dummy.next;
        }
    }
    public static class TwoPointer
    {
        public static void BottomUpMergeSort(int[] array)
        {
            int n = array.Length;
            int[] tempArray = new int[n];

            for (int size = 1; size < n; size *= 2)
            {
                for (int leftStart = 0; leftStart < n - 1; leftStart += 2 * size)
                {
                    int mid = Math.Min(leftStart + size - 1, n - 1); 
                    int rightEnd = Math.Min(leftStart + 2 * size - 1, n - 1);

                    Merge(array, tempArray, leftStart, mid, rightEnd);
                }
            }
        }

        private static void Merge(int[] array, int[] tempArray, int left, int mid, int right)
        {
            int i = left;
            int j = mid + 1;
            int k = left;

            while (i <= mid && j <= right)
            {
                if (array[i] <= array[j])
                {
                    tempArray[k++] = array[i++];
                }
                else
                {
                    tempArray[k++] = array[j++];
                }
            }

            while (i <= mid)
            {
                tempArray[k++] = array[i++];
            }

            while (j <= right)
            {
                tempArray[k++] = array[j++];
            }

            for (int index = left; index <= right; index++)
            {
                array[index] = tempArray[index];
            }
        }
        public static bool CanTransform(string start,string end)
        {
            int n  = end.Length;
            if (start.Replace("X","") != end.Replace("X","")) return false;
            List<int> lStart = Enumerable.Range(0,n).Where(i => start[i] == 'L').ToList();
            List<int> lEnd = Enumerable.Range(0, n).Where(i => end[i] == 'L').ToList();
            List<int> rStart = Enumerable.Range(0, n).Where(i => start[i] == 'R').ToList();
            List<int> rEnd = Enumerable.Range(0, n).Where(i => end[i] == 'R').ToList();

            foreach(var pair in lStart.Zip(lEnd, Tuple.Create))
            {
                if (pair.Item1 < pair.Item2) return false;
            }
            foreach(var pair in rStart.Zip(rEnd, Tuple.Create))
            {
                if (pair.Item1 > pair.Item2) return false;
            }
            return true;
        }
        //1023
        public static IList<bool> CamelMatch(string[] queries,string pattern)
        {
            int pLength = pattern.Length;
            IList<bool> res = new List<bool>();
            foreach(var query in queries) res.Add(isMatch(query, pattern));
            return res;
        }
        private static bool isMatch(string query,string pattern)
        {
            int i = 0, pLength = pattern.Length;
            foreach (var c in query)
            {
                if (i < pLength && c == pattern[i]) i++;
                else if (c < 'a') return false;
            }
            return i == pLength ; 
        }
        //1385
        public static int FindTheDistanceValue(int[] arr1, int[] arr2,int d)
        {
            int arr1l = arr1.Length, arr2l = arr2.Length,ans = 0;
            for(int i = 0;i < arr1l; i++)
            {
                int l = 0,r = arr2l-1;
                bool hasBreak = false;
                while(l < r)
                {
                    if (Math.Abs(arr1[i] - arr2[l]) <= d || Math.Abs(arr1[i] - arr2[r]) <= d)
                    {
                        hasBreak = true;
                        break;
                    }
                    l++;
                    r--;
                }
                if (!hasBreak)
                {
                    ans++;
                    if (arr2l % 2 != 0 && Math.Abs(arr1[i] - arr2[l]) <= d) ans--;
                }
            }
            return ans;
        }
        //845
        public static int LongestMountain(int[] arr)
        {
            int n = arr.Length, ans = 0, initial = 0, r = 0, l = 0;
            while(l < n-2)
            {
                //check if value at [l == l] of [l > l+1] this is invalid
                while (l + 1 < n && arr[l] >= arr[l + 1]) l++;

                r = l+1;
                while(r+1 < n && arr[r] < arr[r + 1])
                {
                    r++;
                }
                while (r + 1 < n && arr[r] > arr[r + 1])
                {
                    r++;
                    ans = Math.Max(ans, r - l + 1);
                }
                l = r;
            }
            return ans;
        }
        //443
        public static int Compress(char[] chars)
        {
            int n = chars.Length, left = 0, right = 0, ans = 0, index = 0;
            if (n == 1) return 1;
            while (right < n)
            {
                while (right < n - 1 && chars[right] == chars[right + 1]) right++;
                int diff = right - left + 1;
                if (diff == 1)
                {
                    ans += 1;
                    chars[index] = chars[left];
                    index++;
                }
                else
                {
                    chars[index++] = chars[left];
                    string diffString = diff.ToString();
                    for (int i = 0; i < diffString.Length; i++)
                    {
                        chars[index++] = (char)diffString[i];
                    }
                    ans += diffString.Length + 1;
                }
                right++;
                left = right;
            }
            return ans;
        }
        public static int FindPairs(int[] nums,int k)
        {
            int n = nums.Length,r = 1,l = 0,cnt = 0;
            Array.Sort(nums);
            while(r < n)
            {
                while (nums[r] - nums[l] > k) l++;
                if (nums[r] - nums[l] == k && l != r)
                {
                    while (l+1 < n && nums[l] == nums[l + 1]) l++;
                    while (r + 1 < n && nums[r] == nums[r + 1]) r++;
                    cnt += 1;
                }
                r++;
            }
            return cnt;
        }
        //696
        public static int CountBinarySubstrings(string s)
        {
            int n = s.Length;
            if (n == 1) return 0;
            int left = 0, right = 0,cnt = 0,count1 = 0,count2 = 0;
            while(right < n-1)
            {
                count1++;
                while (left+1 < n && s[left] == s[left + 1])
                {
                    count1++; 
                    left++;
                }
                right = left + 1;
                while ( right + 1 < n && s[right] == s[right + 1])
                {
                    count2++; 
                    right++;
                }
                if(right < n) count2++;
                cnt += Math.Min(count1,count2);

                count1 = 0; count2 = 0;
                left++;
            }
            return cnt;
        }
        //719 Find k-th smallest pair distance
        //public static int smallestDistancePair(int[] nums int k)
        //{

        //}
        //1750
        public static int MinimumLength(string s)
        {
            int left = 0, right = s.Length - 1;
            while(left < right && s[left] == s[right])
            {
                while (left < right && s[left] == s[left + 1]) left++;
                left++;
                while (left < right && s[right] == s[right - 1]) right--;
                right--;
            }
            return left > right ? 0 : right - left + 1;
        }
        //942 DI String Match
        public static int[] DiStringMatch(string s)
        {
            int n = s.Length,left = 0,right = n;
            int[] result = new int[n+1];
            for(int i=0;i < n;i++)
            {
                //if (s[i] == 'I')
                //{
                //    if(i < 1) result[i] = i;
                //    result[i + 1] = i + 1;
                //}
                //else
                //{
                //    int toSwap = result[i];
                //    result[i] = i + 1;
                //    result[i + 1] = toSwap;
                //}
                if (s[i] == 'I') result[i] = left++;
                else result[i] = right--;
            }
            result[n] = left;
            return result;
        }
        //948 Bag of Tokens
        public static int BagOfTokensScore(int[] tokens,int power)
        {
            int score = 0,left = 0,right = tokens.Length-1;
            while (left <= right)
            {
                if (power <= tokens[left] && score > 0 && left < right)
                {
                    power += tokens[right];
                    right--;
                    score--;
                }
                if (tokens[left] <= power)
                {
                    power -= tokens[left];
                    score++;
                    //left++;
                };
                left++;
            }
            return score;
        }
        //541 Reverse String II
        public static string ReverseStr(string s,int k)
        {
            char[] chars = s.ToCharArray();
            int left = 0,n = s.Length,right = n - 1;
            if(right < k)
            {
                while(left < right)
                {
                    Swap(chars, left, right);
                    left++;
                    right--;
                }
            }
            else
            {
                left = k * 2;
                right = 1;
                while(right < n)
                {
                    Swap(chars, right - 1, right);
                    right += left;
                }
            }
            return new string(chars);
        }
        //27
        public static int RemoveElement(int[] nums,int val)
        {
            int index = 0;
            if (val > 50) return nums.Length;
            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val) nums[index++] = nums[i];
            }
            return index;
        }
        //917
        public static string ReverseOnlyLetters(string s)
        {
            char[] chars = s.ToLower().ToCharArray();
            char[] result = s.ToCharArray();
            int right = chars.Length - 1,left = 0;
            while (left < right)
            {
                int lside = chars[left] - 'a';
                int rside = chars[right] - 'a';
                if (lside < 0 || lside > 25) left++;
                if (rside < 0 || rside > 25) right--;
                if((lside >= 0 && lside <= 25)&& (rside >= 0 && rside <= 25))
                {
                    Swap(result,left, right);
                    left++;
                    right--;
                }
            }
            return new string(result);
        }
        //680
        public static bool ValidPalindrome(string s)
        {
            int left = 0,right = s.Length-1,count = 0;
            while(left < right)
            {
                if (s[left] != s[right])
                {
                    if (s[left + 1] == s[right])
                    {
                        left++;
                        count++;
                    }
                    else
                    {
                        right--;
                        count++;
                    }
                }
                else
                {
                    left++;
                    right--;
                }
                if (count > 1) return false;
            }
            return true;
        }
        //345
        public static string ReverseVowels(string s)
        {
            s.ToCharArray();
            char[] arr = s.ToLower().ToCharArray();
            HashSet<char> chars = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
            int left = 0, right = arr.Length - 1;
            while(left < right)
            {
                while (left < right && !chars.Contains(arr[left])) left++;
                while (left < right && !chars.Contains(arr[right])) right--;
                Swap(arr, left, right);
                left++;
                right--;
            }
            return new String(arr);
        }
        //344
        public static char[] ReverseString(char[] s)
        {
            int left = 0;
            int right = s.Length - 1;
            while(left < right)
            {
                Swap(s, left, right);
                left++;
                right--;
            }
            return s;
        }
        //private static void Swap(char[] arr, int left, int right)
        //{
        //    char temp = arr[left];
        //    arr[left] = arr[right];
        //    arr[right] = temp;
        //}
        //125
        public static bool IsPalindrome(string s)
        {
            string palindrome = Regex.Replace(s, @"[^a-zA-Z0-9]", "").ToLower();
            int len = palindrome.Length/2,left = 0;
            if(palindrome.Length % 2 == 0) left = len - 1;
            else
            {
                left = len - 1;
                len = len + 1;
            }
            while(left >= 0)
            {
                if (palindrome[left] != palindrome[len]) return false;
                left--;
                len++;
            }
            return true;
        }
        //1850
        public static int GetMinSwap(string num,int k)
        {
            int[] permutation = num.Select(c => int.Parse(c.ToString())).ToArray();
            var result = num.Select(c => int.Parse(c.ToString())).ToArray();
            for(int i = 0;i < k; i++)
            {
                NextPermutation(permutation);
            }
           
 
            return CountSwap(result,permutation,result.Length);
        }
        private static int CountSwap(int[] current, int[] terget,int size)
        {
            int i = 0,j = 0,count = 0;
            while(i < size)
            {
                j = i;
                while (current[j] != terget[i]) j++;
                while(i < j)
                {
                    Swap(current, j, j - 1);
                    count++;
                    j--;
                }
                i++;
            }
            return count;
        }
        private static void NextPermutation(int[] permutation)
        {
            int[] res = permutation;
            int n = permutation.Length;
            int right = n - 2;
            while (right>=0 && permutation[right] >= permutation[right+1]) right--;
            if(right < 0) return;
            int index = right;
            right = n - 1;
            while (right >= 0 && permutation[index] >= permutation[right]) right--;
            Swap(permutation, index,right);
            Reverse(permutation, index+1,n-1);
        }
        private static void Swap(int[]nums,int index1,int index2)
        {
            int temp = nums[index1];
            nums[index1] = nums[index2];
            nums[index2] = temp;
        }
        private static void Reverse(int[] nums,int left,int right)
        {
            while(left < right)
            {
                Swap(nums,left,right);
                left++;
                right--;
            }
        }
        //556
        public static int NextGreaterElement(int n)
        {
            //working array
            var array = n.ToString().ToCharArray();

            int len = array.Length;
            int right = len - 2;
            while (right >= 0 && array[right] >= array[right+1]) right--;
            if (right == -1) return -1;
            int index = right;
            right = len - 1;
            while(right > index && array[index] >= array[right]) right--;
            Swap(array, index, right);
            
            Reverse(array, index+1, len-1);
            int result = 0, pow = 1;
            right = len - 1;    
            for(;right >= 0;right--)
            {
                result += (array[right] - '0') * pow;
                pow *= 10;
            }

            return result > int.MaxValue ? -1 : result;
        }
        //31
        //public static int[] NextPermutation(int[] nums)
        //{
        //    //1342 ----1432 --- 1423
        //    int n = nums.Length;
        //    if (n == 1) return nums;
        //    int right = n - 2;
        //    while(right >= 0 && nums[right] >= nums[right+1]) right--;
        //    if(right == -1)
        //    {
        //        Array.Reverse(nums);
        //        return nums;
        //    }
        //    int index = right;
        //    right = n - 1;
        //    while (right >= 0 && nums[index] >= nums[right]) right--;
        //    Swap(nums, index,right);
        //    Array.Reverse(nums,index+1,n-1-index);
        //    return nums;
        //}
        private static void Reverse(char[] array, int index1, int index2)
        {
            while (index1 < index2)
            {
                Swap(array, index1, index2);
                index1++;
                index2--;
            }
        }
        private static void Swap(char[] nums,int left,int right)
        {
            char temp = nums[left];
            nums[left] = nums[right];
            nums[right] = temp;
        }
        //11
        public static int MaxArea(int[] height)
        {
            int left = 0, right = height.Length - 1,MaxWater = 0;
            while(left < right)
            {
                int min = Math.Min(height[left],height[right]);
                MaxWater = Math.Max(MaxWater, min * (right - left));
                if (height[left] < height[right]) left++;
                else right--;
            }
            return MaxWater;
        }
        //42
        public static int Trap(int[] height)
        {
            //420325  two pointer
            int n = height.Length;
            if(n == 0) return 0;
            int l = 0,r = n - 1,maxLeft = height[l],maxRight = height[r],ans = 0;
            while (l < r)
            {
                if(maxLeft < maxRight)
                {
                    l += 1;
                    maxLeft = Math.Max(maxLeft, height[l]);
                    ans += maxLeft - height[l];
                }
                else
                {
                    r -= 1;
                    maxRight = Math.Max(maxRight, height[r]);
                    ans += maxRight - height[r];
                }
            }
            return ans;
        }
        //923
        public static int ThreeSumMulti(int[] nums,int target)
        {
            //1122334455   //here we will use outer while loop in order to increase i with more than 1
            Dictionary<int,int> counter = new Dictionary<int,int>();
            foreach(int c in nums)
            {
                if(!counter.ContainsKey(c)) counter.Add(c,1);
                else counter[c]++;
            }
            Array.Sort(nums);
            int i = 0,n = nums.Length,ans = 0;
            while(i < n-2)
            {
                int j = i,k = n-1;
                while (j < k)//this loop has a run time of o(n)
                {
                    int sum = nums[i] + nums[j] + nums[k];
                    if (sum > target) k--;
                    else if(sum < target) j++;
                    else
                    {
                        if (nums[i] == nums[j] && nums[j] == nums[k])
                        {
                            //math.comb(counti,3);//permutation of counti and number of elements need
                            ans += (counter[nums[i]] * (counter[nums[i]] - 1) * (counter[nums[i]] - 2))/6; // divided by permutation of 3
                        }
                        else if (nums[i] == nums[j] && nums[j] != nums[k])
                        {
                            //math.comb(counti,2);//permutation of counti and number of elements needed here 2elements are equal
                            ans += (counter[nums[i]] * (counter[nums[i]] - 1) * counter[nums[k]]) /2; //divided by permutation of 2
                        }
                        else if (nums[i] != nums[j] && nums[j] == nums[k])
                        {
                            //math.comb(counti,3);//permutation of counti and number of elements need
                            ans += (counter[nums[i]] * counter[nums[j]] * (counter[nums[j]] - 1))/2;//divided by permutation of 2
                        }
                        else   //when none of the values is equal to the other
                        {
                            ans += counter[nums[i]] * counter[nums[j]] * counter[nums[k]];
                        }
                        j += counter[nums[j]];
                        k -= counter[nums[k]];
                    }
                }
                i += counter[nums[i]];
            }
            return ans%1000000007;
        }
        //1877
        public static int MinPairSum(int[] nums)
        {
            Array.Sort(nums);
            int l = 0, r = nums.Length - 1, ans = 0;
            while(l < r)
            {
                ans = Math.Max(ans, nums[l] + nums[r]);
                l++;
                r--;
            }
            return ans;
        }
        //881
        public static int NumRescueBoats(int[] nums,int limit)
        {
            //1223
            //1111
            //there are two possibilities here,,when left+right > limit --> then decrement right
            //when left + right <= limit decrement right and increment left
            Array.Sort(nums);
            int left = 0, right = nums.Length - 1,ans = 0;
            while(left <= right)
            {
                if (nums[left] + nums[right] <= limit)
                {
                    left++;
                    right--;
                }
                else right--;
                ans += 1;
            }
            return ans;
        }
        //633
        public static bool JudgeSquareSumTwoPointer(int c)
        {
            //here we only need to use sqrt as right pointer and zero as left pointer
            //if the square of left + right == c return true
            int sqr = (int)Math.Sqrt(c);
            int left = 0;
            int right = (int)Math.Sqrt(c);

            while(left < right)
            {
                int toCheck = left * left + right * right;
                if(toCheck == c) return true;
                if (toCheck > c) right--;
                else left--;
            }
            return false;
        }
        public static bool JudgeSquareSum(int c)
        {
            //we can use 2 pointer,hashmap or sqrt to solve the solution
            //sqrt works beacuase if the exist a^2 + b^2 = c then
            //the result we get from sqrt(c-a) will be a double and will be equal to the intiger of that value
            int sqr = (int)Math.Sqrt(c);
            for(int i = 0;i < sqr; ++i)
            {
                double b = Math.Sqrt(c - i * i);
                if(b == (int)b) return true;
            }
            return false;
        }
        //1498
        public static int NumSubSeq(int[] nums,int target)
        {
            Array.Sort(nums);
            int n  = nums.Length,ans = 0;
            int mod = 1000000007;
            int[] pow2 = new int[n];
            pow2[0] = 1;
            for (int i = 1; i < n; i++) pow2[i] = pow2[i - 1] * 2 % mod;//This helps to get all the non-empty
            //subarrays at each index or as the element count increases.

            int left = 0, right = n - 1;
            while(left <= right)
            {
                if (nums[left] + nums[right] <= target)
                {
                    ans = (ans + pow2[right - left]) % mod;
                    left++;
                }
                else right--;
            }
            return ans;
        }
        //18
        public static IList<IList<int>> FourSumusingDictionary(int[] nums,int target)
        {
            int n = nums.Length;
            if(n < 4) return new List<IList<int>>();
            var result = new List<IList<int>>();
            Array.Sort(nums);
            var check = new Dictionary<int, int>();
            for (int i = 0; i < n; i++) check.Add(i, nums[i]);

            for(int i = 0;i < n - 3; i++)
            {
                for(int j = i + 1;j < n - 2; j++)
                {
                    for( int k = j + 1; k < n - 1; k++)
                    {
                        int toFind = target - (nums[i] + nums[j] + nums[k]);
                        if(check.ContainsValue(toFind) && check.Last(kv => kv.Value == toFind).Key > k)
                        {
                            result.Add(new List<int> { nums[i], nums[j], nums[k], toFind });
                        }
                        k = check.Last(kv => kv.Value == nums[k]).Key;
                    }
                    j = check.Last(kv => kv.Value == nums[j]).Key;//this avoids same values from being used more than once
                }
                i = check.Last(kv => kv.Value == nums[i]).Key;//this have been duplicated 3 times you can use a separate method
                //to get the index of last occurrence of a value ...private static int GetIndexOfValue...
            }
            return result;
        }
        //18 4Sum
        public static IList<IList<int>> FourSum(int[] nums,int target)
        {
            //Two pointer
            IList<IList<int>> result = new List<IList<int>>();
            int n = nums.Length;
            if(n < 4) return new List<IList<int>>();
            Array.Sort(nums);

            for(int i = 0;i < n - 3; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;
                for(int j = i+1;j < n - 2; j++)
                {
                    if (j != i +1 && nums[j] == nums[j - 1]) continue;
                    int left = j+1, right = n - 1;
                    while(left < right)
                    {
                        int sum = nums[i] + nums[j] + nums[left] + nums[right];
                        if(sum == target) result.Add(new List<int> { nums[i], nums[j], nums[left], nums[right]});
                        if(sum > target)
                        {
                            right--;
                            while(left < right && nums[right] == nums[right - 1]) right--;
                        }
                        else
                        {
                            left++;
                            while(left < right && nums[left] == nums[left - 1]) left++;
                        }
                    }
                }
            }
            return result;
        }
        //15 3Sum
        public static IList<IList<int>> ThreeSumusingDictionary(int[] nums)
        {
            //using hash map
            int n = nums.Length;
            Array.Sort(nums);
            if (n < 3) return new List<IList<int>>();
            IList<IList<int>> list = new List<IList<int>>();
            Dictionary<int,int> check = new Dictionary<int,int>();
            for(int i = 0;i < n; i++) check.Add(i, nums[i]);
            for(int i = 0;i < n - 2; i++)
            {
                if (nums[i] > 0) return list;
                //if (i > 0 && nums[i - 1] == nums[i]) continue;
                for (int j = i + 1; j < n - 1; j++)
                {
                   // if (j != i+1 && nums[j - 1] == nums[j]) continue;
                    int remaining = 0 - (nums[i] + nums[j]);
                    if(check.ContainsValue(remaining) && check.Last(kv => kv.Value == remaining).Key > j)
                    {
                        list.Add(new List<int> { nums[i], nums[j],remaining });
                    }
                    j = check.Last(kv => kv.Value == nums[j]).Key;//this checks for duplicates
                }
                i = check.Last(kv => kv.Value == nums[i]).Key;//this checks for duplicates
            }
            return list;
            //instead of using the 2 if statements we assign index i and j to the last occurrence of their previous values in the map
        }
        //15 3Sum
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            //-4,-1,-1,0,1,2
            //-1,0,1,2,-1,-4
            Array.Sort(nums);
            IList<IList<int>> list = new List<IList<int>>();
            int n = nums.Length;
            //using two pointer
            if(n < 3) return list;
            if (nums[0] > 0) return list;
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i > 0 && nums[i - 1] == nums[i]) continue;
                if (nums[i] > 0) return list;
                int j = i + 1,k = n - 1;
                while(j < k)
                {
                    int sum = nums[i] + nums[j] + nums[k];
                    if(sum == 0) list.Add(new List<int> { nums[i], nums[j], nums[k]});
                    if(sum > 0)
                    {
                        k--;
                        while(j < k && nums[k] == nums[k+1]) k--;
                    }
                    else
                    {
                        j++;
                        while (j < k && (nums[j] == nums[j - 1])) j++;
                    }
                }
            }
            return list;
        }
        //167 Two-sum II
        public static int[] TwoSum(int[] nums,int target)
        {
            int l = 0,r = nums.Length - 1;
            while (l < r)
            {
                int sum = nums[l] + nums[r];
                if(sum == target) return new int[] {l + 1,r + 1};
                if (sum > target) r -= 1;
                else l += 1;
            }
            return new int[] {};
        }
    }
}
