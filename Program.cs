using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 3)
        {
            Console.WriteLine("Usage: replaceStringInFileNames <directoryPath> <oldString> <newString>");
            return;
        }

        string directoryPath = args[0];
        string oldString = args[1];
        string newString = args[2];

        DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
        FileInfo[] files = directoryInfo.GetFiles("*" + oldString + "*");

        foreach (FileInfo file in files)
        {
            string newFileName = file.Name.Replace(oldString, newString);
            file.MoveTo(Path.Combine(directoryPath, newFileName));
            Console.WriteLine("File renamed from {0} to {1}", file.Name, newFileName);
        }

        Console.WriteLine("All matching file names in {0} have been replaced.", directoryPath);
    }
}