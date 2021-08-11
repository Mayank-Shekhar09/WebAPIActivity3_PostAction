using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using PROJECTXBL;
using PROJECTXDTO;

namespace ProjectXAPI.Controllers
{
    public class GraderController : ApiController
    {
        Grader_BL blObj;

        [HttpGet]
        [ActionName("GetParticipantsByCourse")]

        public HttpResponseMessage GetParticipantsByCourseId(string courseId)
        {
            try
            {
                blObj = new Grader_BL();
                List<Grader_DTO> participants = blObj.GetParticipants(courseId);
                List<string> display = new List<string>();
                foreach (var item in participants)
                {
                    display.Add("PSNO:"+item.PSNO + "| Score:" + item.Score);
                }
                if (participants != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(participants));
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }

                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                    response.Content = new StringContent(JsonConvert.SerializeObject("No Participants assigned to this course"));
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

        [HttpGet]
        [ActionName("GetCourseParticipantsByFaculty")]

        public HttpResponseMessage GetCourseParticipantsByFacultyId(string facultyId)
        {
            try
            {
                blObj = new Grader_BL();
                List<Grader_DTO> participants = blObj.GetCourseParticipantFromFacultyId(facultyId);
                List<string> display = new List<string>();
                foreach (var item in participants)
                {
                    display.Add("PSNO:"+item.PSNO + "| CourseId:" + item.CourseId+"| Score:"+item.Score);
                }
                if (participants != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(display));
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }

                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                    response.Content = new StringContent(JsonConvert.SerializeObject("No Course or Participants assigned to this course"));
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



        [HttpGet]
        [ActionName("GetParticipantsByID")]

        public HttpResponseMessage GetCourseParticipantsByPSNO(int psno)
        {
            try
            {
                blObj = new Grader_BL();
                List<Grader_DTO> participants = blObj.GetCourseParticipantFromPSNO(psno);
                List<string> display = new List<string>();
                foreach (var item in participants)
                {
                    display.Add("PSNO:" + item.PSNO +  "| Score:" + item.Score);
                }
                if (participants != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(display));
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }

                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                    response.Content = new StringContent(JsonConvert.SerializeObject("Invalid ID"));
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
        [HttpPost]
        [ActionName("AddGrader")]
        public HttpResponseMessage AddGrader(Grader_DTO graderObj)
        {
            try
            {
                blObj = new Grader_BL();
                int ret = blObj.AddNewGrader(graderObj);
                if (ret == 1)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject("Grader Added Successfully"));
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }
                else if (ret == -1)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject("BCFID exists"));
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }
                else if (ret == -2)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject("PSNo Exist"));
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }
                else if (ret == -3)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject("Score is null"));
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }
                var res = new HttpResponseMessage(HttpStatusCode.OK);
                return res;

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
