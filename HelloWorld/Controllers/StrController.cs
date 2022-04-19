using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorld.Controllers
{
    public class StrController  : Controller
    {
        /// <summary>
        /// #3. 无重复字符的最长子串.
        /// </summary>
        /// <param name="s">字符串.</param>
        /// <returns></returns>
        public int LengthOfLongestSubstring(String s)
        {
            if (s.Length < 2) return s.Length;

            string r = "";
            int R, num;                                 //定义右指针，存储最大长度。
            R = num = 0;
            while (R < s.Length)                        //滑动区间
            {
                if (!r.Contains(s[R]))                  //区间内没有相同值才能右移指针
                {
                    r = r + s[R];
                    R++;
                }
                else
                {
                    r = r.Substring(1, r.Length - 1);   //左边向右移一个，相当于删除第一个值
                }

                num = Math.Max(r.Length, num);
            }

            return num;
        }

        /// <summary>
        /// 5# 最长回文子串.
        /// </summary>
        /// <param name="s">字符串.</param>
        /// <returns></returns>
        public string LongestPalindrome(string s)
        {
            int strLen = s.Length;
            if (strLen < 2)
                return s;
            for (int i = strLen; i > 1; i--)
            {
                for (int j = 0; j + i <= strLen; j++)
                {
                    if (IsPalindrome(s.Substring(j, i)))
                        return s.Substring(j, i);
                }
            }
            return s[0].ToString();
            bool IsPalindrome(string text)
            {
                int len = text.Length;
                int halfLen = len / 2;
                for (int k = 0; k < halfLen; k++)
                {
                    if (text[k] != text[len - 1 - k])
                    {
                        return false;
                    }
                }
                return true;

            }
        }
    }
}