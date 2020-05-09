using System;

using Caliburn.Micro;

using FrontEnd.Core.Models;

namespace FrontEnd.ViewModels
{
    public class WordInputsDetailViewModel : Screen
    {
        public WordInputsDetailViewModel(SampleOrder item)
        {
            Item = item;
        }

        public SampleOrder Item { get; }
    }
}
