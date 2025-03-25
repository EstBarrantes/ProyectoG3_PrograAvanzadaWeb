using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class ProductoDAL : DALGenericoImpl<Producto>, IProductoDAL
    {
        private G3prograavanzadaContext _context;
        public ProductoDAL(G3prograavanzadaContext context) : base(context)
        {
            _context = context;
        }


    }
}
