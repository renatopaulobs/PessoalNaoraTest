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
    class TestCase006_Agendamento
    {
        public static void Agendamento  (IWebDriver driver, string nomeModificado)
        {          
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"dropdownMenu2\"]")));
            driver.FindElement(By.XPath("//*[@id=\"dropdownMenu2\"]")).Click();                  
            driver.FindElement(By.XPath("//*[@id=\"menu-minha-conta\"]")).Click();

            System.Threading.Thread.Sleep(4000);

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"full-name\"]")));
            driver.FindElement(By.XPath("//*[@id=\"full-name\"]")).Clear();
            driver.FindElement(By.XPath("//*[@id=\"full-name\"]")).SendKeys(nomeModificado);

            System.Threading.Thread.Sleep(3000);

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"btn-salvar-alteracoes\"]")));
            driver.FindElement(By.XPath("//*[@id=\"btn-salvar-alteracoes\"]")).Click();

            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"wrap\"]/minha-conta/simple-notifications/div/simple-notification/div/div/div[1]")));
                if (("Sucesso!") == driver.FindElement(By.XPath("//*[@id=\"wrap\"]/minha-conta/simple-notifications/div/simple-notification/div/div/div[1]")).Text)
                {
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
