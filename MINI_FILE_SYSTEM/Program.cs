using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//important
using MINI_FILE_SYSTEM;

namespace MINI_FILE_SYSTEM
{
    public static class Program
    {
        private static Directory current;
        public static string currentPath;

        internal static Directory Current { get => current; set => current = value; }

        static void Main(string[] args)
        {
            VirtualDisk.initialize("miniFat.txt");
            currentPath = new string(Current.dir_name);
            currentPath = currentPath.Trim(new char[] { '\0', ' ' });
            while (true)
            {
                Console.Write(currentPath + "\\" + ">");
                string input = Console.ReadLine();
                if (input != "")
                {
                    parser.ChackInput(input);
                }
                else
                {
                    continue;
                }

            }
        }
    }
}