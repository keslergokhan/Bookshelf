using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.ACore.Abstract
{
    public interface IServiceBase<TEntity> where TEntity :class,IEntity,new()
    {
        IReturnException<object> Add(TEntity entity);
        IReturnException<object> Delete(TEntity entity);
        IReturnException<object> Update(TEntity entity);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        TEntity Get(Expression<Func<TEntity, bool>> filter = null);
    }
}
