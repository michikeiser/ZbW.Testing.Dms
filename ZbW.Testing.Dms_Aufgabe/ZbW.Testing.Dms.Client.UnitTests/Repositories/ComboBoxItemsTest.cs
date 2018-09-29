using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZbW.Testing.Dms.Client.Repositories;

namespace ZbW.Testing.Dms.Client.UnitTests.Repositories {
    [TestClass]
    public class ComboBoxItemsTest {
        [TestMethod]
        public void ComboBoxItems_Check_NotEmpty() {
            // arrange
            // act
            // assert
            Assert.AreEqual(ComboBoxItems.Typ.Count, 2);
        }
    }
}
