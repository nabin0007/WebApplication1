using Domain.DomainModel;
using Infrastructure.Generic_Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.BulkOperations;

namespace Infrastructure.Repository.Employee_Inf
{
    public interface IEmployeeRepo<T> : IGenericRepositoryQuery<T> where T : class
    {
        public IEnumerable<T>? GetEmployeeCode<Q>(T? Entity);
        public IEnumerable<T>? GetEmployeeList<Q>(T? Entity);
    }


}
