using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarPool.Shared.CustomModels;
using CarPool.BDC.Interfaces;
using CarPool.DAL.Interfaces;
using CarPool.DAL.Repositories;

namespace CarPool.BDC.Classes
{
    public class MemberBusiness : IMemberBusiness
    {
        IMemberRepo objDAL;

        /// <summary>
        /// This method is used to fetch All Members
        /// </summary>
        /// <returns></returns>
        /// 
        public object GetApplicationMemberList(MemberCustomModel objMemberModel)
        {
            using (objDAL = new MemberRepo())
            {
                return objDAL.GetApplicationMemberList(objMemberModel);
            }
        }

        public OperationStatus ForgotPassword(ForgotPasswordCustomModel model)
        {
            using (objDAL = new MemberRepo())
            {
                return objDAL.ForgotPassword(model);
            }
        }

        public void Dispose()
        {
            objDAL.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
