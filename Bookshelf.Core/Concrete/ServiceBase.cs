using Bookshelf.ACore.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.ACore.Concrete
{
    /*
        Servis katmanlarını ortak işlemler için.
    */
    public class ServiceBase<TEntityDal, TEntity> : IServiceBase<TEntity>
        where TEntity : class, IEntity, new()
        where TEntityDal : IRepositoryBase<TEntity>
    {
        TEntityDal _entityDal;

        public ServiceBase(TEntityDal entityDal)
        {
            _entityDal = entityDal;
        }

        public IReturnException<object> Add(TEntity entity)
        {
            IReturnException<object> returnException = new ReturnException<object>();

            try
            {
                int AddControl = _entityDal.Add(entity);
                if (AddControl > 0)
                {
                    returnException.SetReturnException(Status: true, Message: "Ekleme işlemi başarılı", Data: entity);
                    return returnException;
                }
                else
                {
                    returnException.SetReturnException(Status: false, Message: "Ekleme başarısız oldu !", Data: entity);
                    return returnException;
                }
            }
            catch (Exception e)
            {
                returnException.SetReturnException(Status:false,Message:"Teknik bir problem oluştu !",Data:entity, Exception: e);
                return returnException;
            }

            
        }

        public IReturnException<object> Delete(TEntity entity)
        {
            IReturnException<object> returnException = new ReturnException<object>();
            try
            {
                int DeleteControl = _entityDal.Delete(entity);
                
                if (DeleteControl > 0)
                {
                    returnException.SetReturnException(Status: true, Message: "Silme işlemi başarılı", Data: entity);
                    return returnException;
                }
                else
                {
                    returnException.SetReturnException(Status: false, Message: "Silme işlemi başarısız !", Data: entity);
                    return returnException;
                }
            }
            catch (Exception e)
            {
                returnException.SetReturnException(Status:false,Message:"Teknik bir problem oluştu !",Data:entity,Exception:e);
                return returnException;
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ? _entityDal.Get() : _entityDal.Get(filter);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ? _entityDal.GetList() : _entityDal.GetList(filter);
        }

        public IReturnException<object> Update(TEntity entity)
        {
            IReturnException<object> returnException = new ReturnException<object>();
            try
            {
                var UpdateControl = _entityDal.Update(entity);
                
                if (UpdateControl > 0)
                {
                    returnException.SetReturnException(Status:true,Message:"Güncelleme işlemi başarılı",Data:entity);
                    return returnException;
                }
                else
                {
                    returnException.SetReturnException(Status: false, Message: "Güncelleme işlemi başarısız !", Data: entity);
                    return returnException;
                }
            }
            catch (Exception e)
            {
                returnException.SetReturnException(Status: false, Message: "Teknik bir problem oluştu !", Data: entity,Exception:e);
                return returnException;
            }
        }
    }
}
