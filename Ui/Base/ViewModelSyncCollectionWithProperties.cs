using System.Collections.ObjectModel;
using System.ComponentModel;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.Base
{
    public abstract class ViewModelSyncCollectionWithProperties<TViewModel, TModel, TModelCollection> :
        ViewModelSyncCollection<TViewModel, TModel, TModelCollection>
        where TViewModel : class, IViewModel<TModel>, INotifyPropertyChanged , new()
        where TModel : INotifyPropertyChanged, new() 
        where TModelCollection : ObservableCollection<TModel>, INotifyPropertyChanged, new()
    {
        protected ViewModelSyncCollectionWithProperties()
        {
            Model.PropertyChanged += OnPropertyChangedInModel;
        }

        protected ViewModelSyncCollectionWithProperties(TModelCollection modelCollection) : base(modelCollection)
        {
            Model.PropertyChanged += OnPropertyChangedInModel;
        }
    }
}