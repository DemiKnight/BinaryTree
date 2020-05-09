using System;

using FrontEnd.ViewModels;

using Xunit;

namespace FrontEnd.Tests.XUnit
{
    // TODO WTS: Add appropriate tests
    public class Tests
    {
        [Fact]
        public void TestMethod1()
        {
        }

        // TODO WTS: Add tests for functionality you add to MainViewModel.
        [Fact]
        public void TestMainViewModelCreation()
        {
            // This test is trivial. Add your own tests for the logic you add to the ViewModel.
            var vm = new MainViewModel();
            Assert.NotNull(vm);
        }

        // TODO WTS: Add tests for functionality you add to SettingsViewModel.
        [Fact]
        public void TestSettingsViewModelCreation()
        {
            // This test is trivial. Add your own tests for the logic you add to the ViewModel.
            var vm = new SettingsViewModel();
            Assert.NotNull(vm);
        }

        // TODO WTS: Add tests for functionality you add to WordAveragesViewModel.
        [Fact]
        public void TestWordAveragesViewModelCreation()
        {
            // This test is trivial. Add your own tests for the logic you add to the ViewModel.
            var vm = new WordAveragesViewModel();
            Assert.NotNull(vm);
        }

        // TODO WTS: Add tests for functionality you add to WordDetailsViewModel.
        [Fact]
        public void TestWordDetailsViewModelCreation()
        {
            // This test is trivial. Add your own tests for the logic you add to the ViewModel.
            var vm = new WordDetailsViewModel();
            Assert.NotNull(vm);
        }

        // TODO WTS: Add tests for functionality you add to WordInputsViewModel.
        [Fact]
        public void TestWordInputsViewModelCreation()
        {
            // This test is trivial. Add your own tests for the logic you add to the ViewModel.
            var vm = new WordInputsViewModel();
            Assert.NotNull(vm);
        }
    }
}
