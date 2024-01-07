using De.HsFlensburg.ClientApp078.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp078.Services.MessageBusWithParameter;
using De.HsFlensburg.ClientApp078.Services.SerializationService;
using Microsoft.Win32;
using Services.XmlBuilder;
using Services.XmlImport;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ModelFileHandler modelFileHandler;

        public AdministrationViewModel AdministrationViewModel { get; set; }
        public OfferViewModel SelectedOffer { get; set; }
        public OrderViewModel SelectedOrder { get; set; }
        public InvoiceViewModel SelectedInvoice { get; set; }
        public MainWindowCommands Commands { get; }
        public MainWindowViewModel(AdministrationViewModel givenAdministrationViewModel)
        {
            AdministrationViewModel = givenAdministrationViewModel;
            modelFileHandler = new ModelFileHandler();
            Commands = new MainWindowCommands(this);
        }

        public void OpenNewOfferWindowMethodWithParameter()
        {
            OpenOfferWindowMessage messageObject = new OpenOfferWindowMessage();

            messageObject.IncomingOffer = new OfferViewModel()
            {
                OfferId = AdministrationViewModel.Model.getOfferIdFromCreation(),
                Date = DateTime.Now,
                Client = new ClientViewModel()
            };
            messageObject.IncomingOffer.SetOfferNr(messageObject.IncomingOffer.OfferId);
            messageObject.NewOffer = true;
            Messenger.Instance.Send<OpenOfferWindowMessage>(messageObject);
        }
        public void OpenOfferWindowMethodWithParameter()
        {
            if (SelectedOffer == null)
            {
                OpenErrorWindowMessage messageObject = new OpenErrorWindowMessage();
                messageObject.Message = "Kein Angebot ausgewählt";
                Messenger.Instance.Send<OpenErrorWindowMessage>(messageObject);
            }
            else
            {
                OpenOfferWindowMessage messageObject = new OpenOfferWindowMessage();
                messageObject.IncomingOffer = SelectedOffer;
                Messenger.Instance.Send<OpenOfferWindowMessage>(messageObject);
            }

        }
        public void OpenOfferMethodWithParameter(object param)
        {
            OfferViewModel offer = (OfferViewModel)param;
            if (offer == null)
            {
                OpenErrorWindowMessage messageObject = new OpenErrorWindowMessage();
                messageObject.Message = "Kein Angebot ausgewählt";
                Messenger.Instance.Send<OpenErrorWindowMessage>(messageObject);
            }
            else
            {
                OpenOfferWindowMessage messageObject = new OpenOfferWindowMessage();
                messageObject.IncomingOffer = offer;
                Messenger.Instance.Send<OpenOfferWindowMessage>(messageObject);
            }

        }

        public void ConvertToOrderCommandMethodWithParameter(object param)
        {
            OfferViewModel offer = (OfferViewModel)param;
            if (offer != null)
            {
                if (!offer.IsOrder)
                {
                    OrderViewModel order = new OrderViewModel()
                    {
                        OrderId = AdministrationViewModel.Model.getOrderIdFromCreation(),
                        Positions = offer.Positions,
                        Reference = offer.Reference,
                        Date = offer.Date,
                        Text = offer.Text,
                        Client = offer.Client,
                    };
                    offer.IsOrder = true;

                    order.SetOrderNr(order.OrderId);
                    order.Model.setPositonId(offer.Model.getPositonId());
                    AdministrationViewModel.Orders.Add(order);
                    OnPropertyChanged("AdministrationViewModel");
                }
                else
                {
                    OpenErrorWindowMessage messageObject = new OpenErrorWindowMessage();
                    messageObject.Message = "Auftrag ist schon eine Rechnung";
                    Messenger.Instance.Send<OpenErrorWindowMessage>(messageObject);
                }
            }
            else
            {
                OpenErrorWindowMessage messageObject = new OpenErrorWindowMessage();
                messageObject.Message = "Kein Angebot ausgewählt";
                Messenger.Instance.Send<OpenErrorWindowMessage>(messageObject);
            }

        }

        public void DeleteOffersCommandMethod()
        {
            for (int i = 0; i < AdministrationViewModel.Offers.Count; i++)
            {
                if (AdministrationViewModel.Offers[i].IsSelected)
                {
                    AdministrationViewModel.Offers.RemoveAt(i);
                }
            }

        }

        public void OpenOrderWindowMethodWithParameter(object param)
        {
            OrderViewModel order = (OrderViewModel)param;
            if (order != null)
            {
                OpenOrderWindowMessage messageObject = new OpenOrderWindowMessage();
                messageObject.IncomingOrder = order;
                Messenger.Instance.Send<OpenOrderWindowMessage>(messageObject);
            }
            else
            {
                OpenErrorWindowMessage messageObject = new OpenErrorWindowMessage();
                messageObject.Message = "Kein Auftrag ausgewählt";
                Messenger.Instance.Send<OpenErrorWindowMessage>(messageObject);
            }

        }

        public void ConvertToInvoiceMethodWithParameter(object param)
        {
            OrderViewModel order = (OrderViewModel)param;
            if (order != null)
            {
                if (!order.IsInvoice)
                {
                    InvoiceViewModel invoice = new InvoiceViewModel()
                    {
                        OrderId = order.OrderId,
                        OrderNr = order.OrderNr,
                        InvoiceId = AdministrationViewModel.Model.getInvoiceIdFromCreation(),
                        Positions = order.Positions,
                        Reference = order.Reference,
                        Date = order.Date,
                        Text = order.Text,
                        Client = order.Client
                    };
                    order.IsInvoice = true;
                    invoice.SetInvoiceNr(invoice.InvoiceId);
                    invoice.Model.setPositonId(order.Model.getPositonId());

                    AdministrationViewModel.Invoices.Add(invoice);
                    OnPropertyChanged("AdministrationViewModel");
                }
                else
                {
                    OpenErrorWindowMessage messageObject = new OpenErrorWindowMessage();
                    messageObject.Message = "Angebot ist schon ein Auftrag";
                    Messenger.Instance.Send<OpenErrorWindowMessage>(messageObject);
                }

            }
            else
            {
                OpenErrorWindowMessage messageObject = new OpenErrorWindowMessage();
                messageObject.Message = "Kein Auftrag ausgewählt";
                Messenger.Instance.Send<OpenErrorWindowMessage>(messageObject);
            }

        }

        public void DeleteOrdersCommandMethod()
        {

            for (int i = 0; i < AdministrationViewModel.Orders.Count; i++)
            {
                if (AdministrationViewModel.Orders[i].IsSelected)
                {
                    AdministrationViewModel.Orders.RemoveAt(i);
                }
            }

        }

        public void OpenInvoiceWindowMethodWithParameter(object param)
        {
            InvoiceViewModel invoice = (InvoiceViewModel)param;
            if (invoice != null)
            {
                OpenInvoiceWindowMessage messageObject = new OpenInvoiceWindowMessage();
                messageObject.IncomingInvoice = invoice;
                Messenger.Instance.Send<OpenInvoiceWindowMessage>(messageObject);
            }
            else
            {
                OpenErrorWindowMessage messageObject = new OpenErrorWindowMessage();
                messageObject.Message = "Keine Rechnung ausgewählt";
                Messenger.Instance.Send<OpenErrorWindowMessage>(messageObject);
            }

        }

        public void DeleteInvoicesCommandMethod()
        {

            for (int i = 0; i < AdministrationViewModel.Invoices.Count; i++)
            {
                if (AdministrationViewModel.Invoices[i].IsSelected)
                {
                    AdministrationViewModel.Invoices.RemoveAt(i);
                }
            }

        }

        public void OpenNewArticleWindowMethodWithParameter()
        {
            OpenNewArticleWindowMessage messageObject = new OpenNewArticleWindowMessage();
            Messenger.Instance.Send<OpenNewArticleWindowMessage>(messageObject);
        }

        public void ImportArticles()
        {
            XmlImport xmlImport = new XmlImport();
            AdministrationViewModel.Model.Articles = xmlImport.ImportArticles();
            OnPropertyChanged("AdministrationViewModel");

        }

        public void ExportArticlesToXmlFileMethod()
        {
            XmlBuilder xmlBuilder = new XmlBuilder();
            xmlBuilder.ExportArticleCollectionToXMLFile(AdministrationViewModel.Articles.Model);
        }


        public void DeleteArticlesCommandMethod()
        {
            for (int i = 0; i < AdministrationViewModel.Articles.Count; i++)
            {
                if (AdministrationViewModel.Articles[i].IsSelected)
                {
                    AdministrationViewModel.Articles.RemoveAt(i);
                }
            }
        }


        public void OpenNewClientWindowMethod()
        {
            OpenNewClientWindowMessage messageObject = new OpenNewClientWindowMessage();
            Messenger.Instance.Send<OpenNewClientWindowMessage>(messageObject);
        }
        public void ImportClients()
        {
            XmlImport xmlImport = new XmlImport();
            AdministrationViewModel.Model.Clients = xmlImport.ImportClients();
            OnPropertyChanged("AdministrationViewModel");

        }

        public void ExportClientsToXmlFileMethod()
        {
            XmlBuilder xmlBuilder = new XmlBuilder();
            xmlBuilder.ExportClientCollectionToXMLFile(AdministrationViewModel.Clients.Model);
        }

        public void DeleteClientsCommandMethod()
        {
            for (int i = 0; i < AdministrationViewModel.Clients.Count; i++)
            {
                if (AdministrationViewModel.Clients[i].IsSelected)
                {
                    AdministrationViewModel.Clients.RemoveAt(i);
                }
            }
        }
        public void LoadModel()
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

        public void SaveModel()
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


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
