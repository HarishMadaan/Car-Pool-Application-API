using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarPool.Shared.CustomModels;
using CarPool.DAL.Interfaces;

namespace CarPool.DAL.Repositories
{
    public class CarPoolAssociationRepo : ICarPoolAssociationRepo
    {
        CarPoolApplicationEntities dbcontext = null;
        Response response;

        /// <summary>
        /// This method is used to save car pool requests
        /// </summary>
        /// <returns></returns>
        public OperationStatus SubmitCarPoolRequest(CarPoolAssociationCustomModel model)
        {
            OperationStatus status = OperationStatus.Error;
            DateTime PoolDate = Convert.ToDateTime(model.DDate);
            try
            {
                using (dbcontext = new CarPoolApplicationEntities())
                {
                    if (model.AssociationId == 0)
                    {
                        var rs = dbcontext.tblCarPoolMemberAssociations.FirstOrDefault(x => x.MemberId == model.MemberId
                        && x.CarPoolId == model.CarPoolId
                        && (x.DDate.Value.Year == PoolDate.Year && x.DDate.Value.Month == PoolDate.Month && x.DDate.Value.Day == PoolDate.Day)
                        );
                        if (rs == null)
                        {
                            tblCarPoolMemberAssociation _addCarPool = new tblCarPoolMemberAssociation
                            {
                                MemberId = model.MemberId,
                                CarPoolId = model.CarPoolId,
                                DDate = PoolDate,
                                Description = model.Description,
                                IsApproved = 1,
                                
                                IsActive = true,
                                IsDeleted = false,
                                CreatedDate = DateTime.Now,
                                CreatedBy = model.CreatedBy,
                                ModifiedDate = DateTime.Now,
                                ModifiedBy = model.ModifiedBy,

                            };
                            dbcontext.tblCarPoolMemberAssociations.Add(_addCarPool);
                            dbcontext.SaveChanges();

                            status = OperationStatus.Success;
                        }
                        else
                        {
                            status = OperationStatus.Duplicate;                            
                        }
                    }
                    else
                    {
                        var rs = dbcontext.tblCarPoolMemberAssociations.FirstOrDefault(m => m.IsDeleted==false
                        && m.MemberId == model.MemberId
                        && m.CarPoolId == model.CarPoolId
                        && (m.DDate.Value.Year == PoolDate.Year && m.DDate.Value.Month == PoolDate.Month && m.DDate.Value.Day == PoolDate.Day)
                        && m.AssociationId != model.AssociationId                        
                        );
                        if (rs == null)
                        {
                            var updatePoolInfo = dbcontext.tblCarPoolMemberAssociations.FirstOrDefault(x => x.AssociationId == model.AssociationId);
                            if (updatePoolInfo != null)
                            {
                                updatePoolInfo.MemberId = model.MemberId;
                                updatePoolInfo.CarPoolId = model.CarPoolId;
                                updatePoolInfo.DDate = PoolDate;
                                updatePoolInfo.Description = model.Description;
                                
                                updatePoolInfo.ModifiedBy = model.ModifiedBy;
                                updatePoolInfo.ModifiedDate = DateTime.Now;

                                dbcontext.SaveChanges();
                                status = OperationStatus.Update;
                            }
                        }
                        else
                        {
                            status = OperationStatus.Duplicate;
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

        public object ListMyCarPoolRequest(int Id, DateTime DDate)
        {
            List<CarPoolAssociationCustomModel> CarPoolListModel = new List<CarPoolAssociationCustomModel>();
            DateTime PoolDate = Convert.ToDateTime(DDate);
            try
            {
                using (dbcontext = new CarPoolApplicationEntities())
                {
                    CarPoolListModel = dbcontext.tblCarPoolMemberAssociations.Where(x => x.IsDeleted == false
                    && x.CarPoolId == Id
                    && ((x.DDate.Value.Year == PoolDate.Year && x.DDate.Value.Month == PoolDate.Month && x.DDate.Value.Day == PoolDate.Day) || PoolDate == null)
                    ).Select(x => new CarPoolAssociationCustomModel
                    {
                        AssociationId = x.AssociationId,
                        CarPoolId = x.CarPoolId,
                        MemberId = x.MemberId,
                        MemberName = x.tblMember != null ? x.tblMember.Name : "",
                        DDate = x.DDate,
                        Description = x.Description,
                        IsApproved = x.IsApproved,
                        
                        IsActive = x.IsActive,
                        IsDeleted = x.IsDeleted,
                        CreatedBy = x.CreatedBy,
                        CreatedDate = x.CreatedDate,
                        ModifiedBy = x.ModifiedBy,
                        ModifiedDate = x.ModifiedDate
                    }).OrderByDescending(x => x.AssociationId).ToList();

                }
            }
            catch (Exception ex)
            {
                dbcontext.Dispose();
                throw ex;
            }
            return CarPoolListModel;
        }

        public object ListAllCarPoolRequest(CarPoolAssociationCustomModel model)
        {
            List<CarPoolAssociationCustomModel> CarPoolListModel = new List<CarPoolAssociationCustomModel>();
            DateTime PoolDate = Convert.ToDateTime(model.DDate);
            try
            {
                using (dbcontext = new CarPoolApplicationEntities())
                {
                    CarPoolListModel = dbcontext.tblCarPoolMemberAssociations.Where(x => x.IsDeleted == false
                    && ((x.DDate.Value.Year == PoolDate.Year && x.DDate.Value.Month == PoolDate.Month && x.DDate.Value.Day == PoolDate.Day) || PoolDate == null)
                    ).Select(x => new CarPoolAssociationCustomModel
                    {
                        AssociationId = x.AssociationId,
                        CarPoolId = x.CarPoolId,
                        MemberId = x.MemberId,
                        MemberName = x.tblMember != null ? x.tblMember.Name : "",
                        DDate = x.DDate,
                        Description = x.Description,
                        IsApproved = x.IsApproved,

                        IsActive = x.IsActive,
                        IsDeleted = x.IsDeleted,
                        CreatedBy = x.CreatedBy,
                        CreatedDate = x.CreatedDate,
                        ModifiedBy = x.ModifiedBy,
                        ModifiedDate = x.ModifiedDate
                    }).OrderByDescending(x => x.AssociationId).ToList();

                }
            }
            catch (Exception ex)
            {
                dbcontext.Dispose();
                throw ex;
            }
            return CarPoolListModel;
        }

        public OperationStatus ActionCarPoolRequest(CarPoolAssociationCustomModel model)
        {
            OperationStatus status = OperationStatus.Error;
            DateTime PoolDate = Convert.ToDateTime(model.DDate);
            try
            {
                using (dbcontext = new CarPoolApplicationEntities())
                {   
                    var updatePoolInfo = dbcontext.tblCarPoolMemberAssociations.FirstOrDefault(x => x.AssociationId == model.AssociationId);
                    if (updatePoolInfo != null)
                    {
                        updatePoolInfo.IsApproved = model.IsApproved;
                        
                        updatePoolInfo.ModifiedBy = model.ModifiedBy;
                        updatePoolInfo.ModifiedDate = DateTime.Now;

                        dbcontext.SaveChanges();
                        status = OperationStatus.Update;
                    }
                    else
                    {
                        status = OperationStatus.Duplicate;
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

        public object ListMyCarPoolActionRequest(int Id, DateTime DDate, int Status)
        {
            List<CarPoolAssociationCustomModel> CarPoolListModel = new List<CarPoolAssociationCustomModel>();
            DateTime PoolDate = Convert.ToDateTime(DDate);
            try
            {
                using (dbcontext = new CarPoolApplicationEntities())
                {
                    CarPoolListModel = dbcontext.tblCarPoolMemberAssociations.Where(x => x.IsDeleted == false
                    && x.CarPoolId == Id
                    && (x.IsApproved == Status || Status == 0)
                    && ((x.DDate.Value.Year == PoolDate.Year && x.DDate.Value.Month == PoolDate.Month && x.DDate.Value.Day == PoolDate.Day) || PoolDate == null)
                    ).Select(x => new CarPoolAssociationCustomModel
                    {
                        AssociationId = x.AssociationId,
                        CarPoolId = x.CarPoolId,
                        MemberId = x.MemberId,
                        MemberName = x.tblMember != null ? x.tblMember.Name : "",
                        DDate = x.DDate,
                        Description = x.Description,
                        IsApproved = x.IsApproved,

                        IsActive = x.IsActive,
                        IsDeleted = x.IsDeleted,
                        CreatedBy = x.CreatedBy,
                        CreatedDate = x.CreatedDate,
                        ModifiedBy = x.ModifiedBy,
                        ModifiedDate = x.ModifiedDate
                    }).OrderByDescending(x => x.AssociationId).ToList();
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
