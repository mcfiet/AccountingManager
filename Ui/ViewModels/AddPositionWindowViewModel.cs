using De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp078.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp078.Services.MessageBusWithParameter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.ViewModels
{
    public class AddPositionWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ArticleViewModel SelectedArticle { get; set; }
        public int Quantity { get; set; }

        public RelayCommand AddPositionCommand { get; }
        public RelayCommand CloseWindowCommand { get; }


        public OfferViewModel incomingOffer;
        public OfferViewModel IncomingOffer
        {
            get { return incomingOffer; }
            set
            {
                incomingOffer = value;
                OnPropertyChanged("IncomingOffer");
            }
        }
        public OrderViewModel incomingOrder;
        public OrderViewModel IncomingOrder
        {
            get { return incomingOrder; }
            set
            {
                incomingOrder = value;
                OnPropertyChanged("IncomingOrder");
            }
        }
        public InvoiceViewModel incomingInvoice;
        public InvoiceViewModel IncomingInvoice
        {
            get { return incomingInvoice; }
            set
            {
                incomingInvoice = value;
                OnPropertyChanged("IncomingInvoice");
            }
        }

        public AdministrationViewModel TheAdministrationViewModel { get; set; }

        public AddPositionWindowViewModel(AdministrationViewModel givenAdministrationViewModel)
        {
            AddPositionCommand = new RelayCommand(AddPositionMethod);
            CloseWindowCommand = new RelayCommand(param => CloseWPFWindow(param));
            TheAdministrationViewModel = givenAdministrationViewModel;

        }

        private void CloseWPFWindow(object param)
        {
            Window window = (Window)param;
            window.Close();
        }


        private void AddPositionMethod()
        {

            PositionViewModel position = new PositionViewModel
            {
                Article = SelectedArticle,
                Quantity = Quantity
            };

            if (IncomingOffer != null)
            {
                IncomingOffer.Positions.Add(position);
                for (int i = 0; i < IncomingOffer.Positions.Count; i++)
                {
                    IncomingOffer.Positions[i].PositionNr = i + 1;
                }
                OnPropertyChanged("IncomingOffer");
            } else if (IncomingOrder != null)
            {
                IncomingOrder.Positions.Add(position);
                for (int i = 0; i < IncomingOrder.Positions.Count; i++)
                {
                    IncomingOrder.Positions[i].PositionNr = i + 1;
                }
                OnPropertyChanged("IncomingOrder");
            } else if (IncomingInvoice != null)
            {
                IncomingInvoice.Positions.Add(position);
                for (int i = 0; i < IncomingInvoice.Positions.Count; i++)
                {
                    IncomingInvoice.Positions[i].PositionNr = i + 1;
                }
                OnPropertyChanged("IncomingInvoice");
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

}
