using De.HsFlensburg.ClientApp078.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp078.Services.MessageBus;
using De.HsFlensburg.ClientApp078.Services.MessageBusWithParameter;
using De.HsFlensburg.ClientApp078.Services.SerializationService;
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
        public ICommand OpenOrderWindowCommand { get; }
        public ICommand OpenInvoiceWindowCommand { get; }
        public ICommand OpenClientsWindowCommand { get; }
        public ICommand OpenArticlesWindowCommand { get; }


        public OfferCollectionViewModel OfferList { get; set; }
        public OrderCollectionViewModel OrderList { get; set; }
        public InvoiceCollectionViewModel InvoiceList { get; set; }
        public ClientCollectionViewModel ClientList { get; set; }
        public ArticleCollectionViewModel ArticleList { get; set; }


        public AdministrationViewModel AdministrationViewModel { get; set; }
        public OfferViewModel SelectedOffer { get; set; }
        public OrderViewModel SelectedOrder { get; set; }
        public InvoiceViewModel SelectedInvoice { get; set; }

        public MainWindowViewModel(AdministrationViewModel givenAdministrationViewModel)
        {

            SaveCommand = new RelayCommand(SaveModel);
            LoadCommand = new RelayCommand(LoadModel);

            OpenNewOfferWindowCommand = new RelayCommand(OpenNewOfferWindowMethodWithParameter);
            OpenOfferWindowCommand = new RelayCommand(OpenOfferWindowMethodWithParameter);
            OpenOrderWindowCommand = new RelayCommand(OpenOrderWindowMethodWithParameter);
            OpenInvoiceWindowCommand = new RelayCommand(OpenInvoiceWindowMethodWithParameter);
            OpenClientsWindowCommand = new RelayCommand(OpenClientsWindowMethodWithParameter);
            OpenArticlesWindowCommand = new RelayCommand(OpenArticlesWindowMethodWithParameter);

            AdministrationViewModel = givenAdministrationViewModel;


            OfferList = AdministrationViewModel.Offers;
            OrderList = AdministrationViewModel.Orders;
            InvoiceList = AdministrationViewModel.Invoices;
            ClientList = AdministrationViewModel.Clients;
            ArticleList = AdministrationViewModel.Articles;


            modelFileHandler = new ModelFileHandler();
            pathForSerialization = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Finances\\data.cc";
        }


        private void OpenClientsWindowMethodWithParameter()
        {
            OpenClientsWindowMessage messageObject = new OpenClientsWindowMessage();
            Messenger.Instance.Send<OpenClientsWindowMessage>(messageObject);
        }
        private void OpenNewOfferWindowMethodWithParameter()
        {
            OpenNewOfferWindowMessage messageObject = new OpenNewOfferWindowMessage();
            Messenger.Instance.Send<OpenNewOfferWindowMessage>(messageObject);
        }
        private void OpenOfferWindowMethodWithParameter()
        {
            OpenOfferWindowMessage messageObject = new OpenOfferWindowMessage();
            messageObject.IncomingOffer = SelectedOffer;
            Messenger.Instance.Send<OpenOfferWindowMessage>(messageObject);
        }
        private void OpenOrderWindowMethodWithParameter()
        {
            OpenOrderWindowMessage messageObject = new OpenOrderWindowMessage();
            messageObject.IncomingOrder = SelectedOrder;
            Messenger.Instance.Send<OpenOrderWindowMessage>(messageObject);
        }
        private void OpenInvoiceWindowMethodWithParameter()
        {
            OpenInvoiceWindowMessage messageObject = new OpenInvoiceWindowMessage();
            messageObject.IncomingInvoice = SelectedInvoice;
            Messenger.Instance.Send<OpenInvoiceWindowMessage>(messageObject);
        }
        private void OpenArticlesWindowMethodWithParameter()
        {
            OpenArticlesWindowMessage messageObject = new OpenArticlesWindowMessage();
            Messenger.Instance.Send<OpenArticlesWindowMessage>(messageObject);
        }

        private void SaveModel()
        {
            modelFileHandler.WriteModelToFile(pathForSerialization, AdministrationViewModel.Model);
        }

        private void LoadModel()
        {
            AdministrationViewModel.Model = modelFileHandler.ReadModelFromFile(pathForSerialization);
        }


        //private void OpenNewOfferWindowMethod()
        //{
        //    ServiceBus.Instance.Send(new OpenNewOfferWindowMessage());
        //}

        //private void OpenOfferWindowMethod()
        //{
        //    ServiceBus.Instance.Send(new OpenOfferWindowMessage());
        //}

        //private void OpenClientsWindowMethod()
        //{
        //    ServiceBus.Instance.Send(new OpenClientsWindowMessage());
        //}

        //private void OpenArticlesWindow()
        //{
        //    ServiceBus.Instance.Send(new OpenArticlesWindowMessage());
        //}

    }
}
