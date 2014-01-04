﻿using CongresoVisible.Contracts.Services;
using Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.Services
{
    public class LocalFilesService : ServiceBase, ILocalFilesService
    {
        public async Task<bool> DoesFileExistAsync(string fileName)
        {
            try
            {
                var localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                var file = await localFolder.GetFileAsync(fileName);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
