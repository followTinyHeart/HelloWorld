using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HelloWorld.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HelloWorldTest
{
    [TestClass]
    public class UnitTest1
    {
        private readonly ILogger<HomeController> _logger;

        [TestMethod]
        [TestCategory("����")]
        public void TestMethod1()
        {
            HomeController controller = new HomeController(_logger);

            JsonResult result = controller.GetGuid();

            Console.WriteLine(result.Value);
        }
    }
}
