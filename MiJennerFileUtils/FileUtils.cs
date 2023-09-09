using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiJenner.FileUtils
{
    public static class FileUtils
    {
        public static bool FolderExists(string folderPath)
        {
            if (!string.IsNullOrWhiteSpace(folderPath))
            {
                if (Directory.Exists(folderPath))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool HasWriteAccess(string folderPath)
        {
            try
            {
                // Attempt to create a temporary file within the directory.
                string tempFilePath = Path.Combine(folderPath, Path.GetRandomFileName());
                if (!File.Exists(tempFilePath))
                {
                    using (FileStream fs = File.Create(tempFilePath))
                    {
                        // The temporary file was created successfully.
                        File.Delete(tempFilePath); // Clean up the temporary file.
                        return true;
                    }
                }
                else
                {
                    // if exists we will run another attemp: 
                    tempFilePath = Path.Combine(folderPath, Path.GetRandomFileName());
                    if (!File.Exists(tempFilePath))
                    {
                        using (FileStream fs = File.Create(tempFilePath))
                        {
                            // The temporary file was created successfully.
                            File.Delete(tempFilePath); // Clean up the temporary file.
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                // You don't have access to the security information
                return false;
            }
            catch (Exception)
            {
                // Other exceptions, handle accordingly
                return false;
            }

            return false; // No write access found
        }

        private static bool TryCreateFolder(string folderPath)
        {
            try
            {
                Directory.CreateDirectory(folderPath);
                return true; // Folder created successfully
            }
            catch (Exception)
            {
                // Handle folder creation failure, log or throw an exception if necessary
                return false;
            }
        }

        /// <summary>
        /// Tries to create file. 
        /// If it already exists it is overwritten. 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>
        /// True if success. 
        /// False if fails. 
        /// </returns>
        private static bool TryCreateFileForce(string filePath)
        {
            try
            {
                // Attempt to create the file, but don't open it.
                using (File.Create(filePath)) { }
                return true; // File creation was successful.
            }
            catch (Exception)
            {
                // Handle any exceptions that may occur during file creation.
                return false; // File creation failed.
            }
        }


        /// <summary>
        /// Tries to create file. 
        /// Unless it already exists.  
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>
        /// True if success. 
        /// False if fails. 
        /// </returns>
        private static bool TryCreateFile(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    // Attempt to create the file, but don't open it.
                    using (File.Create(filePath)) { }
                    return true; // File creation was successful.
                }
                return false;
            }
            catch (Exception)
            {
                // Handle any exceptions that may occur during file creation.
                return false; // File creation failed.
            }
        }


    }
}
