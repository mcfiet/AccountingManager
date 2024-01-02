using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.Base
{
    public interface IViewModel<TOfModel> : INotifyPropertyChanged
    {
        TOfModel Model { get; set; }

        void OnPropertyChangedInModel(object sender, PropertyChangedEventArgs e);
    }
}
