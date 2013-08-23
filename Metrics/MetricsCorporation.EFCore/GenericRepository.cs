using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Linq.Expressions;
using LinqKit;
using MetricsCorporation.Infrastructure.Interfaces;

namespace MetricsCorporation.EFCore
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        const string ActiveFieldName = "Active";
        const string DeletedFieldName = "Deleted";

        internal state_schematicEntities _context;
        internal DbSet<TEntity> _dbSet;

        private bool _supportActive = false;
        private bool _supportSoftDelete = false;

        public GenericRepository(state_schematicEntities context)
        {
            this._context = context;
            this._dbSet = context.Set<TEntity>();

            _supportActive = typeof(ISupportActive).IsAssignableFrom(typeof(TEntity));
            _supportSoftDelete = typeof(ISupportSoftDelete).IsAssignableFrom(typeof(TEntity));
        }

        protected virtual void BeforeInsert(TEntity entity) { }
        protected virtual void BeforeUpdate(TEntity entity) { }
        protected virtual void BeforeDelete(TEntity entity) { }

        public virtual IQueryable<TEntity> AllItems
        {
            get { return _dbSet; }
        }
        
        public virtual IQueryable<TEntity> Items
        {
            get 
            {
                var items = AllItems;
                if (_supportActive)
                    items = items.Where(string.Format("{0}", ActiveFieldName));
                if (_supportSoftDelete)
                    items = items.Where(string.Format("not {0}", DeletedFieldName));
                return items; 
            }
        }

        public virtual IQueryable<TEntity> DeletedItems
        {
            get
            {
                var items = AllItems;
                if (_supportActive)
                    items = items.Where(string.Format("not {0}", ActiveFieldName));
                if (_supportSoftDelete)
                    items = items.Where(string.Format("{0}", DeletedFieldName));
                return items;
            }
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", bool includeDeleted = false )
        {
            IQueryable<TEntity> query = _dbSet.AsExpandable();

            if (_supportActive && !includeDeleted)
                query = query.Where(string.Format("{0}", ActiveFieldName));

            if (_supportSoftDelete && !includeDeleted)
                query = query.Where(string.Format("not {0}", DeletedFieldName));

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        

        public virtual TEntity GetByID(object id, bool includeDeleted = false)
        {
            TEntity entity = _dbSet.Find(id);
            if (entity != null)
            {
                ISupportActive activeEntity = entity as ISupportActive;
                if (activeEntity != null)
                {
                    if (!activeEntity.Active && !includeDeleted)
                        entity = null;
                }
                else
                {
                    ISupportSoftDelete softDelEntity = entity as ISupportSoftDelete;
                    if (softDelEntity != null)
                    {
                        if (softDelEntity.Deleted && !includeDeleted)
                            entity = null;
                    }
                }
            }
            return entity;
        }

        public virtual TEntity Insert(TEntity entity)
        {
            BeforeInsert(entity);

            if (typeof(ISupportActive).IsAssignableFrom(typeof(TEntity)))
            {
                ISupportActive e = (ISupportActive)entity;
                e.Active = true;
            }

            return _dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            BeforeDelete(entityToDelete);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }

            // Add support for ISupportActivateEntity
            ISupportActive entity = entityToDelete as ISupportActive;
            if (entity != null)
            {
                if (entity.Active)
                    entity.Active = false;
            }
            else
            {
                ISupportSoftDelete entSoftDel = entityToDelete as ISupportSoftDelete;
                if (entSoftDel != null)
                {
                    if (!entSoftDel.Deleted)
                        entSoftDel.Deleted = true;
                }
                else
                    _dbSet.Remove(entityToDelete);
            }
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            BeforeUpdate(entityToUpdate);
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
