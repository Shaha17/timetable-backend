using System.Collections.Generic;

namespace timetable_backend
{
    public class Configs
    {
        public static string TimeTableUrl = "https://www.msu.tj/ru/timetable";

        public static Dictionary<string, string> Directions = new()
        {
            {"pmi", "Прикладная математика и информатика"},
            {"geo", "Геология"},
            {"hfmm", "Химия, физика и механика материалов"},
            {"mo", "Международные отношения"},
            {"gmu", "Государственное и муниципальное управление"},
            {"lin", "Лингвистика"},
        };
        public static List<string> HumanitiesDirections = new()
            {Directions["mo"], Directions["gmu"], Directions["lin"]};

        public static List<string> NaturalScienceDirections = new()
            {Directions["pmi"], Directions["geo"], Directions["hfmm"]};
    }
}