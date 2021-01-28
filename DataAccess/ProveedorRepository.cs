using Dapper;
using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess
{
    public class ProveedorRepository : Repository<Proveedor>, IProveedorRepository
    {
        public ProveedorRepository(string connectionString) : base(connectionString)
        {

        }

        public bool DeleteProveedor(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ProId", id);
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Execute("dbo.DeleteProveedor", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    return true;
                }
                catch (Exception err)
                {
                    throw err;
                }

            }
        }

        public bool InsertProveedor(Proveedor proveedor)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@NombreEmpresa", proveedor.NombreEmpresa);
            parameters.Add("@NombreContacto", proveedor.NombreContacto);
            parameters.Add("@TituloContacto", proveedor.TituloContacto);
            parameters.Add("@Ciudad", proveedor.Ciudad);
            parameters.Add("@Pais", proveedor.Pais);
            parameters.Add("@Telefono", proveedor.Telefono);
            parameters.Add("@Fax", proveedor.Fax);
            using var connection = new SqlConnection(_connectionString);
            try
            {
                connection.Execute("dbo.InsertProveedor", parameters, commandType: System.Data.CommandType.StoredProcedure);
                return true;
            }
            catch (Exception err)
            {
                throw err;
            }


        }

        public bool UpdateProveedor(Proveedor proveedor)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", proveedor.Id);
            parameters.Add("@NombreEmpresa", proveedor.NombreEmpresa);
            parameters.Add("@NombreContacto", proveedor.NombreContacto);
            parameters.Add("@TituloContacto", proveedor.TituloContacto);
            parameters.Add("@Ciudad", proveedor.Ciudad);
            parameters.Add("@Pais", proveedor.Pais);
            parameters.Add("@Telefono", proveedor.Telefono);
            parameters.Add("@Fax", proveedor.Fax);
            using var connection = new SqlConnection(_connectionString);
            try
            {
                connection.Execute("dbo.UpdateProveedor", parameters, commandType: System.Data.CommandType.StoredProcedure);
                return true;
            }
            catch (Exception err)
            {
                throw err;
            }
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
