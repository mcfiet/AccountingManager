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
    public class OfferItemViewModel : ViewModelBase<OfferItem>
    {
        public int OfferItemNr
        {
            get
            {
                return Model.OfferItemNr;
            }
            set
            {
                Model.OfferItemNr = value;

            }
        }

        public int Quantity
        {
            get
            {
                return Model.Quantity;
            }
            set
            {
                Model.Quantity = value;

            }
        }

        public float TotalPrice
        {
            get
            {
                return Model.TotalPrice;
            }
            set
            {
                Model.TotalPrice = value;

            }
        }

        public Article Article
        {
            get
            {
                return Model.Article;
            }
            set
            {
                Model.Article = value;

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
