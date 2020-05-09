using System;

using FrontEnd.ViewModels;

using Windows.UI.Xaml.Controls;

namespace FrontEnd.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private MainViewModel ViewModel
        {
            get { return DataContext as MainViewModel; }
        }
    }
}
