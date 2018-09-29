using System;
using System.CodeDom;
using System.Configuration;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
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


        public bool ProcessFile(string filepath, MetadataItem metadata)
        {
            // create folder structure
            var folderPath = this.CreateFolderIfNotExists(metadata.ValutaDateTime);
            var guid = Guid.NewGuid();

            try
            {
                // copy pdf
                File.Copy(filepath, this.GetPdfFilePath(folderPath, guid));
                if (metadata.DeleteFile)
                {
                    File.Delete(filepath);
                }

                // create xml
                XmlSerializer writer = new XmlSerializer(typeof(MetadataItem));
                FileStream file = System.IO.File.Create(this.GetMetaDataFilePath(folderPath, guid));
                writer.Serialize(file, metadata);
                file.Close();

                return true;
            }
            catch (Exception e)
            {
                // TODO: Correct Error handling (Not defined by PO)
                return false;
            }
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

        private string GetPdfFilePath(string folderPath, Guid guid) {
            var xmlName = string.Concat(guid, "_Content", ".pdf");
            return Path.Combine(folderPath, xmlName);
        }

        private string GetMetaDataFilePath(string folderPath, Guid guid)
        {
            var xmlName = string.Concat(guid, "_Metadata", ".xml");
            return Path.Combine(folderPath, xmlName);
        } 
    }
}
