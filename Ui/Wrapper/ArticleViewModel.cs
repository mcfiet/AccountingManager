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
    public class ArticleViewModel : ViewModelBase<Article>
    {
        public int ArticleNr
        {
            get
            {
                return Model.ArticleNr;
            }
            set
            {
                Model.ArticleNr = value;

            }
        }

        public String Name
        {
            get
            {
                return Model.Name;
            }
            set
            {
                Model.Name = value;
            }
        }
        public String Description
        {
            get
            {
                return Model.Description;
            }
            set
            {
                Model.Description = value;
            }
        }
        public int Price
        {
            get
            {
                return Model.Price;
            }
            set
            {
                Model.Price = value;

            }
        }
    }
}
