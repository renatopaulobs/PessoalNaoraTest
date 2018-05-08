using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using AvilaCore;
using System.IO;
using System.Linq;
using OpenQA.Selenium.Interactions;
using log4net;

namespace NaoraTeste.Util
{
    class Acesso
    {
        public static void AcessoNaora(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"login-email\"]")));
            driver.FindElement(By.XPath("//*[@id=\"login-email\"]")).SendKeys("teste@teste.com");
            driver.FindElement(By.XPath("//*[@id=\"login-senha\"]")).SendKeys("123456");
            driver.FindElement(By.XPath("//*[@id=\"btn-login\"]")).Click();
            System.Threading.Thread.Sleep(4000);

        }
    }
}
