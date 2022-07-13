using LocadoraVeiculos.Infra.Logging;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           

            ConfiguracaoLogsLocadora.ConfigurarEscritaLogs();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TelaMenuInicial());
        }
    }
}
