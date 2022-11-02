using System.Collections.Generic;

namespace timetable_backend.Models
{
    public class LessonGroup:List<Lesson>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortTitle { get; set; }

        public LessonGroup()
        {
        }

        public LessonGroup(string title, string shortTitle = null)
        {
            this.Title = title;
            this.ShortTitle = shortTitle;
        }
    }
}