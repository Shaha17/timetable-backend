using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using timetable_backend.Models;

namespace timetable_backend.Services
{
    public static class TimeTableService
    {
        public static async Task<List<LessonGroup>> GetTimeTable(string dirStr, int course)
        {
            var timetableList = new List<LessonGroup>(); 
            int fac = Utils.GetFacultyNumByDirection(Configs.Directions[dirStr]);
            int dir = Utils.GetDirectionNumByDirectionName(Configs.Directions[dirStr]);

            for (int i = 1; i <=7; i++)
            {
                int day = i;
                var html = await GetHtmlTimetableByDay(course, dir, fac, day);
                var lessonGroup = TimetableParser.ParseDayFromHtml(html);
                timetableList.Add(lessonGroup);
            }

            return timetableList;
        }

        public static async Task<List<LessonGroup>> GetTeachersTimetable(string teacher)
        {
            var html = await GetTeachersTimetableHtml(teacher);
            var lessonGroup = TimetableParser.ParseTeachersTimetableFromHtml(html);
            return lessonGroup;
        }

        private static async Task<string> GetTeachersTimetableHtml(string teacher)
        {
            var uriBuilder = new UriBuilder(Configs.TimeTableUrl);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["type"] = "teacher";
            query["search"] = teacher;
            uriBuilder.Query = query.ToString() ?? string.Empty;
            var url = uriBuilder.ToString();
            var htmlString = new WebClient().DownloadString(url);

            return await Task.FromResult(htmlString);
        }

        private static async Task<string> GetHtmlTimetableByDay(int course, int dir, int fac, int day)
        {
            var uriBuilder = new UriBuilder(Configs.TimeTableUrl);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["faculty"] = fac.ToString();
            query["direction"] = dir.ToString();
            query["course"] = course.ToString();
            query["day"] = day.ToString();
            uriBuilder.Query = query.ToString() ?? string.Empty;
            var url = uriBuilder.ToString();

            var htmlString = new WebClient().DownloadString(url);

            return await Task.FromResult( htmlString);
        }
    }
}