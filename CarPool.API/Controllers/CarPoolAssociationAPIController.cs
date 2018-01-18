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
    public class CarPoolAssociationAPIController : ApiController
    {
        #region Global Variable
        Response _response = new Response();
        private IMemberBusiness memberService;
        #endregion

        public CarPoolAssociationAPIController()
        {

        }

        /// <summary>
        /// This method is used to submit Car Pool Requests
        /// </summary>
        /// <returns>List of Car Pool Requests</returns>
        [HttpPost]
        [Route("API/CarPoolAssociation/SubmitCarPoolRequest")]
        public Response SubmitCarPoolRequest(CarPoolAssociationCustomModel model)
        {
            CarPoolAssociationBusiness objBDC = new CarPoolAssociationBusiness();
            _response = new Response();
            try
            {                
                _response.responseData = objBDC.SubmitCarPoolRequest(model);
                _response.message = "Records added successfully !!";
                _response.success = true;
            }
            catch (Exception ex)
            {
                _response.success = false;
                _response.message = ex.Message.ToString();
            }
            finally
            {
                objBDC = null;
            }
            return _response;
        }

        /// <summary>
        /// This method is used to list my Car Pool Requests
        /// </summary>
        /// <returns>List of my Car Pool Requests</returns>
        [HttpGet]
        [Route("API/CarPoolAssociation/ListMyCarPoolRequest/{Id}/{DDate}")]
        public Response ListMyCarPoolRequest(int Id, DateTime DDate)
        {
            CarPoolAssociationBusiness objBDC = new CarPoolAssociationBusiness();
            _response = new Response();
            try
            {
                _response.responseData = objBDC.ListMyCarPoolRequest(Id, DDate);
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
                objBDC = null;
            }
            return _response;
        }

        /// <summary>
        /// This method is used to list all Car Pool Requests
        /// </summary>
        /// <returns>List of all Car Pool Requests</returns>
        [HttpGet]
        [Route("API/CarPoolAssociation/ListAllCarPoolRequest")]
        public Response ListAllCarPoolRequest(CarPoolAssociationCustomModel model)
        {
            CarPoolAssociationBusiness objBDC = new CarPoolAssociationBusiness();
            _response = new Response();
            try
            {
                _response.responseData = objBDC.ListAllCarPoolRequest(model);
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
                objBDC = null;
            }
            return _response;
        }

        /// <summary>
        /// This method is used to submit Car Pool Requests action
        /// </summary>
        /// <returns>List of Car Pool Request action</returns>
        [HttpPost]
        [Route("API/CarPoolAssociation/ActionCarPoolRequest")]
        public Response ActionCarPoolRequest(CarPoolAssociationCustomModel model)
        {
            CarPoolAssociationBusiness objBDC = new CarPoolAssociationBusiness();
            _response = new Response();
            try
            {
                _response.responseData = objBDC.ActionCarPoolRequest(model);
                _response.message = "Records added successfully !!";
                _response.success = true;
            }
            catch (Exception ex)
            {
                _response.success = false;
                _response.message = ex.Message.ToString();
            }
            finally
            {
                objBDC = null;
            }
            return _response;
        }

        /// <summary>
        /// This method is used to list my Car Pool Requests
        /// </summary>
        /// <returns>List of my Car Pool Requests</returns>
        [HttpGet]
        [Route("API/CarPoolAssociation/ListMyCarPoolActionRequest/{Id}/{DDate}/{Status}")]
        public Response ListMyCarPoolActionRequest(int Id, DateTime DDate, int Status)
        {
            CarPoolAssociationBusiness objBDC = new CarPoolAssociationBusiness();
            _response = new Response();
            try
            {
                _response.responseData = objBDC.ListMyCarPoolActionRequest(Id, DDate, Status);
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
                objBDC = null;
            }
            return _response;
        }

    }
}
