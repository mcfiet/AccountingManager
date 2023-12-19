using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects
{
    [Serializable]
    public class Client : INotifyPropertyChanged
    {
        private int id;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("Id");

            }
        }

        private String name;
        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");

            }
        }
        
        private String street;
        public String Street
        {
            get
            {
                return street;
            }
            set
            {
                street = value;
                OnPropertyChanged("Street");

            }
        }
        
        private int houseNumber;
        public int HouseNumber
        {
            get
            {
                return houseNumber;
            }
            set
            {
                houseNumber = value;
                OnPropertyChanged("HouseNumber");

            }
        }
        
        private int zipCode;
        public int ZipCode
        {
            get
            {
                return zipCode;
            }
            set
            {
                zipCode = value;
                OnPropertyChanged("ZipCode");

            }
        }
        
        private String city;
        public String City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
                OnPropertyChanged("City");

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
