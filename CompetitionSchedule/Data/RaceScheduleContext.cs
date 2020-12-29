using CompetitionSchedule.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetitionSchedule.Data
{
    public class RaceScheduleContext: DbContext
    {
        public RaceScheduleContext(DbContextOptions<RaceScheduleContext> options) : base(options)
        {
        }

        public DbSet<RaceSchedule> RaceSchedules { get; set; }
    }
}
