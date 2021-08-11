using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace PROJECTXDAL
{
    public class FacultyDL
    {
        SqlConnection sqlObj;
        SqlCommand sqlCmObj;
        public FacultyDL()
        {
            sqlObj = new SqlConnection(ConfigurationManager.ConnectionStrings["DemoEntities1"].ToString());
        }
        public int AddFaculty(int PSNo, string EmailId, string NAME)
        {

            sqlCmObj = new SqlCommand("dbo.uspFacultyAdd", sqlObj);
            sqlCmObj.CommandType = CommandType.StoredProcedure;
            sqlCmObj.Parameters.AddWithValue("@PSNo", PSNo);

            sqlCmObj.Parameters.AddWithValue("@EmailId", EmailId);
            sqlCmObj.Parameters.AddWithValue("@Name", NAME);
            var returnParameter = sqlCmObj.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            try
            {
               
                sqlObj.Open();
                sqlCmObj.ExecuteNonQuery();
                var result = returnParameter.Value;
                Console.WriteLine(result);
                return (int)result;
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
