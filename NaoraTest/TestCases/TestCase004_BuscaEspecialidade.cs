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

namespace NaoraTest.perfilUsuario
{
    class TestCase004_BuscaEspecialidade
    {
        public static string msg = "msg";

        public static string Busca(IWebDriver driver, string tipo, string tipoConvenio)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
                driver.FindElement(By.XPath("//*[@id=\"input-busca-plano\"]/div/input")).SendKeys(tipoConvenio);
                driver.FindElement(By.XPath("//*[@id=\"wrap\"]/home/div/div/div[1]/div[2]/div/div[5]/div/div/button")).Click();
                System.Threading.Thread.Sleep(7000);

                try
                {
                    msg = driver.FindElement(By.XPath("//*[@id=\"wrap\"]/busca/div/div[1]/div/div[3]")).Text;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);

                    if (tipo == "semCadastro")
                    {
                        return "SUCESSO";
                    }
                    else
                    {
                        return "FALHA";
                    }
                }
              
                return "SUCESSO";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return "FALHA";
            }
        }
    }
}
