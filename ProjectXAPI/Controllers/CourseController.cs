using Newtonsoft.Json;
using PROJECTXBL;
using PROJECTXDTO;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectXAPI.Controllers
{
    public class CourseController : ApiController
    {
        Course_BL blObj;

        [HttpGet]
        [ActionName("GetAllCourses")]
        public HttpResponseMessage GetAllCourses()
        {
            try
            {
                blObj = new Course_BL();
                List<Course_DTO> listOfCourse = blObj.GetAllCourses();

                if (listOfCourse != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(listOfCourse));
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }

                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                    response.Content = new StringContent(JsonConvert.SerializeObject("No Courses Available"));
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
        [ActionName("GetCourseById")]
        public HttpResponseMessage GetCoursesById(string cid)
        {
            try
            {
                blObj = new Course_BL();
                List<Course_DTO> listOfCourse = blObj.GetCourseByCourseId(cid);

                if (listOfCourse != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(listOfCourse));
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }

                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                    response.Content = new StringContent(JsonConvert.SerializeObject("Invalid Course ID"));
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
        [ActionName("AddCourse")]
        public HttpResponseMessage AddCourse(Course_DTO CourseObj)
        {
            try
            {
                blObj = new Course_BL();
                int ret = blObj.AddNewCourse(CourseObj);
                if (ret == 1)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject("Course Added Successfully"));
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }
                else if (ret == -1)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject("Course ID exists"));
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }
                else if (ret == -2)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject("Course Title Exist"));
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }
                else if (ret == -3)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject("Course Duration is null"));
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
