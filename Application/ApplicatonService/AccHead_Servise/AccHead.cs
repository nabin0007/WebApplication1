using Domain.BusinessDomain;
using Domain.DomainModel;
using Infrastructure.Repository.Acc_Head_Inf;
using Infrastructure.UnitOfWork_Inf;
using System.Reflection;
using Z.BulkOperations;


namespace Application.ApplicatonService.AccHead_Servise
{
    public class AccHead<T>(IUnitOfWork<AccHead_Model> UnitOfWork) : IAccHead<T> where T : class
    {
        #region "Constructor"

        readonly IUnitOfWork<AccHead_Model> UnitOfWork = UnitOfWork;
        ResultInfo resultInfo = new ResultInfo();


        #endregion "Constructor"
                
        
        public T? CreateAccHead<Q>(T? Entity)
        {
            throw new NotImplementedException();
        }



        //public T? CreateAccHead<AccHead_Model>(AccHead_Model? Entity)
        //{
        //    try
        //    {
        //        //Entity!.AccHeadModel =new Acc_Head();

        //        ////Entity!.ADM_UserModel!.ID = Convert.ToString(Guid.NewGuid().ToString());
        //        //Entity!.ADM_UserModel!.UserId = Entity.Username!;
        //        //Entity!.ADM_UserModel.Password = Entity.Password!;


        //        // resultInfo = UnitOfWork.Acc_HeadRepo.SingleInsert(Entity!.AccHeadModel);

        //        resultInfo = UnitOfWork.AccHeadRepo.SingleInsert<Acc_Head>(Entity!.AccHeadModel);


        //        if (resultInfo.RowsAffectedInserted > 0)
        //        {
        //            UnitOfWork.Complete();
        //        }
        //        else
        //        {
        //            UnitOfWork.Dispose();
        //        }

        //        return default;

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}







        //public T? CreateAccHead<T1>(T1? models)
        //{
        //    throw new NotImplementedException();
        //}
    }


}
