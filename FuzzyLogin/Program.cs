using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyLogin
{
    class Program
    {
          
        private static Random random = new Random();
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://automation.jameshearn.com/my-account/");

            IWebElement username = driver.FindElement(By.Id("username"));
            IWebElement password = driver.FindElement(By.Id("password"));
            IWebElement loginButton = driver.FindElement(By.Name("login"));
            username.SendKeys(RandomString(10));
            password.SendKeys(RandomString(10));
            loginButton.Click();

            Assert.That(driver.PageSource, Does.Contain("ERROR: Invalid username."));

            driver.Quit();
        }
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
