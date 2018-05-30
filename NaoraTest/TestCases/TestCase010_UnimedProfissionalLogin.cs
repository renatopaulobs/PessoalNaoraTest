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

namespace NaoraTest.TestCases
{
    class TestCase010_UnimedProfissionalLogin
    {
        public static string ProfissionalLogin(IWebDriver driver, string email, string senha)
        {
            try
            {
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div[2]/div/div[2]/div[2]/input")).SendKeys(email);
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div[2]/div/div[2]/div[3]/input")).SendKeys(senha);
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div[2]/div/div[2]/div[4]/button")).Click();
                System.Threading.Thread.Sleep(2000);

                return "SUCESSO";
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return "FALHA";
            }
        }
    }
}
