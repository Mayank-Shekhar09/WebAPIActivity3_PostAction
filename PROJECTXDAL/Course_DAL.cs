using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROJECTXDTO;

namespace PROJECTXDAL
{
    public class Course_DAL
    {
		DemoEntities connect;

		public Course_DAL()
		{
			connect = new DemoEntities();
		}
		public List<Course_DTO> GetAllCourses()
		{
			List<Course_DTO> lstOfCourse = new List<Course_DTO>();
			try
			{
				var listOfCourseFromDb = connect.Courses.ToList();
				foreach (var item in listOfCourseFromDb)
				{
					lstOfCourse.Add(
					new Course_DTO()
					{
						CourseId = item.CourseId,
						CourseTitle = item.CourseTitle,
						CourseDuration = Convert.ToInt32(item.CourseDuration),
						CourseMode = item.CourseMode
					});
				}
				return lstOfCourse;
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		public List<Course_DTO> GetCourseByCourseId(string cid)
		{
			
			List<Course_DTO> course=new List<Course_DTO>();
			try
			{

				var courseFromDb = connect.Courses.Where(x=>x.CourseId==cid).Select(x=>new { x.CourseId, x.CourseTitle, x.CourseDuration, x.CourseMode });
				foreach(var item in courseFromDb)
                {
					course.Add(new Course_DTO()
					{
						CourseId = item.CourseId,
						CourseTitle = item.CourseTitle,
						CourseDuration = Convert.ToInt32(item.CourseDuration),
						CourseMode = item.CourseMode
					});
                }
				return course;
				
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}
	}
}
