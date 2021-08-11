using PROJECTXDTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECTXDAL
{
    public class CoursesDL
    {
        SqlConnection sqlObj;
        SqlCommand sqlCmObj;
        public CoursesDL()
        {
            sqlObj = new SqlConnection(ConfigurationManager.ConnectionStrings["DemoEntities1"].ToString());
        }
        public int AddNewCourse(Course_DTO CourseObj)
        {

            sqlCmObj = new SqlCommand("dbo.usp.AddCourses", sqlObj);
            sqlCmObj.CommandType = CommandType.StoredProcedure;
            sqlCmObj.Parameters.AddWithValue("@CourseId", CourseObj.CourseId);
            sqlCmObj.Parameters.AddWithValue("@CourseTitle", CourseObj.CourseTitle);
            sqlCmObj.Parameters.AddWithValue("@CourseDuration", CourseObj.CourseDuration);
            sqlCmObj.Parameters.AddWithValue("@CourseMode", CourseObj.CourseMode);

            try
            {
                sqlObj.Open();
                SqlParameter rm = sqlCmObj.Parameters.Add("RetVal", SqlDbType.Int);
                rm.Direction = ParameterDirection.ReturnValue;
                int returnValue = (int)rm.Value;
                return returnValue;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Something went Wrong !");
                return -99;

            }
            finally
            {
                sqlObj.Close();
            }
        }
    }
}
