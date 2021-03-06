﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Column(TypeName = "decimal(2, 2)")]
        public decimal Time { get; set; }
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
