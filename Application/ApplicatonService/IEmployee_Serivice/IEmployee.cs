using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ApplicatonService.IEmployee_Serivice
{
    public interface IEmployee<T> where T : class
    {
        public T? GetEmployee_List<Q>(T? Entity);
        public T? Update<Q>(T? Entity);

        public T? Insert<Q>(T? Entity);
    }
}
