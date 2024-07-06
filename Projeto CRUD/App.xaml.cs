using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Configuration;
using System.Data;
using System.Windows;
using System.ComponentModel.DataAnnotations;

namespace Projeto_CRUD
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Criação da Configuration
        public static IConfigurationRoot Configuration { get; private set; }

        //Criação do método de inicialização
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureAppSettings();
            
            //Com a configuration pronta eu alimento a connection string
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            MessageBox.Show(connectionString);
        }

        //Criação do método que lê o JSON e alimenta a configuration
        private void ConfigureAppSettings()
        {
            var builder = new ConfigurationBuilder().
                SetBasePath(Directory.GetCurrentDirectory()).
                AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
        }
    }

}
