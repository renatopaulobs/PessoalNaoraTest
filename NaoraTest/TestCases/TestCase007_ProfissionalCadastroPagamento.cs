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
    class TestCase007_ProfissionalCadastroPagamento
    {
        public static string ProfissionalCadastroPagamento(IWebDriver driver, string tipo, string nome, string numeroCartao, string cep, string rua, string bairro, string numero, string cidade, string estado, string complemento)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                driver.FindElement(By.XPath("//*[@id=\"Email\"]")).SendKeys("teste@teste.com");
                driver.FindElement(By.XPath("//*[@id=\"Password\"]")).SendKeys("123456");
                driver.FindElement(By.XPath("//*[@id=\"login-box\"]/div[2]/button")).Click();
                driver.FindElement(By.XPath("//*[@id=\"paymentMethod_creditCard_holder_name\"]")).Clear();
                driver.FindElement(By.XPath("//*[@id=\"paymentMethod_creditCard_holder_name\"]")).SendKeys(nome);
                driver.FindElement(By.XPath("//*[@id=\"card\"]/div/input")).Clear();

                driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[3]/div/form/div/div[6]/div/div/div/input[1]")).SendKeys(numeroCartao);

                if (tipo == "malFormado")
                {
                    driver.FindElement(By.XPath("//*[@id=\"logoutLink\"]")).Click();
                    return "SUCESSO";
                }

                driver.FindElement(By.XPath("//*[@id=\"sender_address_postalCode\"]")).Clear();
                driver.FindElement(By.XPath("//*[@id=\"sender_address_postalCode\"]")).SendKeys(cep);
                driver.FindElement(By.XPath("//*[@id=\"sender_address_street\"]")).Clear();
                driver.FindElement(By.XPath("//*[@id=\"sender_address_street\"]")).SendKeys(rua);
                driver.FindElement(By.XPath("//*[@id=\"sender_address_district\"]")).Clear();
                driver.FindElement(By.XPath("//*[@id=\"sender_address_district\"]")).SendKeys(bairro);
                driver.FindElement(By.XPath("//*[@id=\"sender_address_number\"]")).Clear();
                driver.FindElement(By.XPath("//*[@id=\"sender_address_number\"]")).SendKeys(numero);
                driver.FindElement(By.XPath("//*[@id=\"sender_address_city\"]")).Clear();
                driver.FindElement(By.XPath("//*[@id=\"sender_address_city\"]")).SendKeys(cidade);

                var selectElement = new SelectElement(driver.FindElement(By.XPath("//*[@id=\"sender_address_state\"]")));
                selectElement.SelectByText("PE");

                driver.FindElement(By.XPath("//*[@id=\"sender_address_complement\"]")).Clear();
                driver.FindElement(By.XPath("//*[@id=\"sender_address_complement\"]")).SendKeys(complemento);
                driver.FindElement(By.XPath("//*[@id=\"form-cadastro-assinatura\"]/div/div[14]/a")).Click();

                System.Threading.Thread.Sleep(9000);

                try
                {
                    driver.FindElement(By.XPath("//*[@id=\"Titulo_chosen\"]/a")).Click();
                    driver.FindElement(By.XPath("//*[@id=\"logoutLink\"]")).Click();
                    return "SUCESSO";
                }
                catch(Exception ex)
                {
                    driver.FindElement(By.XPath("//*[@id=\"logoutLink\"]")).Click();
                    Console.WriteLine(ex);
                    return "FALHA";
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return "FALHA";
            }
        }
    }
}
