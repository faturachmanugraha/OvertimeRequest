using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime_API.Repositories.Interfaces
{
    // harus public
    public interface IRepository<Entity,Key> where Entity : class
    {
        IEnumerable<Entity> GetAll();
        Entity Get(Key key);
        int Create(Entity entity);
        int Update(Entity entity);
        int Delete(Key key);
    }
}
