using System;
using System.IO;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.UnitTests.Services {
    [TestClass]
    public class DocumentServiceTest
    {
        public string TestPath;
        public string SettingsPath;

        [TestInitialize()]
        public void TestInitialize() {
            // set Settings to test folder
            this.TestPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "dms");
            this.SettingsPath = ConfigurationManager.AppSettings.Get(DocumentService.SETTINGS_REPOSITORYFOLDER_KEY);
            ConfigurationManager.AppSettings.Set(DocumentService.SETTINGS_REPOSITORYFOLDER_KEY, TestPath);
        }

        [TestCleanup()]
        public void TestCleanup()
        {
            // reset Settings to test folder
            foreach (string directory in Directory.GetDirectories(TestPath)) {
                Directory.Delete(directory, true);
            }
            Directory.Delete(TestPath, true);

            ConfigurationManager.AppSettings.Set(DocumentService.SETTINGS_REPOSITORYFOLDER_KEY, this.SettingsPath);
        }

        [TestMethod]
        public void DocumentService_CreateYearFolder_Available() {
            // arrange
            var srv = new DocumentService();
            // act
            srv.CreateFolderIfNotExists(new DateTime(9999, 12, 12));

            // assert
            Assert.IsTrue(Directory.Exists(Path.Combine(TestPath, "9999")));
        }

        [TestMethod]
        public void DocumentService_ParseFile_StoredCorrectly() {
            // arrange
            var srv = new DocumentService();
            var pdfToImport = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "123.pdf");
            File.Create(pdfToImport).Dispose();
            var meta = new MetadataItem("desc", new DateTime(9999, 12, 12), "type", "tags", new DateTime(9999, 12, 12), "creator", true);

            // act
            srv.ProcessFile(pdfToImport, meta);

            // assert
            var dir = Directory.GetFiles(Path.Combine(TestPath, "9999"), "*");
            Assert.AreEqual(2, dir.Length);
        }


    }
}
