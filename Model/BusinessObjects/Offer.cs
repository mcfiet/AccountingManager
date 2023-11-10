using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects
{
    [Serializable]
    public class Offer : INotifyPropertyChanged
    {
        private int offerNr;
        public int OfferNr
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

        private String reference;
        public String Reference
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
        private String date;
        public String Date
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
        private String text;
        public String Text
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

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }


        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;


    }
}
