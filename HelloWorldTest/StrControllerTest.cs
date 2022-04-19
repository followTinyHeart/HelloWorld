using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorld.Controllers;

namespace HelloWorldTest
{
    [TestClass]
    public class StrControllerTest
    {
        /// <summary>
        /// 3# 无重复字符的最长子串.
        /// </summary>
        [TestMethod]
        [TestCategory("字符串")]
        public void LengthOfLongestSubstring()
        {
            String str = "pwwkew";

            StrController strController = new StrController();
            int result = strController.LengthOfLongestSubstring(str);

            Console.WriteLine(result);
        }

        /// <summary>
        /// 5# 最长回文子串.
        /// </summary>
        /// <param name="s">字符串.</param>
        /// <returns></returns>
        [TestMethod]
        [TestCategory("字符串")]
        public void LongestPalindromeTest() 
        {
            String str = "cbbd";

            StrController strController = new StrController();
            String result = strController.LongestPalindrome(str);

            Console.WriteLine(result);
        }
    }
}
