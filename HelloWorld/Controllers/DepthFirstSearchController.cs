using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    /// <summary>
    /// 深度优先搜索.
    /// </summary>
    public class DepthFirstSearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
