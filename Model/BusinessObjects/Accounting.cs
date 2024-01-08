using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects
{
    [Serializable]
    public class Accounting : INotifyPropertyChanged
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


        private int positionId;

        public int getPositionIdFromCreation()
        {
            return positionId++;
        }
        public void setPositonId(int id)
        {
            positionId = id;
        }
        public int getPositonId()
        {
            return positionId;
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
        public Client Client { get; set; }

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


