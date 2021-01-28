using Dapper;
using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        
        public ClienteRepository(string connectionString) : base(connectionString)
        {
            
        }
        public bool DeleteCliente(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@CliId", id);
            using (var connection = new SqlConnection(_connectionString))
            {
                try {
                    connection.Execute("dbo.DeleteCliente", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    return true;
                }catch(Exception err)
                {
                    throw err;
                }   

            }
        }

        public bool InsertCliente(Cliente cliente)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Nombre", cliente.Nombre);
            parameters.Add("@Apellido", cliente.Apellido);
            parameters.Add("@Ciudad", cliente.Ciudad);
            parameters.Add("@Pais", cliente.Pais);
            parameters.Add("@Telefono", cliente.Telefono);
            using var connection = new SqlConnection(_connectionString);
            try
            {
                connection.Execute("dbo.InsertCliente", parameters, commandType: System.Data.CommandType.StoredProcedure);
                return true;
            }
            catch (Exception err)
            {
                throw err;
            }
            
            
        }

        public bool UpdateCliente(Cliente cliente)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", cliente.Id);
            parameters.Add("@Nombre", cliente.Nombre);
            parameters.Add("@Apellido", cliente.Apellido);
            parameters.Add("@Ciudad", cliente.Ciudad);
            parameters.Add("@Pais", cliente.Pais);
            parameters.Add("@Telefono", cliente.Telefono);
            using var connection = new SqlConnection(_connectionString);
            try
            {
                connection.Execute("dbo.UpdateCliente", parameters, commandType: System.Data.CommandType.StoredProcedure);
                return true;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public IEnumerable<ListaCliente> ListaPaginadaCliente(int page, int rows)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@page", page);
            parameters.Add("@rows", rows);
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<ListaCliente>("dbo.ListaPaginadaCliente", parameters, commandType: System.Data.CommandType.StoredProcedure);
        }

        
    }
}
