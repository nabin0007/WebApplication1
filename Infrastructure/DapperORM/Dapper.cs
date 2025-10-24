

using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Infrastructure.DapperORM
{
    public class Dapper<T> : IDapper<T>, IDisposable
    {



        protected IDbTransaction? Transaction { get; private set; }
        protected IDbConnection? Connection { get { return Transaction!.Connection!; } }
      

        public Dapper(IDbTransaction? transaction)
        {
            //var configurationBuilder = new ConfigurationBuilder();
            //var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            //configurationBuilder.AddJsonFile(path, false);

            //var root = configurationBuilder.Build();
            //var _sqlConnection = root.GetConnectionString("DefaultConnection");

            //Connection = new SqlConnection(_sqlConnection);

            //_connection = new SqlConnection(configuration!.GetConnectionString("DefaultConnection"));
            //_connection.Open();
            //_transaction = _connection.BeginTransaction();


            Transaction = transaction;
        }


        public IEnumerable<T?> Query(string sql, object param = null!, IDbTransaction transaction = null!, CancellationToken cancellationToken = default)
        {
            try
            {
                return Connection!.Query<T>(sql, param, transaction).AsEnumerable();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public T? QueryFirstOrDefault(string sql, object param = null!, IDbTransaction transaction = null!, CancellationToken cancellationToken = default)
        {
            try
            {
                return Connection.QueryFirstOrDefault<T>(sql, param, transaction);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public T? QuerySingle(string sql, object param = null!, IDbTransaction transaction = null!, CancellationToken cancellationToken = default)
        {
            try
            {
                return Connection.QuerySingle<T>(sql, param, transaction);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public int? Execute(string sql, object param = null!, IDbTransaction transaction = null!, CommandType? commandType = null)
        {
            try
            {
                return Connection!.Execute(sql, param, transaction);
            }
            catch (Exception)
            {
                throw;
            }

        }


        public void Dispose()
        {
            Connection.Dispose();
        }
    }
}
