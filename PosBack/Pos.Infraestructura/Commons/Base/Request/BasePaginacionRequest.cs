using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Infraestructura.Commons.Base.Request
{
    public class BasePaginacionRequest
    {
        public int NumPagina { get; set; } = 1;
        public int NumRegistrosPorPagina { get; set; } = 10;
        public readonly int NumMaxRegistrosPorPagina = 50;
        public string? Ordenar { get; set; } = "asc";
        public string? AtributoPorCualOrdenar { get; set; } = null;

        //Especiicar el registro inicial.
        public int RegistroInicial
        {
            get => NumRegistrosPorPagina;
            set
            {
                NumRegistrosPorPagina = value > NumMaxRegistrosPorPagina ? NumMaxRegistrosPorPagina : value;
            }
        }
    }
}
