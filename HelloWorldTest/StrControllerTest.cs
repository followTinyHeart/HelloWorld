using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorld.Controllers;

namespace HelloWorldTest
{
    [TestClass]
    public class StrControllerTest
    {
        /// <summary>
        /// 无重复字符的最长子串
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
    }
}
