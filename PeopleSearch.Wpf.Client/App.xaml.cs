using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Framework.ConfigurationModel;

namespace PeopleSearch.Wpf.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IConfiguration _configuration;

        protected override void OnStartup(StartupEventArgs e)
        {
            _configuration = new Configuration()
                .AddCommandLine(e.Args);

            base.OnStartup(e);
        }
    }
}
