﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    public class TreeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}