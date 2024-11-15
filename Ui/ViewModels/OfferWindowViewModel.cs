﻿using De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp078.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp078.Services.MessageBusWithParameter;
using De.HsFlensburg.ClientApp078.Services.PdfExport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.ViewModels
{
    public class OfferWindowViewModel : INotifyPropertyChanged
    {

        private ClientViewModel selectedClient;
        public ClientViewModel SelectedClient
        {
            get
            {
                return selectedClient;
            }
            set
            {
                selectedClient = value;
                IncomingOffer.Text = "Sehr geehrte/r " + selectedClient.LastName + ",\n\ngerne bieten wir Ihnen folgende Produkte an.";
                OnPropertyChanged("SelectedClient");
            }
        }
        private OfferViewModel incomingOffer;
        public OfferViewModel IncomingOffer
        {
            get
            {
                return incomingOffer;
            }
            set
            {
                incomingOffer = value;
                OnPropertyChanged("IncomingOffer");
            }
        }

        public RelayCommand OpenAddPositionWindowCommand { get; }
        public RelayCommand ExportPdfCommand { get; }
        public RelayCommand AddOfferCommand { get; }
        public RelayCommand DeletePositionsCommand { get; }
        public AdministrationViewModel TheAdministrationViewModel { get; set; }
        public Button NewBtn { get; set; }
        public OfferWindowViewModel(AdministrationViewModel givenAdministrationViewModel)
        {
            OpenAddPositionWindowCommand = new RelayCommand(OpenAddPositionWindowWithParameter);
            DeletePositionsCommand = new RelayCommand(DeletePositionsMethod);
            ExportPdfCommand = new RelayCommand(ExportPdf);
            AddOfferCommand = new RelayCommand(param => AddOfferMethod(param));
            TheAdministrationViewModel = givenAdministrationViewModel;
            NewBtn = new Button
            {
                Content = "Angebot hinzufügen",
                Name = "AddOfferBtn",
                Style = (Style)Application.Current.TryFindResource("RoundeButton"),
                Command = AddOfferCommand,
            };
        }

        private void DeletePositionsMethod()
        {

            for (int i = 0; i < IncomingOffer.Positions.Count; i++)
            {
                if (IncomingOffer.Positions[i].IsSelected)
                {
                    IncomingOffer.Positions.RemoveAt(i);
                }
            }
            for (int i = 0; i < IncomingOffer.Positions.Count; i++)
            {
                IncomingOffer.Positions[i].PositionNr = i+1;
                
            }

            OnPropertyChanged("IncomingOffer");
        }



        private void ExportPdf()
        {

            PdfExportFileHandler pdf = new PdfExportFileHandler();
            pdf.PDFExport(IncomingOffer.Model);
        }
        private void OpenAddPositionWindowWithParameter()
        {

            OpenAddOfferItemWindowMessage messageObject = new OpenAddOfferItemWindowMessage();
            messageObject.OfferMessage = IncomingOffer;
            Messenger.Instance.Send<OpenAddOfferItemWindowMessage>(messageObject);

        }

        private void AddOfferMethod(object param)
        {
            IncomingOffer.Client = SelectedClient;
            TheAdministrationViewModel.Offers.Add(IncomingOffer);
            Window window = (Window)param;
            object wantedNode = window.FindName("OfferButtons");
            if (wantedNode is Grid)
            {
                Grid wantedChild = wantedNode as Grid;
                wantedChild.Children.Remove(NewBtn);
            }
           
            window.Close();
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
