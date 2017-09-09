using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiver.Lib.Zip.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //Zip();
            //Unzip();
        }

        private static void Zip()
        {
            var zipFile = @"C:\DATA\Zipper.zip";
            var file1 = @"C:\DATA\file1.txt";
            var file2 = @"C:\DATA\file2.txt";

            var zipper = new Zipper(zipFile)
                                .AddFile(file1)
                                .AddFile(file2);
            zipper.Zip();
        }

        private static void Unzip()
        {
            var zipFile = @"C:\DATA\Zipper.zip";
            var unzipPath = @"C:\DATA\Zipper";

            var unzipper = new Unzipper(zipFile, unzipPath);
            unzipper.Unzip();
        }
    }
}
