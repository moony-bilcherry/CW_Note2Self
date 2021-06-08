using Note2Self.Models;
using Note2Self.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note2Self.ValueConverters 
{
    public class SelectedNoteToVMConverter : BaseValueConverter<SelectedNoteToVMConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is SelectedDateViewModel dateVM ? dateVM.Model : null;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Notes note ? new SelectedDateViewModel(note) : null;
           
        }
    }
}
