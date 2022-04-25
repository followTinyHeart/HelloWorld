using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloWorld.Controllers
{
    public class ArrayController : Controller
    {
        #region 十大经典排序算法.
        //冒泡排序.
        //选择排序.
        //插入排序.
        //希尔排序.
        //归并排序.
        //快速排序.
        //堆排序.
        //计数排序.
        //桶排序.
        //基数排序.

        /// <summary>
        /// 冒泡排序.
        /// </summary>
        /// <param name="intArray"></param>
        public void BubbleSort(int[] intArray)
        {
            int temp = 0;
            bool swapped;
            for (int i = 0; i < intArray.Length; i++)
            {
                swapped = false;
                for (int j = 0; j < intArray.Length - 1 - i; j++)
                    if (intArray[j] > intArray[j + 1])
                    {
                        temp = intArray[j];
                        intArray[j] = intArray[j + 1];
                        intArray[j + 1] = temp;
                        if (!swapped)
                            swapped = true;
                    }
                if (!swapped)
                    return;
            }
        }

        /// <summary>
        /// 选择排序.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        public void selection_sort<T>(T[] arr) where T : System.IComparable<T>
        {
            //整數或浮點數皆可使用
            int i, j, min, len = arr.Length;
            T temp;
            for (i = 0; i < len - 1; i++)
            {
                min = i;
                for (j = i + 1; j < len; j++)
                    if (arr[min].CompareTo(arr[j]) > 0)
                        min = j;
                temp = arr[min];
                arr[min] = arr[i];
                arr[i] = temp;
            }
        }

        /// <summary>
        /// 插入排序.
        /// </summary>
        /// <param name="array"></param>
        public static void InsertSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int temp = array[i];
                for (int j = i - 1; j >= 0; j--)
                {
                    if (array[j] > temp)
                    {
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                    else
                        break;
                }
            }
        }

        /// <summary>
        /// 希尔排序.
        /// </summary>
        /// <param name="arr"></param>
        public void ShellSort(int[] arr)
        {
            int gap = 1;

            while (gap < arr.Length)
            {
                gap = gap * 3 + 1;
            }

            while (gap > 0)
            {
                for (int i = gap; i < arr.Length; i++)
                {
                    int tmp = arr[i];
                    int j = i - gap;
                    while (j >= 0 && arr[j] > tmp)
                    {
                        arr[j + gap] = arr[j];
                        j -= gap;
                    }
                    arr[j + gap] = tmp;
                }
                gap /= 3;
            }
        }

        /// <summary>
        /// 归并排序.
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public List<int> sort(List<int> lst)
        {
            if (lst.Count <= 1)
                return lst;
            int mid = lst.Count / 2;
            List<int> left = new List<int>();  // 定义左侧List
            List<int> right = new List<int>(); // 定义右侧List
                                               // 以下兩個循環把 lst 分為左右兩個 List
            for (int i = 0; i < mid; i++)
                left.Add(lst[i]);
            for (int j = mid; j < lst.Count; j++)
                right.Add(lst[j]);
            left = sort(left);
            right = sort(right);
            return merge(left, right);
        }
        /// <summary>
        /// 合併兩個已經排好序的List
        /// </summary>
        /// <param name="left">左側List</param>
        /// <param name="right">右側List</param>
        /// <returns></returns>
        static List<int> merge(List<int> left, List<int> right)
        {
            List<int> temp = new List<int>();
            while (left.Count > 0 && right.Count > 0)
            {
                if (left[0] <= right[0])
                {
                    temp.Add(left[0]);
                    left.RemoveAt(0);
                }
                else
                {
                    temp.Add(right[0]);
                    right.RemoveAt(0);
                }
            }
            if (left.Count > 0)
            {
                for (int i = 0; i < left.Count; i++)
                    temp.Add(left[i]);
            }
            if (right.Count > 0)
            {
                for (int i = 0; i < right.Count; i++)
                    temp.Add(right[i]);
            }
            return temp;
        }

        /// <summary>
        /// 堆排序
        /// </summary>
        /// <param name="arr">待排序数组</param>
        static void HeapSort(int[] arr)
        {
            int vCount = arr.Length;
            int[] tempKey = new int[vCount + 1];
            // 元素索引从1开始
            for (int i = 0; i < vCount; i++)
            {
                tempKey[i + 1] = arr[i];
            }
            // 初始数据建堆（从含最后一个结点的子树开始构建，依次向前，形成整个二叉堆）
            for (int i = vCount / 2; i >= 1; i--)
            {
                Restore(tempKey, i, vCount);
            }
            // 不断输出堆顶元素、重构堆，进行排序
            for (int i = vCount; i > 1; i--)
            {
                int temp = tempKey[i];
                tempKey[i] = tempKey[1];
                tempKey[1] = temp;
                Restore(tempKey, 1, i - 1);
            }
            //排序结果
            for (int i = 0; i < vCount; i++)
            {
                arr[i] = tempKey[i + 1];
            }
        }
        /// <summary>
        /// 二叉堆的重构（针对于已构建好的二叉堆首尾互换之后的重构）
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="rootNode">根结点j</param>
        /// <param name="nodeCount">结点数</param>
        static void Restore(int[] arr, int rootNode, int nodeCount)
        {
            while (rootNode <= nodeCount / 2) // 保证根结点有子树
            {
                //找出左右儿子的最大值
                int m = (2 * rootNode + 1 <= nodeCount && arr[2 * rootNode + 1] > arr[2 * rootNode]) ? 2 * rootNode + 1 : 2 * rootNode;
                if (arr[m] > arr[rootNode])
                {
                    int temp = arr[m];
                    arr[m] = arr[rootNode];
                    arr[rootNode] = temp;
                    rootNode = m;
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// 桶排序.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="bucketCount"></param>
        /// <param name="maxBucketCount"></param>
        public void BucketSort(List<int> list, int bucketCount, int maxBucketCount)
        {
            List<List<int>> buckets = new List<List<int>>(bucketCount);//二维列表
            for (int i = 0; i < bucketCount; i++)
            {
                buckets.Add(new List<int>());
            }
            for (int i = 0; i < list.Count; i++)
            {
                // int j = Mathf.Min(list[i] / (maxBucketCount / bucketCount), bucketCount - 1);//j表示改放的哪个桶,不能大于n-1
                int j = Math.Min(list[i] / (maxBucketCount / bucketCount), bucketCount - 1);//j表示改放的哪个桶,不能大于n-1
                buckets[j].Add(list[i]);//放入对应桶
                for (int x = buckets[j].Count - 1; x > 0; x--)//放一个排序一次，两两对比就可以
                {
                    if (buckets[j][x] < buckets[j][x - 1])//升序
                    {
                        int tmp = buckets[j][x];//交换
                        buckets[j][x] = buckets[j][x - 1];
                        buckets[j][x - 1] = tmp;
                    }
                    else
                    {
                        break;//如果不发生交换直接退出，因为前面的之前就排序好了
                    }
                }
            }
            list.Clear();//输出
            for (int i = 0; i < buckets.Count; i++)
            {
                list.AddRange(buckets[i]);
            }
        }
        #endregion

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
                if (k >= len - 1)
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

        IList<IList<int>> result = new List<IList<int>>();
        /// <summary>
        /// 46# 全排列.
        /// </summary>
        /// <param name="nums">不含重复数字的数组.</param>
        /// <returns></returns>
        public IList<IList<int>> Permute(int[] nums)
        {
            //路径
            LinkedList<int> track = new LinkedList<int>();
            Backtrack3(nums, track);
            return result;
        }

        /// <summary>
        /// 回溯算法，循环前先结束条件，前序做选择，后序撤销选择
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="track"></param>
        private void Backtrack3(int[] nums, LinkedList<int> track)
        {
            //触发结束条件
            if (track.Count == nums.Length)
            {
                result.Add(new List<int>(track));
                return;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (track.Contains(nums[i]))
                    continue;
                track.AddLast(nums[i]);
                Backtrack3(nums, track);
                track.RemoveLast();
            }
        }

        /// <summary>
        /// 47# 全排列Ⅱ.
        /// </summary>
        /// <param name="nums">可包含重复数字的序列.</param>
        /// <returns></returns>
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            List<IList<int>> ans = new List<IList<int>>();
            int len = nums.Length;
            Array.Sort(nums);
            Dfs(nums, len, 0, new bool[len], new LinkedList<int>(), ans);
            return ans;
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="track"></param>
        public void Dfs(int[] nums, int len, int depth, bool[] used, LinkedList<int> pre, List<IList<int>> ans)
        {
            if (len == depth)
            {
                ans.Add(new List<int>(pre));
                return;
            }
            for (int i = 0; i < len; i++)
            {
                if (used[i] || (i > 0 && nums[i] == nums[i - 1] && !used[i - 1]))
                {
                    continue;
                }
                pre.AddLast(nums[i]);
                used[i] = true;
                Dfs(nums, len, depth + 1, used, pre, ans);
                pre.RemoveLast();
                used[i] = false;
            }
        }

        /// <summary>
        /// 48# 旋转图像.
        /// </summary>
        /// <param name="matrix">n * n 二维矩阵.</param>
        public void Rotate(int[][] matrix)
        {
            #region new新数组的方式.
            //String result = String.Empty;

            //int[,] ints = new int[matrix.Length, matrix[0].Length];
            
            //int colIndex = 0;
            //for (int i = 0; i < matrix[0].Length; i++)
            //{
            //    for (int j = matrix.Length - 1; j > -1; j--)
            //    {
            //        ints[i, colIndex] = matrix[j][i];
            //        if (j == 0) { colIndex = 0; }
            //        else { colIndex++; }
            //    }
            //}

            //result = JsonConvert.SerializeObject(ints);

            //return result;
            #endregion

            #region 原数组处理.
            int temp = 0;

            int rowIndex = 0;
            for (int i = 0; i < matrix[0].Length; i++)
            {
                for (int j = matrix.Length - 1; j > matrix.Length - 2; j--)
                {
                    temp = matrix[i][rowIndex];

                    matrix[i][rowIndex] = matrix[j][i];

                    matrix[j][i] = temp;

                    if (j == matrix.Length - 1) { rowIndex = 0; }
                    else { rowIndex++; }
                }
            }

            #endregion
        }

        /// <summary>
        /// 51# N皇后.
        /// </summary>
        /// <param name="n">整数N个皇后.</param>
        /// <returns></returns>
        public IList<IList<string>> SolveNQueens(int n)
        {
            int[,] ans = new int[n, n];
            IList<IList<string>> printAns = new List<IList<string>>();
            SolveNQueens_BackTrack(printAns, ans, 0, n);
            return printAns;
        }

        /// <summary>
        /// 回溯且条件后置
        /// </summary>
        private void SolveNQueens_BackTrack(IList<IList<string>> printAns, int[,] ans, int i, int n)
        {
            if (i == n)
            {
                return;
            }

            //所有的可能在(0-N的位置上)分别填充1
            for (int j = 0; j < n; j++)
            {
                //判断能否填充
                if (NQueue(ans, i, j))
                {
                    ans[i, j] = 1;
                    SolveNQueens_BackTrack(printAns, ans, i + 1, n);
                }
                ans[i, j] = 0;
            }
            return;
        }

        /// <summary>
        /// N皇后判断规则
        /// </summary>
        private bool NQueue(int[,] ans, int i, int j)
        {
            //判断列元素
            for (int k = 0; k < i; k++)
            {
                if (ans[k, j] == 1) return false;
            }
            //判断左对角线元素
            for (int k = j, u = i; k >= 0 && u >= 0; k--, u--)
            {
                if (ans[u, k] == 1) return false;
            }
            //判断右对角线元素
            for (int k = j, u = i; k < ans.GetLength(0) && u >= 0; k++, u--)
            {
                if (ans[u, k] == 1) return false;
            }
            //判断行元素
            for (int k = 0; k < j; k++)
            {
                if (ans[i, k] == 1) return false;
            }
            return true;
        }

        /// <summary>
        /// 将结果转化为string形式
        /// </summary>
        private List<string> AnsToSting(int[,] ans, int n)
        {
            List<string> outStr = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string str = "";
                for (int j = 0; j < n; j++)
                {
                    str += ans[i, j] == 1 ? "Q" : ".";
                }
                outStr.Add(str);
            }
            return outStr;
        }
    }
}