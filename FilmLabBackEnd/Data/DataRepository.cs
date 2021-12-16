using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Autofac.Core;
using FilmLabBackEnd.Models;
using LinqToDB.Identity;

namespace FilmLabBackEnd.Data
{
    public class DataRepository
    {
        private DataConnection Connection {get;}
        public DataRepository(string getConnectionString)
        {
            var optionsBuilder = new LinqToDbConnectionOptionsBuilder();
            optionsBuilder.UsePostgreSQL(getConnectionString);
            Connection = new DataConnection(optionsBuilder.Build());
        }
        
        public ITable<Account> Accounts => Connection.GetTable<Account>();

        public void AccountCreate(Account account)
        {
            Connection.Insert(account);
        }
    }
}