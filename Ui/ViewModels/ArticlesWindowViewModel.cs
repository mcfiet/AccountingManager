using De.HsFlensburg.ClientApp078.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp078.Services.MessageBusWithParameter;
using Services.XmlImport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.ViewModels
{
    public class ArticlesWindowViewModel : INotifyPropertyChanged
    {
        public ICommand OpenNewArticleWindowCommand { get; }
        public ICommand ImportArticlesCommand { get; }
        public RelayCommand DeleteArticlesCommand { get; }
        public RelayCommand CloseWindow { get; }

        private AdministrationViewModel administrationViewModel;
        public AdministrationViewModel AdministrationViewModel
        {
            get
            {
                return administrationViewModel;
            }
            set
            {
                administrationViewModel = value;
                OnPropertyChanged("AdministrationViewModel");
            }
        }

        public ArticlesWindowViewModel(AdministrationViewModel givenAdministrationViewModel)
        {

            OpenNewArticleWindowCommand = new RelayCommand(OpenNewArticleWindowMethodWithParameter);
            ImportArticlesCommand = new RelayCommand(ImportArticles); 
            DeleteArticlesCommand = new RelayCommand(DeleteArticlesCommandMethod);

            CloseWindow = new RelayCommand(param => CloseWPFWindow(param));

            AdministrationViewModel = givenAdministrationViewModel;
        }

        private void DeleteArticlesCommandMethod()
        {
            for (int i = 0; i < AdministrationViewModel.Articles.Count; i++)
            {
                if (AdministrationViewModel.Articles[i].IsSelected)
                {
                    AdministrationViewModel.Articles.RemoveAt(i);
                }
            }
        }

        private void OpenNewArticleWindowMethodWithParameter()
        {
            OpenNewArticleWindowMessage messageObject = new OpenNewArticleWindowMessage();
            Messenger.Instance.Send<OpenNewArticleWindowMessage>(messageObject);
        }
        private void CloseWPFWindow(object param)
        {
            Window window = (Window)param;
            window.Close();
        }
        private void ImportArticles()
        {
            XmlImport xmlImport = new XmlImport();
            AdministrationViewModel.Model.Articles = xmlImport.ImportArticles();
            OnPropertyChanged("AdministrationViewModel");

        }
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
