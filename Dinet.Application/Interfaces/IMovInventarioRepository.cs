using Dinet.Application.DTOs;
using Dinet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinet.Application.Interfaces
{
    public interface IMovInventarioRepository    
    {
        Task<IEnumerable<MovInventario>> GetMovInventariosAsync(DateTime? fechaInicio, DateTime? fechaFin, string tipoMovimiento, string nroDocumento);
        Task<MovInventario>GetMovInventariosByIdAsync(string CodCia, string CompaniaVent, string AlmacenVenta, string TipoMovimiento, string TipoDocumento, string NroDocumento, string CodItem2);
        Task<bool> InsertMovInventarioAsync(MovInventario inventario);
        Task<bool> UpdateMovInventarioAsync(MovInventarioDTO inventario);
        Task<bool> DeleteMovInventarioAsync(string CodCia, string CompaniaVenta, string AlmacenVenta, string TipoMovimiento, string TipoDocumento, string NroDocumento, string CodItem2);
    }
}
