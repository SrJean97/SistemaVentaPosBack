using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Infraestructura.Commons.Base.Request
{
    public class BaseFiltrosRequest : BasePaginacionRequest
    {
        public int? NumeroTipoFiltro { get; set; } = null;
        public string? TextoFiltro { get; set; } = null;
        public int? EstadoFiltro { get; set; } = null;
        public string? FechaInicio { get; set; } = null;
        public string? FechaFinal { get; set; } = null;
        public bool? DescargaExcel { get; set; } = false;
    }
}
