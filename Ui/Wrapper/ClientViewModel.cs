﻿using De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp078.Logic.Ui.Base;
using System;
using System.ComponentModel;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper
{
    public class ClientViewModel: ViewModelBase<Client>
    {

        public int Id
        {
            get
            {
                return Model.Id;
            }
            set
            {
                Model.Id = value;
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
