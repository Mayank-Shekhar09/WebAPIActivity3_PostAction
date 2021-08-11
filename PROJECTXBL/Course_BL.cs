using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROJECTXDTO;
using PROJECTXDAL;

namespace PROJECTXBL
{
    public class Course_BL
    {

        Course_DAL dalObj = new Course_DAL();
        CoursesDL coursedlObj = new CoursesDL();
        public List<Course_DTO> GetAllCourses()
        {
            try
            {
                var lstCourse = dalObj.GetAllCourses();
                return lstCourse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Course_DTO> GetCourseByCourseId(string cid)
        {
            try
            {
                var lstCourse = dalObj.GetCourseByCourseId(cid);
                return lstCourse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int AddNewCourse(Course_DTO CourseObj)
        {
            try
            {
                int lstCourse = coursedlObj.AddNewCourse(CourseObj);
                return lstCourse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
