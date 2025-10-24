
using Dapper;
using Dapper.Transaction;
using Domain.BusinessDomain;
using Domain.DomainModel;
using Infrastructure.Generic_Repository;
using System.Collections;
using System.Data;
using System.Reflection;
using static Dapper.SqlMapper;

namespace Infrastructure.Repository.Employee_Inf
{
    public class EmployeeRepo<T>(IDbTransaction? transaction) : RepositoryBase(transaction), IEmployeeRepo<T> where T : class
    {
        public T GetById(int? id)
        {
            var sql = "SELECT Account_Code, Account_Head, Sl, Dr_Cr, MainCode FROM Acc_Head where sl=@sl";
            var Acc_Head = Connection!.Query<Employee>(sql, new { sl = id });

            return (T)Acc_Head!;
        }

        public async Task<IEnumerable<T>?> GetAllAsync<Q>(T? Entity)
        {

            string sql = @"SELECT top 1 * FROM Company where CompanyId =@CompanyId;
											SELECT top 1 * FROM Location where LocationId =@LocationId;
											SELECT  * FROM BiznessEventNoTag ;
                                            SELECT top 1 * FROM BiznessEventTypeDetail as betd
								                   left outer join BiznessEvent as be on be.BiznessEventId = betd.BiznessEventId
								                   where  be.Name = @Name and BiznessEventTypeId =@BiznessEventTypeId and LocationId = @LocationId and CompanyId = @CompanyId ;

                           
		                    ";



            return (IList<T>?)await Connection!.QueryAsync<Q>(sql, Entity, Transaction);
        }

        public IEnumerable<T>? GetEmployeeCode<Q>(T? Entity)
        {
            try
            {
                var sqlq = "SELECT ROW_NUMBER() OVER (ORDER BY Sl) AS sl, Account_Code, Account_Head, Dr_Cr, MainCode FROM Acc_Head  where MainCode=@MainCode  ";

                return (IList<T>?)Connection!.Query<Q>(sqlq, Entity, Transaction)!.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<T>? GetEmployeeList<Q>(T? Entity)
        {
            try
            {
                Employee_Model? Models = new();
                Models = Entity as Employee_Model;

                var sqlq = "SELECT  EmployeeID, FirstName, LastName, Division, Building, Title, Room FROM     Employee";

                return (IEnumerable<T>?)Connection!.Query<Q>(sqlq, Entity, Transaction)!.ToList();


            }
            catch (Exception)
            {
                throw;
            }

        }
    }

}
