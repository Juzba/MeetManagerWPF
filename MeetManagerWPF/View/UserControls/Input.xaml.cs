using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace MeetManagerWPF.View.UserControls
{
    [ObservableObject]
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






        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                name: "Text",
                propertyType: typeof(string),
                ownerType: typeof(Input),
                // 2. Metadata jsou klíčová!
                typeMetadata: new FrameworkPropertyMetadata(
                    defaultValue: string.Empty,
                    // Tato volba zajistí, že se změny projeví okamžitě (při psaní)
                    // a že binding bude defaultně TwoWay.
                    flags: FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    // (Volitelné, ale doporučené) Explicitní callback pro ladění
                    propertyChangedCallback: null,
                    // (Volitelné) Umožňuje validaci a transformaci hodnoty
                    coerceValueCallback: null,
                    // TOTO je důležité pro okamžitou aktualizaci zdroje (ViewModelu)
                    isAnimationProhibited: false,
                    defaultUpdateSourceTrigger: UpdateSourceTrigger.PropertyChanged
                )
            );

        // 3. Obalující .NET vlastnost (CLR wrapper) s get i set.
        //    WPF ji primárně nepoužívá pro binding, ale je nutná pro přístup z kódu a pro konvenci.
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
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
            this.Text = TextBoxInput.Text;
        }
    }
}
