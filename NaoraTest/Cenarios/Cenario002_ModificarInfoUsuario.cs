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
using NaoraTeste.Util;

namespace NaoraTeste.Cenarios
{
    [TestClass]
    public class Cenario002_ModificarInfoUsuario
    {
        int numLinhas, numColunas, contTesteSucesso = 0, contTesteFalha = 0;
        string alteracao, resultadoTeste, tipo, plano, especialidade;

        //---------------------------------------------------- link para fazer os testes em homologacao
        string BaseUrl = "https://naorahomolog.azurewebsites.net/login";     

        [TestMethod]
        public int ModificaUsuario(string caminho)
        {
            int qtdFalhas;
            var options = new FirefoxOptions();
            options.AddArgument("headless");

            IWebDriver driver = new FirefoxDriver();
            numLinhas = IntegracaoExcel.NumLinhas(caminho, "ModificaUsuario");
            DocumentoPDF.EscrevePDF(caminho, "Edição de Usuário\n" + "Total de testes - " + (numLinhas - 1).ToString());

            driver.Navigate().GoToUrl(BaseUrl);

            for (int i = 2; i <= numLinhas; i++)
            {
                driver.Navigate().GoToUrl(BaseUrl);

                tipo = IntegracaoExcel.LeTabela(caminho, "ModificaUsuario", i, 1);
                alteracao = IntegracaoExcel.LeTabela(caminho, "ModificaUsuario", i, 2);
                resultadoTeste = TestCase005_EditarPaciente.EditarPerfil(driver, tipo, alteracao);

                DocumentoPDF.PrintScreen(caminho, driver, "ModificaUsuario", i);
                IntegracaoExcel.EscreveTabela(caminho, "ModificaUsuario", i, 3, resultadoTeste);

                if (resultadoTeste == "SUCESSO")
                {
                    contTesteSucesso++;
                }
                else
                {
                    contTesteFalha++;
                    DocumentoPDF.AdicionaImagem(caminho, @"Images\Screenshots\SeleniumTestingScreenshotModificaUsuario" + i.ToString());
                    DocumentoPDF.EscreveFalha(caminho, tipo + ": " + especialidade);
                }
            }
            IntegracaoExcel.FechaArquivo(caminho, "ModificaUsuario");
            DocumentoPDF.EscreveResultado(caminho, "Passed: " + (numLinhas - 1 - contTesteFalha).ToString() + " / Failed: " + contTesteFalha.ToString());

            qtdFalhas = contTesteFalha;
            contTesteFalha = 0;
            contTesteSucesso = 0;
            driver.Close();

            return qtdFalhas;
        }     
    }
}
