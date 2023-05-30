using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Aplicacion.Dtos.Response
{
    public class CategoriaResponseDto
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime AuditCreateDate { get; set; }
        public int State { get; set; }
        public string? EstadoDescriptivo { get; set; }
    }
}
