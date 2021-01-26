using Dapper;
using Models;
using Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess
{
    public class ProveedorRepository : Repository<Proveedor>, IProveedorRepository
    {
        public ProveedorRepository(string connectionString) : base(connectionString)
        {

        }
        public IEnumerable<Proveedor> ListaPaginadaProveedor(int page, int rows, string busqueda)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@page", page);
            parameters.Add("@rows", rows);
            parameters.Add("@busqueda", busqueda);
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<Proveedor>("dbo.ListaPaginadaProveedor", parameters, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
