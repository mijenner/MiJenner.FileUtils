# MiJenner.FileUtils

FileUtils is a cross-platform C# .NET class library offering for easy handling of files. 

* ```FolderExists(string)``` Method takes a string with folder name and determines if it already exists or not.

* ```HasWriteAccess(string, [int]])```. Method determines if application has write access to folder (string). This is done by trying to write file with randomly generated file name to the folder. 

* ```TryCreateFolder(string)```. Method tries to create given folder. If success returns true else false.

* ```TryCreateFile(string)```. Method tries to create file given by input string. If success returns true, else false.
* ```TryCreateFileForce(string)```. Method works like above, except if file already exists, in which case it is overwritten (cleared).


