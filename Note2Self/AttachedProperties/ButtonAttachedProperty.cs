using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note2Self
{
    /// <summary>
    /// Свойство, показывающее, занят ли элемент. Если да, то крутится колесико загрузки
    /// </summary>
    public class IsBusyProperty : BaseAttachedProperty<IsBusyProperty, bool>
    {
    }
}
