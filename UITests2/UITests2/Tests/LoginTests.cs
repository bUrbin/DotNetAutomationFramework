using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITests2.Pages;
using UITests2.Utilities;

namespace UITests2.Tests
{
    public class LoginTests
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;

        [SetUp]
        public void Setup()
        {
            _driver = DriverManager.GetDriver();
            _driver.Navigate().GoToUrl(Config.BaseUrl);
            _loginPage = new LoginPage(_driver);
            _loginPage.WaitForPageLoad();
        }

        [Test]
        public void SuccessfulLogin_WithValidCredentials()
        {
            _loginPage.Login(Config.ValidUsername, Config.ValidPassword);
            Assert.That(_driver.Url, Does.Contain("inventory.html"));
        }

        [Test]
        public void FailedLogin_WithInvalidPassword()
        {
            _loginPage.Login(Config.ValidUsername, "wrong_password");
            Assert.That(_loginPage.IsErrorMessageDisplayed(), Is.True);
            Assert.That(_loginPage.GetErrorMessageText(), Does.Contain("Username and password do not match"));
        }

        [TearDown]
        public void TearDown()
        {
            DriverManager.QuitDriver();
        }
    }
}
