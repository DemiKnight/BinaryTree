using System;

using FrontEnd.ViewModels;

namespace FrontEnd.Views.WordInputsDetail
{
    public sealed partial class MasterView
    {
        public MasterView()
        {
            InitializeComponent();
        }

        public WordInputsDetailViewModel ViewModel => DataContext as WordInputsDetailViewModel;
    }
}
