using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MVVMSamples.Views;
using MVVMSamples.ViewModels;

namespace MVVMSamples
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.Startup += App_Startup;
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            MainView _mainView = new MainView(new MainViewModel());
            _mainView.Show();
        }
    }
}
