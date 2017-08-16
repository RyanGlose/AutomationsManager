using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationsManager.Core.Processes
{
    public static class FileOperationsHelper
    {
        public static void CopyFile(string from, string to)
        {
            File.Copy(from, to);
        }
    }
}
