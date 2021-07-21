using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    /// <summary>
    /// 数学.
    /// </summary>
    public class MathematicsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
