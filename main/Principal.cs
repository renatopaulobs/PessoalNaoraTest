using log4net;
using log4net.Config;
using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NaoraTeste;
using NaoraTeste.Cenarios;
using NaoraTest.Cenarios;
using NaoraTeste.Util;

namespace main
{
    public class Principal
    {
         
        public static string caminho = System.IO.Path.GetFullPath("ArquivosDados") + @"\";

        public static int numSuites = 0, numCasos = 0, numFalhas = 0; 
        public static int numCasosCadastro = (IntegracaoExcel.NumLinhas(caminho, "Cadastro") - 1);
        public static int numCasosLogin = (IntegracaoExcel.NumLinhas(caminho, "Login") - 1);
        public static int numCasosModifica = (IntegracaoExcel.NumLinhas(caminho, "ModificaUsuario") - 1);
        public static int numCasosBuscaNome = (IntegracaoExcel.NumLinhas(caminho, "BuscaNome") - 1);
        public static int numCasosBuscaEspecialidade = (IntegracaoExcel.NumLinhas(caminho, "BuscaEspecialidade") - 1);
        public static int numCasosCadastroProfissional = (IntegracaoExcel.NumLinhas(caminho, "CadastroProfissional") - 1);
        public static int numCasosUnimedCadastroProfissional = (IntegracaoExcel.NumLinhas(caminho, "UnimedCadastroProfissional") - 1);
        public static int numCasosUnimedLocal = (IntegracaoExcel.NumLinhas(caminho, "CadastroLocal") - 1);
        public static int numCasosUnimedLogin = (IntegracaoExcel.NumLinhas(caminho, "UnimedLoginProfissional") - 1);
        public static int numCasosHorariosCadastro = (IntegracaoExcel.NumLinhas(caminho, "ProfissionalCadastroHorarios") - 1);

        public static Cenario001_PrimeiroAcesso primeiroAcesso = new Cenario001_PrimeiroAcesso();
        public static Cenario002_ModificarInfoUsuario modificaUsuario = new Cenario002_ModificarInfoUsuario();
        public static Cenario003_BuscaProfissional busca = new Cenario003_BuscaProfissional();
        public static Cenario004_ProfissionalPrimeiroAcesso profissionalPrimeiroAcesso = new Cenario004_ProfissionalPrimeiroAcesso();
        public static Cenario005_UnimedProfissionalPrimeiroAcesso unimedProfissionalPrimeiroAcesso = new Cenario005_UnimedProfissionalPrimeiroAcesso();

        static void Main(string[] args)
        {
            DocumentoPDF.CriandoDocumento(caminho);

            //Paciente
            //numFalhas = numFalhas + primeiroAcesso.Cadastro(caminho); numSuites++; numCasos = numCasos + numCasosCadastro; 
            numFalhas = numFalhas + primeiroAcesso.Login(caminho); numSuites++; numCasos = numCasos + numCasosLogin;
            numFalhas = numFalhas + busca.BuscaNome(caminho); numSuites++; numCasos = numCasos + numCasosBuscaNome;
            numFalhas = numFalhas + busca.BuscaEspecialidade(caminho); numSuites++; numCasos = numCasos + numCasosBuscaEspecialidade;
            //numFalhas = numFalhas + modificaUsuario.ModificaUsuario(caminho); numSuites++; numCasos = numCasos + numCasosModifica;

            //Profissional Agenda
            numFalhas = numFalhas + profissionalPrimeiroAcesso.CadastroProfissionalPagamento(caminho); numSuites++; numCasos = numCasos + numCasosCadastroProfissional;
            numFalhas = numFalhas + profissionalPrimeiroAcesso.CadastroProfissionalDados(caminho); numSuites++; numCasos = numCasos + numCasosCadastroProfissional;

            //Unimed Profissional Agenda
            numFalhas = numFalhas + unimedProfissionalPrimeiroAcesso.ProfissionalCadastro(caminho); numSuites++; numCasos = numCasos + numCasosUnimedCadastroProfissional;
            numFalhas = numFalhas + unimedProfissionalPrimeiroAcesso.ProfissionalLocal(caminho); numSuites++; numCasos = numCasos + numCasosUnimedLocal;
            numFalhas = numFalhas + unimedProfissionalPrimeiroAcesso.ProfissionalLogin(caminho); numSuites++; numCasos = numCasos + numCasosUnimedLogin;
            numFalhas = numFalhas + unimedProfissionalPrimeiroAcesso.ProfissionalHorariosCadastro(caminho); numSuites++; numCasos = numCasos + numCasosHorariosCadastro;
            
            DocumentoPDF.AdicionaTabela(numSuites, numFalhas, numCasos);
            DocumentoPDF.FechaDocumento();
            DocumentoPDF.AdicionaPaginaNum(caminho);

            //SendEmail.EmailProperties(caminho,"renatopaulobs@gmail.com");
        }
    }
}
