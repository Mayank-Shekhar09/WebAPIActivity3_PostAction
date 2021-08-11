using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROJECTXDTO;
using PROJECTXDAL;

namespace PROJECTXBL
{
    public class Faculty_BL
    {
        Faculty_DAL facultyDalObj;
        FacultyDL facultyDLObj;
        public Faculty_BL()
        {
            facultyDalObj = new Faculty_DAL();
            facultyDLObj = new FacultyDL();
        }
        public List<Faculty_DTO> GetAllFaculties()
        {
            try
            {
                var lstFaculty = facultyDalObj.GetAllFaculties();
                return lstFaculty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CourseFacultyMap_DTO> GetCoursesByFacultyName(string facName)
        {
            try
            {

                var courseList = facultyDalObj.GetCoursesByFacultyName(facName);
                return courseList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CourseFacultyMap_DTO> GetFacultiesByCourseId(string courseId)
        {
            try
            {
                var facultyList = facultyDalObj.GetFacultyFromCId(courseId);
                return facultyList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddFaculty(int PSNo, string EmailId, string NAME)
        {
            try
            {
                var lstFaculty = facultyDLObj.AddFaculty(PSNo, EmailId, NAME);
                return (int)lstFaculty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
