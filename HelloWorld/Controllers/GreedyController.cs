﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    /// <summary>
    /// 贪心算法.
    /// 贪心算法（又称贪婪算法）是指，在对问题求解时，总是做出在当前看来是最好的选择，就能得到问题的答案。贪心算法需要充分挖掘题目中条件，没有固定的模式，解决有贪心算法需要一定的直觉和经验。
    /// 贪心算法不是对所有问题都能得到整体最优解。
    /// 能使用贪心算法解决的问题具有「贪心选择性质」。
    /// 「贪心选择性质」严格意义上需要数学证明。
    /// 能使用贪心算法解决的问题必须具备「无后效性」，即某个状态以前的过程不会影响以后的状态，只与当前状态有关
    /// </summary>
    public class GreedyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
