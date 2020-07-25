using System.Collections.Generic;
using DefaultCalendar.Models;

namespace DefaultCalendar.Data
{
    public static class DataLoader
    {
        public static IEnumerable<Event> GetEventAll()
        {
            return new[]{
                new Event{ Title = "Evento 01", Start = "2020-07-26" },
                new Event{ Title = "Evento 02", Start = "2020-07-28" },
            };
        }
    }
}