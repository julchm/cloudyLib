using cloudyLib.Forms;
using cloudyLib.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using cloudyLib.Data;
using cloudyLib.Forms;


namespace cloudyLib
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        public static IServiceProvider ServiceProvider { get; private set; }


        [STAThread]
        static void Main()
        {
            try
            {
                ApplicationConfiguration.Initialize();

                var host = CreateHostBuilder().Build();

                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    try
                    {
                        var context = services.GetRequiredService<LibraryDbContext>();
                        context.Database.Migrate();
                        context.SeedData();
                    }
                    catch (Exception exDb)
                    {
                        MessageBox.Show($"Wyst�pi� b��d podczas inicjalizacji bazy danych: {exDb.Message}", "B��d Bazy Danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                var mainForm = host.Services.GetRequiredService<MainForm>();
                if (mainForm == null)
                {
                    MessageBox.Show("Krytyczny b��d: Nie uda�o si� utworzy� g��wnego okna aplikacji.", "B��d Krytyczny Aplikacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Application.Run(mainForm);
            }
            catch (Exception exGlobal)
            {
                MessageBox.Show($"Nieoczekiwany b��d krytyczny podczas uruchamiania aplikacji: {exGlobal.Message}", "B��d Krytyczny Aplikacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.SetBasePath(AppContext.BaseDirectory);
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    var connectionString = context.Configuration.GetConnectionString("DefaultConnection");

                    services.AddDbContext<LibraryDbContext>(options =>
                        options.UseNpgsql(connectionString));

                    services.AddSingleton<MainForm>();
                    services.AddTransient<LoginView>();
                    services.AddTransient<RegisterView>();
                    services.AddTransient<AdminView>();

                    services.AddTransient<BookListView>();
                    services.AddTransient<MyLoansView>();
                    services.AddTransient<MyReviewsView>();
                    services.AddTransient<EditProfileView>();

                    services.AddSingleton<RateReviewForm>();

                    services.AddTransient<ManageBooksView>();
                    services.AddSingleton<AddEditUserForm>();
                    services.AddTransient<AllLoansView>();
                    services.AddTransient<ManageUsersView>();
                    services.AddTransient<PopularBooksView>();
                    services.AddTransient<AllLoansView>();
                    services.AddTransient<AddEditLoanForm>();
                });
    }

}