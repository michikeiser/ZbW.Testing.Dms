using System;
using System.IO;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.UnitTests.Services {
    [TestClass]
    public class DocumentServiceTest
    {
        public string testPath;
        public string SettingsPath;

        [TestInitialize()]
        public void TestInitialize() {
            // set Settings to test folder
            this.testPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "dms");
            this.SettingsPath = ConfigurationManager.AppSettings.Get(DocumentService.SETTINGS_REPOSITORYFOLDER_KEY);
            ConfigurationManager.AppSettings.Set(DocumentService.SETTINGS_REPOSITORYFOLDER_KEY, testPath);
        }

        [TestCleanup()]
        public void TestCleanup() {
            // reset Settings to test folder
            Directory.Delete(testPath, true);
            ConfigurationManager.AppSettings.Set(DocumentService.SETTINGS_REPOSITORYFOLDER_KEY, this.SettingsPath);
        }

        [TestMethod]
        public void DocumentService_CreateYearFolder_Available() {
            // arrange
            var srv = new DocumentService();
            // act
            srv.CreateFolderIfNotExists(new DateTime(9999, 12, 12));

            // assert
            Assert.IsTrue(Directory.Exists(Path.Combine(testPath, "9999")));
        }

        
    }
}
