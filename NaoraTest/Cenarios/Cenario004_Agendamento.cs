using System;
using System.IO;
using System.Text;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.CSharp;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using AvilaCore;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection;
using OpenQA.Selenium.Support.UI;
using NaoraTeste.perfilUsuario;
using NaoraTest.perfilUsuario;
using log4net.Config;
using log4net;

namespace NaoraTest.Cenarios
{
    [TestClass]
    public class Cenario004_Agendamento
    {
        string BaseUrl = "https://naora.com.br/home";

        [TestMethod]
        public void Agendamento_004(string caminho)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(BaseUrl);
            
            //TestCase002_Login.Login(driver, caminho, this.lines[0], this.lines[1], this.lines[2]);
            TestCase003_BuscaNome.Busca(driver, "Dr. Naora");

            driver.Close();
        }
    }
}
