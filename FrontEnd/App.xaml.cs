﻿using System;
using System.Collections.Generic;

using Caliburn.Micro;

using FrontEnd.Core.Helpers;
using FrontEnd.Services;
using FrontEnd.ViewModels;

using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;

namespace FrontEnd
{
    [Windows.UI.Xaml.Data.Bindable]
    public sealed partial class App
    {
        private Lazy<ActivationService> _activationService;

        private ActivationService ActivationService
        {
            get { return _activationService.Value; }
        }

        public App()
        {
            InitializeComponent();

            EnteredBackground += App_EnteredBackground;
            Resuming += App_Resuming;

            Initialize();

            // Deferred execution until used. Check https://msdn.microsoft.com/library/dd642331(v=vs.110).aspx for further info on Lazy<T> class.
            _activationService = new Lazy<ActivationService>(CreateActivationService);
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            if (!args.PrelaunchActivated)
            {
                await ActivationService.ActivateAsync(args);
            }
        }

        protected override async void OnActivated(IActivatedEventArgs args)
        {
            await ActivationService.ActivateAsync(args);
        }

        private WinRTContainer _container;

        protected override void Configure()
        {
            // This configures the framework to map between MainViewModel and MainPage
            // Normally it would map between MainPageViewModel and MainPage
            var config = new TypeMappingConfiguration
            {
                IncludeViewSuffixInViewModelNames = false
            };

            ViewLocator.ConfigureTypeMappings(config);
            ViewModelLocator.ConfigureTypeMappings(config);

            _container = new WinRTContainer();
            _container.RegisterWinRTServices();

            _container.PerRequest<ShellViewModel>();
            _container.PerRequest<MainViewModel>();
            _container.PerRequest<WordInputsViewModel>();
            _container.PerRequest<WordAveragesViewModel>();
            _container.PerRequest<WordDetailsViewModel>();
            _container.PerRequest<SettingsViewModel>();
            _container.PerRequest<SchemeActivationSampleViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        private ActivationService CreateActivationService()
        {
            return new ActivationService(_container, typeof(ViewModels.MainViewModel), new Lazy<UIElement>(CreateShell));
        }

        private UIElement CreateShell()
        {
            var shellPage = new Views.ShellPage();
            return shellPage;
        }

        private async void App_EnteredBackground(object sender, EnteredBackgroundEventArgs e)
        {
            var deferral = e.GetDeferral();
            await Singleton<SuspendAndResumeService>.Instance.SaveStateAsync();
            deferral.Complete();
        }

        private void App_Resuming(object sender, object e)
        {
            Singleton<SuspendAndResumeService>.Instance.ResumeApp();
        }

        protected override async void OnBackgroundActivated(BackgroundActivatedEventArgs args)
        {
            await ActivationService.ActivateAsync(args);
        }
    }
}
