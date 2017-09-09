using Ionic.Zip;
using System;
using System.IO;

namespace Fiver.Lib.Zip
{
    public sealed class Unzipper
    {
        private string zipFile;
        private string unzipPath;
        private string password;

        public Unzipper(string zipFile, string unzipPath) : this(zipFile, unzipPath, "")
        { }

        public Unzipper(string zipFile, string unzipPath, string password)
        {
            if (string.IsNullOrEmpty(zipFile))
                throw new ArgumentException("zipFile missing");

            if (string.IsNullOrEmpty(unzipPath))
                throw new ArgumentException("unzipPath missing");

            this.zipFile = zipFile;
            this.unzipPath = unzipPath;
            this.password = password;
        }

        public void Unzip()
        {
            if (!File.Exists(this.zipFile))
                throw new FileNotFoundException("Zip File not found");

            using (var zip = ZipFile.Read(this.zipFile))
            {
                zip.Password = this.password;
                zip.ExtractAll(this.unzipPath,
                    ExtractExistingFileAction.OverwriteSilently);
            }
        }
    }
}
