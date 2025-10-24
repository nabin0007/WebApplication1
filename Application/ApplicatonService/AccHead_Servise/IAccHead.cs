using Domain.BusinessDomain;
using Domain.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Application.ApplicatonService.AccHead_Servise
{
    public interface IAccHead<T> where T : class
    {
        // T? CreateAccHead<T1>(T1? models);
        T? CreateAccHead<Q>(T? Entity);
    }
}
