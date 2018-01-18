using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarPool.Shared.CustomModels;

namespace CarPool.BDC.Interfaces
{
    public interface ICarPoolAssociationBusiness : IDisposable
    {
        OperationStatus SubmitCarPoolRequest(CarPoolAssociationCustomModel model);

        object ListMyCarPoolRequest(int Id, DateTime DDate);

        object ListAllCarPoolRequest(CarPoolAssociationCustomModel model);

        OperationStatus ActionCarPoolRequest(CarPoolAssociationCustomModel model);

        object ListMyCarPoolActionRequest(int Id, DateTime DDate, int Status);

    }
}
