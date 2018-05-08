using AvilaCore;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaoraTeste.perfilUsuario
{
    public class DeletePaciente
    {
        public static void DeleteProfissionalAgenda() {

            //connStr.ConnectionString = ConfigurationManager.ConnectionStrings["NaoraTeste"].ConnectionString;
            AvilaApplication.InitializeHelpers();
            AvilaApplication.DataManipulation.Configure("avilasolucoes@oe0dc5r5n9", "@vil@2015", "oe0dc5r5n9.database.windows.net,1433", "naora", false);
            Assert.IsTrue(AvilaApplication.DataManipulation.CheckConnection());
            AvilaApplication.DataManipulation.ExecuteProcedure("sp_deleteUsuarioAgenda", new string[] { "Email" }, new string[] { "teste@teste.com" });
        }
        public static void DeleteProfissionalUnimed()
        {
            AvilaApplication.InitializeHelpers();
            AvilaApplication.DataManipulation.Configure("avilasolucoes@oe0dc5r5n9", "@vil@2015", "oe0dc5r5n9.database.windows.net,1433", "naora", false);
            Assert.IsTrue(AvilaApplication.DataManipulation.CheckConnection());
            AvilaApplication.DataManipulation.ExecuteProcedure("sp_deleteUsuario", new string[] { "Email" }, new string[] { "teste@teste.com" });
            
            //O atributo 'importado' profissional na tabela dbo.ProfissionalImportacao 
            AvilaApplication.DataManipulation.ExecuteNonQuery("UPDATE [dbo].[ProfissionalImportacao] SET [importado] = 0 WHERE [id] = 2109");
        }
    }
}
