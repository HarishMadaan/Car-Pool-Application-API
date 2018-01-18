using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Transactions;

using System.Web;

using CarPool.Shared.CustomModels;
using CarPool.DAL.Interfaces;

namespace CarPool.DAL.Repositories
{
    public class CarPoolRegistrationRepo : ICarPoolRegistrationRepo
    {
        CarPoolApplicationEntities dbcontext = null;
        Response response;


        /// <summary>
        /// This method is used to save new pool info
        /// </summary>
        /// <returns></returns>
        public OperationStatus SaveCarPoolApplication(CarPoolRegistrationCustomModel model)
        {
            OperationStatus status = OperationStatus.Error;
            try
            {
                using (dbcontext = new CarPoolApplicationEntities())
                {
                    if (model.Id == 0)
                    {
                        tblCarPoolRegistration _addCarPool = new tblCarPoolRegistration
                        {
                            MemberId = model.MemberId,
                            Source = model.Source,
                            Destination = model.Destination,
                            PoolDate = model.PoolDate,
                            Time = model.Time,
                            Charges = model.Charges,
                            SeatsAvailable = model.SeatsAvailable,                           

                            IsActive = true,
                            IsDeleted = false,
                            CreatedDate = DateTime.Now,
                            CreatedBy = model.CreatedBy,
                            ModifiedDate = DateTime.Now,
                            ModifiedBy = model.ModifiedBy,

                        };
                        dbcontext.tblCarPoolRegistrations.Add(_addCarPool);
                        dbcontext.SaveChanges();

                        status = OperationStatus.Success;
                    }
                    else
                    {
                        var updatePoolInfo = dbcontext.tblCarPoolRegistrations.FirstOrDefault(m => m.Id == model.Id);
                        if (updatePoolInfo != null)
                        {
                            updatePoolInfo.MemberId = model.MemberId;
                            updatePoolInfo.Source = model.Source;
                            updatePoolInfo.Destination = model.Destination;
                            updatePoolInfo.PoolDate = model.PoolDate;
                            updatePoolInfo.Time = model.Time;
                            updatePoolInfo.Charges = model.Charges;
                            updatePoolInfo.SeatsAvailable = model.SeatsAvailable;

                            updatePoolInfo.ModifiedBy = model.ModifiedBy;
                            updatePoolInfo.ModifiedDate = DateTime.Now;

                            dbcontext.SaveChanges();
                            status = OperationStatus.Update;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                dbcontext.Dispose();
                status = OperationStatus.Exception;
                throw ex;
            }
            
            return status;
        }

        public object SearchCarPoolApplication(CarPoolRegistrationCustomModel model)
        {
            List<CarPoolRegistrationCustomModel> CarPoolListModel = new List<CarPoolRegistrationCustomModel>();
            DateTime SearchDate = Convert.ToDateTime(model.PoolDate);
            try
            {
                using (dbcontext = new CarPoolApplicationEntities())
                {
                    CarPoolListModel = dbcontext.tblCarPoolRegistrations.Where(x => x.IsDeleted == false
                    && (x.PoolDate.Value.Year == SearchDate.Year
                    && x.PoolDate.Value.Month == SearchDate.Month
                    && x.PoolDate.Value.Day == SearchDate.Day)
                    && (x.Source.ToLower().Trim().Contains(model.Source.ToLower().Trim()) || model.Source.Trim() == String.Empty || model.Source == null)
                    && (x.Destination.ToLower().Trim().Contains(model.Destination.ToLower().Trim()) || model.Destination.Trim() == String.Empty || model.Destination == null)
                    ).Select (x => new CarPoolRegistrationCustomModel
                    {
                        Id = x.Id,
                        MemberId = x.MemberId,
                        MemberName = x.tblMember != null ? x.tblMember.Name : "",
                        MobileNo = x.tblMember != null ? x.tblMember.MobileNo : "",
                        EmailId = x.tblMember != null ? x.tblMember.EmailId : "",
                        Source = x.Source,
                        Destination = x.Destination,
                        PoolDate = x.PoolDate,
                        Charges = x.Charges,
                        Time = x.Time,
                        SeatsAvailable = x.SeatsAvailable,

                        IsActive = x.IsActive,
                        IsDeleted = x.IsDeleted,
                        CreatedBy = x.CreatedBy,
                        CreatedDate = x.CreatedDate,
                        ModifiedBy = x.ModifiedBy,
                        ModifiedDate = x.ModifiedDate
                    }).OrderByDescending(x => x.Id).ToList();
                    
                }
            }
            catch (Exception ex)
            {
                dbcontext.Dispose();
                throw ex;
            }
            return CarPoolListModel;

            //DateTime KMEndDate = objDailyKisanMarketReportModel.EndDate.Add(new TimeSpan(5, 30, 0));
            //DailyKisanListDetailQ = DailyKisanListDetailQ.Where(x =>
            //       (x.SaleDate.Year >= KMStartDate.Year
            //    && x.SaleDate.Month >= KMStartDate.Month
            //    && x.SaleDate.Day >= KMStartDate.Day)
            //    && (x.SaleDate.Year <= KMEndDate.Year
            //    && x.SaleDate.Month <= KMEndDate.Month
            //    && x.SaleDate.Day <= KMEndDate.Day)

        }


        public object MyCarPoolApplication(int MemberId)
        {
            List<CarPoolRegistrationCustomModel> CarPoolListModel = new List<CarPoolRegistrationCustomModel>();
            try
            {
                using (dbcontext = new CarPoolApplicationEntities())
                {
                    CarPoolListModel = dbcontext.tblCarPoolRegistrations.Where(x => x.IsDeleted == false
                    && (x.MemberId == MemberId)                    
                    ).Select(x => new CarPoolRegistrationCustomModel
                    {
                        Id = x.Id,
                        MemberId = x.MemberId,
                        MemberName = x.tblMember != null ? x.tblMember.Name : "",
                        MobileNo = x.tblMember != null ? x.tblMember.MobileNo : "",
                        EmailId = x.tblMember != null ? x.tblMember.EmailId : "",
                        Source = x.Source,
                        Destination = x.Destination,
                        PoolDate = x.PoolDate,
                        Charges = x.Charges,
                        Time = x.Time,
                        SeatsAvailable = x.SeatsAvailable,

                        IsActive = x.IsActive,
                        IsDeleted = x.IsDeleted,
                        CreatedBy = x.CreatedBy,
                        CreatedDate = x.CreatedDate,
                        ModifiedBy = x.ModifiedBy,
                        ModifiedDate = x.ModifiedDate
                    }).OrderByDescending(x => x.Id).ToList();

                }
            }
            catch (Exception ex)
            {
                dbcontext.Dispose();
                throw ex;
            }
            return CarPoolListModel;
        }

        public void Dispose()
        {
            dbcontext.Dispose();
            GC.SuppressFinalize(this);
            //throw new NotImplementedException();
        }
    }
}
