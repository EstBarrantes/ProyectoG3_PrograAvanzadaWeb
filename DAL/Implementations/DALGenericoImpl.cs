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
    public class DALGenericoImpl<TEntity> : IDALGenerico<TEntity> where TEntity : class
    {

        private ProyectoContext _ProyectoContext;

        public DALGenericoImpl(ProyectoContext ProyectoContext)
        {
            
            _ProyectoContext = ProyectoContext;
        }

        public bool Add(TEntity entity)
        {
            try
            {
                _ProyectoContext.Add(entity);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public TEntity Get(int id)
        {

            return _ProyectoContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _ProyectoContext.Set<TEntity>().ToList();
        }

        public bool Remove(TEntity entity)
        {
            try
            {
                _ProyectoContext.Set<TEntity>().Attach(entity);
                _ProyectoContext.Set<TEntity>().Remove(entity);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update(TEntity entity)
        {
            try
            {
                _ProyectoContext.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
