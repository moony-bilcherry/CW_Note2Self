using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note2Self.ViewModels
{
    public interface INestedViewModel : INotifyPropertyChanged
    {
        BaseViewModel SelectedViewModel { get; set; }
    }
}
