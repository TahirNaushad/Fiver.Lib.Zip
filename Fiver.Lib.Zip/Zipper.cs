using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;

namespace Fiver.Lib.Zip
{
    public sealed class Zipper
    {
        private string zipFile;
        private string password;
        private Dictionary<string, MemoryStream> streams;

        public Zipper(string zipFile) : this(zipFile, "")
        { }

        public Zipper(string zipFile, string password)
        {
            if (string.IsNullOrEmpty(zipFile))
                throw new ArgumentException("zipFile missing");

            this.zipFile = zipFile;
            this.password = password;
            this.streams = new Dictionary<string, MemoryStream>();
        }

        public Zipper AddFile(string file)
        {
            var filename = Path.GetFileName(file);
            var stream = new MemoryStream(File.ReadAllBytes(file));
            return AddStream(filename, stream);
        }

        public Zipper AddStream(string filename, MemoryStream stream)
        {
            this.streams.Add(filename, stream);
            return this;
        }

        public void Zip()
        {
            var zipStream = new MemoryStream();
            using (var zip = new ZipFile())
            {
                zip.Password = this.password;
                foreach (var item in this.streams)
                {
                    zip.AddEntry(item.Key, item.Value);
                }
                zip.Save(zipStream);
            }
            zipStream.Position = 0;

            using (var fs = new FileStream(this.zipFile, FileMode.Create))
            {
                zipStream.CopyTo(fs);
            }
        }
    }
}
