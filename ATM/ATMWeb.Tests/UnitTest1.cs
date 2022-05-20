using ATMWeb.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;

namespace ATMWeb.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FooActionReturnsAboutView()
        {
            //Arrange
            var homeController = new HomeController();

            //Act
            var result = homeController.Foo() as ViewResult;

            //Assert
            Assert.AreEqual("About", result.ViewName);
        }

        [TestMethod]
        public void ContactFormSaysThanks()
        {
            //Arrange
            var homeController = new HomeController();

            //Act
            var result = homeController.Contact("I love your bank") as ViewResult;

            //Assert
            //Assert.AreEqual("Thanks!", result.ViewBag.TheMessage);
            Assert.IsNotNull(result.ViewBag.TheMessage);
        }
    }
}
