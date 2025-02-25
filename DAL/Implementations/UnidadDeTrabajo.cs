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
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        public IRolDAL RolDAL { get; set; }

        private ProyectoContext _proyectoContext;

        public UnidadDeTrabajo(ProyectoContext proyectoContext,
                        IRolDAL rolDAL) 
        {
            this._proyectoContext = proyectoContext;
            this.RolDAL = rolDAL;
                
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
