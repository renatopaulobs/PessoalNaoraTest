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
    class TestCase012_ProfissionalHorariosCadastro
    {
        public static string ProfissionalHorarios(IWebDriver driver, string tipo, string turno, string recorrente)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);

                //Agendamento de horarios
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[1]/div[1]/div[2]/div/ul/li[2]/div/h3/a/i")).Click();
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[1]/div[1]/div[2]/div/ul/li[2]/a/i")).Click();
                System.Threading.Thread.Sleep(3000);

                //Selecao de Dias
                //Segunda
                driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/div/div[1]/ul/li[2]")).Click();
                System.Threading.Thread.Sleep(3000);
                driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/div/div[2]/div[2]/div[2]/div/div[1]/div/div/label/span[2]")).Click();
                driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/div/div[2]/div[2]/div[3]/button")).Click();

                System.Threading.Thread.Sleep(3000);

                //Terca
                driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/div/div[1]/ul/li[3]")).Click();
                System.Threading.Thread.Sleep(3000);
                driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/div/div[2]/div[3]/div[2]/div/div[1]/div/div/label/span[2]")).Click();
                driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/div/div[2]/div[3]/div[3]/button")).Click();

                System.Threading.Thread.Sleep(3000);

                //Quarta
                driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/div/div[1]/ul/li[4]")).Click();
                System.Threading.Thread.Sleep(3000);
                driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/div/div[2]/div[4]/div[2]/div/div[1]/div/div/label/span[2]")).Click();
                driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/div/div[2]/div[4]/div[3]/button")).Click();

                System.Threading.Thread.Sleep(3000);

                //Quinta
                driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/div/div[1]/ul/li[5]")).Click();
                System.Threading.Thread.Sleep(3000);
                driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/div/div[2]/div[5]/div[2]/div/div[1]/div/div/label/span[2]")).Click();
                driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/div/div[2]/div[5]/div[3]/button")).Click();

                System.Threading.Thread.Sleep(3000);

                //Sexta
                driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/div/div[1]/ul/li[6]")).Click();
                System.Threading.Thread.Sleep(3000);
                driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/div/div[2]/div[6]/div[2]/div/div[1]/div/div/label/span[2]")).Click();
                driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/div/div[2]/div[6]/div[3]/button")).Click();

                System.Threading.Thread.Sleep(3000);

                //Sabado
                driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/div/div[1]/ul/li[7]")).Click();
                System.Threading.Thread.Sleep(3000);
                driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/div/div[2]/div[7]/div[2]/div/div[1]/div/div/label/span[2]")).Click();
                driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/div/div[2]/div[7]/div[3]/button")).Click();

                System.Threading.Thread.Sleep(3000);
                driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[1]/button")).Click();

                System.Threading.Thread.Sleep(5000);

                return "SUCESSO";
            }

            catch(Exception ex)
            {
                Console.Write(ex);
                return "FALHA";
            }
            
        }
    }
}
