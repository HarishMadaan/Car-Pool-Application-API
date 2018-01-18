using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarPool.Shared.CustomModels;

namespace CarPool.BDC.Interfaces
{
    public interface ICarPoolRegistrationBusiness : IDisposable
    {
        OperationStatus SaveCarPoolApplication(CarPoolRegistrationCustomModel model);

        object SearchCarPoolApplication(CarPoolRegistrationCustomModel model);

        object MyCarPoolApplication(int MemberId);

    }
}
