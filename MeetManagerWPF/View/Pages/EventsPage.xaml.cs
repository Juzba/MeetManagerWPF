﻿using MeetManagerWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MeetManagerWPF.View.Pages
{
    /// <summary>
    /// Interakční logika pro EventsPage.xaml
    /// </summary>
    public partial class EventsPage : Page
    {
        public EventsPage(EventsViewModel eventsViewModel)
        {
            InitializeComponent();
            DataContext = eventsViewModel;
        }
    }
}
