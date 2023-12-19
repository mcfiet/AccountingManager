//using De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp078.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp078.Services.MessageBus;
using De.HsFlensburg.ClientApp078.Services.SerializationService;
using Services.PdfExport;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public ICommand OpenNewOfferWindowCommand { get; }
        public ICommand OpenOfferWindowCommand { get; }
        public ICommand OpenClientsWindowCommand { get; }
        public ICommand OpenArticlesWindowCommand { get; }


        public OfferCollectionViewModel OfferList { get; set; }
        public ClientCollectionViewModel ClientList { get; set; }
        public ArticleCollectionViewModel ArticleList { get; set; }


        public AdministrationViewModel AdministrationViewModel { get; set; }   

        public MainWindowViewModel(AdministrationViewModel givenAdministrationViewModel)
        {
            
            SaveCommand = new RelayCommand(SaveModel);
            LoadCommand = new RelayCommand(LoadModel);

            OpenNewOfferWindowCommand = new RelayCommand(OpenNewOfferWindowMethod);
            OpenOfferWindowCommand = new RelayCommand(OpenOfferWindowMethod);
            OpenClientsWindowCommand = new RelayCommand(OpenClientsWindowMethod);
            OpenArticlesWindowCommand = new RelayCommand(OpenArticlesWindow);

            AdministrationViewModel = givenAdministrationViewModel;

            
            OfferList = AdministrationViewModel.Offers;
            ClientList = AdministrationViewModel.Clients;
            ArticleList = AdministrationViewModel.Articles;


            modelFileHandler = new ModelFileHandler();
            pathForSerialization = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Finances\\data.cc";
        }

        private void OpenNewOfferWindowMethod()
        {
            ServiceBus.Instance.Send(new OpenNewOfferWindowMessage());
        }
        
        private void OpenOfferWindowMethod()
        {
            ServiceBus.Instance.Send(new OpenOfferWindowMessage());
        }

        private void OpenClientsWindowMethod()
        {
            ServiceBus.Instance.Send(new OpenClientsWindowMessage());
        }

        private void OpenArticlesWindow()
        {
            ServiceBus.Instance.Send(new OpenArticlesWindowMessage());
        }


        private void SaveModel()
        {
            modelFileHandler.WriteModelToFile(pathForSerialization, AdministrationViewModel.Model);
        }

        private void LoadModel()
        {
            AdministrationViewModel.Model = modelFileHandler.ReadModelFromFile(pathForSerialization);
        }
    }
}
