using De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp078.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp078.Services.MessageBus;
using De.HsFlensburg.ClientApp078.Services.MessageBusWithParameter;
using De.HsFlensburg.ClientApp078.Services.PdfExport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.ViewModels
{
    public class OfferWindowViewModel : INotifyPropertyChanged
    {

        public ClientViewModel SelectedClient { get; set; }
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

        public ICommand UpdateOfferCommand { get; }
        public ICommand OpenAddOfferItemWindowCommand { get; }
        public ICommand ExportPdfCommand { get; }
        public OfferCollectionViewModel offerCollection;
        public ClientCollectionViewModel ClientList { get; set; }
        public OfferCollectionViewModel OfferList { get; set; }
        public OfferWindowViewModel(AdministrationViewModel givenAdministrationViewModel)
        {
            UpdateOfferCommand = new RelayCommand(UpdateOfferMethod);
            OpenAddOfferItemWindowCommand = new RelayCommand(OpenAddOfferItemWindowWithParameter);
            ExportPdfCommand = new RelayCommand(ExportPdf);
            offerCollection = givenAdministrationViewModel.Offers;

            OfferList = givenAdministrationViewModel.Offers;

            ClientList = givenAdministrationViewModel.Clients;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;



        private void UpdateOfferMethod()
        {

        }

        private void ExportPdf()
        {

            PdfExportFileHandler pdf = new PdfExportFileHandler();
            pdf.PDFExport(IncomingOffer.Model);
        }

        private void OpenAddOfferItemWindow()
        {

            ServiceBus.Instance.Send(new OpenAddOfferItemWindowMessage());

        }
        private void OpenAddOfferItemWindowWithParameter()
        {

            OpenAddOfferItemWindowMessage messageObject = new OpenAddOfferItemWindowMessage();
            messageObject.Message = IncomingOffer;
            Messenger.Instance.Send<OpenAddOfferItemWindowMessage>(messageObject);

        }
    }
}
