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
    class TestCase011_ProfissionalCadastroLocal
    {
        public static string ProfissionalLocal(IWebDriver driver, string nome, string telefone, string cep, string numero)
        {
            try
            {
                driver.FindElement(By.XPath("//*[@id=\"Nome\"]")).SendKeys(nome);
                driver.FindElement(By.XPath("//*[@id=\"Telefone\"]")).SendKeys(telefone);
                driver.FindElement(By.XPath("//*[@id=\"Endereco_Cep\"]")).SendKeys(cep);
                driver.FindElement(By.XPath("//*[@id=\"Endereco_Numero\"]")).SendKeys(numero);
                //driver.FindElement(By.XPath("//*[@id=\"Salvar\"]")).Click();
                
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
