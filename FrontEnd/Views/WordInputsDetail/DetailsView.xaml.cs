using System;

using FrontEnd.ViewModels;

namespace FrontEnd.Views.WordInputsDetail
{
    public sealed partial class DetailsView
    {
        public DetailsView()
        {
            InitializeComponent();
        }

        public WordInputsDetailViewModel ViewModel => DataContext as WordInputsDetailViewModel;
    }
}
