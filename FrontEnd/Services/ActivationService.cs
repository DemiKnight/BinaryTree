﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Caliburn.Micro;

using FrontEnd.Activation;
using FrontEnd.Core.Helpers;

using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FrontEnd.Services
{
    // For more information on understanding and extending activation flow see
    // 
    /**
     * @brief Deals with the initialisation of the program.
     * @see
     */
    internal class ActivationService
    {
        private readonly WinRTContainer _container;
        private readonly Type _defaultNavItem;
        private readonly Lazy<UIElement> _shell;

        public ActivationService(WinRTContainer container, Type defaultNavItem, Lazy<UIElement> shell = null)
        {
            _container = container;
            _shell = shell;
            _defaultNavItem = defaultNavItem;
        }

        public async Task ActivateAsync(object activationArgs)
        {
            if (IsInteractive(activationArgs))
            {
                // Initialize services that you need before app activation
                // take into account that the splash screen is shown while this code runs.
                await InitializeAsync();

                // Do not repeat app initialization when the Window already has content,
                // just ensure that the window is active
                if (Window.Current.Content == null)
                {
                    // Create a Shell or Frame to act as the navigation context
                    if (_shell?.Value == null)
                    {
                        var frame = new Frame();
                        NavigationService = _container.RegisterNavigationService(frame);
                        Window.Current.Content = frame;
                    }
                    else
                    {
                        var viewModel = ViewModelLocator.LocateForView(_shell.Value);

                        ViewModelBinder.Bind(viewModel, _shell.Value, null);

                        ScreenExtensions.TryActivate(viewModel);

                        NavigationService = _container.GetInstance<INavigationService>();
                        Window.Current.Content = _shell?.Value;
                    }
                }
            }

            var activationHandler = GetActivationHandlers()
                                                .FirstOrDefault(h => h.CanHandle(activationArgs));

            if (activationHandler != null)
            {
                await activationHandler.HandleAsync(activationArgs);
            }

            if (IsInteractive(activationArgs))
            {
                var activation = activationArgs as IActivatedEventArgs;
                if (activation.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    await Singleton<SuspendAndResumeService>.Instance.RestoreSuspendAndResumeData();
                }

                var defaultHandler = new DefaultActivationHandler(_defaultNavItem, NavigationService);
                if (defaultHandler.CanHandle(activationArgs))
                {
                    await defaultHandler.HandleAsync(activationArgs);
                }

                // Ensure the current window is active
                Window.Current.Activate();

                // Tasks after activation
                await StartupAsync();
            }
        }

        private INavigationService NavigationService { get; set; }

        private async Task InitializeAsync()
        {
            await Singleton<BackgroundTaskService>.Instance.RegisterBackgroundTasksAsync().ConfigureAwait(false);
            await ThemeSelectorService.InitializeAsync().ConfigureAwait(false);
            await WindowManagerService.Current.InitializeAsync();
        }

        private async Task StartupAsync()
        {
            // TODO WTS: This is a sample to demonstrate how to add a UserActivity. Please adapt and move this method call to where you consider convenient in your app.
            await UserActivityService.AddSampleUserActivity();
            await ThemeSelectorService.SetRequestedThemeAsync();
            await FirstRunDisplayService.ShowIfAppropriateAsync();
        }

        private IEnumerable<ActivationHandler> GetActivationHandlers()
        {
            yield return Singleton<BackgroundTaskService>.Instance;
            yield return Singleton<SuspendAndResumeService>.Instance;
            yield return new SchemeActivationHandler(NavigationService);
        }

        private bool IsInteractive(object args)
        {
            return args is IActivatedEventArgs;
        }
    }
}
