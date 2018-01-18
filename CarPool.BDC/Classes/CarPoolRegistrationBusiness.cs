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
    public class CarPoolRegistrationBusiness : ICarPoolRegistrationBusiness
    {
        ICarPoolRegistrationRepo objDAL;

        /// <summary>
        /// This method is used to fetch All Kisan Market
        /// </summary>
        /// <returns></returns>
        /// 
        public object SearchCarPoolApplication(CarPoolRegistrationCustomModel model)
        {
            using (objDAL = new CarPoolRegistrationRepo())
            {
                return objDAL.SearchCarPoolApplication(model);
            }
        }

        public OperationStatus SaveCarPoolApplication(CarPoolRegistrationCustomModel model)
        {
            using (objDAL = new CarPoolRegistrationRepo())
            {
                return objDAL.SaveCarPoolApplication(model);
            }
        }

        public object MyCarPoolApplication(int MemberId)
        {
            using (objDAL = new CarPoolRegistrationRepo())
            {
                return objDAL.MyCarPoolApplication(MemberId);
            }
        }

        public void Dispose()
        {
            objDAL.Dispose();
            GC.SuppressFinalize(this);
        }

        
    }
}
