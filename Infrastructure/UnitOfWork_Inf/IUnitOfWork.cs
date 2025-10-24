using Infrastructure.Generic_Repository;

namespace Infrastructure.UnitOfWork_Inf
{
    public interface IUnitOfWork<T> : IGenericRepository<T>, IDisposable where T : class
    {
        void Complete();
    }
}
