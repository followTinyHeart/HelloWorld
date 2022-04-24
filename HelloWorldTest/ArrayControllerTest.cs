using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using HelloWorld.Controllers;

namespace HelloWorldTest
{
    /// <summary>
    /// 用于LeetCode题库的单元测试
    /// </summary>
    [TestClass]
    public class ArrayControllerTest
    {
        private ArrayController controller;
        public ArrayControllerTest() 
        {
            this.controller = new ArrayController();
        }

        /// <summary>
        /// 两数之和
        /// </summary>
        [TestCategory("数组")]
        [TestMethod]
        public void TwoSumTest()
        {
            //ArrayController controller = new ArrayController();

            int[] nums = { 2, 7, 11, 15 };
            int target = 9;

            int[] result = this.controller.TwoSum(nums, target);

            Console.WriteLine(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// 寻找两个有序数组中的中位数
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        [TestCategory("数组")]
        [TestMethod]
        public void FindMedianSortedArraysTest()
        {
            ArrayController controller = new ArrayController();

            int[] nums1 = { 1, 3 };
            int[] nums2 = { 2, 4 };

            double result = 0.0;

            result = controller.FindMedianSortedArrays(nums1, nums2);

            Console.WriteLine(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// 盛最多水的容器
        /// </summary>
        [TestCategory("数组")]
        [TestMethod]
        public void MaxAreaTest()
        {
            ArrayController controller = new ArrayController();

            int[] height = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };

            int result = 0;
            result = controller.MaxArea(height);

            Console.WriteLine(JsonConvert.SerializeObject(result));
        }


        /// <summary>
        /// 三数之和
        /// </summary>
        [TestMethod]
        [TestCategory("数组")]
        public void ThreeSum()
        {
            int[] nums = { -1, 0, 1, 2, -1, -4 };

            IList<IList<int>> result = new List<IList<int>>();

            ArrayController controller = new ArrayController();

            result = controller.ThreeSum(nums);

            Console.WriteLine(JsonConvert.SerializeObject(result));

        }


        /// <summary>
        /// 最接近的三数之和
        /// </summary>
        [TestMethod]
        [TestCategory("数组")]
        public void ThreeSumClosestTest()
        {
            int[] nums = { 13, 2, 0, -14, -20, 19, 8, -5, -13, -3, 20,
                15, 20, 5, 13, 14, -17, -7, 12, -6, 0,
                20, -19, -1, -15, -2, 8, -2, -9, 13, 0,
                -3, -18, -9, -9, -19, 17, -14, -19, -4, -16,
                2, 0, 9, 5, -7, -4, 20, 18, 9, 0, 12, -1, 10,
                -17, -11, 16, -13, -14, -3, 0, 2, -18, 2, 8, 20,
                -15, 3, -13, -12, -2, -19, 11, 11, -10, 1, 1, -10,
                -2, 12, 0, 17, -19, -7, 8, -19, -17, 5, -5, -10, 8,
                0, -12, 4, 19, 2, 0, 12, 14, -9, 15, 7, 0, -16, -5,
                16, -12, 0, 2, -16, 14, 18, 12, 13, 5, 0, 5, 6};
            int target = -59;
            int result = 0;

            ArrayController ArrayController = new ArrayController();

            result = ArrayController.ThreeSumClosest(nums, target);

            Console.WriteLine(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// 27#移除元素.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        [TestMethod]
        [TestCategory("数组")]
        public void RemoveElementTest() 
        {
            int[] nums = { 0, 1, 2, 2, 3, 0, 4, 2 };
            int nVal = 2;
            int result = 0;

            ArrayController arrayController = new ArrayController();
            result = arrayController.RemoveElement(nums, nVal);

            Console.WriteLine(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// 33# 搜索旋转排序数组.
        /// </summary>
        [TestMethod]
        [TestCategory("数组")]
        public void SearchTest()
        {
            int[] nums = { 4, 5, 6, 7, 0, 1, 2 };
            int target = 3;
            int result = 0;

            ArrayController arrayController = new ArrayController();
            result = arrayController.Search(nums, target);

            Console.WriteLine(result);
        }

        /// <summary>
        /// 34# 在排序数组中查找元素的第一个和最后一个位置.
        /// </summary>
        /// <param name="nums">按照升序排列的整数数组.</param>
        /// <param name="target">目标值 .</param>
        /// <returns></returns>
        [TestMethod]
        [TestCategory("数组")]
        public void SearchRangeTest() 
        {
            int[] nums = new int[] {  };
            int target = 0;
            int[] result = new int[nums.Length];

            ArrayController arrayController = new ArrayController();
            result = arrayController.SearchRange(nums, target);

            Console.WriteLine(String.Join(",", result));
        }

        /// <summary>
        /// 35# 搜索插入位置.
        /// </summary>
        /// <param name="nums">排序数组.</param>
        /// <param name="target">目标值.</param>
        /// <returns></returns>
        [TestMethod]
        [TestCategory("数组")]
        public void SearchInsertTest() 
        {
            int result = -1;
            int[] numx = new int[] { 1, 3, 5,6 };
            int target = 2;

            ArrayController arrayController = new ArrayController();
            result = arrayController.SearchInsert(numx, target);

            Console.WriteLine(result);
        }

        /// <summary>
        /// 36# 有效的数独.
        /// </summary>
        [TestMethod]
        [TestCategory("数组")]
        public void IsValidSudokuTest() 
        {
            bool result = false;

            char[][] chars = {
                new char[] { '8', '3', '.', '.', '7', '.', '.', '.', '.' },
                new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.'},
                new char[] {'.', '9', '8', '.', '.', '.', '.', '6', '.'},
                new char[] {'8', '.', '.', '.', '6', '.', '.', '.', '3'},
                new char[] {'4', '.', '.', '8', '.', '3', '.', '.', '1'},
                new char[] {'7', '.', '.', '.', '2', '.', '.', '.', '6'},
                new char[] {'.', '6', '.', '.', '.', '.', '2', '8', '.'},
                new char[] {'.', '.', '.', '4', '1', '9', '.', '.', '5'},
                new char[] {'.', '.', '.', '.', '8', '.', '.', '7', '9'}
                };

            ArrayController arrayController = new ArrayController();
            result = arrayController.IsValidSudoku(chars);

            Console.WriteLine(result); 
        }

        /// <summary>
        /// 39# 组合总和.
        /// </summary>
        /// <param name="candidates">无重复元素整数数组.</param>
        /// <param name="target">目标值.</param>
        /// <returns></returns>
        [TestMethod]
        [TestCategory("数组")]
        public void CombinationSumTest() 
        {
            IList<IList<int>> result = new List<IList<int>>();

            int[] candidates = new int[] { 2,3,6,7};
            int target = 7;

            ArrayController arrayController = new ArrayController();
            result = arrayController.CombinationSum(candidates, target);

            Console.WriteLine(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// 40# 组合总和Ⅱ.
        /// </summary>
        /// <param name="candidates">候选人编号集合.</param>
        /// <param name="target">目标数.</param>
        /// <returns></returns>
        [TestMethod]
        [TestCategory("数组")]
        public void CombinationSum2Test()
        {
            IList<IList<int>> result = new List<IList<int>>();

            int[] candidates = new int[] { 10,1,2,7,6,1,5};
            int target = 8;

            ArrayController arrayController = new ArrayController();
            result = arrayController.CombinationSum2(candidates, target);

            Console.WriteLine(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// 41# 缺失的第一个正数.
        /// </summary>
        /// <param name="nums">未排序的整数数组.</param>
        /// <returns></returns>
        [TestMethod]
        [TestCategory("数组")]
        public void FirstMissingPositiveTest() 
        {
            int result = 0;
            int[] nums = new int[] { 0,2,2,1,1,};

            ArrayController arrayController = new ArrayController();
            result =  arrayController.FirstMissingPositive(nums);

            Console.WriteLine(result);
        }

        /// <summary>
        /// 42# 接雨水.
        /// </summary>
        /// <param name="height">非负整数数组.</param>
        /// <returns></returns>
        [TestMethod]
        [TestCategory("数组")]
        public void TrapTest() 
        {
            int result = 0;
            int[] height = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };

            ArrayController arrayController = new ArrayController();
            result = arrayController.Trap(height);

            Console.WriteLine(result);
        }

        /// <summary>
        /// 45# 跳跃游戏Ⅱ.
        /// </summary>
        /// <param name="nums">非负整数数组.</param>
        /// <returns></returns>
        [TestMethod]
        [TestCategory("数组")]
        public void JumpTest() 
        {
            int result = 0;
            int[] nums = new int[] { 2, 3, 1, 1, 4 };

            //ArrayController arrayController = new ArrayController();
            result = this.controller.Jump(nums);

            Console.WriteLine(result);
        }

        /// <summary>
        /// 46# 全排列.
        /// </summary>
        /// <param name="nums">不含重复数字的数组.</param>
        [TestMethod]
        [TestCategory("数组")]
        public void PermuteTest() 
        {
            IList<IList<int>> result = new List<IList<int>>();
            int[] nums = new int[] { 1, 2, 3 };

            result = this.controller.Permute(nums);

            Console.WriteLine(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// 47# 全排列Ⅱ.
        /// </summary>
        /// <param name="nums">可包含重复数字的序列.</param>
        /// <returns></returns>
        [TestMethod]
        [TestCategory("数组")]
        public void AA() 
        {
            IList<IList<int>> result = new List<IList<int>>();
            int[] nums = new int[] { 1, 1, 2 };

            result = this.controller.PermuteUnique(nums);

            Console.WriteLine(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// 48# 旋转图像.
        /// </summary>
        /// <param name="matrix">n * n 二维矩阵.</param>
        [TestMethod]
        [TestCategory("数组")]
        public void RotateTest()
        {
            int[][] matrix ={
                                new int[] { 5,1,9,11 },
                                new int[] { 2,4,8,10 },
                                new int[] { 13,3,6,7 },
                                new int[] { 15,14,12,16 }
                            };
            
            this.controller.Rotate(matrix);

            Console.WriteLine(JsonConvert.SerializeObject(matrix));
        }

        public void SolveNQueensTest() 
        {
            IList<IList<String>> result = new List<IList<String>>();

            int n = 1;

            result = this.controller.SolveNQueens(n);

            Console.WriteLine(JsonConvert.SerializeObject(result));
        }
    }
}
