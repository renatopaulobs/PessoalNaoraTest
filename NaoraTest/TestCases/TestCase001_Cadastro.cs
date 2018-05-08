using System;
using System.Text;
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
    [TestClass]
    public class TestCase001_Cadastro
    {
        [TestMethod]
        public static string Cadastrar(IWebDriver driver, string tipo, string nome, string email, string senha, string dataNascimento, string celular, string plano, Enum sexo)
        {
            //Mapeamento de elementos da pagina e preenchimento de informações de cadastro.
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                System.Threading.Thread.Sleep(1000);

                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"full-name\"]")));
                driver.FindElement(By.XPath("//*[@id=\"full-name\"]")).Clear();
                driver.FindElement(By.XPath("//*[@id=\"full-name\"]")).SendKeys(nome);
                driver.FindElement(By.Id("email")).Clear();
                driver.FindElement(By.Id("email")).SendKeys(email);
                driver.FindElement(By.Id("email-confirm")).Clear();
                driver.FindElement(By.Id("email-confirm")).SendKeys(email);
                driver.FindElement(By.Id("password")).Clear();
                driver.FindElement(By.Id("password")).SendKeys(senha);
                driver.FindElement(By.Id("password-confirm")).Clear();
                driver.FindElement(By.Id("password-confirm")).SendKeys(senha);
                driver.FindElement(By.Id("birthday")).Clear();
                driver.FindElement(By.Id("birthday")).SendKeys(dataNascimento);

                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"celularNovo\"]")));
                driver.FindElement(By.XPath("//*[@id=\"celularNovo\"]")).Clear();
                driver.FindElement(By.XPath("//*[@id=\"celularNovo\"]")).SendKeys(celular);
                driver.FindElement(By.Id("rbmasculino")).Click();
                driver.FindElement(By.Id("rbParticular")).Click();

                if (tipo != "Acordo")
                    driver.FindElement(By.CssSelector("input[value='termoUso'")).Click();

                if (tipo == "Plano")
                {
                    driver.FindElement(By.XPath("//*[@id=\"rbPlanoSaude\"]")).Click();

                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"planoSaude\"]")));
                    driver.FindElement(By.XPath("//*[@id=\"planoSaude\"]")).SendKeys(plano);
                    driver.FindElement(By.XPath("//*[@id=\"planoSaude\"]")).SendKeys(OpenQA.Selenium.Keys.Enter);
                }

                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"btn-criar-conta\"]")));
                driver.FindElement(By.XPath("//*[@id=\"btn-criar-conta\"]")).Click();

                System.Threading.Thread.Sleep(9000);

                switch (tipo)
                {
                    case "Nome":
                        {
                            try
                            {
                                driver.FindElement(By.XPath("//*[@id=\"wrap\"]/confirmar-conta/div/div/div[2]/div/div[1]/div/p[1]"));
                                return "FALHA";
                            }
                            catch
                            {
                                return "SUCESSO";
                            }
                        }
                    case "Email":
                        {
                            try
                            {
                                driver.FindElement(By.XPath("//*[@id=\"wrap\"]/confirmar-conta/div/div/div[2]/div/div[1]/div/p[1]"));
                                return "FALHA";
                            }
                            catch
                            {
                                return "SUCESSO";
                            }
                        }
                    case "Senha":
                        {
                            try
                            {
                                driver.FindElement(By.XPath("//*[@id=\"wrap\"]/confirmar-conta/div/div/div[2]/div/div[1]/div/p[1]"));
                                return "FALHA";
                            }
                            catch
                            {
                                return "SUCESSO";
                            }
                        }
                    case "Data":
                        {
                            try
                            {
                                driver.FindElement(By.XPath("//*[@id=\"wrap\"]/confirmar-conta/div/div/div[2]/div/div[1]/div/p[1]"));
                                return "FALHA";
                            }
                            catch
                            {
                                return "SUCESSO";
                            }
                        }
                    case "Celular":
                        {
                            try
                            {
                                driver.FindElement(By.XPath("//*[@id=\"wrap\"]/confirmar-conta/div/div/div[2]/div/div[1]/div/p[1]"));
                                return "FALHA";
                            }
                            catch
                            {
                                return "SUCESSO";
                            }
                        }
                    case "Sexo":
                        {
                            try
                            {
                                driver.FindElement(By.XPath("//*[@id=\"wrap\"]/confirmar-conta/div/div/div[2]/div/div[1]/div/p[1]"));
                                return "FALHA";
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                                return "SUCESSO";
                            }
                        }
                    case "Plano":
                        {
                            try
                            {
                                driver.FindElement(By.XPath("//*[@id=\"wrap\"]/confirmar-conta/div/div/div[2]/div/div[1]/div/p[1]"));
                                return "SUCESSO";
                            }
                            catch
                            {
                                return "FALHA";
                            }
                        }
                    case "Acordo":
                        {
                            try
                            {
                                driver.FindElement(By.XPath("//*[@id=\"wrap\"]/confirmar-conta/div/div/div[2]/div/div[1]/div/p[1]"));
                                return "FALHA";
                            }
                            catch
                            {
                                return "SUCESSO";
                            }
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