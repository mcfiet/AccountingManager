using De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp078.Logic.Ui.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper
{
    public class OfferViewModel : ViewModelBase<Offer>
    {
        public OfferItemCollectionViewModel OfferItems { 
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

        public int OfferNr
        {
            get
            {
                return Model.OfferNr;
            }
            set
            {
                Model.OfferNr = value;

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
    }
}
