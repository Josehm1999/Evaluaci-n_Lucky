﻿using Dapper.Contrib.Extensions;
using Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected string _connectionString;
        public Repository(string connection)
        {
            SqlMapperExtensions.TableNameMapper = (type) => { return $"{type.Name}"; };
            _connectionString = connection;
        }
        public bool Delete(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            T entity =connection.Get<T>(id);
            return connection.Delete(entity);
        }

        public T GetById(int Id)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Get<T>(Id);
        }

        public IEnumerable<T> GetList()
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.GetAll<T>();
        }

        public int Insert(T entity)
        {
            using var connection = new SqlConnection(_connectionString);
            return (int)connection.Insert(entity);
        }

        public bool Update(T entity)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Update(entity);
        }

        
    }
}
