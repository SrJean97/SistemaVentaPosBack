using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Infraestructura.Persistencia.Interfaces
{
    public interface IRepositorioGenerico<T> where T : class
    {
        //Este repositorio generico va a contener el crud común entre todas las clases conocidas.
    }
}
