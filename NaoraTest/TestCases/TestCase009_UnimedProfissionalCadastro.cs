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
    class TestCase009_UnimedProfissionalCadastro
    {
        public static string ProfissionalCadastro(IWebDriver driver, string tipo, string crm, string estado, string cpf, string email, string senha, string profissao, string especialidade)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                //Cadastro Pessoal
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div[2]/div/div[1]/div[2]/div[1]/div/div[1]/input")).SendKeys(crm);
                var selectElement = new SelectElement(driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div[2]/div/div[1]/div[2]/div[1]/div/div[2]/select")));
                selectElement.SelectByText(estado);

                driver.FindElement(By.XPath("//*[@id=\"cpf\"]")).SendKeys(cpf);
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div[2]/div/div[1]/div[2]/div[3]/button")).Click();

                System.Threading.Thread.Sleep(5000);
                    
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[3]/div/div/div[1]/input")).SendKeys(email);
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[3]/div/div/div[2]/input")).SendKeys(email);
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[3]/div/div/div[3]/input")).SendKeys(senha);
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[3]/div/div/div[4]/input")).SendKeys(senha);
                driver.FindElement(By.XPath("//*[@id=\"celular\"]")).SendKeys("087996562191");
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[3]/div/div/div[6]/label/input")).Click();
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[3]/div/div/div[7]/button")).Click();

                System.Threading.Thread.Sleep(4000);

                driver.Navigate().GoToUrl("https://unimedrecife.naora.com.br/AssinaturaPagamento/SucessoCadastro");
                driver.FindElement(By.XPath("//*[@id=\"logoutLink\"]")).Click();

                System.Threading.Thread.Sleep(2000);

                if (tipo == "bemFormado")
                {
                    driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div[2]/div/div[2]/div[2]/input")).SendKeys(email);
                    driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div[2]/div/div[2]/div[3]/input")).SendKeys(senha);
                    driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div[2]/div/div[2]/div[4]/button")).Click();

                    System.Threading.Thread.Sleep(2000);

                    driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[3]/form/div/div[1]/div[6]/div/div/div/div/input")).SendKeys(profissao);
                    driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[3]/form/div/div[1]/div[6]/div/div/div/div/input")).SendKeys(Keys.Enter);

                    driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[3]/form/div/div[1]/div[9]/div/div/ul/li/input")).Click();
                    driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[3]/form/div/div[1]/div[9]/div/div/ul/li/input")).SendKeys(especialidade);
                    driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[3]/form/div/div[1]/div[9]/div/div/ul/li/input")).SendKeys(Keys.Enter);

                    driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[3]/form/div/div[1]/div[11]/div/button")).Click();
                    System.Threading.Thread.Sleep(5000);

                    return "SUCESSO";
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
