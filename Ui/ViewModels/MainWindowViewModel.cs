﻿//using De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp078.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp078.Services.MessageBus;
using De.HsFlensburg.ClientApp078.Services.SerializationService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.ViewModels
{
    public class MainWindowViewModel
    {
        private ModelFileHandler modelFileHandler;
        private string pathForSerialization;

        public ICommand SaveCommand { get; }
        public ICommand LoadCommand { get; }

        public ICommand OpenNewOfferWindowCommand { get; }
        public ICommand OpenClientsWindowCommand { get; }
        public ICommand OpenNewArticleWindowCommand { get; }


        public OfferCollectionViewModel OfferList { get; set; }
        public ClientCollectionViewModel ClientList { get; set; }
        public ArticleCollectionViewModel ArticleList { get; set; }


        public AdministrationViewModel AdministrationViewModel { get; set; }   

        public MainWindowViewModel(AdministrationViewModel givenAdministrationViewModel)
        {
            
            SaveCommand = new RelayCommand(SaveModel);
            LoadCommand = new RelayCommand(LoadModel);

            OpenNewOfferWindowCommand = new RelayCommand(OpenNewOfferWindowMethod);
            OpenClientsWindowCommand = new RelayCommand(OpenClientsWindowMethod);
            OpenNewArticleWindowCommand = new RelayCommand(OpenNewArticleWindow);

            AdministrationViewModel = givenAdministrationViewModel;

            
            OfferList = AdministrationViewModel.Offers;
            ClientList = AdministrationViewModel.Clients;
            ArticleList = AdministrationViewModel.Articles;


            modelFileHandler = new ModelFileHandler();
            pathForSerialization = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ClientCollectionSerialization\\MyClient.cc";
        }

        private void OpenNewOfferWindowMethod()
        {
            ServiceBus.Instance.Send(new OpenNewOfferWindowMessage());
        }

        private void OpenClientsWindowMethod()
        {
            ServiceBus.Instance.Send(new OpenClientsWindowMessage());
        }

        private void OpenNewArticleWindow()
        {
            ServiceBus.Instance.Send(new OpenNewArticleWindowMessage());
        }


        private void SaveModel()
        {
            modelFileHandler.WriteModelToFile(pathForSerialization, AdministrationViewModel.Model);
        }

        private void LoadModel()
        {
            AdministrationViewModel.Model = modelFileHandler.ReadModelFromFile(pathForSerialization);
        }
    }
}
