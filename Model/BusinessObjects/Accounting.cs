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


        private int offerItemId;

        public int getPositionIdFromCreation()
        {
            return offerItemId++;
        }
        public void setPositonId(int id)
        {
            offerItemId = id;
        }
        public int getPositonId()
        {
            return offerItemId;
        }
        public PositionCollection Positions { get; set; }
        public Accounting()
        {
            Positions = new PositionCollection();
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



        private DateTime date;
        public DateTime Date
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
                foreach (Position position in Positions)
                {
                    sum += position.TotalPrice;
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


