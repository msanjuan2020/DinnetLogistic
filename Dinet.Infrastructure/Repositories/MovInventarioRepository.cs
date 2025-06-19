using Dinet.Application.Interfaces;
using Dinet.Domain.Entities;
using Microsoft.Data.SqlClient;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dinet.Application.DTOs;


namespace Dinet.Infrastructure.Repositories
{
    public class MovInventarioRepository : IMovInventarioRepository
    {
        private readonly SqlConnection _connection;

        public MovInventarioRepository(SqlConnection connection)
        {
            _connection = connection;
        }
        public async Task<IEnumerable<MovInventario>> GetMovInventariosAsync(DateTime? fechaInicio, DateTime? fechaFin, string tipoMovimiento, string nroDocumento)
        {

            var parameters = new DynamicParameters();
            parameters.Add("FechaInicio", fechaInicio ?? (object)DBNull.Value, DbType.DateTime);
            parameters.Add("FechaFin", fechaFin ?? (object)DBNull.Value, DbType.DateTime);
            parameters.Add("TipoMovimiento", tipoMovimiento ?? (object)DBNull.Value, DbType.String);
            parameters.Add("NumeroDocumento", nroDocumento ?? (object)DBNull.Value, DbType.String);

            using (var connection = new SqlConnection(_connection.ConnectionString))
            {
                await connection.OpenAsync();
                var inventarios = await connection.QueryAsync<MovInventario>("SP_ConsultaMovInventario", parameters, commandType: System.Data.CommandType.StoredProcedure);  // Pasar los parámetros al stored procedure
                return inventarios; 
            }
        }

        public async Task<MovInventario> GetMovInventariosByIdAsync(string CodCia, string CompaniaVent, string AlmacenVenta, string TipoMovimiento, string TipoDocumento, string NroDocumento, string CodItem2)
        {
            var parameters = new DynamicParameters();
            parameters.Add("CodCia", CodCia, DbType.String);
            parameters.Add("CompaniaVenta", CompaniaVent, DbType.String);
            parameters.Add("AlmacenVenta", AlmacenVenta, DbType.String);
            parameters.Add("TipoMovimiento", TipoMovimiento, DbType.String);
            parameters.Add("TipoDocumento", TipoDocumento, DbType.String);
            parameters.Add("NroDocumento", NroDocumento, DbType.String);
            parameters.Add("CodItem2", CodItem2, DbType.String);
            using (var connection = new SqlConnection(_connection.ConnectionString))
            {
                await connection.OpenAsync();
                var inventario = await connection.QueryFirstOrDefaultAsync<MovInventario>("SP_GetMovInventarioById", parameters, commandType: CommandType.StoredProcedure);
                return inventario ?? new MovInventario();
            }
        }

        public async Task<bool> InsertMovInventarioAsync(MovInventario inventario)
        {
            var parameters = new DynamicParameters();
            parameters.Add("CodCia", inventario.CodCia, DbType.String);
            parameters.Add("CompaniaVenta", inventario.CompaniaVenta, DbType.String);
            parameters.Add("AlmacenVenta", inventario.AlmacenVenta, DbType.String);
            parameters.Add("TipoMovimiento", inventario.TipoMovimiento, DbType.String);
            parameters.Add("TipoDocumento", inventario.TipoDocumento, DbType.String);
            parameters.Add("NroDocumento", inventario.NroDocumento, DbType.String);
            parameters.Add("CodItem2", inventario.CodItem2, DbType.String);
            parameters.Add("Proveedor", inventario.Proveedor, DbType.String);
            parameters.Add("AlmacenDestino", inventario.AlmacenDestino, DbType.String);
            parameters.Add("Cantidad", inventario.Cantidad, DbType.Decimal);
            parameters.Add("DocRef1", inventario.DocRef1, DbType.String);
            parameters.Add("DocRef2", inventario.DocRef2, DbType.String);
            parameters.Add("DocRef3", inventario.DocRef3, DbType.String);
            parameters.Add("DocRef4", inventario.DocRef4, DbType.String);
            parameters.Add("DocRef5", inventario.DocRef5, DbType.String);
            parameters.Add("FechaTransaccion", inventario.FechaTransaccion, DbType.DateTime);
            using (var connection = new SqlConnection(_connection.ConnectionString))
            {
                var response =  await connection.ExecuteAsync("SP_InsertMovInventario", parameters, commandType: CommandType.StoredProcedure);
                if (response > 0)
                {
                    return true;
                }
                else
                {
                    // Si no se insertó ningún registro, retornamos false
                    return false;
                }
            }


        }

        public async Task<bool> UpdateMovInventarioAsync(MovInventarioDTO inventario)
        {
            

            var parameters = new DynamicParameters();
            parameters.Add("CodCia", inventario.CodCia, DbType.String);
            parameters.Add("CompaniaVenta", inventario.CompaniaVenta, DbType.String);
            parameters.Add("AlmacenVenta", inventario.AlmacenVenta, DbType.String);
            parameters.Add("TipoMovimiento", inventario.TipoMovimiento, DbType.String);
            parameters.Add("TipoDocumento", inventario.TipoDocumento, DbType.String);
            parameters.Add("NroDocumento", inventario.NroDocumento, DbType.String);
            parameters.Add("CodItem2", inventario.CodItem2, DbType.String);
            parameters.Add("Proveedor", inventario.Proveedor, DbType.String);
            parameters.Add("AlmacenDestino", inventario.AlmacenDestino, DbType.String);
            parameters.Add("Cantidad", inventario.Cantidad, DbType.Decimal);
            parameters.Add("DocRef1", inventario.DocRef1, DbType.String);
            parameters.Add("DocRef2", inventario.DocRef2, DbType.String);
            parameters.Add("DocRef3", inventario.DocRef3, DbType.String);
            parameters.Add("DocRef4", inventario.DocRef4, DbType.String);
            parameters.Add("DocRef5", inventario.DocRef5, DbType.String);
            parameters.Add("FechaTransaccion", inventario.FechaTransaccion, DbType.DateTime);

            using (var connection = new SqlConnection(_connection.ConnectionString))
            {
                await connection.OpenAsync();
                var rowsAffected = await connection.ExecuteAsync("SP_UpdateMovInventario", parameters, commandType: CommandType.StoredProcedure);
                return rowsAffected > 0;
            }
        }
        public async Task<bool> DeleteMovInventarioAsync(string CodCia, string CompaniaVenta, string AlmacenVenta, string TipoMovimiento, string TipoDocumento, string NroDocumento, string CodItem2)
        {
            var parameters = new DynamicParameters();
            parameters.Add("CodCia", CodCia, DbType.String);
            parameters.Add("CompaniaVenta", CompaniaVenta, DbType.String);
            parameters.Add("AlmacenVenta", AlmacenVenta, DbType.String);
            parameters.Add("TipoMovimiento", TipoMovimiento, DbType.String);
            parameters.Add("TipoDocumento", TipoDocumento, DbType.String);
            parameters.Add("NroDocumento", NroDocumento, DbType.String);
            parameters.Add("CodItem2", CodItem2, DbType.String);


            using (var connection = new SqlConnection(_connection.ConnectionString))
            {
                await connection.OpenAsync();
                var rowsAffected = await connection.ExecuteAsync("SP_DeleteMovInventario", parameters, commandType: CommandType.StoredProcedure);
                return rowsAffected > 0;
            }
        }
    }
}
