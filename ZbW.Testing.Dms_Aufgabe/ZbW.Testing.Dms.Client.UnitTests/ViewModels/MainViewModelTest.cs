using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZbW.Testing.Dms.Client.ViewModels;
using Prism.Commands;
using ZbW.Testing.Dms.Client.Views;

namespace ZbW.Testing.Dms.Client.UnitTests.ViewModels {
    
    [TestClass]
    public class MainViewModelTest {
        [TestMethod]
        public void MainViewModel_Init_UserName()
        {
            // arrange
            var vm = new MainViewModel("asdf");
            // act
            // assert
            Assert.AreEqual(vm.Benutzer, "asdf");
        }

        [TestMethod]
        public void MainViewModel_Init_CmdNavigateToDocumentDetail()
        {
            // arrange
            var vm = new MainViewModel("a");
            // act
            // assert
            Assert.IsInstanceOfType(vm.CmdNavigateToDocumentDetail, typeof(DelegateCommand));
        }

        [TestMethod]
        public void MainViewModel_Init_CmdNavigateToSearch() {
            // arrange
            var vm = new MainViewModel("a");
            // act
            // assert
            Assert.IsInstanceOfType(vm.CmdNavigateToSearch, typeof(DelegateCommand));
        }


        [TestMethod]
        public void MainViewModel_Init_Content() {
            // arrange
            var vm = new MainViewModel("a");
            // act
            // assert
            Assert.IsNull(vm.Content);
        }

        [TestMethod]
        public void MainViewModel_Open_DocumentDetail() {
            // arrange
            var vm = new MainViewModel("a");
            // act
            vm.CmdNavigateToDocumentDetail.Execute();

            // assert
            Assert.IsInstanceOfType(vm.Content, typeof(DocumentDetailView));
            Assert.IsTrue(vm.DocumentDetailViewActive);
        }

        [TestMethod]
        public void MainViewModel_Open_Search() {
            // arrange
            var vm = new MainViewModel("a");
            // act
            vm.CmdNavigateToSearch.Execute();

            // assert
            Assert.IsInstanceOfType(vm.Content, typeof(SearchView));
            Assert.IsTrue(vm.SearchViewActive);
        }
    }
}
