using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects
{
    [Serializable]
    public abstract class Accounting : INotifyPropertyChanged
    {
        private int offerItemId;

        public int getOfferItemIdFromCreation()
        {
            return offerItemId++;
        }
        public OfferItemCollection OfferItems { get; set; }
        public Accounting()
        {
            OfferItems = new OfferItemCollection();
        }


        private string reference;
        public string Reference
        {
            get
            {
                return reference;
            }
            set
            {
                reference = value;
                OnPropertyChanged("Reference");

            }
        }



        private string date;
        public string Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
                OnPropertyChanged("Date");

            }
        }
        private string text;
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                OnPropertyChanged("Text");

            }
        }
        private Client client;
        public Client Client
        {
            get
            {
                return client;
            }
            set
            {
                client = value;
                OnPropertyChanged("Client");

            }
        }

        public float TotalPrice
        {
            get
            {
                float sum = 0;
                foreach (var item in OfferItems)
                {
                    sum += item.TotalPrice;
                }
                return sum;
            }
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


