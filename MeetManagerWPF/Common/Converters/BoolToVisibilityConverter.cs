﻿using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MeetManagerWPF.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        // Parametr invert definuje, zda převodník vrací opačnou logiku
        public bool Invert { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool boolValue = (bool)(value ?? false);
            if (Invert) boolValue = !boolValue;

            return boolValue ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility visibility)
            {
                bool result = visibility == Visibility.Visible;
                return Invert ? !result : result;
            }
            return false;
        }
    }
}
