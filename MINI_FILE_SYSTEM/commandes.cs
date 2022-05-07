using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MINI_FILE_SYSTEM
{
    public static class Command
    {
        public static void Help(string input = "")
        {
            bool F = false;
            string[] commands = { "cd", "help", "dir", "quit", "copy", "cls", "del", "md", "rd", "rename", "type", "import", "export" };
            foreach (string i in commands)
            {
                if (input.ToLower() == i)
                {
                    F = true;
                    break;
                }
            }
            if (input == "")
            {
                Console.WriteLine("cd       - Change the current default directory to .");
                Console.WriteLine("           If the argument is not present, report the current directory.");
                Console.WriteLine("           If the directory does not exist an appropriate error should be reported.");
                Console.WriteLine("cls      - Clear the screen.");
                Console.WriteLine("dir      - List the contents of directory .");
                Console.WriteLine("quit     - Quit the shell.");
                Console.WriteLine("copy     - Copies one or more files to another location");
                Console.WriteLine("del      - Deletes one or more files.");
                Console.WriteLine("help     - Provides Help information for commands.");
                Console.WriteLine("md       - Creates a directory.");
                Console.WriteLine("rd       - Removes a directory.");
                Console.WriteLine("rename   - Renames a file.");
                Console.WriteLine("type     - Displays the contents of a text file.");
                Console.WriteLine("import   – import text file(s) from your computer");
                Console.WriteLine("export   – export text file(s) to your computer");
            }
            else if (input != "" && F)
            {
                switch (input)
                {
                    case "cd":
                        Console.WriteLine("Change the current default directory to the directory given in the argument.");
                        Console.WriteLine("If the argument is not present, report the current directory.");
                        Console.WriteLine("If the directory does not exist an appropriate error should be reported.");
                        Console.WriteLine(input + " command syntax is \n cd \n or \n cd [directory]");
                        Console.WriteLine("[directory] can be directory name or fullpath of a directory");
                        break;
                    case "cls":
                        Console.WriteLine("Clear the screen.");
                        Console.WriteLine(input + " command syntax is \n cls");
                        break;
                    case "dir":
                        Console.WriteLine("List the contents of directory given in the argument.");
                        Console.WriteLine("If the argument is not present, list the content of the current directory.");
                        Console.WriteLine("If the directory does not exist an appropriate error should be reported.");
                        Console.WriteLine(input + " command syntax is \n dir \n or \n dir [directory]");
                        Console.WriteLine("[directory] can be directory name or fullpath of a directory");
                        break;
                    case "quit":
                        Console.WriteLine("Quit the shell.");
                        Console.WriteLine(input + " command syntax is \n quit");
                        break;
                    case "copy":
                        Console.WriteLine("Copies one or more files to another location.");
                        Console.WriteLine(input + " command syntax is \n copy [source]+ [destination]");
                        Console.WriteLine("+ after [source] represent that you can pass more than file Name (or fullpath of file) or more than directory Name (or fullpath of directory)");
                        Console.WriteLine("[source] can be file Name (or fullpath of file) or directory Name (or fullpath of directory)");
                        Console.WriteLine("[destination] can be directory name or fullpath of a directory");
                        break;
                    case "del":
                        Console.WriteLine("Deletes one or more files.");
                        Console.WriteLine("NOTE: it confirms the user choice to delete the file before deleting");
                        Console.WriteLine(input + " command syntax is \n del [file]+");
                        Console.WriteLine("+ after [file] represent that you can pass more than file Name (or fullpath of file)");
                        Console.WriteLine("[file] can be file Name (or fullpath of file)");
                        break;
                    case "help":
                        Console.WriteLine("Provides Help information for commands.");
                        Console.WriteLine(input + " command syntax is \n help \n or \n For more information on a specific command, type help [command]");
                        Console.WriteLine("command - displays help information on that command.");
                        break;
                    case "md":
                        Console.WriteLine("Creates a directory.");
                        Console.WriteLine(input + " command syntax is \n md [directory]");
                        Console.WriteLine("[directory] can be a new directory name or fullpath of a new directory");
                        break;
                    case "rd":
                        Console.WriteLine("Removes a directory.");
                        Console.WriteLine("NOTE: it confirms the user choice to delete the directory before deleting");
                        Console.WriteLine(input + " command syntax is \n rd [directory]");
                        Console.WriteLine("[directory] can be a directory name or fullpath of a directory");
                        break;
                    case "rename":
                        Console.WriteLine("Renames a file.");
                        Console.WriteLine(input + " command syntax is \n rd [fileName] [new fileName]");
                        Console.WriteLine("[fileName] can be a file name or fullpath of a filename ");
                        Console.WriteLine("[new fileName] can be a new file name not fullpath ");
                        break;
                    case "type":
                        Console.WriteLine("Displays the contents of a text file.");
                        Console.WriteLine(input + " command syntax is \n type [file]");
                        Console.WriteLine("NOTE: it displays the filename before its content for every file");
                        Console.WriteLine("[file] can be file Name (or fullpath of file) of text file");
                        break;
                    case "import":
                        Console.WriteLine("– import text file(s) from your computer ");
                        Console.WriteLine(input + " command syntax is \n import [destination] [file]+");
                        Console.WriteLine("+ after [file] represent that you can pass more than file Name (or fullpath of file) of text file");
                        Console.WriteLine("[file] can be file Name (or fullpath of file) of text file");
                        Console.WriteLine("[destination] can be directory name or fullpath of a directory in your implemented file system");
                        break;
                    case "export":
                        Console.WriteLine("– export text file(s) to your computer ");
                        Console.WriteLine(input + " command syntax is \n export [destination] [file]+");
                        Console.WriteLine("+ after [file] represent that you can pass more than file Name (or fullpath of file) of text file");
                        Console.WriteLine("[file] can be file Name (or fullpath of file) of text file in your implemented file system");
                        Console.WriteLine("[destination] can be directory name or fullpath of a directory in your computer");
                        break;
                }
            }
            else if (F == false)
            {
                Console.WriteLine("ERROR!!!: " + input + " This inputmand is not supported by the project.");
            }
        }
        public static void Clear(string name = " ")
        {
            if (name == " ")
            {
                Console.Clear();
            }
            else
            {
                Console.WriteLine("ERROR!!! cls command syntax is");
                Console.WriteLine("cls \n function: Clear the screen.");
            }
        }
        public static void Quit(string name = " ")
        {
            if (name == " ")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Error: quit command syntax is ");
                Console.WriteLine("quit \n function: Quit the shell.");
            }
        }
        public static void moveToDir(string path)
        {
            Directory dir = moveTodir(path, true, false);
            if (dir != null)
            {
                dir.ReadDirectory();
                Program.Current = dir;
            }
            else
            {
                Console.WriteLine($"Eroor : path {path} is not exists!");
            }
        }
        public static void moveToDirUsedInAnother(string path)
        {
            Directory dir = moveTodir(path, false, false);
            if (dir != null)
            {
                dir.ReadDirectory();
                Program.Current = dir;
            }
            else
            {
                Console.WriteLine("the system cannot find the specified folder.!");
            }
        }

        private static Directory moveTodir(string p, bool usedInCD, bool isUsedInRD)
        {
            Directory d = null;
            string[] arr = p.Split('\\');
            string path;
            if (arr.Length == 1) 
            {
                if (arr[0] != "..")
                {
                    int i = Program.Current.searchDirectory(arr[0]);
                    if (i == -1)
                        return null;
                    else
                    {
                        string nameOfDiserableFolder = new string(Program.Current.entries[i].dir_name); 
                        byte attr = Program.Current.entries[i].dir_attr;
                        int fisrtcluster = Program.Current.entries[i].firs_cluster;
                        d = new Directory(nameOfDiserableFolder, attr, fisrtcluster, Program.Current); d.ReadDirectory();
                        path = Program.currentPath; 
                        path += "\\" + nameOfDiserableFolder.Trim();
                        if (usedInCD)
                            Program.currentPath = path;
                    }
                }
                else 
                {
                    if (Program.Current.parent != null)
                    {
                        d = Program.Current.parent;
                        d.ReadDirectory();
                        path = Program.currentPath;
                        path = path.Substring(0, path.LastIndexOf('\\'));  
                        if (usedInCD)
                            Program.currentPath = path;
                    }
                    else 
                    {
                        d = Program.Current;
                        d.ReadDirectory();
                    }
                }
            }
            else if (arr.Length > 1)
            {

                List<string> ListOfHandledPath = new List<string>();
                for (int i = 0; i < arr.Length; i++)
                    if (arr[i] != "")
                        ListOfHandledPath.Add(arr[i]);

                Directory rootDirectory = new Directory("M:", 0x10, 5, null);
                rootDirectory.ReadDirectory();


                if (ListOfHandledPath[0].Equals("m:") || ListOfHandledPath[0].Equals("M:")) 
                {
                    path = "M:";
                    int howLongIsMyWay;
                    if (isUsedInRD || usedInCD)
                    {
                        howLongIsMyWay = ListOfHandledPath.Count;
                    }
                    else
                    {
                        howLongIsMyWay = ListOfHandledPath.Count - 1;
                    }
                    for (int i = 1; i < howLongIsMyWay; i++) 
                    {
                        int j = rootDirectory.searchDirectory(ListOfHandledPath[i]);
                        if (j != -1) 
                        {
                            Directory tempOfParent = rootDirectory;
                            string newName = new string(rootDirectory.entries[j].dir_name);
                            byte attr = rootDirectory.entries[j].dir_attr;
                            int fc = rootDirectory.entries[j].firs_cluster;
                            rootDirectory = new Directory(newName, attr, fc, tempOfParent);
                            rootDirectory.ReadDirectory();
                            path += "\\" + newName.Trim(new char[] { '\0', ' ' });
                        }
                        else
                        {
                            return null;
                        }
                    }
                    d = rootDirectory;
                    if (usedInCD)
                        Program.currentPath = path;
                }
                else if (ListOfHandledPath[0] == "..")
                {
                    d = Program.Current;
                    for (int i = 0; i < ListOfHandledPath.Count; i++)
                    {
                        if (d.parent != null)
                        {
                            d = d.parent;
                            d.ReadDirectory();
                            path = Program.currentPath;
                            path = path.Substring(0, path.LastIndexOf('\\'));
                            if (usedInCD)
                                Program.currentPath = path;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                    return null;
            }
            return d;
        }


        public static void makeFolder(string name)
        {
            string[] arr = name.Split('\\');
            if (arr.Length == 1) 
            {
                if (Program.Current.searchDirectory(arr[0]) == -1)
                {
                    DirectoryEntry d = new DirectoryEntry(arr[0], 0x10, 0, 0);

                    if (FAT.GetEmptyCulster() != -1)
                    {
                        Program.Current.entries.Add(d);
                        Program.Current.WriteDirectory();
                        if (Program.Current.parent != null)
                        {
                            Program.Current.parent.updateContent(Program.Current.getDirectoryEntry());
                            Program.Current.parent.WriteDirectory();
                        }
                        FAT.writeFat();
                    }
                    else
                        Console.WriteLine("The Disk is Full :(");
                }
                else
                    Console.WriteLine($"{arr[0]} is aready existed :(");
            }
            else if (arr.Length > 1)
            {
                Directory dir = moveTodir(name, false, false);
                if (dir == null)
                    Console.WriteLine($"The Path {name} Is not exist");
                else
                {
                    if (FAT.GetEmptyCulster() != -1)
                    {

                        DirectoryEntry d = new DirectoryEntry(arr[arr.Length - 1], 0x10, 0, 0); 
                        dir.entries.Add(d);
                        dir.WriteDirectory();
                        dir.parent.updateContent(dir.getDirectoryEntry());
                        dir.parent.WriteDirectory();
                        FAT.writeFat();
                    }
                    else
                        Console.WriteLine("The Disk is Full :(");
                }
            }

        }
        public static void dir()
        {
            int fc = 0, dc = 0, fz_sum = 0;
            Console.WriteLine("Directory of " + Program.currentPath);
            Console.WriteLine();
            for (int i = 0; i < Program.Current.entries.Count; i++)
            {
                if (Program.Current.entries[i].dir_attr == 0x0)
                {
                    Console.WriteLine($"\t{Program.Current.entries[i].dir_fileSize} \t {new string(Program.Current.entries[i].dir_name)}");
                    fc++;
                    fz_sum += Program.Current.entries[i].dir_fileSize;
                }
                else if (Program.Current.entries[i].dir_attr == 0x10)
                {
                    Console.WriteLine($"\t<DIR> {new string(Program.Current.entries[i].dir_name)}");
                    dc++;
                }
            }
            Console.WriteLine($"{"\t\t"}{fc} File(s)    {fz_sum} bytes");
            Console.WriteLine($"{"\t\t"}{dc} Dir(s)    {VirtualDisk.getFreeSpace()} bytes free");
        }


        public static void rd(string name)
        {


            string[] arr = name.Split('\\');
            Directory dir = moveTodir(name, false, true);
            if (dir != null)
            {
                Console.Write($"Are you sure that you want to delete {new string(dir.dir_name).Trim()} , please enter Y for yes or N for no:");
                string choice = Console.ReadLine().ToLower();
                if (choice.Equals("y"))
                    dir.deleteDirectory();
            }
            else
                Console.WriteLine($"directory \" {arr[arr.Length - 1]} \" is not exists!");

        }

        public static void import(string dest)
        {
            if (File.Exists(dest))
            {
                string content = File.ReadAllText(dest);
                int size = content.Length;
                string[] names = dest.Split("\\");
                string name = names[names.Length - 1];
                int j = Program.Current.searchDirectory(name);
                if (j == -1)
                {
                    int fc;
                    if (size > 0)
                    {
                        fc = FAT.GetEmptyCulster();
                    }
                    else
                    {
                        fc = 0;
                    }
                    FILE newFile = new FILE(name, 0X0, fc, Program.Current, content, size);

                    newFile.writeFile();
                    

                    DirectoryEntry d = new DirectoryEntry(new string(name), 0X0, fc, size);
                    Program.Current.entries.Add(d);
                    Program.Current.WriteDirectory();
                }
                else
                {
                    Console.WriteLine($"{name} is already exist in your virtual disk");
                }

            }
            else
            {
                Console.WriteLine("The file you specified does not exist in your compuret");
            }
        }


        public static void type(string name)
        {
            string[] path = name.Split("\\");
            if (path.Length > 1)
            {
                for (int i = 1; i < path.Length - 1; i++)
                    moveToDirUsedInAnother(path[i]);

                name = path[path.Length - 1];
            }

            int j = Program.Current.searchDirectory(name);
            if (j != -1)
            {
                int fc = Program.Current.entries[j].firs_cluster;
                int sz = Program.Current.entries[j].dir_fileSize;
                string content = null;
                FILE file = new FILE(name, 0x0, fc, Program.Current, content, sz);
                file.ReadFile();
                Console.WriteLine(file.content);
            }
            else
            {
                Console.WriteLine("The System could not found the file specified");
            }
            Directory rootDirectory = new Directory("M:", 0x10, 5, null);
            Program.Current = rootDirectory;
            Program.Current.ReadDirectory();
        }

        public static void export(string source, string dest)
        {
            string[] path = source.Split("\\");
            if (path.Length > 1)
            {
                for (int i = 1; i < path.Length - 1; i++)
                    moveToDirUsedInAnother(path[i]);

                source = path[path.Length - 1];
            }
            int j = Program.Current.searchDirectory(source);
            if (j != -1)
            {
                if (System.IO.Directory.Exists(dest))
                {
                    int fc = Program.Current.entries[j].firs_cluster;
                    int sz = Program.Current.entries[j].dir_fileSize;
                    string content = null;
                    FILE file = new FILE(source, 0x0, fc, Program.Current, content, sz);
                    file.ReadFile();
                    StreamWriter sw = new StreamWriter(dest + "\\" + source);
                    sw.Write(file.content);
                    sw.Flush();
                    sw.Close();
                }
                else
                {
                    Console.WriteLine("The system cannot find the path specified in hte coputer dis");
                }

            }
            else
            {
                Console.WriteLine("The system cannot find the file you want to export in the virtual disk");
            }
            Directory rootDirectory = new Directory("M:", 0x10, 5, null);
            Program.Current = rootDirectory;
            Program.Current.ReadDirectory();
        }

        public static void rename(string oldName, string newName)
        {
            string[] path = oldName.Split("\\"); 
            if (path.Length > 1)
            {
                for (int i = 1; i < path.Length - 1; i++)
                    moveToDirUsedInAnother(path[i]);
                oldName = path[path.Length - 1];
            }

            int j = Program.Current.searchDirectory(oldName);
            if (j != -1)
            {
                if (Program.Current.searchDirectory(newName) == -1)
                {
                    DirectoryEntry d = Program.Current.entries[j];
                    if (d.dir_attr == 0x0)
                    {
                        string[] fileName = newName.Split('.');
                        char[] goodName = covert_data.getProperFileName(fileName[0].ToCharArray(), fileName[1].ToCharArray());
                        d.dir_name = goodName;
                    }
                    else if (d.dir_attr == 0x10)
                    {
                        char[] goodName =covert_data.getProperDirName(newName.ToCharArray());
                        d.dir_name = goodName;
                    }
                    Program.Current.entries.RemoveAt(j);
                    Program.Current.entries.Insert(j, d);
                    Program.Current.WriteDirectory();
                }
                else
                {
                    Console.WriteLine("Doublicate File Name exist or file cannot be found");
                }
            }
            else
            {
                Console.WriteLine("The System Cannot Find the File specified");
            }

            Directory rootDirectory = new Directory("M:", 0x10, 5, null);
            Program.Current = rootDirectory;
            Program.Current.ReadDirectory();
        }
        public static void del(string fileName)
        {
            string[] path = fileName.Split("\\");
            if (path.Length > 1)
            {
                for (int i = 1; i < path.Length - 1; i++)
                    moveToDirUsedInAnother(path[i]);

                fileName = path[path.Length - 1];
            }
            int j = Program.Current.searchDirectory(fileName);
            if (j != -1)
            {
                if (Program.Current.entries[j].dir_attr == 0x0)
                {
                    int fc = Program.Current.entries[j].firs_cluster;
                    int sz = Program.Current.entries[j].dir_fileSize;
                    FILE file = new FILE(fileName, 0x0, fc, Program.Current, null, sz);
                    file.deleteFile();
                }
                else
                {
                    Console.WriteLine("The System Cannot Find The file specified");
                }
            }
            else
            {
                Console.WriteLine("The System Cannot Find The file specified");
            }

            Directory rootDirectory = new Directory("M:", 0x10, 5, null);
            Program.Current = rootDirectory;
            Program.Current.ReadDirectory();
        }
        public static void copy(string source, string dest)
        {
            int j = Program.Current.searchDirectory(source);
            int fc;
            int sz;
            if (source == dest)
            {
                Console.WriteLine("the file cannot be copied onto itself");
                return;
            }
            if (j != -1)
            {
                fc = Program.Current.entries[j].firs_cluster;
                sz = Program.Current.entries[j].dir_fileSize;
                string[] myWay = dest.Split("\\");
                for (int i = 1; i < myWay.Length; i++)
                    moveToDirUsedInAnother(myWay[i]);
                int x = Program.Current.searchDirectory(source);
                if (x != -1)
                {
                    Console.Write("The File is aleary existed, Do you want to overwrite it ?, please enter Y for yes or N for no:");
                    string choice = Console.ReadLine().ToLower();
                    if (choice.Equals("y"))
                    {
                        DirectoryEntry d = new DirectoryEntry(new string(source), 0X0, fc, sz);
                        Program.Current.entries.Add(d);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    DirectoryEntry d = new DirectoryEntry(new string(source), 0X0, fc, sz);
                    Program.Current.entries.Add(d);
                    Program.Current.WriteDirectory();
                }
                Directory rootDirectory = new Directory("M:", 0x10, 5, null);
                Program.Current = rootDirectory;
                Program.Current.ReadDirectory();
            }
            else
            {
                Console.WriteLine($"The File ${source} Is Not Existed In your disk");
            }
        }

    }
}
