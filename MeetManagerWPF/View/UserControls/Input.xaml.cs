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
    public partial class Input : UserControl
    {
        public Input()
        {
            InitializeComponent();
            DataContext = this;
        }

        private string _placeholder = "";
        public string Placeholder
        {
            get { return _placeholder; }
            set { _placeholder = value; }
        }

        private string _background = "";
        public new string Background
        {
            get { return _background; }
            set { _background = value; }
        }

        private string _foreground = "";
        public new string Foreground
        {
            get { return _foreground; }
            set { _foreground = value; }
        }

        private string _placeholderColor = "";
        public string PlaceholderColor
        {
            get { return _placeholderColor; }
            set { _placeholderColor = value; }
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
