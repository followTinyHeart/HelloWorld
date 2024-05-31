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

        [TestMethod]
        [TestCategory("常用")]
        public void TestMethod2()
        {

        }

        public void AddTest() { }

        public void FromMac() { }

        public void CommitTest()
        {
            test3 test3 = new test3();
            test3.Name = "";
            test3.Name2 = "";

            test2 test2 = new test2();
            test2.Name = "";
            test2.Name2 = "";
        }
    }

    public class UserInfo
    {
        public String Guid { get; set; }
        public String Name { get; set; }
        public int Age { get; set; }
    }

    public class test1
    {
        public String Name { get; set; }

        public String Name2 { get; set; }
    }


    public class test2 : test1
    {
        public String Name3 { get; set; }

        public String Name4 { get; set; }
    }

    public class test3 : test2
    {
        public String Name5 { get; set; }

        public String Name6 { get; set; }
    }

    public interface iTest 
    {
        String name { get; set; }
    }

    public interface iTest2 
    {
        String NameT { get; set; }
    }

    public class iTest1 : iTest,iTest2
    {
        public string name { get; set; }

        public string NameT { get; set; }
    }
}
