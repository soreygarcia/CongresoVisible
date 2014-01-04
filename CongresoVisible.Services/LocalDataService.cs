﻿using CongresoVisible.Contracts.Services;
using CongresoVisible.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CongresoVisible.Models;
using SQLite.Net;
using Infrastructure.Common;

namespace CongresoVisible.Phone.Infrastructure
{
    public class LocalDataService : ServiceBase, ILocalDataService
    {
        IDbConnectionService dbConnectionService;

        SQLiteConnection connection;
        string connectionString = string.Empty;

        public LocalDataService()
        {
            dbConnectionService = GetService<IDbConnectionService>();

            connection = dbConnectionService.Connection;
            connection.CreateTable<Person>();  
        }

        public List<Person> GetFollowing()
        {
            return connection.Table<Person>().ToList();
        }

        public void SavePerson(Person person)
        {
            connection.Insert(person);
        }

        public void RemovePerson(int id)
        {
            var person = connection.Table<Person>().Where(p => p.list_number == id).FirstOrDefault();

            if (person != null)
                connection.Delete(person);
        }
    }
}
