using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CarPool.Shared.CustomModels;
using CarPool.BDC.Interfaces;
using CarPool.BDC.Classes;

namespace CarPool.API.Controllers
{    
    public class MemberAPIController : ApiController
    {
        #region Global Variable
        Response _response = new Response();
        private IMemberBusiness memberService;
        #endregion

        public MemberAPIController()
        {
            
        }

        /// <summary>
        /// This method is used to fetch Farmer Registration
        /// </summary>
        /// <returns>List of Farmer Registration</returns>
        [HttpGet]
        [Route("API/MemberAPI/GetApplicationMemberList")]
        public Response GetApplicationMemberList(MemberCustomModel objMemberModel)
        {
            _response = new Response();
            try
            {
                MemberBusiness memberService = new MemberBusiness();
                _response.responseData = memberService.GetApplicationMemberList(objMemberModel);
                _response.message = "Records loaded successfully !!";
                _response.success = true;
            }
            catch (Exception ex)
            {
                _response.success = false;
                _response.message = ex.Message.ToString();
            }
            finally
            {
                memberService = null;
            }
            return _response;
        }

        /// <summary>
        /// This method is used for forgot password
        /// </summary>
        /// <returns>forgot password</returns>
        [HttpPost]
        [Route("API/MemberAPI/ForgotPassword")]
        public Response ForgotPassword(ForgotPasswordCustomModel model)
        {
            _response = new Response();
            try
            {
                MemberBusiness memberService = new MemberBusiness();
                _response.responseData = memberService.ForgotPassword(model);
                _response.message = "Mail Sent Successfully !!";
                _response.success = true;
            }
            catch (Exception ex)
            {
                _response.success = false;
                _response.message = ex.Message.ToString();
            }
            finally
            {
                memberService = null;
            }
            return _response;
        }

    }
}
