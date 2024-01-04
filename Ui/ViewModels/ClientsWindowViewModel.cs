using De.HsFlensburg.ClientApp078.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp078.Services.MessageBusWithParameter;
using De.HsFlensburg.ClientApp078.Services.SerializationService;
using Services.XmlBuilder;
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
    public class ClientsWindowViewModel : INotifyPropertyChanged
    {

        public ICommand OpenNewClientWindowCommand { get; }
        public ICommand ExportClientsToXmlCommand { get; }
        public ICommand ImportClientsCommand { get; }
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


        public ClientsWindowViewModel(AdministrationViewModel givenAdministrationViewModel)
        {

            OpenNewClientWindowCommand = new RelayCommand(OpenNewClientWindowMethod);
            ExportClientsToXmlCommand = new RelayCommand(ExportClientsToXmlFileMethod);
            ImportClientsCommand = new RelayCommand(ImportClients);
            CloseWindow = new RelayCommand(param => CloseWPFWindow(param));

            AdministrationViewModel = givenAdministrationViewModel;

        }

        private void OpenNewClientWindowMethod()
        {
            OpenNewOfferItemWindowMessage messageObject = new OpenNewOfferItemWindowMessage();
            Messenger.Instance.Send<OpenNewOfferItemWindowMessage>(messageObject);
        }
        private void ExportClientsToXmlFileMethod()
        {
            XmlBuilder xmlBuilder = new XmlBuilder();
            xmlBuilder.ExportClientCollectionToHtmlFile(AdministrationViewModel.Clients.Model);
        }
        private void CloseWPFWindow(object param)
        {
            Window window = (Window)param;
            window.Close();
        }
        private void ImportClients()
        {
            XmlImport xmlImport = new XmlImport();
            AdministrationViewModel.Model.Clients = xmlImport.ImportClients();
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
