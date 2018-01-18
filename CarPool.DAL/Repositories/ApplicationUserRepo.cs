using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Configuration;
using CarPool.Shared.CustomModels;
using CarPool.DAL.Interfaces;

namespace CarPool.DAL.Repositories
{
    public class ApplicationUserRepo : IApplicationUserRepo
    {

        CarPoolApplicationEntities dbcontext = null;
        
        /// <summary>
        /// method is used for validate application users
        /// </summary>
        /// <param name="Logininfo"></param>
        /// <returns></returns>
        public object GetLoginUser(LoginUserModel Logininfo)
        {
            APIResponse _response = new APIResponse();
            LoggedInUserModel lgAppUserDetails = new LoggedInUserModel();
            object objLgAppUserDetails;
            try
            {
                using (dbcontext = new CarPoolApplicationEntities())
                {
                    Logininfo.UserName = Logininfo.UserName.ToLower();
                    tblApplicationUser lgDetail = dbcontext.tblApplicationUsers.FirstOrDefault(x => x.UserName.ToLower() == Logininfo.UserName && x.IsDeleted == false);

                    if (lgDetail != null)
                    {
                        if (lgDetail.Password == Logininfo.Password)
                        {
                            lgAppUserDetails.ApplicationUserId = lgDetail.ApplicationUserId;
                            lgAppUserDetails.IsActive = lgDetail.IsActive;
                            lgAppUserDetails.UserIdentityKey = lgDetail.UserIdentityKey;
                            lgAppUserDetails.success = true;
                            lgAppUserDetails.ErrorMessage = "User Authenticated!!";
                            lgAppUserDetails.Name = lgDetail.Name == null ? "" : lgDetail.Name;
                            lgAppUserDetails.EmailId = lgDetail.EmailId;
                            lgAppUserDetails.MobileNo = lgDetail.MobileNo;
                            lgAppUserDetails.Gender = lgDetail.tblMember != null ? lgDetail.tblMember.Gender : null;
                            lgAppUserDetails.DateOfBirth = lgDetail.tblMember != null ? lgDetail.tblMember.DateOfBirth : null;
                            lgAppUserDetails.Address = lgDetail.tblMember != null ? lgDetail.tblMember.Address : null;
                            lgAppUserDetails.FatherName = lgDetail.tblMember != null ? lgDetail.tblMember.FatherName : null;
                            lgAppUserDetails.MotherName = lgDetail.tblMember != null ? lgDetail.tblMember.MotherName : null;

                            _response.Message = "User Authenticated!!";
                            _response.IsSucess = true;

                        }
                        else
                        {
                            lgAppUserDetails.ErrorMessage = "Invalid password!!";
                            _response.Message = "Invalid password!!";
                            _response.IsSucess = false;
                        }
                    }
                    else
                    {
                        lgAppUserDetails.ErrorMessage = "Invalid username!!";
                        _response.Message = "Invalid username!!";
                        _response.IsSucess = false;
                    }
                }
            }
            catch (Exception ex)
            {
                lgAppUserDetails = null;
                objLgAppUserDetails = null;
                dbcontext = null;
                lgAppUserDetails.ErrorMessage = ex.Message.ToString();
            }
            objLgAppUserDetails = lgAppUserDetails;
            return objLgAppUserDetails;
        }


        /// <summary>
        /// This method is used to save new members
        /// </summary>
        /// <returns></returns>
        public OperationStatus SaveApplicationUser(ApplicationUserModel applicationUserModel)
        {
            OperationStatus status = OperationStatus.Error;
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    using (dbcontext = new CarPoolApplicationEntities())
                    {
                        if (applicationUserModel.ApplicationUserId == 0)
                        {
                            var rs = dbcontext.tblApplicationUsers.FirstOrDefault(x => x.UserName == applicationUserModel.UserName && x.IsDeleted == false);
                            if (rs == null)
                            {
                                tblMember _addMember = new tblMember
                                {
                                    Name = applicationUserModel.Name,
                                    EmailId = applicationUserModel.EmailId,
                                    MobileNo = applicationUserModel.MobileNo,
                                    Gender = applicationUserModel.Gender,
                                    DateOfBirth = applicationUserModel.DateOfBirth,
                                    Address=applicationUserModel.Address,
                                    FatherName = applicationUserModel.FatherName,
                                    MotherName=applicationUserModel.MotherName,
                                     
                                    IsActive = true,
                                    IsDeleted = false,
                                    CreatedDate = DateTime.Now,
                                    CreatedBy = applicationUserModel.CreatedBy,
                                    ModifiedDate = DateTime.Now,
                                    ModifyBy = applicationUserModel.ModifyBy,

                                };
                                dbcontext.tblMembers.Add(_addMember);
                                dbcontext.SaveChanges();
                                int userid = _addMember.MemberId;

                                tblApplicationUser _applicationUserinfo = new tblApplicationUser
                                {
                                    Name = applicationUserModel.Name,
                                    EmailId = applicationUserModel.EmailId,
                                    MobileNo = applicationUserModel.MobileNo,
                                    UserIdentityKey = userid,
                                    UserName = applicationUserModel.UserName,
                                    Password = applicationUserModel.Password,

                                    IsActive = true,
                                    IsDeleted = false,
                                    CreatedDate = DateTime.Now,
                                    CreatedBy = applicationUserModel.CreatedBy,
                                    ModifiedDate = DateTime.Now,
                                    ModifyBy = applicationUserModel.ModifyBy,
                                };

                                dbcontext.tblApplicationUsers.Add(_applicationUserinfo);
                                dbcontext.SaveChanges();

                                status = OperationStatus.Success;
                                ts.Complete();
                            }
                            else
                            {
                                status = OperationStatus.Duplicate;
                                //ts.Dispose();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    dbcontext.Dispose();
                    status = OperationStatus.Exception;
                    ts.Dispose();
                    throw ex;
                }
            }
            return status;
        }

        public void Dispose()
        {
            dbcontext.Dispose();
            GC.SuppressFinalize(this);
            //throw new NotImplementedException();
        }
    }
}
