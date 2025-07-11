using CommunityToolkit.Mvvm.Messaging;
using MeetManagerWPF.Services;
using MeetManagerWPF.View;
using MeetManagerWPF.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MeetManagerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IHost _host;

        public MainWindow(MainViewModel mainViewModel, IHost host)
        {
            InitializeComponent();
            DataContext = mainViewModel;
            _host = host;

            WeakReferenceMessenger.Default.Register<NavigateMessage>(this, (r, m) =>
            {
                var page = (Page)_host.Services.GetRequiredService(m.Value)!;
                FrameMW.Navigate(page);
            });
        }

    }
}