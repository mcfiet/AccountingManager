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
        public AdministrationViewModel(): base()
        {
            Offers = new OfferCollectionViewModel();
            Orders = new OrderCollectionViewModel();
            Invoices = new InvoiceCollectionViewModel();
            Clients = new ClientCollectionViewModel();
            Articles = new ArticleCollectionViewModel();
            Offers.Model = this.Model.Offers;
            Orders.Model = this.Model.Orders;
            Invoices.Model = this.Model.Invoices;
            Clients.Model = this.Model.Clients;
            Articles.Model = this.Model.Articles;
        }
        public OfferCollectionViewModel Offers { get; set; }
        public OrderCollectionViewModel Orders { get; set; }
        public InvoiceCollectionViewModel Invoices { get; set; }

        public ClientCollectionViewModel Clients { get; set; }

        public ArticleCollectionViewModel Articles { get; set; }
        
        public override void NewModelAssigned()
        {
            if (this.Offers != null)
            {
                Offers.Model = this.Model?.Offers;
            }
            if (this.Orders != null)
            {
                Orders.Model = this.Model?.Orders;
            }
            if (this.Invoices != null)
            {
                Invoices.Model = this.Model?.Invoices;
            }
            if (this.Clients != null)
            {
                Clients.Model = this.Model?.Clients;
            }
            if (this.Articles != null)
            {
                Articles.Model = this.Model?.Articles;
            }
        }

        internal void OnPropertyChangedInModel(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }
    }
}
