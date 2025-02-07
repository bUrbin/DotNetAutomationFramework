using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITests2.Utilities
{
    public static class DriverManager
    {
        private static IWebDriver? _driver;
        private static readonly object _lock = new object();

        public static IWebDriver GetDriver()
        {
            lock (_lock)
            {
                if (_driver == null)
                {
                    _driver = new ChromeDriver();
                    _driver.Manage().Window.Maximize();
                }
                return _driver;
            }
        }

        public static void QuitDriver()
        {
            lock (_lock)
            {
                if (_driver != null)
                {
                    _driver.Quit();
                    _driver = null;
                }
            }
        }
    }
}
