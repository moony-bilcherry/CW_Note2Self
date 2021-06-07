using System;
using System.Globalization;
using System.Linq;
using System.Windows;

namespace Note2Self.ValueConverters
{
    /// <summary>
    /// Конвертирует True/False в <see cref="Visibility"/> Visible/Hidden
    /// </summary>
    public class HasNoteConverter : BaseValueConverter<HasNoteConverter>
    {


        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DataWorker.HasNote((DateTime)value);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}