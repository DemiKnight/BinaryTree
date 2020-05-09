using System;
using Windows.Security.Cryptography.Core;
using Windows.Storage;
using Windows.Storage.Pickers;
using Caliburn.Micro;

using FrontEnd.Helpers;

namespace FrontEnd.ViewModels
{
    public class MainViewModel : Screen
    {
        private String _path = "This is Ttest";
        private StorageFile _file;


        public String Path
        {
            get => _path;
            set { Set(ref _path, value); }
        }

        protected StorageFile File
        {
            get => _file;
            set
            {
                Set(ref _file, value);
            }
        }

        public MainViewModel()
        {
        }

        protected async void GetPathFromPicker()
        {
            var picker = new FileOpenPicker();

            picker.ViewMode = PickerViewMode.List;
            picker.SuggestedStartLocation = PickerLocationId.Desktop;
            picker.FileTypeFilter.Add(".txt");

            File = await picker.PickSingleFileAsync();
            if (File != null)
            {
                Path = File.Path;

            }
            

        }
    }
}
