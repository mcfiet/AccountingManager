using De.HsFlensburg.ClientApp078.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp078.Services.MessageBusWithParameter;
using De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper;
using System.ComponentModel;
using System.Windows.Input;
using De.HsFlensburg.ClientApp078.Services.PdfExport;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.ViewModels
{
    public class InvoiceWindowViewModel : INotifyPropertyChanged
    {

        public ClientViewModel SelectedClient { get; set; }
        private InvoiceViewModel incomingInvoice;
        public InvoiceViewModel IncomingInvoice
        {
            get
            {
                return incomingInvoice;
            }
            set
            {
                incomingInvoice = value;
                OnPropertyChanged("IncomingInvoice");
            }
        }

        public ICommand OpenAddOfferItemWindowCommand { get; }
        public ICommand ExportPdfCommand { get; }
        public ClientCollectionViewModel ClientList { get; set; }
        public OfferCollectionViewModel OfferList { get; set; }
        public OrderCollectionViewModel OrderList { get; set; }
        public AdministrationViewModel Administration { get; set; }
        public InvoiceWindowViewModel(AdministrationViewModel givenAdministrationViewModel)
        {
            OpenAddOfferItemWindowCommand = new RelayCommand(OpenAddPositionWindowWithParameter);
            ExportPdfCommand = new RelayCommand(ExportPdf);

            Administration = givenAdministrationViewModel;

            OfferList = Administration.Offers;
            OrderList = Administration.Orders;
            ClientList = Administration.Clients;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;



        private void ExportPdf()
        {

            PdfExportFileHandler pdf = new PdfExportFileHandler();
            pdf.PDFExport(IncomingInvoice.Model);
        }

        private void OpenAddPositionWindowWithParameter()
        {

            OpenAddOfferItemWindowMessage messageObject = new OpenAddOfferItemWindowMessage();
            messageObject.InvoiceMessage = IncomingInvoice;
            Messenger.Instance.Send<OpenAddOfferItemWindowMessage>(messageObject);

        }
    }
}
