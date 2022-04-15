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
        /// <param name="str"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring(String str)
        {
            String result = "";
            String strRepeat = "";

            for (int i = 0; i < str.Length; i++)
            {
                if (result.Contains(str[i]))
                {
                    
                }
                else
                {
                    result += str[i];
                }
            }

            return result.Length;
        }
    }
}