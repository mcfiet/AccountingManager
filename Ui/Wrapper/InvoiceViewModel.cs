using De.HsFlensburg.ClientApp078.Logic.Ui.Base;
using De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper
{
    public class InvoiceViewModel : ViewModelBase<Invoice>
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
        public PositionCollectionViewModel Positions
        {
            get
            {
                var positions = new PositionCollectionViewModel();
                positions.Model = Model.Positions;
                return positions;
            }
            set
            {
                this.Model.Positions = value.Model;

            }
        }

        public int OrderNr
        {
            get
            {
                return Model.OrderNr;
            }
            set
            {
                Model.OrderNr = value;

            }
        }

        public int InvoiceNr
        {
            get
            {
                return Model.InvoiceNr;
            }
            set
            {
                Model.InvoiceNr = value;

            }
        }

        public string Reference
        {
            get
            {
                return Model.Reference;
            }
            set
            {
                Model.Reference = value;

            }
        }
        public DateTime Date
        {
            get
            {
                return Model.Date;
            }
            set
            {
                Model.Date = value;

            }
        }

        public string Text
        {
            get
            {
                return Model.Text;
            }
            set
            {
                Model.Text = value;

            }
        }
        public ClientViewModel Client
        {
            get
            {
                var client = new ClientViewModel();
                client.Model = Model.Client;
                return client;
            }
            set
            {
                this.Model.Client = value.Model;
            }
        }


        public float TotalPrice
        {
            get
            {
                return Model.TotalPrice;
            }
        }
    }
}
