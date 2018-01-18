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
    public class CarPoolAssociationBusiness : ICarPoolAssociationBusiness
    {
        ICarPoolAssociationRepo objDAL;

        /// <summary>
        /// This method is used to fetch All Association
        /// </summary>
        /// <returns></returns>
        public OperationStatus SubmitCarPoolRequest(CarPoolAssociationCustomModel model)
        {
            using (objDAL = new CarPoolAssociationRepo())
            {
                return objDAL.SubmitCarPoolRequest(model);
            }
        }

        public object ListMyCarPoolRequest(int Id, DateTime DDate)
        {
            using (objDAL = new CarPoolAssociationRepo())
            {
                return objDAL.ListMyCarPoolRequest(Id, DDate);
            }
        }

        public object ListAllCarPoolRequest(CarPoolAssociationCustomModel model)
        {
            using (objDAL = new CarPoolAssociationRepo())
            {
                return objDAL.ListAllCarPoolRequest(model);
            }
        }

        public OperationStatus ActionCarPoolRequest(CarPoolAssociationCustomModel model)
        {
            using (objDAL = new CarPoolAssociationRepo())
            {
                return objDAL.ActionCarPoolRequest(model);
            }
        }

        public object ListMyCarPoolActionRequest(int Id, DateTime DDate, int Status)
        {
            using (objDAL = new CarPoolAssociationRepo())
            {
                return objDAL.ListMyCarPoolActionRequest(Id, DDate, Status);
            }
        }
        
        public void Dispose()
        {
            objDAL.Dispose();
            GC.SuppressFinalize(this);
        }


    }
}
