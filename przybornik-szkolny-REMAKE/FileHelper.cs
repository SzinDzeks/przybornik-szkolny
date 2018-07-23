using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace przybornik_szkolny_REMAKE
{
    class FileHelper
    {
        public static void CreateDirectoryIfNotExists(string dirPath)
        {
            DirectoryInfo dir = new DirectoryInfo(dirPath);
            if (!dir.Exists) dir.Create();
        }
    }
}
