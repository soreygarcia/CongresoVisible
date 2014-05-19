using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Phone.Contracts
{
    public interface IUserStorageService
    {
        void EnsureDirectory(string path);

        string[] GetFiles(string path);

        IsolatedStorageFileStream OpenFile(string path, FileMode mode);

        void WriteText(string fileName, string text);

        void AppendLine(string fileName, string line);

        string ReadText(string fileName);

        bool FileExists(string fileName);

        void DeleteFile(string fileName);

        string[] GetFileNames(string path);

        void WriteTextToFile(string fileName, string text);

        void WriteLineToFile(string fileName, string line);

        string ReadTextFromFile(string fileName);

        void Delete(string fileName);

        void Dispose();
    }
}
