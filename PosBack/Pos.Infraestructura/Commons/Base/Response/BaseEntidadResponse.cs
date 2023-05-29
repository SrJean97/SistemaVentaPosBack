using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Infraestructura.Commons.Base.Response
{
    public class BaseEntidadResponse<T>
    {
        public int? TotalRegistros { get; set; }
        public List<T>? TotalItems { get; set;}
    }
}