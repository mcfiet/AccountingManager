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

        public string getOfferNr(int id)
        {
            return AccountingNumber.CreateOfferNrFromId(id+1);
        }

      
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }


        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;


    }
}
