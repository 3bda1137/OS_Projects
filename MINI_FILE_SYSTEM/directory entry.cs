using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MINI_FILE_SYSTEM
{
    internal class DirectoryEntry
    {
        public char[] dir_name = new char[11];
        public byte dir_attr;
        public byte[] dir_empty = new byte[12];
        public int firs_cluster;
        public int dir_fileSize;


        public DirectoryEntry(string name, byte attr, int fcluster, int fileSize)
        {
            dir_attr = attr;
            firs_cluster = fcluster;
            this.dir_fileSize = fileSize;

            if (attr == 0X0)
            {
                string[] fileName = name.Split('.');
                this.dir_name = covert_data.getProperFileName(fileName[0].ToCharArray(), fileName[1].ToCharArray());
            }
            else if (attr == 0x10)
            {
                this.dir_name = covert_data.getProperDirName(name.ToCharArray());
            }

        }

    }
}
