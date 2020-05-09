using System;
using System.Linq;
using System.Threading.Tasks;

using Caliburn.Micro;

using FrontEnd.Core.Services;
using FrontEnd.Helpers;

namespace FrontEnd.ViewModels
{
    public class WordInputsViewModel : Conductor<WordInputsDetailViewModel>.Collection.OneActive
    {
        protected override async void OnInitialize()
        {
            base.OnInitialize();

            await LoadDataAsync();
        }

        public async Task LoadDataAsync()
        {
            Items.Clear();

            var data = await SampleDataService.GetMasterDetailDataAsync();

            Items.AddRange(data.Select(d => new WordInputsDetailViewModel(d)));
        }
    }
}
