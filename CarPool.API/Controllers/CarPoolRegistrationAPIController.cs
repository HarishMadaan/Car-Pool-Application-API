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
    public class CarPoolRegistrationAPIController : ApiController
    {
        #region Global Variable
        Response _response = new Response();
        private IMemberBusiness memberService;
        #endregion
        
        public CarPoolRegistrationAPIController()
        {

        }

        /// <summary>
        /// This method is used to fetch Farmer Registration
        /// </summary>
        /// <returns>List of Farmer Registration</returns>
        [HttpPost]
        [Route("API/CarPoolRegistrationAPI/SearchCarPoolApplication")]
        public Response SearchCarPoolApplication(CarPoolRegistrationCustomModel model)
        {
            _response = new Response();
            try
            {
                CarPoolRegistrationBusiness objBDC = new CarPoolRegistrationBusiness();
                _response.responseData = objBDC.SearchCarPoolApplication(model);
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
        /// This method is used to fetch Farmer Registration
        /// </summary>
        /// <returns>List of Farmer Registration</returns>
        [HttpPost]
        [Route("API/CarPoolRegistrationAPI/SaveCarPoolApplication")]
        public Response SaveCarPoolApplication(CarPoolRegistrationCustomModel model)
        {
            _response = new Response();
            try
            {
                CarPoolRegistrationBusiness objBDC = new CarPoolRegistrationBusiness();
                _response.responseData = objBDC.SaveCarPoolApplication(model);
                _response.message = "Records saved successfully !!";
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
        /// This method is used to fetch Farmer Registration
        /// </summary>
        /// <returns>List of Farmer Registration</returns>
        [HttpGet]
        [Route("API/CarPoolRegistrationAPI/MyCarPoolApplication/{MemberId}")]
        public Response MyCarPoolApplication(int MemberId)
        {
            _response = new Response();
            try
            {
                CarPoolRegistrationBusiness objBDC = new CarPoolRegistrationBusiness();
                _response.responseData = objBDC.MyCarPoolApplication(MemberId);
                _response.message = "Records saved successfully !!";
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
