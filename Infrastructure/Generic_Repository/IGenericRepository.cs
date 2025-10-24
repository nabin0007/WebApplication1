using Domain.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Z.BulkOperations;

namespace Infrastructure.Generic_Repository
{
    public interface IGenericRepository<T> where T : class
    {
        #region insert update delete     
        ResultInfo SingleInsert<Q>(T? entity);
        ResultInfo SingleUpdate(T? entity);
        ResultInfo SingleDelete(T? entity);
        ResultInfo BulkInsert(List<T?> entity); 
        Task<T> AddAsync<Q>(T entity);
        public ResultInfo Update(Employee entity);
        #endregion

    }

    public interface IGenericRepositoryQuery<T> where T : class
    {
        public T GetById(int? id);
        public Task<IEnumerable<T>?> GetAllAsync<Q>(T? Entity);
    }
}
