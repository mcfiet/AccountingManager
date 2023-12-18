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

        private Article article;
        public Article Article
        {
            get
            {
                return article;
            }
            set
            {
                article = value;
                OnPropertyChanged("Article");

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

        private float totalPrice;
        public float TotalPrice
        {
            get
            {
                return totalPrice;
            }
            set
            {
                setTotalPrice();
                OnPropertyChanged("TotalPrice");
            }
        }

        public void setTotalPrice()
        {
            totalPrice = article.Price * quantity;
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
