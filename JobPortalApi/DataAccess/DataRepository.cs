using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobPortalApi.Models;
using System.Data.Entity;

namespace JobPortalApi.DataAccess
{
    
    
        public class DataRepository<TEntity> where TEntity : class
        {

            internal JobPortalDbEntities context;
            internal DbSet<TEntity> dbSet;

            public DataRepository(JobPortalDbEntities context)
            {
                this.context = context;
                this.dbSet = context.Set<TEntity>();
            }
            public virtual IEnumerable<TEntity> Get()
            {
                IQueryable<TEntity> query = dbSet;
                return query.ToList();
            }
            public virtual IEnumerable<TEntity> GetEger()
            {
                context.Configuration.LazyLoadingEnabled = false;
                IQueryable<TEntity> query = dbSet;
                return query.ToList();
            }

            public virtual TEntity GetByID(object id)
            {
                return dbSet.Find(id);
            }

            public virtual void Insert(TEntity entity)
            {
                dbSet.Add(entity);
            }

            public virtual void Delete(object id)
            {
                TEntity entityToDelete = dbSet.Find(id);
                DeleteData(entityToDelete);
            }

            public virtual void DeleteData(TEntity entityToDelete)
            {
                if (context.Entry(entityToDelete).State == System.Data.Entity.EntityState.Detached)
                {
                    dbSet.Attach(entityToDelete);
                }
                dbSet.Remove(entityToDelete);
            }

            public virtual void Attach(TEntity entityToUpdate)
            {
                dbSet.Attach(entityToUpdate);
                context.Entry(entityToUpdate).State = System.Data.Entity.EntityState.Modified;

            }
        }

    }


