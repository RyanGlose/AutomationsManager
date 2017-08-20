using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SevenZip;

namespace AutomationsManager.Core.Processes
{
    public static class ArchivingHelper
    {
        public static void ArchiveFile(string path)
        {
            //var compressor = new SevenZipCompressor(path);

            //compressor.CompressDirectory("D:\\SQL\\");
            var sevenZipPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), (Environment.Is64BitProcess ? "lib\\x64" : "lib\\x86") + "\\7za.dll");
            SevenZipBase.SetLibraryPath(sevenZipPath);

            var compressor = new SevenZip.SevenZipCompressor();
            compressor.CompressFiles("D:\\Shared\\archive.7z", path);
        }
    }
}
