﻿using IocAndDiXamarinForms.Interfaces;
using IocAndDiXamarinForms.Services;
using IocAndDiXamarinForms.ViewModels;
using IocAndDiXamarinForms.Views;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Xamarin.Forms;

namespace IocAndDiXamarinForms
{
    public partial class App : Application
    {
        public App(ITextToSpeech textToSpeech)
        {
            InitializeComponent();

            //var textToSpeach = DependencyService.Get<ITextToSpeech>();

            var unityContainer = new UnityContainer();
            // register dependencies
            unityContainer.RegisterType<IProductsService, ProductsService>();
            unityContainer.RegisterInstance(typeof(ITextToSpeech), textToSpeech);
            unityContainer.RegisterInstance(typeof(ProductsViewModel));//optional

            var unityServiceLocator = new UnityServiceLocator(unityContainer);
            ServiceLocator.SetLocatorProvider(() => unityServiceLocator);

            MainPage = new NavigationPage(new ProductsPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
