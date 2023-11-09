using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects
{
    [Serializable]
    public class OfferItem : INotifyPropertyChanged
    {
        private int offerItemNr;
        public int OfferItemNr
        {
            get
            {
                return offerItemNr;
            }
            set
            {
                offerItemNr = value;
                OnPropertyChanged("OfferItemNr");

            }
        }

        private int quantity;
        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
                OnPropertyChanged("Quantity");

            }
        }

        private int totalPrice;
        public int TotalPrice
        {
            get
            {
                return totalPrice;
            }
            set
            {
                totalPrice = value;
                OnPropertyChanged("TotalPrice");

            }
        }

        public float calcTotalPrice(Article article)
        {
            return article.Price * quantity;
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
