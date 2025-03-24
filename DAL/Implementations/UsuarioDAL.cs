using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class UsuarioDAL : DALGenericoImpl<Usuario>, IUsuarioDAL
    {
        private G3prograavanzadaContext _context;
    public UsuarioDAL(G3prograavanzadaContext context) : base(context)
    {
        _context = context;
    }
    }
}
