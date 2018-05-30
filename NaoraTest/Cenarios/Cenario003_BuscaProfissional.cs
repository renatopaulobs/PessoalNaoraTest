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
using NaoraTeste.Util;
using NaoraTest.perfilUsuario;
using log4net.Config;
using log4net;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.CSharp.RuntimeBinder;
using System.Runtime.InteropServices;

namespace NaoraTeste.Cenarios
{
    [TestClass]
    public class Cenario003_BuscaProfissional
    {
        string BuscaUrl = "https://naorahomolog.azurewebsites.net/home";

        enum sexo { Feminino = 0, Masculino = 1 };

        int numLinhas, numColunas, contTesteSucesso = 0, contTesteFalha = 0;
        string nome, email, senha, dataNascimento, celular, resultadoTeste, tipo, plano, especialidade;

        SqlConnectionStringBuilder connStr = new SqlConnectionStringBuilder();

        [TestMethod]
        public int BuscaNome(string caminho)
        {
            int qtdFalhas;

            var options = new FirefoxOptions();
            options.AddArgument("headless");

            IWebDriver driver = new FirefoxDriver();

            numLinhas = IntegracaoExcel.NumLinhas(caminho, "BuscaNome");
            DocumentoPDF.EscrevePDF(caminho, "Busca por Nome\n" + "Total de testes - " + (numLinhas - 1).ToString());

            for (int i = 2; i <= numLinhas; i++)
            {
                driver.Navigate().GoToUrl(BuscaUrl);

                tipo = IntegracaoExcel.LeTabela(caminho, "BuscaNome", i, 1);
                nome = IntegracaoExcel.LeTabela(caminho, "BuscaNome", i, 2);
                
                resultadoTeste = TestCase003_BuscaNome.Busca(driver, tipo, nome);

                DocumentoPDF.PrintScreen(caminho, driver, "BuscaNome", i);
                IntegracaoExcel.EscreveTabela(caminho, "BuscaNome", i, 3, resultadoTeste);

                if (resultadoTeste == "SUCESSO")
                {
                    contTesteSucesso++;
                }
                else
                {
                    contTesteFalha++;
                    DocumentoPDF.AdicionaImagem(caminho, @"Images\Screenshots\SeleniumTestingScreenshotBuscaNome" + i.ToString());
                    DocumentoPDF.EscreveFalha(caminho, tipo + ": " + nome);
                }
            }
            IntegracaoExcel.FechaArquivo(caminho, "BuscaNome");
            DocumentoPDF.EscreveResultado(caminho, "Passed: " + (numLinhas - 1 - contTesteFalha).ToString() + " / Failed: " + contTesteFalha.ToString());

            qtdFalhas = contTesteFalha;
            contTesteFalha = 0;
            contTesteSucesso = 0;

            driver.Close();

            return qtdFalhas;
        }

        [TestMethod]
        public int BuscaEspecialidade(string caminho)
        {
            int qtdFalhas;
            var options = new FirefoxOptions();
            options.AddArgument("headless");

            IWebDriver driver = new FirefoxDriver();

            numLinhas = IntegracaoExcel.NumLinhas(caminho, "BuscaEspecialidade");
            DocumentoPDF.EscrevePDF(caminho, "Busca por Especialidade\n" + "Total de testes - " + (numLinhas - 1).ToString());

            for (int i = 2; i <= numLinhas; i++)
            {
                driver.Navigate().GoToUrl(BuscaUrl);

                tipo = IntegracaoExcel.LeTabela(caminho, "BuscaEspecialidade", i, 1);
                especialidade = IntegracaoExcel.LeTabela(caminho, "BuscaEspecialidade", i, 2);

                resultadoTeste = TestCase004_BuscaEspecialidade.Busca(driver, tipo, especialidade);

                DocumentoPDF.PrintScreen(caminho, driver, "BuscaEspecialidade", i);
                IntegracaoExcel.EscreveTabela(caminho, "BuscaEspecialidade", i, 3, resultadoTeste);

                if (resultadoTeste == "SUCESSO")
                {
                    contTesteSucesso++;
                }
                else
                {
                    contTesteFalha++;
                    DocumentoPDF.AdicionaImagem(caminho, @"Images\Screenshots\SeleniumTestingScreenshotBuscaEspecialidade" + i.ToString());
                    DocumentoPDF.EscreveFalha(caminho, tipo + ": " +especialidade);
                }
            }
            IntegracaoExcel.FechaArquivo(caminho, "BuscaEspecialidade");
            DocumentoPDF.EscreveResultado(caminho, "Passed: " + (numLinhas - 1 - contTesteFalha).ToString() + " / Failed: " + contTesteFalha.ToString());

            qtdFalhas = contTesteFalha;
            contTesteFalha = 0;
            contTesteSucesso = 0;

            driver.Close();
            return qtdFalhas;
        }
    }
}