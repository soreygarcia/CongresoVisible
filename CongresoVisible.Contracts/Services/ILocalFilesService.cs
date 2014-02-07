﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.Contracts.Services
{
    public interface ILocalFilesService 
    {
        Task<bool> DoesFileExistAsync(string connectionString);
    }
}
