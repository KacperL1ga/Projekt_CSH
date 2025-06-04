using System;
using System.Windows.Forms;

namespace BankApp
{
    internal static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DataBaseBankSeeder.Seed(); // Inicjalizacja bazy danych przy starcie aplikacji
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Logowanie());
        }
    }
}
