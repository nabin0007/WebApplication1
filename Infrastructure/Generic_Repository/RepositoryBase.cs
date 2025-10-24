using System.Data;

namespace Infrastructure.Generic_Repository
{
    public abstract class RepositoryBase(IDbTransaction? transaction)
    {
        protected IDbTransaction? Transaction { get; set; } = transaction!;
        protected IDbConnection? Connection =  transaction!.Connection!;
    }
}
