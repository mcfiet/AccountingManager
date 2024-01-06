using De.HsFlensburg.ClientApp078.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp078.Services.MessageBusWithParameter;
using De.HsFlensburg.ClientApp078.Services.SerializationService;
using Microsoft.Win32;
using Services.XmlBuilder;
using Services.XmlImport;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ModelFileHandler modelFileHandler;
        private string pathForSerialization;

        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand LoadCommand { get; private set; }
        public RelayCommand OpenNewOfferWindowCommand { get; private set; }
        public RelayCommand OpenOfferWindowCommand { get; private set; }
        public RelayCommand OpenOrderWindowCommand { get; private set; }
        public RelayCommand OpenInvoiceWindowCommand { get; private set; }
        public RelayCommand DeleteOffersCommand { get; private set; }
        public RelayCommand DeleteOrdersCommand { get; private set; }
        public RelayCommand DeleteInvoicesCommand { get; private set; }
        public RelayCommand OpenNewArticleWindowCommand { get; private set; }
        public RelayCommand ImportArticlesCommand { get; private set; }
        public RelayCommand ExportArticlesCommand { get; private set; }
        public RelayCommand DeleteArticlesCommand { get; private set; }
        public RelayCommand OpenNewClientWindowCommand { get; private set; }
        public RelayCommand ExportClientsToXmlCommand { get; private set; }
        public RelayCommand ImportClientsCommand { get; private set; }
        public RelayCommand DeleteClientsCommand { get; private set; }
        public RelayCommand ConvertToOrderCommand { get; private set; }
        public RelayCommand ConvertToInvoiceCommand { get; private set; }

        public AdministrationViewModel AdministrationViewModel { get; set; }

        public OfferViewModel SelectedOffer { get; set; }
        public OrderViewModel SelectedOrder { get; set; }
        public InvoiceViewModel SelectedInvoice { get; set; }

        public MainWindowViewModel(AdministrationViewModel givenAdministrationViewModel)
        {
            initCommands();

            AdministrationViewModel = givenAdministrationViewModel;
            modelFileHandler = new ModelFileHandler();
            pathForSerialization = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Finances\\data.cc";
        }

        private void initCommands()
        {
            SaveCommand = new RelayCommand(SaveModel);
            LoadCommand = new RelayCommand(LoadModel);

            OpenNewOfferWindowCommand = new RelayCommand(OpenNewOfferWindowMethodWithParameter);
            OpenOfferWindowCommand = new RelayCommand(OpenOfferWindowMethodWithParameter);
            OpenOrderWindowCommand = new RelayCommand(OpenOrderWindowMethodWithParameter);
            OpenInvoiceWindowCommand = new RelayCommand(OpenInvoiceWindowMethodWithParameter);
            DeleteOffersCommand = new RelayCommand(DeleteOffersCommandMethod);
            DeleteOrdersCommand = new RelayCommand(DeleteOrdersCommandMethod);
            DeleteInvoicesCommand = new RelayCommand(DeleteInvoicesCommandMethod);

            OpenNewArticleWindowCommand = new RelayCommand(OpenNewArticleWindowMethodWithParameter);
            ImportArticlesCommand = new RelayCommand(ImportArticles);
            ExportArticlesCommand = new RelayCommand(ExportArticlesToXmlFileMethod);
            DeleteArticlesCommand = new RelayCommand(DeleteArticlesCommandMethod);

            OpenNewClientWindowCommand = new RelayCommand(OpenNewClientWindowMethod);
            ExportClientsToXmlCommand = new RelayCommand(ExportClientsToXmlFileMethod);
            ImportClientsCommand = new RelayCommand(ImportClients);
            DeleteClientsCommand = new RelayCommand(DeleteClientsCommandMethod);

            ConvertToOrderCommand = new RelayCommand(ConvertToOrderCommandMethodWithParameter);
            ConvertToInvoiceCommand = new RelayCommand(ConvertToInvoiceMethodWithParameter);
        }

        private void OpenNewOfferWindowMethodWithParameter()
        {
            OpenOfferWindowMessage messageObject = new OpenOfferWindowMessage();
            messageObject.IncomingOffer = new OfferViewModel();
            messageObject.IncomingOffer.OfferId = AdministrationViewModel.Model.getOfferIdFromCreation();
            messageObject.IncomingOffer.Date = DateTime.Now;
            messageObject.IncomingOffer.SetOfferNr(messageObject.IncomingOffer.OfferId);
            messageObject.IncomingOffer.Client = new ClientViewModel();
            Messenger.Instance.Send<OpenOfferWindowMessage>(messageObject);
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

        private void SaveModel()
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                FileName = "data.cc",
                DefaultExt = ".cc",
                Filter = "Data (.cc)|*.cc",
                Title = "Speichern unter"
            };
            Nullable<bool> result = sfd.ShowDialog();

            string dir = System.IO.Path.Combine(sfd.FileName);
            modelFileHandler.WriteModelToFile(dir, AdministrationViewModel.Model);
        }

        private void LoadModel()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                FileName = "data.cc",
                DefaultExt = ".cc",
                Filter = "Data (.cc)|*.cc",
                Title = "Daten laden"
            };
            Nullable<bool> result = ofd.ShowDialog();
            string dir = ofd.FileName;
            AdministrationViewModel.Model = modelFileHandler.ReadModelFromFile(dir);
        }

        private void DeleteOffersCommandMethod()
        {

            for (int i = 0; i < AdministrationViewModel.Offers.Count; i++)
            {
                if (AdministrationViewModel.Offers[i].IsSelected)
                {
                    AdministrationViewModel.Offers.RemoveAt(i);
                }
            }

        }

        private void DeleteOrdersCommandMethod()
        {

            for (int i = 0; i < AdministrationViewModel.Orders.Count; i++)
            {
                if (AdministrationViewModel.Orders[i].IsSelected)
                {
                    AdministrationViewModel.Orders.RemoveAt(i);
                }
            }

        }

        private void DeleteInvoicesCommandMethod()
        {

            for (int i = 0; i < AdministrationViewModel.Invoices.Count; i++)
            {
                if (AdministrationViewModel.Invoices[i].IsSelected)
                {
                    AdministrationViewModel.Invoices.RemoveAt(i);
                }
            }

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

        private void ImportArticles()
        {
            XmlImport xmlImport = new XmlImport();
            AdministrationViewModel.Model.Articles = xmlImport.ImportArticles();
            OnPropertyChanged("AdministrationViewModel");

        }

        private void ExportArticlesToXmlFileMethod()
        {
            XmlBuilder xmlBuilder = new XmlBuilder();
            xmlBuilder.ExportArticleCollectionToXMLFile(AdministrationViewModel.Articles.Model);
        }




        private void DeleteClientsCommandMethod()
        {
            for (int i = 0; i < AdministrationViewModel.Clients.Count; i++)
            {
                if (AdministrationViewModel.Clients[i].IsSelected)
                {
                    AdministrationViewModel.Clients.RemoveAt(i);
                }
            }
        }

        private void OpenNewClientWindowMethod()
        {
            OpenNewClientWindowMessage messageObject = new OpenNewClientWindowMessage();
            Messenger.Instance.Send<OpenNewClientWindowMessage>(messageObject);
        }
        private void ExportClientsToXmlFileMethod()
        {
            XmlBuilder xmlBuilder = new XmlBuilder();
            xmlBuilder.ExportClientCollectionToXMLFile(AdministrationViewModel.Clients.Model);
        }

        private void ImportClients()
        {
            XmlImport xmlImport = new XmlImport();
            AdministrationViewModel.Model.Clients = xmlImport.ImportClients();
            OnPropertyChanged("AdministrationViewModel");

        }

        private void ConvertToOrderCommandMethodWithParameter()
        {
            OrderViewModel order = new OrderViewModel()
            {
                OrderId = AdministrationViewModel.Model.getOrderIdFromCreation(),
                Positions = SelectedOffer.Positions,
                Reference = SelectedOffer.Reference,
                Date = SelectedOffer.Date,
                Text = SelectedOffer.Text,
                Client = SelectedOffer.Client
            };
            order.SetOrderNr(order.OrderId);
            order.Model.setPositonId(SelectedOffer.Model.getPositonId());

            AdministrationViewModel.Orders.Add(order);
        }


        private void ConvertToInvoiceMethodWithParameter()
        {
            InvoiceViewModel invoice = new InvoiceViewModel()
            {
                OrderId = SelectedOrder.OrderId,
                OrderNr = SelectedOrder.OrderNr,
                InvoiceId = AdministrationViewModel.Model.getInvoiceIdFromCreation(),
                Positions = SelectedOrder.Positions,
                Reference = SelectedOrder.Reference,
                Date = SelectedOrder.Date,
                Text = SelectedOrder.Text,
                Client = SelectedOrder.Client
            };
            invoice.SetInvoiceNr(invoice.InvoiceId);
            invoice.Model.setPositonId(SelectedOrder.Model.getPositonId());

            AdministrationViewModel.Invoices.Add(invoice);
        }


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
