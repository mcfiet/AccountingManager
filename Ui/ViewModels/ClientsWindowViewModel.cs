using De.HsFlensburg.ClientApp078.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp078.Services.MessageBus;
using De.HsFlensburg.ClientApp078.Services.MessageBusWithParameter;
using De.HsFlensburg.ClientApp078.Services.SerializationService;
using Services.XmlBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.ViewModels
{
    public class ClientsWindowViewModel
    {

        public ICommand OpenNewClientWindowCommand { get; }
        public ICommand ExportClientsToXmlCommand { get; }
        public ClientCollectionViewModel ClientList { get; set; }

        public ClientsWindowViewModel(AdministrationViewModel givenAdministrationViewModel)
        {

            OpenNewClientWindowCommand = new RelayCommand(OpenNewClientWindowMethod);
            ExportClientsToXmlCommand = new RelayCommand(ExportClientsToXmlFileMethod);

            ClientList = givenAdministrationViewModel.Clients;

        }

        private void OpenNewClientWindowMethod()
        {
            OpenNewClientWindowMessage messageObject = new OpenNewClientWindowMessage();
            Messenger.Instance.Send<OpenNewClientWindowMessage>(messageObject);
        }
        private void ExportClientsToXmlFileMethod()
        {
            XmlBuilder xmlBuilder = new XmlBuilder();
            xmlBuilder.ExportClientCollectionToHtmlFile(ClientList.Model);
        }
        //private void OpenNewClientWindowMethod()
        //{
        //    ServiceBus.Instance.Send(new OpenNewClientWindowMessage());
        //}

    }
}
