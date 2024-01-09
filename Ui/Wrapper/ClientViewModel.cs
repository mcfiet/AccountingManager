using De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp078.Logic.Ui.Base;
using System;
using System.ComponentModel;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper
{
    public class ClientViewModel: ViewModelBase<Client>
    {

        public bool IsSelected
        {
            get
            {
                return Model.IsSelected;
            }
            set
            {
                Model.IsSelected = value;
            }
        }
        public int Id
        {
            get
            {
                return Model.Id;
            }
            set
            {
                Model.Id = value;
            }
        }

        public String FirstName
        {
            get
            {
                return Model.FirstName;
            }
            set
            {
                Model.FirstName = value;
            }
        }
        

        public String LastName
        {
            get
            {
                return Model.LastName;
            }
            set
            {
                Model.LastName = value;
            }
        }

        public String Street
        {
            get
            {
                return Model.Street;
            }
            set
            {
                Model.Street = value;

            }
        }

        public int HouseNumber
        {
            get
            {
                return Model.HouseNumber;
            }
            set
            {
                Model.HouseNumber = value;

            }
        }

        public int ZipCode
        {
            get
            {
                return Model.ZipCode;
            }
            set
            {
                Model.ZipCode = value;

            }
        }

        public String City
        {
            get
            {
                return Model.City;
            }
            set
            {
                Model.City = value;

            }
        }
    }
}
