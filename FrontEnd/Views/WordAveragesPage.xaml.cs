using System;

using FrontEnd.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace FrontEnd.Views
{
    public sealed partial class WordAveragesPage : Page
    {
        // TODO WTS: Change the chart as appropriate to your app.
        // For help see http://docs.telerik.com/windows-universal/controls/radchart/getting-started
        public WordAveragesPage()
        {
            InitializeComponent();
        }

        private WordAveragesViewModel ViewModel
        {
            get { return DataContext as WordAveragesViewModel; }
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            await ViewModel.LoadDataAsync();
        }
    }
}
