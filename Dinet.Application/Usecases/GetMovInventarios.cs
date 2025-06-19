using Dinet.Application.DTOs;
using Dinet.Application.Interfaces;
using Dinet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinet.Application.Usecases
{
    public class GetMovInventarios
    {
        private readonly IMovInventarioRepository _repository;
        public GetMovInventarios(IMovInventarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<MovInventarioDTO>> ExecuteAsync(DateTime? fechaInicio, DateTime? fechaFin, string tipoMovimiento, string nroDocumento)
        {
            var inventarios = await _repository.GetMovInventariosAsync(fechaInicio, fechaFin, tipoMovimiento, nroDocumento);

            var inventariosDTO = new List<MovInventarioDTO>();
            foreach (var inventario in inventarios)
            {
                inventariosDTO.Add(new MovInventarioDTO
                {
                    CodCia = inventario.CodCia,
                    CompaniaVenta = inventario.CompaniaVenta,
                    AlmacenVenta = inventario.AlmacenVenta,
                    TipoMovimiento = inventario.TipoMovimiento,
                    TipoDocumento = inventario.TipoDocumento,
                    NroDocumento = inventario.NroDocumento,
                    CodItem2 = inventario.CodItem2,
                    Proveedor = inventario.Proveedor,
                    AlmacenDestino = inventario.AlmacenDestino,
                    Cantidad = inventario.Cantidad,
                    FechaTransaccion = inventario.FechaTransaccion
                });
            }
            return inventariosDTO;
        }

        public async Task<MovInventarioDTO>ExecuteByIdAsync(string CodCia, string CompaniaVent, string AlmacenVenta, string TipoMovimiento, string TipoDocumento, string NroDocumento, string CodItem2)
        {
            var inventario = await _repository.GetMovInventariosByIdAsync(CodCia, CompaniaVent, AlmacenVenta, TipoMovimiento, TipoDocumento, NroDocumento, CodItem2);
            var inventariosDTO = new MovInventarioDTO
                {
                    CodCia = inventario.CodCia,
                    CompaniaVenta = inventario.CompaniaVenta,
                    AlmacenVenta = inventario.AlmacenVenta,
                    TipoMovimiento = inventario.TipoMovimiento,
                    TipoDocumento = inventario.TipoDocumento,
                    NroDocumento = inventario.NroDocumento,
                    CodItem2 = inventario.CodItem2,
                    Proveedor = inventario.Proveedor,
                    AlmacenDestino = inventario.AlmacenDestino,
                    Cantidad = inventario.Cantidad,
                    DocRef1 = inventario.DocRef1,
                    DocRef2 = inventario.DocRef2,
                    DocRef3 = inventario.DocRef3,
                    DocRef4 = inventario.DocRef4,
                    DocRef5 = inventario.DocRef5,
                    
                FechaTransaccion = inventario.FechaTransaccion
                };
            
            return inventariosDTO;
        }

        public async Task<bool> ExecuteInsertAsync(MovInventario inventario)
        {

            var response = await _repository.InsertMovInventarioAsync(inventario);
            if (!response)
            {

            }
            return response;

        }

        public async Task<bool> ExecuteUpdateAsync(MovInventarioDTO inventario)
        {

            return await _repository.UpdateMovInventarioAsync(inventario);
        }

        public async Task<bool> ExecuteDeleteAsync(string CodCia, string CompaniaVenta, string AlmacenVenta, string TipoMovimiento, string TipoDocumento, string NroDocumento, string CodItem2)
        {

            return await _repository.DeleteMovInventarioAsync(CodCia, CompaniaVenta, AlmacenVenta, TipoMovimiento, TipoDocumento, NroDocumento, CodItem2);
        }
    }
}
