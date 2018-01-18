using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarPool.Shared.CustomModels;

namespace CarPool.DAL.Interfaces
{
    public interface IApplicationUserRepo : IDisposable
    {
        object GetLoginUser(LoginUserModel Logininfo);
        OperationStatus SaveApplicationUser(ApplicationUserModel user);
    }
}
