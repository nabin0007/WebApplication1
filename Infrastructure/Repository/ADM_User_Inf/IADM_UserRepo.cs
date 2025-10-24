using Domain.DomainModel;
using Infrastructure.Generic_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ADM_User_Inf
{
    public interface IADM_UserRepo<T> : IGenericRepository<T> where T : class {
        

    }
}
