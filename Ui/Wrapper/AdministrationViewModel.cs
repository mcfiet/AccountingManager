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
    public class AdministrationViewModel : ViewModelBase<Administration>
    {
      
        public OfferCollectionViewModel Offers
        {
            get
            {
                OfferCollectionViewModel temp = new OfferCollectionViewModel();
                temp.Model = Model.Offers;
                return temp;
            }
            set => Model.Offers = value.Model;
        }
        public OrderCollectionViewModel Orders {
            get
            {
                OrderCollectionViewModel temp = new OrderCollectionViewModel();
                temp.Model = Model.Orders;
                return temp;
            }
            set => Model.Orders = value.Model;
        }
        public InvoiceCollectionViewModel Invoices
        {
            get
            {
                InvoiceCollectionViewModel temp = new InvoiceCollectionViewModel();
                temp.Model = Model.Invoices;
                return temp;
            }
            set => Model.Invoices = value.Model;
        }
        public ClientCollectionViewModel Clients
        {
            get
            {
                ClientCollectionViewModel temp = new ClientCollectionViewModel();
                temp.Model = Model.Clients;
                return temp;
            }
            set => Model.Clients = value.Model;
        }

        public ArticleCollectionViewModel Articles
        {
            get
            {
                ArticleCollectionViewModel temp = new ArticleCollectionViewModel();
                temp.Model = Model.Articles;
                return temp;
            }
            set => Model.Articles = value.Model;
        }
    }
}
