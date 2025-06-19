using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinet.Application.DTOs
{
    public class MovInventarioDTO
    {
        public string CodCia { get; set; } = string.Empty;
        public string CompaniaVenta { get; set; } = string.Empty;
        public string AlmacenVenta { get; set; } = string.Empty;
        public string TipoMovimiento { get; set; } = string.Empty;
        public string TipoDocumento { get; set; } = string.Empty;
        public string NroDocumento { get; set; } = string.Empty;
        public string CodItem2 { get; set; } = string.Empty;
        public string Proveedor { get; set; } = string.Empty;
        public string AlmacenDestino { get; set; } = string.Empty;
        public int? Cantidad { get; set; }
        public string DocRef1 { get; set; }
        public string DocRef2 { get; set; }
        public string DocRef3  { get; set; }
        public string DocRef4 { get; set; }
        public string DocRef5 { get; set; }
        public DateTime? FechaTransaccion { get; set; }
    }
}
