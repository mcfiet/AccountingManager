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

        public RelayCommand OpenAddOfferItemWindowCommand { get; }
        public RelayCommand ExportPdfCommand { get; }
        public AdministrationViewModel AdministrationViewModel { get; set; }
        public OrderWindowViewModel(AdministrationViewModel givenAdministrationViewModel)
        {
            
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
