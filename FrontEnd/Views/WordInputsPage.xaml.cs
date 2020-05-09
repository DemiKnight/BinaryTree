using System;
using System.Linq;

using FrontEnd.ViewModels;

using Microsoft.Toolkit.Uwp.UI.Controls;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FrontEnd.Views
{
    public sealed partial class WordInputsPage : Page
    {
        public WordInputsPage()
        {
            InitializeComponent();
        }

        private WordInputsViewModel ViewModel
        {
            get { return DataContext as WordInputsViewModel; }
        }

        private void MasterDetailsViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (MasterDetailsViewControl.ViewState == MasterDetailsViewState.Both)
            {
                ViewModel.ActiveItem = ViewModel.Items.FirstOrDefault();
            }
        }
    }
}
