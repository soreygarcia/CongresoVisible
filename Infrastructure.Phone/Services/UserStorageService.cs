using Infrastructure.Common.Contracts;
using Infrastructure.Phone.Contracts;
using System;
using System.IO;
using System.IO.IsolatedStorage;

namespace Infrastructure.Phone.Services
{
    public class UserStorageService : IDisposable, IUserStorageService
    {
        static private object userStoreLock = new object();

        private IsolatedStorageFile userStore = null;
        ILogService logService;

        public UserStorageService()
        {
            userStore = IsolatedStorageFile.GetUserStoreForApplication();
        }

        public UserStorageService(ILogService logService)
        {
            this.logService = logService;
            userStore = IsolatedStorageFile.GetUserStoreForApplication();
        }

        public void EnsureDirectory(string path)
        {
            lock (userStoreLock)
            {
                if (!userStore.DirectoryExists(path))
                {
                    userStore.CreateDirectory(path);
                }
            }
        }

        public string[] GetFiles(string path)
        {
            EnsureDirectory(path);
            return userStore.GetFileNames(path + "/*");
        }

        public IsolatedStorageFileStream OpenFile(string path, FileMode mode)
        {
            return userStore.OpenFile(path, mode);
        }

        public void WriteText(string fileName, string text)
        {
            lock (userStoreLock)
            {
                using (IsolatedStorageFileStream fileStream = userStore.OpenFile(fileName, FileMode.Create))
                {
                    using (var writer = new StreamWriter(fileStream))
                    {
                        writer.WriteLine(text);
                    }
                }
            }
        }

        public void AppendLine(string fileName, string line)
        {
            lock (userStoreLock)
            {
                using (IsolatedStorageFileStream fileStream = userStore.OpenFile(fileName, FileMode.Append))
                {
                    using (var writer = new StreamWriter(fileStream))
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }

        public string ReadText(string fileName)
        {
            lock (userStoreLock)
            {
                using (IsolatedStorageFileStream fileStream = userStore.OpenFile(fileName, FileMode.Open))
                {
                    using (var reader = new StreamReader(fileStream))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }

        public bool FileExists(string fileName)
        {
            return userStore.FileExists(fileName);
        }

        public void DeleteFile(string fileName)
        {
            userStore.DeleteFile(fileName);
        }

        public string[] GetFileNames(string path)
        {
            using (var userStorage = new UserStorageService())
            {
                return userStorage.GetFiles(path);
            }
        }

        public void WriteTextToFile(string fileName, string text)
        {
            using (var userStorage = new UserStorageService())
            {
                userStorage.WriteText(fileName, text);
            }
        }

        public void WriteLineToFile(string fileName, string line)
        {
            using (var userStorage = new UserStorageService())
            {
                userStorage.AppendLine(fileName, line);
            }
        }

        public string ReadTextFromFile(string fileName)
        {
            try
            {
                using (var userStorage = new UserStorageService())
                {
                    lock (userStoreLock)
                    {
                        if (userStorage.FileExists(fileName))
                        {
                            return userStorage.ReadText(fileName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logService.WriteError("UserStorage.ReadTextFromFile", ex);
            }
            return String.Empty;
        }

        public void Delete(string fileName)
        {
            using (var userStorage = new UserStorageService())
            {
                userStorage.DeleteFile(fileName);
            }
        }

        #region Dispose
        
        public void Dispose()
        {
            if (userStore != null)
            {
                userStore.Dispose();
                userStore = null;
            }
        }
        #endregion
    }
}