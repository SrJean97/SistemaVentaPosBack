using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Infraestructura.Persistencia.Interfaces
{
    public interface IUnitOfWork :  IDisposable
    {
        //Acá crearemos todas nuestras interfaces a utilizara  nivel de interfaces de infraestructura.





        //Estos dos métodos 
        void SaveChanges();
        public  Task SaveChangesAsync();
    }
}
