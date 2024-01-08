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

        public RelayCommand OpenAddPositionWindowCommand { get; }
        public RelayCommand ExportPdfCommand { get; }
        public RelayCommand DeletePositionsCommand { get; }

        public InvoiceWindowViewModel()
        {
            OpenAddPositionWindowCommand = new RelayCommand(OpenAddPositionWindowWithParameter);
            DeletePositionsCommand = new RelayCommand(DeletePositionsMethod);
            ExportPdfCommand = new RelayCommand(ExportPdf);
        }


        private void DeletePositionsMethod()
        {

            for (int i = 0; i < IncomingInvoice.Positions.Count; i++)
            {
                if (IncomingInvoice.Positions[i].IsSelected)
                {
                    IncomingInvoice.Positions.RemoveAt(i);
                }
            }
            for (int i = 0; i < IncomingInvoice.Positions.Count; i++)
            {
                IncomingInvoice.Positions[i].PositionNr = i + 1;

            }

            OnPropertyChanged("IncomingInvoice");
        }

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
