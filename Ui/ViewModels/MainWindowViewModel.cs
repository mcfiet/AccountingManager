﻿using De.HsFlensburg.ClientApp078.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp078.Services.MessageBusWithParameter;
using De.HsFlensburg.ClientApp078.Services.SerializationService;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.ViewModels
{
    public class MainWindowViewModel
    {
        private ModelFileHandler modelFileHandler;
        private string pathForSerialization;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand SaveCommand { get; private set; }
        public ICommand LoadCommand { get; private set; }

        public ICommand OpenNewOfferWindowCommand { get; private set; }
        public ICommand OpenOfferWindowCommand { get; private set; }
        public ICommand OpenOrderWindowCommand { get; private set; }
        public ICommand OpenInvoiceWindowCommand { get; private set; }
        public ICommand OpenClientsWindowCommand { get; private set; }
        public ICommand OpenArticlesWindowCommand { get; private set; }
        public ICommand DeleteOffersCommand { get; private set; }
        public ICommand DeleteOrdersCommand { get; private set; }
        public ICommand DeleteInvoicesCommand { get; private set; }

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
            OpenClientsWindowCommand = new RelayCommand(OpenClientsWindowMethodWithParameter);
            OpenArticlesWindowCommand = new RelayCommand(OpenArticlesWindowMethodWithParameter);
            DeleteOffersCommand = new RelayCommand(DeleteOffersCommandMethod);
            DeleteOrdersCommand = new RelayCommand(DeleteOrdersCommandMethod);
            DeleteInvoicesCommand = new RelayCommand(DeleteInvoicesCommandMethod);
        }

        private void OpenClientsWindowMethodWithParameter()
        {
            OpenClientsWindowMessage messageObject = new OpenClientsWindowMessage();
            Messenger.Instance.Send<OpenClientsWindowMessage>(messageObject);
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
        private void OpenArticlesWindowMethodWithParameter()
        {
            OpenArticlesWindowMessage messageObject = new OpenArticlesWindowMessage();
            Messenger.Instance.Send<OpenArticlesWindowMessage>(messageObject);
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


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
