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
        public AdministrationViewModel()
        {
            Offers = new OfferCollectionViewModel();
            Clients = new ClientCollectionViewModel();
            Articles = new ArticleCollectionViewModel();
        }
        public OfferCollectionViewModel Offers { get; set; }

        public ClientCollectionViewModel Clients { get; set; }

        public ArticleCollectionViewModel Articles { get; set; }
        
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
