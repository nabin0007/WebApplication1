using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DapperORM
{
    public interface IDapper<T>
    {
        public IEnumerable<T?> Query(string sql, object param = null!, IDbTransaction transaction = null!, CancellationToken cancellationToken = default);
        public T? QueryFirstOrDefault(string sql, object param = null!, IDbTransaction transaction = null!, CancellationToken cancellationToken = default);
        public T? QuerySingle(string sql, object param = null!, IDbTransaction transaction = null!, CancellationToken cancellationToken = default);
        public int? Execute(string sql, object param = null!, IDbTransaction transaction = null!, CommandType? commandType = null);
        
    }
}
