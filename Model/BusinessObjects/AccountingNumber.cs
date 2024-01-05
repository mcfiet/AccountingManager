using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects
{
    public static class AccountingNumber
    {
        public static string CreateOfferNrFromId(int id)
        {
            int digits = id.ToString().Length;
            switch (digits)
            {
                case 1:
                    return "A-" + DateTime.Now.Year + "-000" + id;

                case 2:
                    return "A-" + DateTime.Now.Year + "-00" + id;
                case 3:
                    return "A-" + DateTime.Now.Year + "-0" + id;
                case 4:
                    return "A-" + DateTime.Now.Year + "-" + id;
            }
            return id.ToString();
        }
        public static string CreateOrderNrFromId(int id)
        {
            int digits = id.ToString().Length;
            switch (digits)
            {
                case 1:
                    return "Au-" + DateTime.Now.Year + "-000" + id;

                case 2:
                    return "Au-" + DateTime.Now.Year + "-00" + id;
                case 3:
                    return "Au-" + DateTime.Now.Year + "-0" + id;
                case 4:
                    return "Au-" + DateTime.Now.Year + "-" + id;
            }
            return id.ToString();
        }
        public static string CreateInvoiceNrFromId(int id)
        {
            int digits = id.ToString().Length;
            switch (digits)
            {
                case 1:
                    return "R-" + DateTime.Now.Year + "-000" + id;

                case 2:
                    return "R-" + DateTime.Now.Year + "-00" + id;
                case 3:
                    return "R-" + DateTime.Now.Year + "-0" + id;
                case 4:
                    return "R-" + DateTime.Now.Year + "-" + id;
            }
            return id.ToString();
        }
    }
}
