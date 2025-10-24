using Dapper;
using Domain.DomainModel;
using System.Data;
using Z.BulkOperations;
using Z.Dapper.Plus;

namespace Infrastructure.UnitOfWork_Inf
{
    public class UnitOfWork<T>(IDbTransaction transaction) : IUnitOfWork<T> where T : class
    {
        private bool _disposed;
        private IDbConnection _connection = transaction.Connection!;
        private readonly ResultInfo? ResultInfo = new ();

        public ResultInfo SingleInsert<Q>(T? entity)
        {
            try
            {
                transaction.UseBulkOptions(options =>
                {
                    options.UseRowsAffected = true;
                    options.ResultInfo = ResultInfo;
                }
                ).SingleInsert(entity);

                return ResultInfo!;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public ResultInfo SingleUpdate(T? entity)
        {
            try
            {
                transaction.UseBulkOptions(options =>
                {
                    options.UseRowsAffected = true;
                    options.ResultInfo = ResultInfo;
                }).SingleUpdate(entity);

                return ResultInfo!;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public ResultInfo SingleDelete(T? entity)
        {
            try
            {
                transaction.UseBulkOptions(options =>
                {
                    options.UseRowsAffected = true;
                    options.ResultInfo = ResultInfo;
                }).SingleDelete(entity);

                return ResultInfo!;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public ResultInfo BulkInsert(List<T?> entity)
        {
            try
            {
                transaction.UseBulkOptions(options =>
                {
                    options.UseRowsAffected = true;
                    options.ResultInfo = ResultInfo;
                }).BulkInsert(entity);

                return ResultInfo!;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> AddAsync<Q>(T entity)
        {
            try
            {
                var sql = @" Insert into ADM_User (ID,UserId, Password) VALUES (@ID,@UserId, @Password)  SELECT CAST(SCOPE_IDENTITY() as int";

                //  var result =await _connection!.ExecuteAsync<Q>(sql, entity, _transaction, null, CommandType.Text);

                entity = (T)await _connection.QueryAsync<T>(sql, entity, transaction, null, CommandType.Text);


                return entity; 

            }
            catch (Exception)
            {
                throw;
            }
        }

        public ResultInfo Update(Employee entity)
        {
            try
            {
                //var sql = @" UPDATE Employee
                //                    SET  FirstName =@FirstName, LastName =@LastName, Division =@Division, Building =@Building, Title =@Title, Room =@Room
                //                    WHERE  (EmployeeID = @EmployeeID ) ";

                //  var result =await _connection!.ExecuteAsync<Q>(sql, entity, _transaction, null, CommandType.Text);

               // entity = _connection.Query<Employee>(sql, entity, transaction,true, null, CommandType.Text);



                var sql1 = " UPDATE Employee SET  FirstName =@FirstName, LastName =@LastName, Division =@Division, Building =@Building, Title =@Title, Room =@Room WHERE  (EmployeeID = @EmployeeID ) ";
                _connection.Execute(sql1, entity, transaction);



                ResultInfo!.RowsAffectedInserted = 1;





                  return ResultInfo!; 

            }
            catch (Exception)
            {
                throw;
            }
        }




        #region ///  Complete  //   Dispose   //Dispose  // ~UnitOfWork()

        public void Complete()
        {
            try
            {
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                transaction.Dispose();
                transaction = _connection.BeginTransaction();
                _connection.Close();
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~UnitOfWork()
        {
            Dispose(false);
        }               
        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (transaction != null)
                    {
                        transaction.Dispose();
                        transaction = null!;
                    }
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null!;
                    }
                }
                _disposed = true;
            }
        }

        #endregion
    }
}
