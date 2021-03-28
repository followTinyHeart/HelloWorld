using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HelloWorld.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HelloWorldTest
{
    [TestClass]
    public class HomeControllerTest
    {
        private readonly ILogger<HomeController> _logger;


        [TestMethod]
        [TestCategory("常用")]
        public void TestMethod1()
        {
            HomeController controller = new HomeController(_logger);

            JsonResult result = controller.GetGuid();

            Console.WriteLine(result.Value);
        }

        public void AddTest() { }


        public void FromMac() { }
    }
}
