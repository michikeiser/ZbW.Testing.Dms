using System;
using System.Configuration;
using System.IO;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.Services {
    class DocumentService {
        public const string SETTINGS_REPOSITORYFOLDER_KEY = "RepositoryDir";

        public string RepositoryDir
        {
            get
            {
                return ConfigurationManager.AppSettings.Get(SETTINGS_REPOSITORYFOLDER_KEY);
            }
        }


        public bool ProcessFile(string filepath, MetadataItem meta)
        {
            // check folder structure
            var folderPath = this.CreateFolderIfNotExists(meta.ValutaDateTime);
            return false;
        }

        /***
         * Creates Folder Structure (Subfolder per Year)
         *
         * @return full folder path
         */
        public string CreateFolderIfNotExists(DateTime datetime)
        {
            if (!Directory.Exists(RepositoryDir))
            {
                Directory.CreateDirectory(RepositoryDir);
            }

            var yearpath = Path.Combine(RepositoryDir, datetime.Year.ToString());
            if (!Directory.Exists(yearpath)) {
                Directory.CreateDirectory(yearpath);
            }

            return yearpath;
        }
    }
}
