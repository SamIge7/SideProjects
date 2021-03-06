﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompetitionSchedule.Models
{
    public class RaceSchedule
    {
        public int Id { get; set; }
        [Display(Name = "Event Name")]
        public string EventName { get; set; }
        [Display(Name = "Competition Distance(s)")]
        public string CompetitionDistances { get; set; }
        [Display(Name = "Competition Date")]
        [DataType(DataType.Date)]
        public DateTime CompetitionDate { get; set; }
        public string Location { get; set; }
        [Display(Name = "Competition Type")]
        public RaceType EventType { get; set; }

        public enum RaceType
        {
            [Display(Name = "Open Meeting")]
            Open,
            [Display(Name = "Champs")]
            Championship,
            [Display(Name = "League Match")]
            League
        }
    }
}
