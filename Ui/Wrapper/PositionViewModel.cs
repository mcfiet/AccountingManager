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
    public class PositionViewModel : ViewModelBase<Position>
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

        public int PositionNr
        {
            get
            {
                return Model.PositionNr;
            }
            set
            {
                Model.PositionNr = value;

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
    }
}
