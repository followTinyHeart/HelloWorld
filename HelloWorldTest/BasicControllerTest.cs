using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using HelloWorld.Controllers;

namespace HelloWorldTest
{
    [TestClass]
    public class BasicControllerTest
    {
        private BasicController controller;
        public BasicControllerTest() 
        {
            this.controller = new BasicController();
        }

        /// <summary>
        /// Is C#7.0.
        /// </summary>
        [TestMethod]
        [TestCategory("语法")]
        public void Grammar_Is_Test() 
        {
            this.controller.Grammar_Is();
        }
    }
}
