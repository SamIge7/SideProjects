using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompetitionSchedule.Models
{
    public class RaceSchedule
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string CompetitionDistances { get; set; }
        [DataType(DataType.Date)]
        public DateTime CompetitionDate { get; set; }
        public string Location { get; set; }
    }
}
