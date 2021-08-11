using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PROJECTXDTO;
using PROJECTXBL;
using Newtonsoft.Json;

namespace ProjectXAPI.Controllers
{
    public class ModelController : ApiController
    {

        DeliveryModel_BL blObj;

        [HttpGet]
        [ActionName("GetAllModels")]
        public HttpResponseMessage GetAllDeliveryModels()
        {
            try
            {
                blObj = new DeliveryModel_BL();
                List<DeliveryModel_DTO> listOfModel = blObj.GetAllModels();
                if (listOfModel != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(listOfModel));
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }

                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                    response.Content = new StringContent(JsonConvert.SerializeObject("No Delivery Models Available"));
                    return response;
                }


            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(JsonConvert.SerializeObject("Something went wrong"));
                return response;
            }
        }
    }
}
