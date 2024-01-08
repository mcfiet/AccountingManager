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

        public AdministrationViewModel TheAdministrationViewModel { get; set; }
        public MainWindowCommands Commands { get; }
        public MainWindowViewModel(AdministrationViewModel givenAdministrationViewModel)
        {
            TheAdministrationViewModel = givenAdministrationViewModel;
            modelFileHandler = new ModelFileHandler();
            Commands = new MainWindowCommands(this);
        }

        public void OpenNewOfferWindowMethodWithParameter()
        {
            OpenOfferWindowMessage messageObject = new OpenOfferWindowMessage();

            messageObject.IncomingOffer = new OfferViewModel()
            {
                OfferId = TheAdministrationViewModel.Model.GetOfferIdFromCreation(),
                Date = DateTime.Now,
                Client = new ClientViewModel()
            };
            messageObject.IncomingOffer.SetOfferNr(messageObject.IncomingOffer.OfferId);
            messageObject.NewOffer = true;
            Messenger.Instance.Send<OpenOfferWindowMessage>(messageObject);
        }
        public void OpenOfferMethodWithParameter(object param)
        {
            OfferViewModel offer = (OfferViewModel)param;
            OpenOfferWindowMessage messageObject = new OpenOfferWindowMessage();
            messageObject.IncomingOffer = offer;
            Messenger.Instance.Send<OpenOfferWindowMessage>(messageObject);

        }

        public void ConvertToOrderMethodWithParameter(object param)
        {
            OfferViewModel offer = (OfferViewModel)param;
            if (!offer.IsOrder)
            {
                OrderViewModel order = new OrderViewModel()
                {
                    OrderId = TheAdministrationViewModel.Model.GetOrderIdFromCreation(),
                    Positions = offer.Positions,
                    Reference = offer.Reference,
                    Date = offer.Date,
                    Text = offer.Text,
                    Client = offer.Client,
                };
                offer.IsOrder = true;

                order.SetOrderNr(order.OrderId);
                order.Model.setPositonId(offer.Model.getPositonId());
                TheAdministrationViewModel.Orders.Add(order);
                OnPropertyChanged("TheAdministrationViewModel");
            }
            else
            {
                OpenErrorWindowMessage messageObject = new OpenErrorWindowMessage();
                messageObject.Message = "Auftrag ist schon ein Auftrag";
                Messenger.Instance.Send<OpenErrorWindowMessage>(messageObject);
            }
        }

        public void DeleteOffersMethod()
        {
            for (int i = 0; i < TheAdministrationViewModel.Offers.Count; i++)
            {
                if (TheAdministrationViewModel.Offers[i].IsSelected)
                {
                    TheAdministrationViewModel.Offers.RemoveAt(i);
                }
            }

        }

        public void OpenOrderWindowMethodWithParameter(object param)
        {
            OrderViewModel order = (OrderViewModel)param;
            OpenOrderWindowMessage messageObject = new OpenOrderWindowMessage();
            messageObject.IncomingOrder = order;
            Messenger.Instance.Send<OpenOrderWindowMessage>(messageObject);
        }

        public void ConvertToInvoiceMethodWithParameter(object param)
        {
            OrderViewModel order = (OrderViewModel)param;
            if (!order.IsInvoice)
            {
                InvoiceViewModel invoice = new InvoiceViewModel()
                {
                    OrderId = order.OrderId,
                    OrderNr = order.OrderNr,
                    InvoiceId = TheAdministrationViewModel.Model.GetInvoiceIdFromCreation(),
                    Positions = order.Positions,
                    Reference = order.Reference,
                    Date = order.Date,
                    Text = order.Text,
                    Client = order.Client
                };
                order.IsInvoice = true;
                invoice.SetInvoiceNr(invoice.InvoiceId);
                invoice.Model.setPositonId(order.Model.getPositonId());

                TheAdministrationViewModel.Invoices.Add(invoice);
                OnPropertyChanged("TheAdministrationViewModel");
            }
            else
            {
                OpenErrorWindowMessage messageObject = new OpenErrorWindowMessage();
                messageObject.Message = "Angebot ist schon ein Auftrag";
                Messenger.Instance.Send<OpenErrorWindowMessage>(messageObject);
            }

        }

        public void DeleteOrdersMethod()
        {

            for (int i = 0; i < TheAdministrationViewModel.Orders.Count; i++)
            {
                if (TheAdministrationViewModel.Orders[i].IsSelected)
                {
                    TheAdministrationViewModel.Orders.RemoveAt(i);
                }
            }

        }

        public void OpenInvoiceWindowMethodWithParameter(object param)
        {
            InvoiceViewModel invoice = (InvoiceViewModel)param;
            OpenInvoiceWindowMessage messageObject = new OpenInvoiceWindowMessage();
            messageObject.IncomingInvoice = invoice;
            Messenger.Instance.Send<OpenInvoiceWindowMessage>(messageObject);
        }

        public void DeleteInvoicesMethod()
        {

            for (int i = 0; i < TheAdministrationViewModel.Invoices.Count; i++)
            {
                if (TheAdministrationViewModel.Invoices[i].IsSelected)
                {
                    TheAdministrationViewModel.Invoices.RemoveAt(i);
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
            TheAdministrationViewModel.Model.Articles = xmlImport.ImportArticles();
            OnPropertyChanged("TheAdministrationViewModel");

        }

        public void ExportArticlesToXmlFileMethod()
        {
            XmlBuilder xmlBuilder = new XmlBuilder();
            xmlBuilder.ExportArticleCollectionToXMLFile(TheAdministrationViewModel.Articles.Model);
        }


        public void DeleteArticlesMethod()
        {
            for (int i = 0; i < TheAdministrationViewModel.Articles.Count; i++)
            {
                if (TheAdministrationViewModel.Articles[i].IsSelected)
                {
                    TheAdministrationViewModel.Articles.RemoveAt(i);
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
            TheAdministrationViewModel.Model.Clients = xmlImport.ImportClients();
            OnPropertyChanged("TheAdministrationViewModel");

        }

        public void ExportClientsToXmlFileMethod()
        {
            XmlBuilder xmlBuilder = new XmlBuilder();
            xmlBuilder.ExportClientCollectionToXMLFile(TheAdministrationViewModel.Clients.Model);
        }

        public void DeleteClientsMethod()
        {
            for (int i = 0; i < TheAdministrationViewModel.Clients.Count; i++)
            {
                if (TheAdministrationViewModel.Clients[i].IsSelected)
                {
                    TheAdministrationViewModel.Clients.RemoveAt(i);
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
            TheAdministrationViewModel.Model = modelFileHandler.ReadModelFromFile(dir);
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
            modelFileHandler.WriteModelToFile(dir, TheAdministrationViewModel.Model);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
