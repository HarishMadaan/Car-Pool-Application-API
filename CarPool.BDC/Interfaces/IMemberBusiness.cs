using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarPool.Shared.CustomModels;

namespace CarPool.BDC.Interfaces
{
    public interface IMemberBusiness : IDisposable
    {
        object GetApplicationMemberList(MemberCustomModel objMemberModel);
        OperationStatus ForgotPassword(ForgotPasswordCustomModel model);
    }
}
