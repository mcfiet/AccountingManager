using De.HsFlensburg.ClientApp078.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp078.Services.MessageBus;
using De.HsFlensburg.ClientApp078.Services.SerializationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.ViewModels
{
    public class MainWindowViewModel
    {
        private ModelFileHandler modelFileHandler;
        private string pathForSerialization;

        public ICommand SaveCommand { get; }
        public ICommand LoadCommand { get; }

        public ICommand OpenNewClientWindowCommand { get; }
        public ICommand OpenNewArticleWindowCommand { get; }


        public ArticleCollectionViewModel MyList { get; set; }

        public MainWindowViewModel(ClientCollectionViewModel viewModelCollection, ArticleCollectionViewModel articleModelCollection)
        {
            
            SaveCommand = new RelayCommand(SaveModel);
            LoadCommand = new RelayCommand(LoadModel);

            OpenNewClientWindowCommand = new RelayCommand(OpenNewClientWindowMethod);
            OpenNewArticleWindowCommand = new RelayCommand(OpenNewArticleWindow);

            MyList = articleModelCollection;
            modelFileHandler = new ModelFileHandler();
            pathForSerialization = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ClientCollectionSerialization\\MyClient.cc";
        }

        private void OpenNewClientWindowMethod()
        {
            ServiceBus.Instance.Send(new OpenNewClientWindowMessage());
        }

        private void OpenNewArticleWindow()
        {
            ServiceBus.Instance.Send(new OpenNewArticleWindowMessage());
        }


        private void SaveModel()
        {
            modelFileHandler.WriteModelToFile(pathForSerialization, MyList.Model);
        }

        private void LoadModel()
        {
            MyList.Model = modelFileHandler.ReadModelFromFile(pathForSerialization);
        }
    }
}
