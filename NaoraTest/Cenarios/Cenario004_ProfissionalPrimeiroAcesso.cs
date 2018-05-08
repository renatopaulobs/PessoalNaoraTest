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
using NaoraTest.TestCases;
using NaoraTest.perfilUsuario;
using log4net.Config;
using log4net;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.CSharp.RuntimeBinder;
using System.Runtime.InteropServices;

namespace NaoraTest.Cenarios
{
    [TestClass]
    public class Cenario004_ProfissionalPrimeiroAcesso
    {
        string BuscaUrl = "https://agenda.naora.com.br/Usuario/Login";

        int numLinhas, contTesteSucesso = 0, contTesteFalha = 0;
        string resultadoTeste, tipo, nome, numeroCartao, titulo, nomePagina, cpf, sexo, profissao, experiencia, cep, rua, bairro, numero, cidade, estado, complemento;

        SqlConnectionStringBuilder connStr = new SqlConnectionStringBuilder();

        [TestMethod]
        public int CadastroProfissionalPagamento(string caminho)
        {
            int qtdFalhas;
            var options = new FirefoxOptions();
            options.AddArgument("headless");

            IWebDriver driver = new FirefoxDriver();
            numLinhas = IntegracaoExcel.NumLinhas(caminho, "CadastroProfissional");
            DocumentoPDF.EscrevePDF(caminho, "Cadastro Pagamento Profissional\n"+"Total de testes - " + (numLinhas-1).ToString());

            for (int i=2; i<=numLinhas; i++)
            {
                driver.Navigate().GoToUrl(BuscaUrl);

                DeletePaciente.DeleteProfissionalAgenda();

                tipo = IntegracaoExcel.LeTabela(caminho, "CadastroProfissional", i, 1); 
                nome = IntegracaoExcel.LeTabela(caminho, "CadastroProfissional", i, 2);
                numeroCartao = IntegracaoExcel.LeTabela(caminho, "CadastroProfissional", i, 3);
                cep = IntegracaoExcel.LeTabela(caminho, "CadastroProfissional", i, 4);              
                rua = IntegracaoExcel.LeTabela(caminho, "CadastroProfissional", i, 5);
                bairro = IntegracaoExcel.LeTabela(caminho, "CadastroProfissional", i, 6);
                numero = IntegracaoExcel.LeTabela(caminho, "CadastroProfissional", i, 7);
                cidade = IntegracaoExcel.LeTabela(caminho, "CadastroProfissional", i, 8);
                estado = IntegracaoExcel.LeTabela(caminho, "CadastroProfissional", i, 9);
                complemento = IntegracaoExcel.LeTabela(caminho, "CadastroProfissional", i, 10);
                
                resultadoTeste = TestCase007_ProfissionalCadastroPagamento.ProfissionalCadastroPagamento(driver, tipo, nome, numeroCartao, cep, rua, bairro, numero, cidade, estado, complemento);

                DocumentoPDF.PrintScreen(caminho, driver, "CadastroProfissional", i);
                IntegracaoExcel.EscreveTabela(caminho, "CadastroProfissional", i, 11, resultadoTeste);

                if(resultadoTeste == "SUCESSO")
                {
                    contTesteSucesso++;
                }
                else
                {
                    contTesteFalha++;
                    DocumentoPDF.AdicionaImagem(caminho, @"Images\Screenshots\SeleniumTestingScreenshotCadastroProfissional" + i.ToString());
                    DocumentoPDF.EscreveFalha(caminho, tipo + ": " + nome + ", " + numeroCartao + ", " + cep + ", " + rua + ", " + bairro + ", " + numero + ", " + cidade + ", " + estado + ", " + complemento);
                }
            }
            IntegracaoExcel.FechaArquivo(caminho, "CadastroProfissional");
            DocumentoPDF.EscreveResultado(caminho, "Passed: " + (numLinhas - 1 - contTesteFalha).ToString() + " / Failed: " + contTesteFalha.ToString());

            qtdFalhas = contTesteFalha;
            contTesteFalha = 0;
            contTesteSucesso = 0;

            driver.Close();
            return qtdFalhas;
        }

        [TestMethod]
        public int CadastroProfissionalDados(string caminho)
        {
            int qtdFalhas;
            var options = new FirefoxOptions();
            options.AddArgument("headless");

            IWebDriver driver = new FirefoxDriver();
            numLinhas = IntegracaoExcel.NumLinhas(caminho, "CadastroProfissional");
            DocumentoPDF.EscrevePDF(caminho, "Cadastro Dados Profissional\n" + "Total de testes - " + (numLinhas - 1).ToString());

            for (int i = 2; i <= 2; i++)
            {
                driver.Navigate().GoToUrl(BuscaUrl);

                DeletePaciente.DeleteProfissionalAgenda();

                tipo = IntegracaoExcel.LeTabela(caminho, "CadastroProfissional", i, 1);
                nome = IntegracaoExcel.LeTabela(caminho, "CadastroProfissional", i, 2);
                nomePagina = IntegracaoExcel.LeTabela(caminho, "CadastroProfissional", i, 3);
                cpf = IntegracaoExcel.LeTabela(caminho, "CadastroProfissional", i, 4);
                sexo = IntegracaoExcel.LeTabela(caminho, "CadastroProfissional", i, 5);
                profissao = IntegracaoExcel.LeTabela(caminho, "CadastroProfissional", i, 6);
                experiencia = IntegracaoExcel.LeTabela(caminho, "CadastroProfissional", i, 7);

                resultadoTeste = TestCase008_ProfissionalCadastroDados.ProfissionalCadastroDados(driver, tipo, titulo, nome, nomePagina, cpf, sexo, profissao, experiencia);

                DocumentoPDF.PrintScreen(caminho, driver, "CadastroProfissional", i);
                IntegracaoExcel.EscreveTabela(caminho, "CadastroProfissional", i, 8, resultadoTeste);

                if (resultadoTeste == "SUCESSO")
                {
                    contTesteSucesso++;
                }
                else
                {
                    contTesteFalha++;
                    DocumentoPDF.AdicionaImagem(caminho, @"Images\Screenshots\SeleniumTestingScreenshotCadastroProfissional" + i.ToString());
                    DocumentoPDF.EscreveFalha(caminho, tipo + ": " + nome + ", " + nomePagina + ", " + cpf + ", " + sexo + ", " + profissao + ", " + experiencia);

                }
            }
            IntegracaoExcel.FechaArquivo(caminho, "CadastroProfissional");
            DocumentoPDF.EscreveResultado(caminho, "Passed: " + (numLinhas - 1 - contTesteFalha).ToString() + " / Failed: " + contTesteFalha.ToString());

            qtdFalhas = contTesteFalha;
            contTesteFalha = 0;
            contTesteSucesso = 0;

            driver.Close();
            return qtdFalhas;
        }
    }
}
