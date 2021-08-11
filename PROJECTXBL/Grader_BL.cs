using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROJECTXDTO;
using PROJECTXDAL;

namespace PROJECTXBL
{
    public class Grader_BL
    {
        Grader_DAL dalObj = new Grader_DAL();
        GraderDL graderObj = new GraderDL();
        public List<Grader_DTO> GetParticipants(string courseid)
        {
            try
            {
                var participantList = dalObj.GetParticipantsbyCourse(courseid);
                return participantList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Grader_DTO> TopPerformers(string courseid)
        {
            try
            {
                var result = dalObj.TopPerformers(courseid);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Grader_DTO> BottomPerformers(string courseid)
        {
            try
            {
                var result = dalObj.BottomPerformance(courseid);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Grader_DTO> GetCourseParticipantFromFacultyId(string psno)
        {
            try
            {
                var listofCourse = dalObj.GetCourseParticipantsFromFacultyId(psno);
                return listofCourse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Grader_DTO> GetCourseParticipantFromPSNO(int psno)
        {
            try
            {
                var listofParticipants = dalObj.GetParticipantByPSNO(psno);
                return listofParticipants;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Grader_DTO> GetParticipantGreaterThanEqual(float score)
        {
            try
            {
                var listofParticipants = dalObj.GetParticipantGreaterThanAndEqualScore(score);
                return listofParticipants;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddNewGrader(Grader_DTO GraderObj)
        {
            try
            {
                int listofParticipants = graderObj.AddNewGrader(GraderObj);
                return listofParticipants;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
