using De.HsFlensburg.ClientApp078.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp078.Services.MessageBusWithParameter;
using De.HsFlensburg.ClientApp078.Services.PdfExport;
using System.ComponentModel;
using System.Windows.Input;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.ViewModels
{
    public class OrderWindowViewModel : INotifyPropertyChanged
    {

        public ClientViewModel SelectedClient { get; set; }
        private OrderViewModel incomingOrder;
        public OrderViewModel IncomingOrder
        {
            get
            {
                return incomingOrder;
            }
            set
            {
                incomingOrder = value;
                OnPropertyChanged("IncomingOrder");
            }
        }

        public ICommand ConvertToInvoiceCommand { get; }
        public ICommand OpenAddOfferItemWindowCommand { get; }
        public ICommand ExportPdfCommand { get; }
        public AdministrationViewModel AdministrationViewModel { get; set; }
        public OrderWindowViewModel(AdministrationViewModel givenAdministrationViewModel)
        {
            ConvertToInvoiceCommand = new RelayCommand(ConvertToInvoiceMethodWithParameter);
            OpenAddOfferItemWindowCommand = new RelayCommand(OpenAddPositionWindowWithParameter);
            ExportPdfCommand = new RelayCommand(ExportPdf);

            AdministrationViewModel = givenAdministrationViewModel;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;



        private void ConvertToInvoiceMethodWithParameter()
        {
            InvoiceViewModel invoice = new InvoiceViewModel()
            {
                OrderId = IncomingOrder.OrderId,
                OrderNr = IncomingOrder.OrderNr,
                InvoiceId = AdministrationViewModel.Model.getInvoiceIdFromCreation(),
                Positions = IncomingOrder.Positions,
                Reference = IncomingOrder.Reference,
                Date = IncomingOrder.Date,
                Text = IncomingOrder.Text,
                Client = IncomingOrder.Client
            };
            invoice.SetInvoiceNr(invoice.InvoiceId);
            invoice.Model.setPositonId(IncomingOrder.Model.getPositonId());

            AdministrationViewModel.Invoices.Add(invoice);
        }

        private void ExportPdf()
        {

            PdfExportFileHandler pdf = new PdfExportFileHandler();
            pdf.PDFExport(IncomingOrder.Model);
        }

        private void OpenAddPositionWindowWithParameter()
        {

            OpenAddOfferItemWindowMessage messageObject = new OpenAddOfferItemWindowMessage();
            messageObject.OrderMessage = IncomingOrder;
            Messenger.Instance.Send<OpenAddOfferItemWindowMessage>(messageObject);

        }
    }
}
