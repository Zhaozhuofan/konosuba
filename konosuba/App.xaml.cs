using konosuba.Helpers;
using konosuba.Models;
using konosuba.ViewModels;
using konosuba.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace konosuba
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; }
        public static new App Current => (App)Application.Current;

        public App()
        {
            var container = new ServiceCollection();

            container.AddSingleton<WebHelper>();
            container.AddSingleton<ViewModelBase>();
            container.AddTransient<MainWindowViewModel>();
            container.AddTransient<MainWindow>();
            
            ServiceProvider = container.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow = ServiceProvider.GetService<MainWindow>();
            MainWindow!.Show();
        }
    }

}
