using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects
{
    [Serializable]
    public class Offer : Accounting 
    {


        private int offerId;
        public int OfferId
        {
            get
            {
                return offerId;
            }
            set
            {
                offerId = value;
                OnPropertyChanged("OfferNr");

            }
        }

        private string offerNr;

        public string OfferNr
        {
            get
            {
                return offerNr;
            }
            set
            {
                offerNr = value;
                OnPropertyChanged("OfferNr");
            }
        }
        
        private bool isOrder;

        public bool IsOrder
        {
            get
            {
                return isOrder;
            }
            set
            {
                isOrder = value;
                OnPropertyChanged("IsOrder");
            }
        }

        

        public string getOfferNr(int id)
        {
            return AccountingNumber.CreateOfferNrFromId(id+1);
        }
    }
}
