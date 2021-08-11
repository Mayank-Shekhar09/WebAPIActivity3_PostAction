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
    public class FacultyController : ApiController
    {
        Faculty_BL blObj;


        [HttpGet]
        [ActionName("GetAllFaculties")]
        public HttpResponseMessage GetAllCourses()
        {
            try
            {
                blObj = new Faculty_BL();
                List<Faculty_DTO> listOfFaculties = blObj.GetAllFaculties();
                if (listOfFaculties != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(listOfFaculties));
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }

                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                    response.Content = new StringContent(JsonConvert.SerializeObject("No Faculties Available"));
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
        [ActionName("GetCourseByFaculty")]
        public HttpResponseMessage GetCourseByFacultyName(string fname)
        {
            try {
                blObj = new Faculty_BL();
                List<CourseFacultyMap_DTO> listOfCourses = blObj.GetCoursesByFacultyName(fname);

                List<string> display = new List<string>();
                foreach (var item in listOfCourses)
                {
                    display.Add("CourseId:" + item.CourseId);
                }
                if (listOfCourses != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(display));
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }

                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                    response.Content = new StringContent(JsonConvert.SerializeObject("No Courses assigned to this faculty available."));
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
        [ActionName("GetFacultyByCourse")]
        public HttpResponseMessage GetFacultyByCourseId(string courseId)
        {
            try { 
                blObj = new Faculty_BL();
                List<CourseFacultyMap_DTO> listOfFaculties = blObj.GetFacultiesByCourseId(courseId);
                List<string> display = new List<string>();
                foreach (var item in listOfFaculties)
                {
                    display.Add("PSNO:" + item.PSNO + "| Primary (P) /other Faculty (O):" + item.PrimaryFaculty);
                }
                if (listOfFaculties != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(display));
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }

                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                    response.Content = new StringContent(JsonConvert.SerializeObject("No faculties assigned to this course available."));
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
        [ActionName("AddFaculty")]
        public HttpResponseMessage AddFaculty(int PSNo, string EmailId, string NAME)
        {
            try
            {
                blObj = new Faculty_BL();
                int ret = blObj.AddFaculty(PSNo, EmailId, NAME);
                if (ret==1)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject("Faculty Added Successfully"));
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }
                else if (ret == -1)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject("PSNo Exist"));
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }
                else if (ret == -2)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject("Email ID Exist"));
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }
                else if (ret == -3)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject("Faculty Name Exist"));
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
