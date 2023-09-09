namespace MiJenner.FileUtils
{
    public static class FileUtils
    {
        /// <summary>
        /// Checks if folder exist, but first if string is non-empty. 
        /// </summary>
        /// <param name="folderPath"></param>
        /// <returns>
        /// True if folder exists. 
        /// False if not. 
        /// </returns>
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


        /// <summary>
        /// Checks if user has write access to folderPath by writing a randomly named 
        /// file to folder. 
        /// It takes an optional parameter which by default is 3 which determines how many
        /// different random names are attempted. 
        /// If all randomly named files exists in advance it may erroneously return false, but 
        /// statistically risc is very low. 
        /// <code>
        /// public static bool HasWriteAccess(string folderPath)
        /// public static bool HasWriteAccess(string folderPath, int maxAttempts = 3)
        /// </code>
        /// </summary>
        /// <param name="folderPath"></param>
        /// <param name="maxAttempts"></param>
        /// <returns></returns>
        public static bool HasWriteAccess(string folderPath, int maxAttempts = 3)
        {
            if (Directory.Exists(folderPath))
            {
                try
                {
                    int cnt = maxAttempts;
                    while (cnt > 0)
                    {
                        // Attempt to create a temporary file within the directory.
                        string tempFilePath = Path.Combine(folderPath, Path.GetRandomFileName());
                        if (!File.Exists(tempFilePath))
                        {
                            using (FileStream fs = File.Create(tempFilePath))
                            {
                            }
                            // The temporary file was created successfully.
                            File.Delete(tempFilePath); // Clean up the temporary file.
                            return true;
                        }
                        cnt--; 
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

            }
            else
            {
                // Directory doesn't exist. 
                return false;
            }
            return false; 

        }

        /// <summary>
        /// Tries to create a folder without exceptions. 
        /// </summary>
        /// <param name="folderPath"></param>
        /// <returns>
        /// True if success. 
        /// False if not. 
        /// </returns>
        public static bool TryCreateFolder(string folderPath)
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
        /// If it already exists it is overwritten. n
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>
        /// True if success. 
        /// False if not. Could happen if access issues. 
        /// </returns>
        public static bool TryCreateFileForce(string filePath)
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
        /// False if fails. Could happen if access issues or if file already exists. 
        /// </returns>
        public static bool TryCreateFile(string filePath)
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
