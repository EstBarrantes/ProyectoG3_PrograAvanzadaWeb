using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class RolDAL : DALGenericoImpl<Rol>, IRolDAL
    {
        private ProyectoContext _context;
        public RolDAL (ProyectoContext context) : base(context)
        {
            _context = context;
        }


    }
}
