using CompetitionSchedule.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetitionSchedule.Data
{
    public class RaceResultContext: DbContext
    {
        public RaceResultContext(DbContextOptions<RaceResultContext> options) :base(options)
        {       
        }

        public DbSet<RaceResult> RaceResults { get; set; }
    }
}
