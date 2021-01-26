using Dapper;
using Models;
using Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        
        public ClienteRepository(string connectionString) : base(connectionString)
        {
            
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
