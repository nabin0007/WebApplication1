using Application.ApplicatonService.IServiceRepository;
using Domain.DomainModel;
using Infrastructure.Repository.IRepo_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.ApplicatonService.ServiceRepository
{
    public class Login_Registration : ILogin_Registration
    {
        #region "Constructor"

        IADM_User ADM_User;
        public Login_Registration(IADM_User ADM_User)
        {
            this.ADM_User = ADM_User;
        }


        #endregion "Constructor"


        public ADM_User LoginSessionCreate(ADM_User ADM_User_obj)
        {
           
            return ADM_User.GetByIdAsync(ADM_User_obj)!;

        }
    }
}
