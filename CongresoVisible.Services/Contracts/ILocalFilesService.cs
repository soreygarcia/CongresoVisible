using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.Services.Contracts
{
    public interface ILocalFilesService 
    {
        Task<bool> DoesFileExistAsync(string connectionString);
    }
}
