using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note2Self.ViewModels
{
    public interface INestedViewModel
    {
        BaseViewModel SelectedViewModel { get; set; }
    }
}
