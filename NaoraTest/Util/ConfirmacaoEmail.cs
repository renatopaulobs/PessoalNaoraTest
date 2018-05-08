using AvilaCore;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaoraTest.perfilUsuario
{
    public class ConfirmacaoEmail
    {
        public static void confirmarEmail(IWebDriver driver)
        {
            AvilaApplication.InitializeHelpers();
            AvilaApplication.DataManipulation.Configure("avilasolucoes@oe0dc5r5n9", "@vil@2015", "oe0dc5r5n9.database.windows.net,1433", "naora_dev", false);
            Assert.IsTrue(AvilaApplication.DataManipulation.CheckConnection());

            AvilaApplication.DataManipulation.ExecuteProcedure("confirmarEmail", new string[] { "Email" }, new string[] { "teste@teste.com" });
        }
    }
}
