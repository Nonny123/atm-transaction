using ATMWeb.Controllers;
using ATMWeb.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;

namespace ATMWeb.Tests
{
    [TestClass]
    public class UnitTest1
    {
        //unit test
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

        //unit test
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

        //Integration test with mocked dependecy(fakedbset)
        //can automated with rhinomocks, moqteam
        [TestMethod]
        public void BalanceIsCorrectAfterDeposit()
        {
            //Arrange
            var fakeDb = new FakeApplicationDbContext();
            fakeDb.CheckingAccounts = new FakeDbSet<CheckingAccount>();
            var checkingAccount = new CheckingAccount { Id = 1, AccountNumber = 
                "000123TEST", Balance = 0 };
            fakeDb.CheckingAccounts.Add(checkingAccount);
            fakeDb.Transactions = new FakeDbSet<Transaction>();
            var transactionController = new TransactionController(fakeDb);

            //Act
            transactionController.Deposit(new Transaction
            {
                CheckingAccountId = 1,
                Amount = 25
            });

            //Assert
            Assert.AreEqual(25, checkingAccount.Balance);
        }


    }
}
