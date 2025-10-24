
using Domain.BusinessDomain;
using Domain.DomainModel;
using Infrastructure.Repository.Employee_Inf;
using Infrastructure.UnitOfWork_Inf;
using Z.BulkOperations;

namespace Application.ApplicatonService.IEmployee_Serivice
{
    public class Employee<T>(IUnitOfWork<Employee> UnitOfWork, IEmployeeRepo<Employee> Employee_Repo) : IEmployee<T> where T : class
    {
        #region "Constructor"
        ResultInfo resultInfo = new();

        readonly IUnitOfWork<Employee> UnitOfWork = UnitOfWork;

        readonly IEmployeeRepo<Employee> Employee_Repo = Employee_Repo;



        #endregion " End Constructor"


        public Employee_Model? Models { get; set; }


        public T? GetEmployee_List<Q>(T? Entity)
        {
            Models = new();
            Models = Entity as Employee_Model;

            Models!.ListEmployeeModel = (IList<Employee>?)Employee_Repo.GetEmployeeList<Employee>(Models.EmployeeModel)!;

            return Models as T;

        }

        public T? Update<Q>(T? Entity)
        {
            try
            {
                Models = new();
                Models = Entity as Employee_Model;

                resultInfo = UnitOfWork.Update(Models!.EmployeeModel!);

                if (resultInfo.RowsAffectedInserted > 0)
                {
                    UnitOfWork.Complete();
                    Models!.EmployeeModel!.EmployeeID = resultInfo.RowsAffected;
                }
                else
                {
                    UnitOfWork.Dispose();
                }

                return Models as T;
            }
            catch
            {
                throw;
            }

        }


        public T? Insert<Q>(T? Entity)
        {
            try
            {
                Models = new();
                Models = Entity as Employee_Model;

                resultInfo = UnitOfWork.SingleInsert<Employee>(Models!.EmployeeModel!);

                if (resultInfo.RowsAffectedInserted > 0)
                {
                    UnitOfWork.Complete();
                    Models!.EmployeeModel!.EmployeeID = resultInfo.RowsAffected;
                }
                else
                {
                    UnitOfWork.Dispose();
                }

                return Models as T;
            }
            catch
            {
                throw;
            }

        }


    }
}
