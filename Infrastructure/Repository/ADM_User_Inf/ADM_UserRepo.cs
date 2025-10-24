
using Dapper;
using Dapper.Transaction;
using Domain.DomainModel;
using Infrastructure.Generic_Repository;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.Transactions;
using Z.BulkOperations;
using Z.Dapper.Plus;

namespace Infrastructure.Repository.ADM_User_Inf
{

    public class ADM_UserRepo<T>(IDbTransaction? transaction, ResultInfo resultInfo) : RepositoryBase(transaction), IADM_UserRepo<T> where T : class
    {

        public async Task<T> AddAsync<Q>(T? entity)
        {
            try
            {
                var sql = @" Insert into ADM_User (ID,UserId, Password) VALUES (@ID,@UserId, @Password)";

                var result = await Connection!.ExecuteScalarAsync<T>(sql, entity, Transaction, null, CommandType.Text);

                return (T)result!;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public ResultInfo SingleInsert<Q>(T? entity)
        {
            try
            {
                transaction.UseBulkOptions(options =>
                {
                    options.UseRowsAffected = true;
                    options.ResultInfo = resultInfo;
                    options.InsertKeepIdentity = true;
                }
                ).SingleInsert(entity);

                return resultInfo!;

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
                    options.ResultInfo = resultInfo;
                }).SingleUpdate(entity);

                return resultInfo!;

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
                    options.ResultInfo = resultInfo;
                }).SingleDelete(entity);

                return resultInfo!;

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
                    options.ResultInfo = resultInfo;
                }).BulkInsert(entity);

                return resultInfo!;

            }
            catch (Exception)
            {
                throw;
            }


        }    
        public  T GetById(int id)
        {

            dynamic Materials = new ExpandoObject();

            dynamic Product = new ExpandoObject();
            dynamic MeasureUnit = new ExpandoObject();

        
            var Sql =
                      @"  SELECT Materials.*, " +
                      "   Product.ItemtId as _SplitPoint_," +
                      "   Product.*, " +
                      "   MeasureUnit.IntIdUM as _SplitPoint_, " +
                      "   MeasureUnit.* " +
                      "   FROM Materials INNER JOIN " +
                      "   Product ON Materials.ItemtId = Product.ItemtId INNER JOIN " +
                      "   MeasureUnit ON Materials.IntIdUM = MeasureUnit.IntIdUM ";

            //List<Materials> fTecnica3 =  Connection!.Query<Materials>
            //    (
            //        Sql,new[] { typeof(Materials), typeof(Product), typeof(MeasureUnit) },
            //        (objects) =>
            //        {
            //            Materials mat = (Materials)objects[0];
            //            mat.Product = (Product)objects[1];
            //            mat.MeasureUnit = (MeasureUnit)objects[2];
            //            return mat!;
            //        },
            //        splitOn: "_SplitPoint_"
            //    ).ToList();



            //dynamic myObj = new ExpandoObject();
            //myObj.Name = "John";

            //string name = myObj.Name; // name = "John"

            //string sql = "SELECT * FROM Authors A INNER JOIN Books B ON A.Id = B.AuthorId";

            //using (IDbConnection db = new SqlConnection(ConnectionString))
            //{
            //    var authors = db.Query<Author, Book>(sql).ToList();

            //    return authors;
            //}

            throw  new NotImplementedException();

        }
        public Task<IEnumerable<T>?> GetAllAsync<Q>(T? Entity)
        {

           // string sql = @"SELECT top 1 * FROM Company where CompanyId =@CompanyId;
											//SELECT top 1 * FROM Location where LocationId =@LocationId;
											//SELECT  * FROM BiznessEventNoTag ;
           //                                 SELECT top 1 * FROM BiznessEventTypeDetail as betd
								   //                left outer join BiznessEvent as be on be.BiznessEventId = betd.BiznessEventId
								   //                where  be.Name = @Name and BiznessEventTypeId =@BiznessEventTypeId and LocationId = @LocationId and CompanyId = @CompanyId ;


		    //"
           // ;

           // using (var multi = await Connection.QueryMultipleAsync(sql, new { Name = eventName, BiznessEventTypeId = eventTypeId, CompanyId = companyId, LocationId = locationId }))
           // {
           //     Company_Obj = await multi!.ReadFirstAsync<Company>();
           //     Location_Obj = await multi.ReadFirstAsync<Location>();
           //     BiznessEventNoTag_Objlist = multi.Read<BiznessEventNoTag>().ToList();

           //     BiznessEventTypeDetail_Obj = await multi.ReadFirstAsync<BiznessEventTypeDetail>();
           //     //BiznessEventNoTag_Objlist = await multi!.ReadFirstAsync<BiznessEventNoTag>();

           //     //BiznessEventNoTag_Objlists = multi.Read<BiznessEventNoTag>().ToList()!;  // saiful

           // }



            throw new NotImplementedException();
        }
    }
}
