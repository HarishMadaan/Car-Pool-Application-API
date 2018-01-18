using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarPool.Shared.CustomModels;
using CarPool.DAL.Interfaces;
using System.Net.Mail;
using System.Net;

namespace CarPool.DAL.Repositories
{
    public class MemberRepo : IMemberRepo
    {
        CarPoolApplicationEntities dbcontext = null;
        Response response;
        
        public object GetApplicationMemberList(MemberCustomModel objMemberModel)
        {
            IList<MemberCustomModel> MemberListModel = new List<MemberCustomModel>();

            using (response = new Response())
            {
                using (dbcontext = new CarPoolApplicationEntities())
                {
                    try
                    {
                        response.success = true;
                        MemberListModel = dbcontext.tblMembers.Where(x => x.IsDeleted == false)
                            .Select(x => new MemberCustomModel
                            {
                                MemberId = x.MemberId,
                                Name = x.Name,
                                EmailId = x.EmailId,
                                MobileNo = x.MobileNo,
                                MotherName = x.MotherName,
                                FatherName = x.FatherName,
                                Address = x.Address,
                                DateOfBirth = x.DateOfBirth,
                                Gender = x.Gender,
                                Image = x.Image,
                                IsActive = x.IsActive,
                                IsDeleted = x.IsDeleted,
                                CreatedBy = x.CreatedBy,
                                CreatedDate = x.CreatedDate,
                                ModifyBy = x.ModifyBy,
                                ModifiedDate = x.ModifiedDate,

                            }).OrderByDescending(x => x.MemberId).ToList();

                        return MemberListModel;

                    }
                    catch (Exception ex)
                    {
                        response.success = false;
                        response.message = ex.Message;
                        return response;
                    }
                }
            }
        }

        public OperationStatus ForgotPassword(ForgotPasswordCustomModel model)
        {
            OperationStatus status = OperationStatus.Error;
            try
            {
                using (dbcontext = new CarPoolApplicationEntities())
                {
                    var rs = dbcontext.tblApplicationUsers.FirstOrDefault(x => x.UserName == model.UserName);
                    if (rs != null)
                    {
                        string from = "madaan.harish08@gmail.com"; //any valid GMail ID  
                        string to = Convert.ToString(rs.EmailId); //any valid GMail ID  
                        using (MailMessage mail = new MailMessage(from, to))
                        {
                            mail.Subject = "Car Pool Management Forgot Password";
                            mail.Body = "Dear "+rs.Name+ " <br><br>Please use this password to login: "+rs.Password+"<br><br>Thanks,<br>Team";

                            mail.IsBodyHtml = true;
                            SmtpClient smtp = new SmtpClient();
                            smtp.Host = "smtp.gmail.com";
                            smtp.Port = 587;
                            smtp.UseDefaultCredentials = false;
                            smtp.Credentials = new System.Net.NetworkCredential
                            ("madaan.harish08@gmail.com", "shally123");// Enter seders User name and password 
                            smtp.EnableSsl = true;
                            smtp.Send(mail);

                            status = OperationStatus.Success;
                        }
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

        public void Dispose()
        {
            dbcontext.Dispose();
            GC.SuppressFinalize(this);
            //throw new NotImplementedException();
        }
    }
}
