using De.HsFlensburg.ClientApp078.Logic.Ui.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.Base
{
    public abstract class ViewModelBase<TModel> : IViewModel<TModel>
    where TModel : new()
    {
        private TModel _model;

        public TModel Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged();
            }
        }

        protected ViewModelBase()
        {
            Initialize(new TModel());
        }

        protected ViewModelBase(TModel modelObject)
        {
            Initialize(modelObject);
        }

        private void Initialize(TModel modelObject)
        {
            Model = modelObject;
            if (Model is INotifyPropertyChanged modelPropChanged)
            {
                modelPropChanged.PropertyChanged += OnPropertyChangedInModel;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void OnPropertyChangedInModel(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }
    }
}
