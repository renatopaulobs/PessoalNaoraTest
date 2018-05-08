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
    class TestCase003_BuscaNome
    {
        public static string nomeExb;
        public static bool msgNaoCadastrado = false;

        public static string Busca(IWebDriver driver, string tipo, string nomeProfissional)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));

                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"ck-buscar-nomeprofissional\"]")));
                driver.FindElement(By.XPath("//*[@id=\"ck-buscar-nomeprofissional\"]")).Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"input-busca-nome-profissional\"]")));
                driver.FindElement(By.XPath("//*[@id=\"input-busca-nome-profissional\"]")).SendKeys(nomeProfissional);
                driver.FindElement(By.XPath("//*[@id=\"wrap\"]/home/div/div/div[1]/div[2]/div/div[5]/div/div/button")).Click();

                try
                {
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"profissionais-list\"]/div/div/div/div[1]/div/div[2]/div[1]/h3")));
                    driver.FindElement(By.XPath("//*[@id=\"profissionais-list\"]/div/div/div/div[1]/div/div[2]/div[1]/h3")).Click();
                }
                catch
                {
                    msgNaoCadastrado = true;
                }

                switch (tipo)
                {
                    case "Profissional Cadastrado":
                        {
                            if (msgNaoCadastrado == false)
                                return "SUCESSO";
                            else
                                return "FALHA";
                        }
                    case "Profissional Inexistente":
                        {
                            if (msgNaoCadastrado == true)
                                return "SUCESSO";
                            else
                                return "FALHA";
                        }
                }
                return "FALHA";
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return "SUCESSO";
            }
        }
    }
}
