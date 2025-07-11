using CommunityToolkit.Mvvm.Messaging;
using MeetManagerWPF.Services;
using MeetManagerWPF.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using System.Windows.Controls;

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
                if (m.FrameName == Constants.FrameMainVindow)
                {
                    var page = (Page)_host.Services.GetRequiredService(m.PageType)!;
                    FrameMW.Navigate(page);
                }
            });




        }

    }
}