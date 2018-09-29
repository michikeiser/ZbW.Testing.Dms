using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZbW.Testing.Dms.Client.ViewModels;

namespace ZbW.Testing.Dms.Client.UnitTests.ViewModels {
    [TestClass]
    public class DocumentDetailViewModelTest {
        [TestMethod]
        public void DocumentDetailViewModel_Init_Empty() {
            // arrange
            var vm = new DocumentDetailViewModel("asdf", () => {});
            // act

            // assert
            Assert.IsNull(vm.Stichwoerter);
            Assert.IsNull(vm.Bezeichnung);
            Assert.IsNull(vm.SelectedTypItem);
            Assert.IsNull(vm.ValutaDatum);
            Assert.AreEqual(vm.IsRemoveFileEnabled, false);
            Assert.AreEqual(vm.TypItems.Count, 2);
            Assert.AreEqual(vm.Erfassungsdatum.Date, DateTime.Now.Date);
            Assert.AreEqual(vm.Benutzer, "asdf");
        }

        [TestMethod]
        public void DocumentDetailViewModel_EmptyAll_CanNotSave() {
            // arrange
            var vm = new DocumentDetailViewModel("asdf", () => { });
            // act

            // assert
            Assert.IsFalse(vm.CanCmdSpeichern());
        }

        [TestMethod]
        public void DocumentDetailViewModel_Metadata_CanSave() {
            // arrange
            var vm = new DocumentDetailViewModel("asdf", () => { });
            // act
            vm.Bezeichnung = "asdf";
            vm.ValutaDatum = DateTime.Now;
            vm.SelectedTypItem = "asdf";
            

            // assert
            Assert.IsTrue(vm.CanCmdSpeichern());
        }
    }
}
