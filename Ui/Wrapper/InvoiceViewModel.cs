using De.HsFlensburg.ClientApp078.Logic.Ui.Base;
using De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper
{
    public class InvoiceViewModel : ViewModelBase<Invoice>
    {
        public InvoiceViewModel() : base()
        {
            //OfferItems = new OfferItemCollectionViewModel();
            //OfferItems.Model = this.Model.OfferItems;
        }

        public OfferItemCollectionViewModel OfferItems
        {
            get
            {
                var offerItems = new OfferItemCollectionViewModel();
                offerItems.Model = Model.OfferItems;
                return offerItems;
            }
            set
            {
                this.Model.OfferItems = value.Model;

            }
        }

        public int OrderNr
        {
            get
            {
                return Model.OrderNr;
            }
            set
            {
                Model.OrderNr = value;

            }
        }

        public int InvoiceNr
        {
            get
            {
                return Model.InvoiceNr;
            }
            set
            {
                Model.InvoiceNr = value;

            }
        }

        public string Reference
        {
            get
            {
                return Model.Reference;
            }
            set
            {
                Model.Reference = value;

            }
        }
        public string Date
        {
            get
            {
                return Model.Date;
            }
            set
            {
                Model.Date = value;

            }
        }

        public string Text
        {
            get
            {
                return Model.Text;
            }
            set
            {
                Model.Text = value;

            }
        }
        public ClientViewModel Client
        {
            get
            {
                var client = new ClientViewModel();
                client.Model = Model.Client;
                return client;
            }
            set
            {
                this.Model.Client = value.Model;
            }
        }


        public float TotalPrice
        {
            get
            {
                return Model.TotalPrice;
            }
        }
        //public override void NewModelAssigned()
        //{
        //    if (this.OfferItems != null)
        //    {
        //        OfferItems.Model = this.Model?.OfferItems;
        //    }

        //}
        //internal void OnPropertyChangedInModel(object sender, PropertyChangedEventArgs e)
        //{
        //    OnPropertyChanged(e.PropertyName);
        //}
    }
}
