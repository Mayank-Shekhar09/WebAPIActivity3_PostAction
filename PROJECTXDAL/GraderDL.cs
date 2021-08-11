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
    public class GraderDL
    {
        SqlConnection sqlObj;
        SqlCommand sqlCmObj;
        public GraderDL()
        {
            sqlObj = new SqlConnection(ConfigurationManager.ConnectionStrings["DemoEntities1"].ToString());
        }
        public int AddNewGrader(Grader_DTO GraderObj)
        {

            sqlCmObj = new SqlCommand("dbo.uspGraderInput", sqlObj);
            sqlCmObj.CommandType = CommandType.StoredProcedure;
            sqlCmObj.Parameters.AddWithValue("@BCFId", GraderObj.BCFId);
            sqlCmObj.Parameters.AddWithValue("@PSNO", GraderObj.PSNO);
            sqlCmObj.Parameters.AddWithValue("@Score", GraderObj.Score);

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
                Console.WriteLine("Oops! Something went Wrong !");
                return 0;

            }
            finally
            {
                sqlObj.Close();
            }
        }
    }
}
