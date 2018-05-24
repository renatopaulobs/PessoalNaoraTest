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
    public class Cenario005_UnimedProfissionalPrimeiroAcesso
    {
        string buscaUrl = "https://unimedrecife.naora.com.br/UnimedUsuario/Login";
        string localUrl = "https://unimedrecife.naora.com.br/Local/Cadastro";

        int numLinhas, contTesteSucesso = 0, contTesteFalha = 0;      
        string resultadoTeste, tipo, telefone, nome, numeroCartao, especialidade, titulo, nomePagina, crm, cpf, sexo, profissao, experiencia, cep, rua, bairro, numero, cidade, estado, complemento, email, senha;

        SqlConnectionStringBuilder connStr = new SqlConnectionStringBuilder();

        [TestMethod]
        public int ProfissionalCadastro(string caminho)
        {
            int qtdFalhas;
            var options = new FirefoxOptions();
            options.AddArgument("headless");

            IWebDriver driver = new FirefoxDriver();
            numLinhas = IntegracaoExcel.NumLinhas(caminho, "UnimedCadastroProfissional");
            DocumentoPDF.EscrevePDF(caminho, "Cadastro Profissional Unimed\n" + "Total de testes - " + (numLinhas - 1).ToString());

            for (int i = 2; i <= numLinhas; i++)
            {
                driver.Navigate().GoToUrl(buscaUrl);

                DeletePaciente.DeleteProfissionalUnimed();

                tipo = IntegracaoExcel.LeTabela(caminho, "UnimedCadastroProfissional", i, 1);
                crm = IntegracaoExcel.LeTabela(caminho, "UnimedCadastroProfissional", i, 2);
                estado = IntegracaoExcel.LeTabela(caminho, "UnimedCadastroProfissional", i, 3);
                cpf = IntegracaoExcel.LeTabela(caminho, "UnimedCadastroProfissional", i, 4);
                email = IntegracaoExcel.LeTabela(caminho, "UnimedCadastroProfissional", i, 5);
                senha = IntegracaoExcel.LeTabela(caminho, "UnimedCadastroProfissional", i, 6);
                profissao = IntegracaoExcel.LeTabela(caminho, "UnimedCadastroProfissional", i, 7);
                especialidade = IntegracaoExcel.LeTabela(caminho, "UnimedCadastroProfissional", i, 8);

                resultadoTeste = TestCase009_UnimedProfissionalCadastro.ProfissionalCadastro(driver, tipo, crm, estado, cpf, email, senha, profissao, especialidade);

                DocumentoPDF.PrintScreen(caminho, driver, "UnimedCadastroProfissional", i);
                IntegracaoExcel.EscreveTabela(caminho, "UnimedCadastroProfissional", i, 9, resultadoTeste);

                if (resultadoTeste == "SUCESSO")
                {
                    contTesteSucesso++;
                }
                else
                {
                    contTesteFalha++;
                    DocumentoPDF.AdicionaImagem(caminho, @"Images\Screenshots\SeleniumTestingScreenshotUnimedCadastroProfissional" + i.ToString());
                    DocumentoPDF.EscreveFalha(caminho, tipo + ": " + crm + ", " + estado + ", " + cpf + ", " + email + ", " + senha + ", " + profissao + ", " + especialidade);
                }
            }
            IntegracaoExcel.FechaArquivo(caminho, "UnimedCadastroProfissional");
            DocumentoPDF.EscreveResultado(caminho, "Passed: " + (numLinhas - 1 - contTesteFalha).ToString() + " / Failed: " + contTesteFalha.ToString());

            qtdFalhas = contTesteFalha;
            contTesteFalha = 0;
            contTesteSucesso = 0;

            driver.Close();
            return qtdFalhas;
        }

        public int ProfissionaHorariosCadastro(string caminho)
        {
            int qtdFalhas;
            var options = new FirefoxOptions();
            options.AddArgument("headless");

            IWebDriver driver = new FirefoxDriver();
            numLinhas = IntegracaoExcel.NumLinhas(caminho, "ProfissionalCadastroHorarios");
            DocumentoPDF.EscrevePDF(caminho, "Cadastro Profissional Horario\n" + "Total de testes - " + (numLinhas - 1).ToString());

            for (int i = 2; i <= numLinhas; i++)
            {
                driver.Navigate().GoToUrl(buscaUrl);

                tipo = IntegracaoExcel.LeTabela(caminho, "ProfissionalCadastroHorarios", i, 1);
                nome = IntegracaoExcel.LeTabela(caminho, "ProfissionalCadastroHorarios", i, 2);

                TestCase010_UnimedProfissionalLogin.ProfissionalLogin(driver, "teste@teste.com", "123456");
                resultadoTeste = TestCase012_ProfissionalHorariosCadastro.ProfissionalHorarios(driver);

                DocumentoPDF.PrintScreen(caminho, driver, "ProfissionalCadastroHorarios", i);
                IntegracaoExcel.EscreveTabela(caminho, "ProfissionalCadastroHorarios", i, 3, resultadoTeste);

                if (resultadoTeste == "SUCESSO")
                {
                    contTesteSucesso++;
                }
                else
                {
                    contTesteFalha++;
                    DocumentoPDF.AdicionaImagem(caminho, @"Images\Screenshots\SeleniumTestingScreenshotProfissionalCadastroHorarios" + i.ToString());
                    DocumentoPDF.EscreveFalha(caminho, tipo + ": " + nome);
                }
            }
            IntegracaoExcel.FechaArquivo(caminho, "ProfissionalCadastroHorarios");
            DocumentoPDF.EscreveResultado(caminho, "Passed: " + (numLinhas - 1 - contTesteFalha).ToString() + " / Failed: " + contTesteFalha.ToString());

            qtdFalhas = contTesteFalha;
            contTesteFalha = 0;
            contTesteSucesso = 0;

            driver.Close();
            return qtdFalhas;
        }

        public int ProfissionalLogin(string caminho)
        {
            int qtdFalhas;
            var options = new FirefoxOptions();
            options.AddArgument("headless");

            IWebDriver driver = new FirefoxDriver();
            numLinhas = IntegracaoExcel.NumLinhas(caminho, "UnimedLoginProfissional");
            DocumentoPDF.EscrevePDF(caminho, "Login Profissional Unimed\n" + "Total de testes - " + (numLinhas - 1).ToString());

            for (int i = 2; i <= numLinhas; i++)
            {
                driver.Navigate().GoToUrl(buscaUrl);

                tipo = IntegracaoExcel.LeTabela(caminho, "UnimedLoginProfissional", i, 1);
                email = IntegracaoExcel.LeTabela(caminho, "UnimedLoginProfissional", i, 2);
                senha = IntegracaoExcel.LeTabela(caminho, "UnimedLoginProfissional", i, 3);

                resultadoTeste = TestCase010_UnimedProfissionalLogin.ProfissionalLogin(driver, email, senha);
                TestCase011_ProfissionalCadastroLocal.ProfissionalLocal(driver, "Teste", "08199999999", "50670160", "222");
                DocumentoPDF.PrintScreen(caminho, driver, "UnimedLoginProfissional", i);
                IntegracaoExcel.EscreveTabela(caminho, "UnimedLoginProfissional", i, 4, resultadoTeste);

                if (resultadoTeste == "SUCESSO")
                {
                    contTesteSucesso++;
                }
                else
                {
                    contTesteFalha++;
                    DocumentoPDF.AdicionaImagem(caminho, @"Images\Screenshots\SeleniumTestingScreenshotUnimedLoginProfissional" + i.ToString());
                    DocumentoPDF.EscreveFalha(caminho, tipo + ": " + email + ", " + senha);
                }
            }
            IntegracaoExcel.FechaArquivo(caminho, "UnimedLoginProfissional");
            DocumentoPDF.EscreveResultado(caminho, "Passed: " + (numLinhas - 1 - contTesteFalha).ToString() + " / Failed: " + contTesteFalha.ToString());

            qtdFalhas = contTesteFalha;
            contTesteFalha = 0;
            contTesteSucesso = 0;

            driver.Close();
            return qtdFalhas;
        }

        public int ProfissionalLocal(string caminho)
        {
            int qtdFalhas;
            var options = new FirefoxOptions();
            options.AddArgument("headless");

            IWebDriver driver = new FirefoxDriver();
            numLinhas = IntegracaoExcel.NumLinhas(caminho, "CadastroLocal");
            DocumentoPDF.EscrevePDF(caminho, "Cadastro Profissional Local\n" + "Total de testes - " + (numLinhas - 1).ToString());

            for (int i = 2; i <= numLinhas; i++)
            {
                driver.Navigate().GoToUrl(buscaUrl);

                tipo = IntegracaoExcel.LeTabela(caminho, "CadastroLocal", i, 1);
                nome = IntegracaoExcel.LeTabela(caminho, "CadastroLocal", i, 2);
                telefone = IntegracaoExcel.LeTabela(caminho, "CadastroLocal", i, 3);
                cep = IntegracaoExcel.LeTabela(caminho, "CadastroLocal", i, 4);
                numero = IntegracaoExcel.LeTabela(caminho, "CadastroLocal", i, 5);

                TestCase010_UnimedProfissionalLogin.ProfissionalLogin(driver, email, senha);
                resultadoTeste = TestCase011_ProfissionalCadastroLocal.ProfissionalLocal(driver, nome, telefone, cep, numero);

                DocumentoPDF.PrintScreen(caminho, driver, "CadastroLocal", i);
                IntegracaoExcel.EscreveTabela(caminho, "CadastroLocal", i, 6, resultadoTeste);

                if (resultadoTeste == "SUCESSO")
                {
                    contTesteSucesso++;
                }
                else
                {
                    contTesteFalha++;
                    DocumentoPDF.AdicionaImagem(caminho, @"Images\Screenshots\SeleniumTestingScreenshotCadastroLocal" + i.ToString());
                    DocumentoPDF.EscreveFalha(caminho, tipo + ": " + nome + ", " + telefone + ", " + cep + ", " + numero);
                }
            }
            IntegracaoExcel.FechaArquivo(caminho, "CadastroLocal");
            DocumentoPDF.EscreveResultado(caminho, "Passed: " + (numLinhas - 1 - contTesteFalha).ToString() + " / Failed: " + contTesteFalha.ToString());

            qtdFalhas = contTesteFalha;
            contTesteFalha = 0;
            contTesteSucesso = 0;

            driver.Close();
            return qtdFalhas;
        }
    }
}
