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

        public RelayCommand OpenAddPositionWindowCommand { get; }
        public RelayCommand ExportPdfCommand { get; }
        public RelayCommand DeletePositionsCommand { get; }
        public OrderWindowViewModel()
        {
            
            OpenAddPositionWindowCommand = new RelayCommand(OpenAddPositionWindowWithParameter);
            DeletePositionsCommand = new RelayCommand(DeletePositionsMethod);
            ExportPdfCommand = new RelayCommand(ExportPdf);
        }

        private void DeletePositionsMethod()
        {

            for (int i = 0; i < IncomingOrder.Positions.Count; i++)
            {
                if (IncomingOrder.Positions[i].IsSelected)
                {
                    IncomingOrder.Positions.RemoveAt(i);
                }
            }
            for (int i = 0; i < IncomingOrder.Positions.Count; i++)
            {
                IncomingOrder.Positions[i].PositionNr = i + 1;

            }

            OnPropertyChanged("IncomingOrder");
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
