using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.ACore.Abstract
{
    public interface IRepositoryBase<Entity>
    {
        int Add(Entity entity);
        int Update(Entity entity);
        int Delete(Entity entity);
        List<Entity> GetList(Expression<Func<Entity, bool>> filter = null);
        Entity Get(Expression<Func<Entity, bool>> filter = null);
    }
}
