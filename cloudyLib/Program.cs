using cloudyLib.Forms;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace cloudyLib
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //var configuration = new ConfigurationBuilder()
            //       .SetBasePath(Directory.GetCurrentDirectory())
            //       .AddJsonFile("appsettings.json")
            //       .Build();

            // Pobranie connection string
            //var connectionString = configuration.GetConnectionString("DefaultConnection");

            //// Testowe po³¹czenie z baz¹ danych
            //using (var conn = new NpgsqlConnection(connectionString))
            //{
            //    conn.Open();
            //    Console.WriteLine("Po³¹czono z baz¹ danych!");
            //}

            // Uruchomienie aplikacji WinForms
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new LoginForm());
        }
    }
}