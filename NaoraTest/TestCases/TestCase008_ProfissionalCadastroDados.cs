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
    class TestCase008_ProfissionalCadastroDados
    {
        public static string ProfissionalCadastroDados(IWebDriver driver, string tipo, string titulo, string nome, string nomePagina, string cpf, string sexo, string profissao, string experiencia)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                driver.FindElement(By.XPath("//*[@id=\"Email\"]")).SendKeys("teste@teste.com");
                driver.FindElement(By.XPath("//*[@id=\"Password\"]")).SendKeys("123456");
                driver.FindElement(By.XPath("//*[@id=\"login-box\"]/div[2]/button")).Click();

                System.Threading.Thread.Sleep(2000);

                driver.FindElement(By.XPath("//*[@id=\"Titulo_chosen\"]/a")).Click();
                driver.FindElement(By.XPath("//*[@id=\"Titulo_chosen\"]/div/div/input")).SendKeys("Dr.");
                driver.FindElement(By.XPath("//*[@id=\"Titulo_chosen\"]/div/div/input")).SendKeys(Keys.Enter);

                driver.FindElement(By.XPath("//*[@id=\"Nome\"]")).SendKeys(nome);
                //driver.FindElement(By.XPath("//*[@id=\"NomeUsuario\"]")).SendKeys(nomePagina);
                driver.FindElement(By.XPath("//*[@id=\"Cpf\"]")).SendKeys(cpf);
                driver.FindElement(By.XPath("//*[@id=\"Sexo_chosen\"]/a")).Click();
                driver.FindElement(By.XPath("//*[@id=\"Sexo_chosen\"]/div/div/input")).SendKeys("Masculino");
                driver.FindElement(By.XPath("//*[@id=\"Sexo_chosen\"]/div/div/input")).SendKeys(Keys.Enter);

                driver.FindElement(By.XPath("//*[@id=\"Profissoes_chosen\"]/a")).Click();
                driver.FindElement(By.XPath("//*[@id=\"Profissoes_chosen\"]/div/div/input")).SendKeys("Dentista");
                driver.FindElement(By.XPath("//*[@id=\"Profissoes_chosen\"]/div/div/input")).SendKeys(Keys.Enter);

                driver.FindElement(By.XPath("//*[@id=\"Biografia\"]")).SendKeys(experiencia);

                return "SUCESSO";
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return "FALHA";
            }
        }
    }
}
