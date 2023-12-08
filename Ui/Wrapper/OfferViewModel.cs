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
    public class OfferViewModel : ViewModelBase<Offer>
    {
        public int OfferNr
        {
            get
            {
                return Model.OfferNr;
            }
            set
            {
                Model.OfferNr = value;

            }
        }

        public String Reference
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
        public String Date
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

        public String Text
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
        private ClientViewModel client;
        public ClientViewModel Client
        {
            get 
            { 
                return client; 
            }
            set
            {
                client = value;
                this.Model.Client = value.Model;
            }
        }
        private ArticleCollectionViewModel articles;
        public ArticleCollectionViewModel Articles
        {
            get 
            { 
                return articles; 
            }
            set
            {
                articles = value;
                this.Model.Articles = value.Model;
            }
        }

        public override void NewModelAssigned()
        {
            if (this.Client != null)
            {
                Client.Model = this.Model?.Client;
            }

        }
        internal void OnPropertyChangedInModel(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }
    }
}
