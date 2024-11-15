﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects
{
    [Serializable]
    public class Invoice : Order
    {

        private int invoiceId;
        public int InvoiceId
        {
            get
            {
                return invoiceId;
            }
            set
            {
                invoiceId = value;
                OnPropertyChanged("InvoiceId");

            }
        }
        private string invoiceNr;

        public string InvoiceNr
        {
            get
            {
                return invoiceNr;
            }
            set
            {
                invoiceNr = value;
                OnPropertyChanged("InvoiceNr");
            }
        }

        private bool isPayed;
        public bool IsPayed
        {
            get
            {
                return isPayed;
            }
            set
            {
                isPayed = value;
                OnPropertyChanged("IsPayed");
            }
        }

        public string GetInvoiceNr(int id)
        {
            return AccountingNumber.CreateInvoiceNrFromId(id + 1);
        }


    }
}
