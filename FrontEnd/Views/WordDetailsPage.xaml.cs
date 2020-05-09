using System;

using FrontEnd.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace FrontEnd.Views
{
    public sealed partial class WordDetailsPage : Page
    {
        // TODO WTS: Change the grid as appropriate to your app, adjust the column definitions on WordDetailsPage.xaml.
        // For more details see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid
        public WordDetailsPage()
        {
            InitializeComponent();
        }

        private WordDetailsViewModel ViewModel
        {
            get { return DataContext as WordDetailsViewModel; }
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            await ViewModel.LoadDataAsync();
        }
    }
}
