using De.HsFlensburg.ClientApp078.Logic.Ui.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.Base
{
    public class ViewModelSyncCollection<TViewModel, TModel, TModelCollection> :
     ObservableCollection<TViewModel>, IViewModel<TModelCollection>
     where TViewModel : class, IViewModel<TModel>, INotifyPropertyChanged, new()
     where TModel : new()
     where TModelCollection : ObservableCollection<TModel>, new()
    {
        private TModelCollection _model;
        public TModelCollection Model
        {
            get => _model;
            set
            {
                Clear();
                _model = value;
                WrapListItems();

                foreach (var viewModel in this)
                {
                    if (viewModel.Model is INotifyPropertyChanged modelPropertyChanged)
                    {
                        modelPropertyChanged.PropertyChanged += viewModel.OnPropertyChangedInModel;
                    }
                }

                OnPropertyChanged(nameof(Model));
                _model.CollectionChanged += ModelCollectionChanged;
            }
        }

        protected ViewModelSyncCollection()
        {
            _model = new TModelCollection();
            CollectionChanged += ViewModelCollectionChanged;
            _model.CollectionChanged += ModelCollectionChanged;
        }

        protected ViewModelSyncCollection(TModelCollection modelCollection)
        {
            _model = modelCollection;
            CollectionChanged += ViewModelCollectionChanged;
            _model.CollectionChanged += ModelCollectionChanged;
            WrapListItems();
        }

        private bool _syncDisabled;

        private void WrapListItems()
        {
            _syncDisabled = true;
            foreach (var element in _model)
            {
                var wrapper = new TViewModel();
                wrapper.Model = element;
                Add(wrapper);
            }
            _syncDisabled = false;
        }

        private void ViewModelCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (_syncDisabled) return;
            _syncDisabled = true;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var model in e.NewItems.OfType<TViewModel>().Select(v => v.Model))
                        Model.Add(model);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (var model in e.OldItems.OfType<TViewModel>().Select(v => v.Model))
                        Model.Remove(model);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    Model.Clear();
                    break;
            }
            _syncDisabled = false;
        }

        private void ModelCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (_syncDisabled) return;
            _syncDisabled = true;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var model in e.NewItems.OfType<TModel>())
                    {
                        var temp = new TViewModel { Model = model };
                        Add(temp);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (var model in e.OldItems.OfType<TModel>())
                    {
                        Remove(GetViewModelOfModel(model));
                    }

                    break;
                case NotifyCollectionChangedAction.Reset:
                    Clear();
                    break;
            }
            _syncDisabled = false;
        }

        private TViewModel GetViewModelOfModel(TModel client)
        {
            return this.FirstOrDefault(cvm => cvm.Model.Equals(client));
        }

        private void OnPropertyChanged(string propertyName = null)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        public void OnPropertyChangedInModel(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }
    }
}
