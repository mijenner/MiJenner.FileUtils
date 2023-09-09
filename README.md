# MiJenner.FileUtils

FileUtils is a cross-platform C# .NET class library offering for easy handling of files. 

* ```FolderExists(string)``` Method takes a string with folder name and determines if it already exists or not.

* ```HasWriteAccess(string, [int]])```. Method determines if application has write access to folder (string). This is done by trying to write file with randomly generated file name to the folder. 

* ```TryCreateFolder(string)```. Method tries to create given folder. If success returns true else false.

* ```TryCreateFile(string)```. Method tries to create file given by input string. If success returns true, else false.
* ```TryCreateFileForce(string)```. Method works like above, except if file already exists, in which case it is overwritten (cleared).

# Examples 
```cs
string currentDir = Directory.GetCurrentDirectory();
Console.WriteLine("string currentDir = DirectoryGetCurrentDirectory(): " + currentDir);
Console.WriteLine("FileUtils.FolderExists(currentDir): " +FileUtils.FolderExists(currentDir));
Console.WriteLine("FileUtils.FolderExists(\"numb\"): " +FileUtils.FolderExists("blahh"));
Console.WriteLine("FileUtils.HasWriteAccess(currentDir): "+ FileUtils.HasWriteAccess(currentDir));
Console.WriteLine("FileUtils.HasWriteAccess(\"blah\"): " +FileUtils.HasWriteAccess("blahh"));
// pre-cleanup 
File.Delete(Path.Combine(currentDir, "MyFile.txt"));
Console.WriteLine("FileUtils.TryCreateFile(Path.Combin(currentDir, \"MyFile.txt\")): " + FileUtils.TryCreateFil(Path.Combine(currentDir, "MyFile.txt")));
Console.WriteLine("FileUtils.TryCreateFile(Path.Combin(currentDir, \"MyFile-exists.txt\")): " + FileUtilsTryCreateFile(Path.Combine(currentDir, "MyFile-existstxt")));
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
Console.WriteLine("FileUtils.TryCreateFolder(folderPath): "+ FileUtils.TryCreateFolder(folderPath));
```


