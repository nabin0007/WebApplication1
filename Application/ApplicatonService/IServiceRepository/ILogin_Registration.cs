using Domain.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Application.ApplicatonService.IServiceRepository
{
	public  interface ILogin_Registration
	{
        ADM_User LoginSessionCreate(ADM_User ADM_User_obj);
    }
}
