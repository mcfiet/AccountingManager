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
        public ClientCollectionViewModel ClientList { get; set; }
        public OfferCollectionViewModel OfferList { get; set; }
        public OrderCollectionViewModel OrderList { get; set; }
        public InvoiceCollectionViewModel InvoiceList { get; set; }
        public AdministrationViewModel Administration { get; set; }
        public OrderWindowViewModel(AdministrationViewModel givenAdministrationViewModel)
        {
            ConvertToInvoiceCommand = new RelayCommand(ConvertToInvoiceMethodWithParameter);
/*            OpenAddOfferItemWindowCommand = new RelayCommand(OpenAddOfferItemWindowWithParameter);
            ExportPdfCommand = new RelayCommand(ExportPdf);*/

            Administration = givenAdministrationViewModel;

            OfferList = Administration.Offers;
            OrderList = Administration.Orders;
            InvoiceList = Administration.Invoices;
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



        private void ConvertToInvoiceMethodWithParameter()
        {
            InvoiceViewModel invoice = new InvoiceViewModel()
            {
                OrderNr = IncomingOrder.OrderNr,
                InvoiceNr = Administration.Model.getInvoiceIdFromCreation(),
                OfferItems = IncomingOrder.OfferItems,
                Reference = IncomingOrder.Reference,
                Date = IncomingOrder.Date,
                Text = IncomingOrder.Text,
                Client = IncomingOrder.Client
            };

            InvoiceList.Add(invoice);
        }

/*        private void ExportPdf()
        {

            PdfExportFileHandler pdf = new PdfExportFileHandler();
            pdf.PDFExport(IncomingOrder.Model);
        }*/

        private void OpenAddOfferItemWindow()
        {

            ServiceBus.Instance.Send(new OpenAddOfferItemWindowMessage());

        }
/*        private void OpenAddOfferItemWindowWithParameter()
        {

            OpenAddOfferItemWindowMessage messageObject = new OpenAddOfferItemWindowMessage();
            messageObject.Message = IncomingOffer;
            Messenger.Instance.Send<OpenAddOfferItemWindowMessage>(messageObject);

        }*/
    }
}
