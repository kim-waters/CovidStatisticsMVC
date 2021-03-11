using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MvcCovidStatistics.Models;

namespace MvcCovidStatistics.Data
{
    public class CovidDbContext : IdentityDbContext
    {
        public CovidDbContext(DbContextOptions<CovidDbContext> options)
            : base(options)
        {
        }
        public DbSet<DayRecord> DayRecords { get; set; }
    }
}
