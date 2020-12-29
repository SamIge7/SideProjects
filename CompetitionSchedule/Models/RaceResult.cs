using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompetitionSchedule.Models
{
    public class RaceResult
    {
        public int Id { get; set; }
        [Display(Name = "Event Name")]
        public string EventName { get; set; }
        [Display(Name = "Competition Distance")]
        public string CompetitionDistance { get; set; }
        [Display(Name = "Competition Date")]
        [DataType(DataType.Date)]
        public DateTime CompetitionDate { get; set; }
        public string Location { get; set; }
        public decimal Time { get; set; }
    }
}
