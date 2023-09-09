using MiJenner.FileUtils;

namespace UsageExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string currentDir = Directory.GetCurrentDirectory();
            Console.WriteLine("string currentDir = Directory.GetCurrentDirectory(): " + currentDir);

            Console.WriteLine("FileUtils.FolderExists(currentDir): " + FileUtils.FolderExists(currentDir));
            Console.WriteLine("FileUtils.FolderExists(\"numb\"): " + FileUtils.FolderExists("blahh"));

            Console.WriteLine("FileUtils.HasWriteAccess(currentDir): " + FileUtils.HasWriteAccess(currentDir));
            Console.WriteLine("FileUtils.HasWriteAccess(\"blah\"): " + FileUtils.HasWriteAccess("blahh"));

            // pre-cleanup 
            File.Delete(Path.Combine(currentDir, "MyFile.txt"));
            Console.WriteLine("FileUtils.TryCreateFile(Path.Combine(currentDir, \"MyFile.txt\")): " + FileUtils.TryCreateFile(Path.Combine(currentDir, "MyFile.txt")));
            Console.WriteLine("FileUtils.TryCreateFile(Path.Combine(currentDir, \"MyFile-exists.txt\")): " + FileUtils.TryCreateFile(Path.Combine(currentDir, "MyFile-exists.txt")));

            string folderPath = Path.Combine(currentDir, "Data");
            // pre-cleanup 
            try
            {
                Directory.Delete(folderPath);
            }
            catch (Exception)
            {
                Console.WriteLine("Folder" + folderPath + "\nWasn't present before trying to create it!");
            }
            Console.WriteLine("FileUtils.TryCreateFolder(folderPath): " + FileUtils.TryCreateFolder(folderPath));


        }
    }
}