using Dapper;
using Models;
using Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccess
{
    public class OrdenRepository: Repository<Orden>, IOrdenRepository
    {
        public OrdenRepository(string connectionString) : base(connectionString)
        {
            
        }

        public bool DeleteOrden(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@OrdenId", id);
            using (var connection = new SqlConnection(_connectionString))
            {
               
                    var reader = connection.Execute("dbo.DeleteOrdenById", parameters, commandType: System.Data.CommandType.StoredProcedure);
                connection.Close();
                if (reader==1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
        }
        public ListaOrden GetOrdenById(int OrdenId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@OrdenId", OrdenId);
            using (var connection = new SqlConnection(_connectionString)) 
            {
                var reader = connection.QueryMultiple("dbo.Orden_by_id", parameters, commandType: System.Data.CommandType.StoredProcedure);

                var ListaOrden = reader.Read<ListaOrden>().ToList();
                var ListaItemsOrden = reader.Read<ListaOrdenItem>().ToList();

                foreach (ListaOrden item in ListaOrden) item.SetDetails(ListaItemsOrden);
                return ListaOrden.FirstOrDefault();
            }
        }

        public IEnumerable<ListaOrden> GetOrdenPaginada(int page, int rows)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@page", page);
            parameters.Add("@rows", rows);
            using var connection = new SqlConnection(_connectionString);
            var reader = connection.QueryMultiple("dbo.Orden_paginada", parameters, commandType: System.Data.CommandType.StoredProcedure);

            var orderList = reader.Read<ListaOrden>().ToList();
            var orderItemList = reader.Read<ListaOrdenItem>().ToList();

            foreach (ListaOrden item in orderList) item.SetDetails(orderItemList);
            return orderList;
        }
    }
}
