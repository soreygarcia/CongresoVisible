﻿using CongresoVisible.Contracts.Services;
using CongresoVisible.FakeServices.Contracts;
using Infrastructure.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.FakeServices
{
    public class FakeNavigationService : INavigationService
    {
        public Action<Type> Callback { get; set; }

        public void Navigate<T>()
        {
            Callback(typeof(T));
        }

        public void Navigate<T>(object parameter)
        {
            throw new NotImplementedException();
        }

        public void GoBack()
        {
            throw new NotImplementedException();
        }
    }
}
