using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects
{
    [Serializable]
    public class Order : Accounting
    {


        private int orderId;
        public int OrderId
        {
            get
            {
                return orderId;
            }
            set
            {
                orderId = value;
                OnPropertyChanged("OrderId");

            }
        }

        private string orderNr;

        public string OrderNr
        {
            get
            {
                return orderNr;
            }
            set
            {
                orderNr = value;
                OnPropertyChanged("OrderNr");
            }
        }
        private bool isInvoice;
        public bool IsInvoice
        {
            get
            {
                return isInvoice;
            }
            set
            {
                isInvoice = value;
                OnPropertyChanged("IsInvoice");
            }
        }


        public string GetOrderNr(int id)
        {
            return AccountingNumber.CreateOrderNrFromId(id + 1);
        }

    }
}
