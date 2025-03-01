﻿using DAL.Interfaces;
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
        private G3prograavanzadaContext _context;
        public RolDAL (G3prograavanzadaContext context) : base(context)
        {
            _context = context;
        }


    }
}
