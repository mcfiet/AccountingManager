using De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp078.Logic.Ui.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper
{
    public class OrderViewModel : ViewModelBase<Order>
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

        public int OrderId
        {
            get
            {
                return Model.OrderId;
            }
            set
            {
                Model.OrderId = value;

            }
        }

        public string OrderNr
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

        public void SetOrderNr(int id)
        {
            OrderNr = Model.GetOrderNr(id);
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
                Model.Client = value.Model;
            }
        }


        public float TotalPrice
        {
            get
            {
                return Model.TotalPrice;
            }
        }

        public bool IsInvoice
        {
            get
            {
                return Model.IsInvoice;
            }
            set
            {
                Model.IsInvoice = value;
            }
        }

    }
}
