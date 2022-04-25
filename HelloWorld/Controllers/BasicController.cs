using Microsoft.AspNetCore.Mvc;
using System;

namespace HelloWorld.Controllers
{
    /// <summary>
    /// 语法测试.
    /// </summary>
    public class BasicController : Controller
    {
        /// <summary>
        /// Is C#7.0.
        /// </summary>
        public void Grammar_Is()
        {
            int? a = 42;
            if (a is int valueOfA)
            {
                System.Console.WriteLine($"a is {valueOfA}");
            }
            else
            {
                System.Console.WriteLine($"a does not have a value");
            }
        }
    }
}
