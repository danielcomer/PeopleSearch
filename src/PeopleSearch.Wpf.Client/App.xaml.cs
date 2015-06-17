using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Framework.ConfigurationModel;
using Ninject;
using PeopleSearch.Wpf.Client.IoC;

namespace PeopleSearch.Wpf.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IKernel _kernel;

        protected override void OnStartup(StartupEventArgs e)
        {
            _kernel = new StandardKernel(new PeopleSearchNinjectModule());

            NinjectServiceLocator.Initialize(_kernel);

            base.OnStartup(e);
        }
    }
}
