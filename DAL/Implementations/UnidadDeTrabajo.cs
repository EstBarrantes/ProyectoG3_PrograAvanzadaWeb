﻿using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        public IRolDAL RolDAL { get; set; }
        public ICategoriaDAL CategoriaDAL { get; set; }

        private G3prograavanzadaContext _proyectoContext;

        public UnidadDeTrabajo(G3prograavanzadaContext proyectoContext,
                        IRolDAL rolDAL,
                        ICategoriaDAL categoriaDAL)
        {
            this._proyectoContext = proyectoContext;
            this.RolDAL = rolDAL;
            CategoriaDAL = categoriaDAL;
        }



        public bool Complete()
        {
            try
            {
                _proyectoContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Dispose()
        {
            this._proyectoContext.Dispose();
        }
    }
}
