﻿using System;
using System.Linq;

namespace Core.Interfaces.Data
{
    public interface IContext : IDisposable
    {
        void Add<T>(T entity) where T : class;
        void CreateStructure();
        void DeleteDatabase();
        void Delete<T>(T entity) where T : class;
        void DetectChanges();
        void DropStructure();
        long ExecuteCommand(string commandText);
        IQueryable<T> Query<T>() where T : class;
        int SaveChanges();
        void Update<T>(T entity) where T : class;
    }
}
