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
            sqlCmObj.Parameters.AddWithValue("@PSNO", PSNo);

            sqlCmObj.Parameters.AddWithValue("@emailId", EmailId);
            sqlCmObj.Parameters.AddWithValue("@facultyName", NAME);
            var returnParameter = sqlCmObj.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            try
            {

                sqlObj.Open();

                SqlParameter prmReturn = new SqlParameter();
                prmReturn.ParameterName = "ReturnValue";
                prmReturn.Direction = System.Data.ParameterDirection.ReturnValue;
                prmReturn.SqlDbType = System.Data.SqlDbType.Int;
                sqlCmObj.Parameters.Add(prmReturn);
                sqlCmObj.ExecuteNonQuery();
                int returnVal = Convert.ToInt32(prmReturn.Value);
                return returnVal;
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Oops something Wrong");
                throw ex;

            }
            finally
            {
                sqlObj.Close();
            }
        }
    }
}
