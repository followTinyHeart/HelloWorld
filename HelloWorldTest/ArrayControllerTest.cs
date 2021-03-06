﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCodeItemBank.Controllers;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LeetCodeItemBank.Tests
{
    /// <summary>
    /// 用于LeetCode题库的单元测试
    /// </summary>
    [TestClass]
    public class ArrayControllerTest
    {
        /// <summary>
        /// 两数之和
        /// </summary>
        [TestCategory("数组")]
        [TestMethod]
        public void TwoSumTest()
        {
            ArrayController controller = new ArrayController();

            int[] nums = { 2, 7, 11, 15 };
            int target = 9;

            int[] result = controller.TwoSum(nums, target);

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
    }
}
