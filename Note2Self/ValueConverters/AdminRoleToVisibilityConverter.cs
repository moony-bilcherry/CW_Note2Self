using Note2Self.Models;
using System;
using System.Globalization;
using System.Windows;

namespace Note2Self
{
    /// <summary>
    /// Конвертирует True/False в <see cref="Visibility"/> Visible/Hidden
    /// </summary>
    public class AdminRoleToVisibilityConverter : BaseValueConverter<AdminRoleToVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Roles)value == Roles.Admin ? Visibility.Visible : Visibility.Hidden;
 
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}