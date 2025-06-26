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

namespace MeetManagerWPF.View.UserControls
{
    /// <summary>
    /// Interakční logika pro Input.xaml
    /// </summary>
    public partial class Input : UserControl
    {
        public Input()
        {
            InitializeComponent();
        }

        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            TextBoxInput.Clear();
        }

        private void TextBoxInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxInput.Text)) TextBlockPlaceHolder.Visibility = Visibility.Visible;
            else TextBlockPlaceHolder.Visibility = Visibility.Hidden;
        }
    }
}
