using Microsoft.EntityFrameworkCore;
using Overtime_API.Context;
using Overtime_API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime_API.Repositories
{
    public class GeneralRepository<Context, Entity, Key> : IRepository<Entity, Key>
        where Entity : class
        where Context : MyContext
    {
        private readonly MyContext myContext;
        private readonly DbSet<Entity> entities;
        public GeneralRepository(MyContext myContext)
        {
            this.myContext = myContext;
            entities = myContext.Set<Entity>();
        }

        public int Create(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("entity");
            }
            entities.Add(entity);
            return myContext.SaveChanges();
        }

        public int Delete(Key key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("entity");
            };
            Entity entity = entities.Find(key);
            entities.Remove(entity);
            return myContext.SaveChanges();
        }

        public Entity Get(Key key)
        {
            return entities.Find(key);
        }

        public IEnumerable<Entity> GetAll()
        {
            return entities.ToList();
        }

        public int Update(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            myContext.Entry(entity).State = EntityState.Modified;
            var result = myContext.SaveChanges();
            return result;
        }
    }
}
