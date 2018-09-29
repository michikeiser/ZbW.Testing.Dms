using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.UnitTests.Model {
    [TestClass]
    public class MetadataItemTest {
        [TestMethod]
        public void MetadataItem_Init_HasData() {
            // arrange
            // act
            var meta = new MetadataItem("desc", DateTime.Today, "type", "tags", DateTime.Today, "creator", true);

            // assert
            Assert.AreEqual(meta.Description, "desc");
            Assert.AreEqual(meta.ValutaDateTime, DateTime.Today);
            Assert.AreEqual(meta.Tags, "tags");
            Assert.AreEqual(meta.Type, "type");
            Assert.AreEqual(meta.CreationDateTime, DateTime.Today);
            Assert.AreEqual(meta.Creator, "creator");
            Assert.AreEqual(meta.DeleteFile, true);
        }
    }
}
