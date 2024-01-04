using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects
{
    [Serializable]
    public class Position : INotifyPropertyChanged
    {
        private bool isSelected;
        public bool IsSelected
        {
            get
            {
                return isSelected;
            }
            set
            {
                isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        private int positionNr;
        public int PositionNr
        {
            get
            {
                return positionNr;
            }
            set
            {
                positionNr = value;
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

        public float TotalPrice
        {
            get
            {
                return quantity * article.Price;
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
