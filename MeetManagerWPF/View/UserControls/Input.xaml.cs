using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace MeetManagerWPF.View.UserControls
{
    [ObservableObject]
    public partial class Input : UserControl
    {
        public Input()
        {
            InitializeComponent();
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



        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            nameof(TextInp), typeof(string), typeof(Input),
            new PropertyMetadata(string.Empty));

        public string TextInp
        {
            get => (string)GetValue(TextProperty);
            set { 
                SetValue(TextProperty, value);

            }
        }



        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            TextBoxInput.Clear();
        }

        private void TextBoxInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxInput.Text)) TextBlockPlaceHolder.Visibility = Visibility.Visible;
            else
            {
                TextBlockPlaceHolder.Visibility = Visibility.Hidden;
            }
        }
    }
}
