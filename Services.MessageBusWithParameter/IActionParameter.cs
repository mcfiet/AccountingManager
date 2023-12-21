using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp078.Services.MessageBusWithParameter
{
    interface IActionParameter
    {
        void ExecuteWithParameter(object parameter);
    }
}
