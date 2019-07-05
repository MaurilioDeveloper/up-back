using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Positivo.AtividadesComplementares.Infrastructure.IRepositoy;
using Qualyteam.Repository;

namespace Positivo.AtividadesComplementares.Infrastructure.Repository
{
    public class Repository<T, Key> : IRepository<T, Key> where T : class
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }
        
        public virtual IEnumerable<T> UpdateRange(IEnumerable<T> entities)
        {
            _context.Set<T>().UpdateRange(entities);
            return entities;
        }
        
       public void UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            
        }

        public virtual T Update(Key key, T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var actualEntity = Find(key);
            if (actualEntity == null) throw new ArgumentNullException(nameof(entity));

            _context.Entry(actualEntity).CurrentValues.SetValues(entity);
            if (actualEntity is BaseEntity) 
            {
                foreach (var property in typeof(BaseEntity).GetProperties()) 
                {
                    _context
                        .Entry(actualEntity)
                        .Property(property.Name)
                        .IsModified = false;
                }
            }
            return actualEntity;
        }

        public async virtual Task<T> FindAsync(Key key)
        {
            var primaryKeys = PrimaryKeys(_context);

            var keyProperties = typeof(Key).GetProperties();
            IQueryable<T> entities = _context.Set<T>();
            var parameter = Expression.Parameter(typeof(T), "x");
            if (keyProperties.Count() == 0)
            {
                var lambda = (Expression<Func<T, bool>>)
                    Expression.Lambda(
                        Expression.Equal(
                            Expression.Property(parameter, primaryKeys[0]),
                            Expression.Constant(key)),
                        parameter);
                entities = entities.Where(lambda);
            }
            else
            {
                var i = 0;
                foreach (var property in keyProperties)
                {
                    var primaryKey = primaryKeys.ToList().Where(k => k == property.Name).First();
                    var lambda = (Expression<Func<T, bool>>)
                        Expression.Lambda(
                            Expression.Equal(
                                Expression.Property(parameter, primaryKey),
                                Expression.Constant(property.GetValue(key))),
                            parameter);
                    entities = entities.Where(lambda);
                    i++;
                }
            }

            return await entities.FirstOrDefaultAsync();
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual T Delete(Key key)
        {
            var entity = Find(key);
            if (entity == null) new ArgumentNullException(nameof(entity));
            Delete(entity);
            return entity;
        }

        public virtual void Dispose()
        {
            _context.Dispose();
        }

        public virtual void Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Set<T>().Add(entity);
        }

        public int Count(Func<T, bool> include)
        {
            IEnumerable<T> entities = _context.Set<T>();
            if (include != null)
            {
                entities = entities.Where(include);
            }
            return entities.Count();
        }

        public virtual List<T> List(Func<T, bool> filter)
        {
            IEnumerable<T> entities = _context.Set<T>();

            if (filter != null)
            {
                entities = entities.Where(filter);
            }

            return entities.ToList();
        }

        private List<string> PrimaryKeys(DbContext context)
        {
            var entityType = context.Model.FindEntityType(typeof(T));
            var primaryKeys = entityType.FindPrimaryKey();

            return primaryKeys.Properties.Select(k => k.Name).ToList();
        }

        public virtual T Find(Key key)
        {
            var primaryKeys = PrimaryKeys(_context);

            var keyProperties = typeof(Key).GetProperties();
            IQueryable<T> entities = _context.Set<T>();
            var parameter = Expression.Parameter(typeof(T), "x");
            if (keyProperties.Count() == 0)
            {
                var lambda = (Expression<Func<T, bool>>)
                    Expression.Lambda(
                        Expression.Equal(
                            Expression.Property(parameter, primaryKeys[0]),
                            Expression.Constant(key)),
                        parameter);
                entities = entities.Where(lambda);
            }
            else
            {
                var i = 0;
                foreach (var property in keyProperties)
                {
                    var primaryKey = primaryKeys.ToList().Where(k => k == property.Name).First();
                    var lambda = (Expression<Func<T, bool>>)
                        Expression.Lambda(
                            Expression.Equal(
                                Expression.Property(parameter, primaryKey),
                                Expression.Constant(property.GetValue(key))),
                            parameter);
                    entities = entities.Where(lambda);
                    i++;
                }
            }

            return entities.AsNoTracking().FirstOrDefault();
        }

        public virtual void Clean()
        {
            var set = _context.Set<T>();
            set.RemoveRange(set);
        }
    }
}