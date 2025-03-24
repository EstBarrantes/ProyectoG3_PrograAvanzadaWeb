using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnidadDeTrabajo: IDisposable
    {
        IRolDAL RolDAL { get; }
        ICategoriaDAL CategoriaDAL { get; }
       
        IUsuarioDAL UsuarioDAL { get; }

        bool Complete();
    }
}
