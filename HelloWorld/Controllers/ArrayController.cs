﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloWorld.Controllers
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

            for (int i = 0; i < numsLength - 2; i++)
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

        /// <summary>
        /// 36# 有效的数独.
        /// </summary>
        /// <param name="board">数独数字集合.</param>
        /// <returns></returns>
        public bool IsValidSudoku(char[][] board)
        {
            // 定义数字行内出现的次数
            int[,] row = new int[9, 9];
            //定义数字列内出现的次数
            int[,] column = new int[9, 9];
            //定义数字九宫格内出现的次数最大为9次
            int[,,] jiugongge = new int[3, 3, 9];

            //遍历数组
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    char c = board[i][j];
                    //只要存在数字
                    if (c != '.')
                    {
                        //把数字-1化成索引下标,c是字符串要减去字符串，-1会报错。
                        int index = c - '1';
                        //这个时候++意思是第i行这个c值次数+1，默认row第二位就是{1-9}-1；每一行都有可能是1-9
                        //例如现在是第一行第一列是9，就在row[1][8]号位置+1
                        row[i, index]++;
                        //列同理
                        column[j, index]++;
                        //并且九宫格内次数也要+1,例如也是第1行第一列，i/3 j/3会自动定位到所在的小宫格
                        jiugongge[i / 3, j / 3, index]++;
                        //次数大于1就不成立一个数独
                        if (row[i, index] > 1 || column[j, index] > 1 || jiugongge[i / 3, j / 3, index] > 1) return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 37# 解数独.
        /// </summary>
        /// <param name="board"></param>
        public void SolveSudoku(char[][] board)
        {

        }

        /// <summary>
        /// 39# 组合总和.
        /// </summary>
        /// <param name="candidates">无重复元素整数数组.</param>
        /// <param name="target">目标值.</param>
        /// <returns></returns>
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> sum = new List<IList<int>>();

            // 排序
            var candidateList = candidates.ToList();
            candidateList.Sort();
            Backtrack(candidateList.ToArray(), target, new List<int>(), 0, 0, sum);

            return sum;
        }

        /// <summary>
        /// 回溯算法.
        /// </summary>
        /// <param name="candidates">整数数组.</param>
        /// <param name="target">目标整数.</param>
        /// <param name="temp">临时列表.</param>
        /// <param name="sum">列表中整数和.</param>
        /// <param name="i">索引.</param>
        /// <param name="res">结果集.</param>
        private void Backtrack(int[] candidates, int target, List<int> temp, int sum, int i, IList<IList<int>> res)
        {
            // 当前值可以重复被选取，从索引i开始遍历.
            for (int j = i; j < candidates.Length; j++)
            {
                // 临时列表中加入对应索引j的值.
                temp.Add(candidates[j]);

                // 累计和.
                sum += candidates[j];

                // 大于等于目标值时，后续循环只会使和更大，处理后可以直接结束循环.
                if (sum >= target)
                {
                    // 满足和等于目标值加入结果集.
                    if (sum == target)
                        res.Add(temp.ToArray());
                    // 临时列表回溯，并跳出循环
                    temp.RemoveAt(temp.Count - 1);
                    break;
                }
                else
                {
                    // 当和小于目标值时，继续递归进行累计，注意因为同一数字可重复使用所以索引传入j.
                    Backtrack(candidates, target, temp, sum, j, res);
                    // 临时列表回溯
                    temp.RemoveAt(temp.Count - 1);
                    // 减去对应值
                    sum -= candidates[j];
                }
            }
        }

        /// <summary>
        /// 40# 组合总和Ⅱ.
        /// </summary>
        /// <param name="candidates">候选人编号集合.</param>
        /// <param name="target">目标数.</param>
        /// <returns></returns>
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            IList<IList<int>> sum = new List<IList<int>>();

            // 排序
            var candidateList = candidates.ToList();
            candidateList.Sort();
            Backtrack2(candidateList.ToArray(), target, new List<int>(), 0, sum);

            return sum;
        }

        /// <summary>
        /// 回溯算法,去掉重复.
        /// </summary>
        /// /// <param name="candidates">整数数组.</param>
        /// <param name="target">目标整数.</param>
        /// <param name="temp">临时列表.</param>
        /// <param name="sum">列表中整数和.</param>
        /// <param name="i">索引.</param>
        /// <param name="res">结果集.</param>
        private void Backtrack2(int[] candidates, int target, List<int> temp, int i, IList<IList<int>> res)
        {
            if (target == 0)
                res.Add(temp.ToArray());
            else if (target > 0)
                for (int j = i; j < candidates.Length; j++)
                {
                    // 剪枝，当j不是循环中第一个值，且当前值等于前一个值时，重复，去除
                    if (j > i && candidates[j] == candidates[j - 1])
                        continue;
                    temp.Add(candidates[j]);
                    target -= candidates[j];
                    Backtrack2(candidates, target, temp, j + 1, res);
                    temp.RemoveAt(temp.Count - 1);
                    target += candidates[j];
                }
        }

        /// <summary>
        /// 41# 缺失的第一个正数.
        /// </summary>
        /// <param name="nums">未排序的整数数组.</param>
        /// <returns></returns>
        public int FirstMissingPositive(int[] nums)
        {
            int len = nums.Length - 1;
            if (len == 0 && nums[0] == 1) return 2;

            //第一步先将所有正数全部放置在相应索引上 单指针
            int quick = 0;
            while (quick <= len)
            {
                if (nums[quick] > 0 && nums[quick] <= len + 1)
                {
                    int temp = nums[quick] - 1;
                    while (nums[temp] != temp + 1)
                    {
                        //这一步的目的是将nums[temp]赋值为temp+1
                        //同时记录nums[temp]的原始值index
                        //对num[index]做相同操作
                        int index = nums[temp];
                        nums[temp] = temp + 1;
                        //如果下一个列表值小于0则直接赋值并跳出循环
                        //如果index的值大于列表长度也直接跳出
                        if (index - 1 < 0 || index - 1 > len)
                        {
                            break;
                        }
                        //如果下一个值为正数则继续交换
                        else
                        {
                            temp = index - 1;
                        }
                    }
                }
                else
                {
                    nums[quick] = -1;
                }
                quick++;
            }

            //第二步沿着数组寻找点
            for (int i = 0; i <= len; i++)
            {
                if (nums[i] != i + 1) return i + 1;
            }

            return len + 2;
        }

        /// <summary>
        /// 42# 接雨水.
        /// </summary>
        /// <param name="height">非负整数数组.</param>
        /// <returns></returns>
        public int Trap(int[] height)
        {
            int n = height.Length;
            if (n == 0)
                return 0;

            int[,] dp = new int[n, 2];
            dp[0, 0] = height[0];               // 第一位.
            dp[n - 1, 1] = height[n - 1];       // 最后一位.

            for (int i = 1; i < n; i++)
            {
                dp[i, 0] = Math.Max(height[i], dp[i - 1, 0]);
            }

            for (int i = n - 2; i >= 0; i--)
            {
                dp[i, 1] = Math.Max(height[i], dp[i + 1, 1]);
            }

            int res = 0;
            for (int i = 1; i < n - 1; i++)
            {
                res += Math.Min(dp[i, 0], dp[i, 1]) - height[i];
            }

            return res;
        }

        /// <summary>
        /// 45# 跳跃游戏Ⅱ.
        /// </summary>
        /// <param name="nums">非负整数数组.</param>
        /// <returns></returns>
        public int Jump(int[] nums)
        {
            int len = nums.Length;
            if (len == 1) { return 0; }

            // 记录能够到达的最远距离.
            int k = 0;
            // 步数.
            int step = 0;
            // 记录上一步step跳的最远距离.
            int end = 0;

            for (int i = 0; i < len; i++)
            {
                // 更新最大距离.
                k = Math.Max(k, i + nums[i]);

                // 大于数组的总长,即能跳到最后的位置.
                if (k >= len-1)
                {
                    return step + 1;
                }

                if (end == i) 
                {
                    step++;
                    end = k;
                }
            }

            return step;
        }

    }
}