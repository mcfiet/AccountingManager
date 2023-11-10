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
        public OfferCollection Offers
        {
            get
            {
                return Model.Offers;
            }
            set
            {
                Model.Offers = value;
            }
        }
        public ClientCollection Clients
        {
            get
            {
                return Model.Clients;
            }
            set
            {
                Model.Clients = value;
            }
        }
        public ArticleCollection Articles
        {
            get
            {
                return Model.Articles;
            }
            set
            {
                Model.Articles = value;
            }
        }
        public override void NewModelAssigned()
        {
            throw new NotImplementedException();
        }

        internal void OnPropertyChangedInModel(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }
    }
}
