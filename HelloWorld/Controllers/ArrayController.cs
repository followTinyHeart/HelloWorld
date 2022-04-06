using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeItemBank.Controllers
{
    public class ArrayController : Controller
    {
        /// <summary>
        /// #1两数之和.
        /// for循环的嵌套使用.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {
            //方法一：
            //int a = 0; int b = 0;

            //int diffValue = 0;

            //for (int i = 0; i < nums.Length; i++)
            //{
            //    diffValue = target - nums[i];

            //    for (int j = i + 1; j < nums.Length; j++)
            //    {
            //        if (diffValue == nums[j])
            //        {
            //            a = i;
            //            b = j;
            //        }
            //        else
            //        {
            //            return null;
            //        }
            //    }
            //}

            //int[] result = { a, b };

            //return result;

            //方法二：
            var dic = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int temp = target - nums[i];
                if (dic.Keys.Contains(temp))
                    return new int[] { dic[temp], i };

                //当前数据存字典，实现空间换时间
                dic[nums[i]] = i;
            }
            return null;
        }

        /// <summary>
        /// #4寻找两个有序数组中的中位数.
        /// 1、for循环的嵌套使用
        /// 2、List集合合并数组AddRange方法，Sort排序方法
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            double result = 0;

            List<int> numsList = new List<int>();

            //合并数组
            numsList.AddRange(nums1);
            numsList.AddRange(nums2);

            //list集合转int数组
            numsList.ToArray();

            //排序
            numsList.Sort();

            if ((numsList.Count % 2) == 0)
            {
                result = (numsList[(numsList.Count / 2) - 1] + numsList[numsList.Count / 2]) / 2.0;
            }
            else
            {
                result = numsList[(numsList.Count / 2 + numsList.Count % 2) - 1];
            }

            return result;
        }

        /// <summary>
        /// #11盛最多水的容器.
        /// </summary>
        /// Math.Max和Math.Min方法的使用
        /// <param name="height"></param>
        /// <returns></returns>
        public int MaxArea(int[] height)
        {
            int result = 0;

            for (int i = 0; i < height.Length; i++)
            {
                for (int j = i + 1; j < height.Length; j++)
                {
                    result = Math.Max(result, Math.Min(height[i], height[j]) * (j - i));
                }
            }

            return result;
        }


        /// <summary>
        /// 15#三数之和.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (nums.Length <= 3)
            {
                if (nums.Length == 3 && nums.Sum() == 0)
                {
                    result.Add(nums.ToList());
                }
                return result;
            }

            var len = nums.Length;
            Array.Sort(nums);
            for (var i = 0; i < len - 2; i++)
            {
                if (nums[i] > 0) break;
                if (i > 0 && nums[i] == nums[i - 1]) continue;  // 去重
                int left = i + 1, right = len - 1;
                while (left < right)
                {
                    var sum = nums[i] + nums[left] + nums[right];
                    if (sum == 0)
                    {
                        result.Add(new List<int> { nums[i], nums[left], nums[right] });
                        // 重复的数字跳过
                        while (left < right && nums[left] == nums[left + 1]) left++;
                        while (left < right && nums[right] == nums[right - 1]) right--;
                        left++;
                        right--;
                    }
                    else
                    {
                        if (sum < 0) left++;
                        else right--;
                    }
                }
            }
            return result;


            //自己思路    卡在去重
            //IList<IList<int>> result = new List<IList<int>>();

            //IList<IList<int>> containsList = new List<IList<int>>();

            //for (int i = 0; i < nums.Length; i++)
            //{
            //    for (int j = i + 1; j < nums.Length; j++)
            //    {
            //        for (int l = j + 1; l < nums.Length; l++)
            //        {
            //            if (nums[i] + nums[j] + nums[l] == 0)
            //            {
            //                int[] intArray = new int[] { nums[i], nums[j], nums[l] };

            //                Array.Sort(intArray);

            //                if (nums[i] == nums[j] || nums[i] == nums[l])
            //                {

            //                }
            //                else
            //                {
            //                    result.Add(new int[] { nums[i], nums[j], nums[l] });
            //                }
            //            }

            //        }
            //    }
            //}

            //return result;
        }


        /// <summary>
        /// 16#最接近的三数之和.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int ThreeSumClosest(int[] nums, int target)
        {
            int result = nums[0] + nums[1] + nums[2];
            int distance = Math.Abs(target - result);
            Array.Sort(nums);
            int numsLength = nums.Length;

            for (int i = 0; i < numsLength-2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue; // 去重
                int left = i + 1;
                int right = numsLength - 1;
                while (left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];
                    if (sum == target) { return target; }
                    
                    if (Math.Abs(target - sum) < distance)
                    {
                        result = sum;
                        distance = Math.Abs(target - sum);
                    }
                    if (sum < target) { left++; }
                    else { right--; }
                }
            }

            //int result = 0;
            //int threeNum = 0;
            //List<int> diffValueArray = new List<int>();
            //List<int> diffValueArray2 = new List<int>();


            //if (nums.Length<3)
            //{
            //    if (nums.Length==3)
            //    {
            //        result = nums[0] + nums[1] + nums[2];
            //    }
            //}

            //Array.Sort(nums);

            //for (int i = 0; i < nums.Length; i++)
            //{
            //    for (int j = i + 1; j < nums.Length; j++)
            //    {
            //        for (int k = j + 1; k < nums.Length; k++)
            //        {
            //            threeNum = nums[i] + nums[j] + nums[k];


            //            diffValueArray.Add(threeNum);

            //            diffValueArray2.Add(Math.Abs(threeNum - target));
            //        }
            //    }
            //}

            //for (int i = 0; i < diffValueArray.Count; i++)
            //{
            //    if (diffValueArray2.Min() == diffValueArray2[i])
            //    {
            //        result = diffValueArray[i];
            //    }
            //}

            return result;
        }


        /// <summary>
        /// 18#四数之和.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();



            return result;
        }


        /// <summary>
        /// 26#删除排序数组中的重复项.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int RemoveDuplicates(int[] nums)
        {
            int result = 0;



            return result;
        }

        /// <summary>
        /// 27#移除元素.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="val"></param>
        /// <returns>移除元素之后，数组的长度.</returns>
        public int RemoveElement(int[] nums, int val)
        {
            int n = nums.Count();
            if (n == 0 || nums == null) return 0;

            int i = 0;
            foreach (int num in nums)
            {
                if (num != val)
                {
                    nums[i++] = num;
                }
            }

            return i;
        }

        /// <summary>
        /// 31#下一个排列.
        /// </summary>
        /// <param name="nums"></param>
        public void NextPermutation(int[] nums)
        {
            //if (nums.Count() <= 1) return;
            //int j = nums.Count() - 1;
            //while (j - 1 >= 0 && nums[j - 1] >= nums[j]) { --j; }
            //if (j == 0)
            //{
            //    for (int i = 0; i < nums.Count() / 2; ++i)
            //    {
            //        swap(nums[i], nums[nums.Count() - 1 - i]);
            //    }

            //    return;
            //}

            //int r = nums.Count() - 1;
            //while (r >= j)
            //{
            //    if (nums[r] > nums[j - 1]) break;
            //    --r;
            //}

            //swap(nums[r], nums[j - 1]);
            //int cnt = (nums.Count() - j) / 2;
            //int i = 0;
            //while (cnt > 0)
            //{
            //    swap(nums[j + i], nums[nums.Count() - 1 - i]);
            //    ++i; --cnt;
            //}
            //return;
        }

        /// <summary>
        /// 33# 搜索旋转排序数组.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Search(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++) { if (nums[i] == target) return i; }
            return -1;
        }

        /// <summary>
        /// 34# 在排序数组中查找元素的第一个和最后一个位置.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] SearchRange(int[] nums, int target)
        {
            int[] result = new int[nums.Length];

            if (nums.Length > 0)
            {
                int startNum = -1;
                int endNum = -1;
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] == target)
                    {
                        if (startNum == -1)
                        {
                            startNum = i;
                        }

                        if (startNum > -1)
                        {
                            endNum = i;
                        }
                    }
                }

                result = new int[] { startNum, endNum };
            }
            else 
            {
                result = new int[] { -1, -1 };
            }

            return result;
        }

        /// <summary>
        /// 35# 搜索插入位置.
        /// </summary>
        /// <param name="nums">排序数组.</param>
        /// <param name="target">目标值.</param>
        /// <returns></returns>
        public int SearchInsert(int[] nums, int target)
        {
            int result = -1;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] >= target)
                {
                    return i;
                }
            }

            return nums.Length;

            // 自己的方法.
            //List<int> numxList = new List<int>(nums);

            //if (nums.Length > 0)
            //{
            //    numxList.Add(target);
            //    numxList.Sort();

            //    for (int i = 0; i < numxList.Count(); i++)
            //    {
            //        if (numxList[i] == target )
            //        {
            //            if (result == -1)
            //            {
            //                result = i;
            //            }
            //        }
            //    }
            //}
            //else 
            //{
            //    result = 0;
            //}

            //return result;
        }
    }
}