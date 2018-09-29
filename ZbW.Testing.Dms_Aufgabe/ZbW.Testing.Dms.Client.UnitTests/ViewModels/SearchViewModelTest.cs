using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZbW.Testing.Dms.Client.ViewModels;

namespace ZbW.Testing.Dms.Client.UnitTests.ViewModels {
    [TestClass]
    public class SearchViewModelTest {
        [TestMethod]
        public void SearchViewModel_Init_Empty() {
            // arrange
            var vm = new SearchViewModel();
            // act

            // assert
            Assert.IsNull(vm.Suchbegriff);
            Assert.IsNull(vm.SelectedTypItem);
            Assert.IsNull(vm.FilteredMetadataItems);
            Assert.IsNull(vm.SelectedMetadataItem);
            Assert.AreEqual(vm.TypItems.Count, 2);
        }
    }
}
