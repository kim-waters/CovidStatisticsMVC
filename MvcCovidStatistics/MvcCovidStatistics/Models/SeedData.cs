using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcCovidStatistics.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCovidStatistics.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CovidDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<CovidDbContext>>()))
            {
                // Look for any movies.
                if (context.DayRecords.Any())
                {
                    return;   // DB has been seeded
                }

                context.DayRecords.AddRange(
                    new DayRecord
                    {
                        Date = DateTime.Now,
                        NumVaccinated = 21000000,
                        NumDeaths = 190,
                        NumRecovered = 4450,
                        NewCases = 5962,
                    },
                    new DayRecord
                    {
                        Date = DateTime.Now.AddDays(-1),
                        NumVaccinated = 20000000,
                        NumDeaths = 205,
                        NumRecovered = 5230,
                        NewCases = 7345,
                    },
                    new DayRecord
                    {
                        Date = DateTime.Now.AddDays(-2),
                        NumVaccinated = 19000000,
                        NumDeaths = 220,
                        NumRecovered = 6534,
                        NewCases = 9324,
                    },
                    new DayRecord
                    {
                        Date = DateTime.Now.AddDays(-3),
                        NumVaccinated = 17000000,
                        NumDeaths = 268,
                        NumRecovered = 13224,
                        NewCases = 19029,
                    },
                    new DayRecord
                    {
                        Date = DateTime.Now.AddDays(-4),
                        NumVaccinated = 16000000,
                        NumDeaths = 334,
                        NumRecovered = 15343,
                        NewCases = 18902,
                    },
                    new DayRecord
                    {
                        Date = DateTime.Now.AddDays(-5),
                        NumVaccinated = 15000000,
                        NumDeaths = 352,
                        NumRecovered = 17354,
                        NewCases = 23654,
                    },
                    new DayRecord
                    {
                        Date = DateTime.Now.AddDays(-6),
                        NumVaccinated = 14000000,
                        NumDeaths = 415,
                        NumRecovered = 19324,
                        NewCases = 26345,
                    },
                    new DayRecord
                    {
                        Date = DateTime.Now.AddDays(-7),
                        NumVaccinated = 15000000,
                        NumDeaths = 456,
                        NumRecovered = 21354,
                        NewCases = 26654,
                    }
                    );


                context.SaveChanges();
            }
        }
    }
}
