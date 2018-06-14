namespace ZbW.DocumentManagementSystem.Client.Services
{
    using System;
    using System.Configuration;
    using System.IO;

    internal class PersistanceService
    {
        public void CopyFileToRepository(string sourceFilePath, string filename, DateTime? valutaDatum)
        {
            var repoDir = ConfigurationManager.AppSettings["RepositoryDir"];

            var path = Path.Combine(repoDir, valutaDatum.GetValueOrDefault().Year.ToString());

            Directory.CreateDirectory(path);


            File.Copy(sourceFilePath, Path.Combine(path, filename));
        }
    }
}