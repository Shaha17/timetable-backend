using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using timetable_backend.Models;
using timetable_backend.Services;

namespace timetable_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimetableController : ControllerBase
    {
        private readonly ILogger<TimetableController> _logger;

        public TimetableController(ILogger<TimetableController> logger)
        {
            _logger = logger;
        }
        // GET: api/Timetable
        [HttpGet]
        public async Task<List<LessonGroup>> Get([FromQuery] string dir, [FromQuery] int course)
        {
            int dirNum = Utils.GetDirectionNumByDirectionName(dir);
            int facNum = Utils.GetFacultyNumByDirection(dir);

            var rez = await TimeTableService.GetTimeTable(dir, course);
            _logger.LogInformation($"Request for timetable for {dir} {course.ToString()} {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}");
            return rez;
        }

        [HttpGet("byteacher")]
        public async Task<List<LessonGroup>> ByTeacher([FromQuery] string teacher)
        {
            var rez = await TimeTableService.GetTeachersTimetable(teacher);
            _logger.LogInformation($"Request for teacher's timetable {teacher} {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}");
            return rez;
        }
    }
}