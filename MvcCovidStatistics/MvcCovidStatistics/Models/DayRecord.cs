using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MvcCovidStatistics.Models
{
    public class DayRecord
    {
        public int Id { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Number of people vaccinated")]
        public int NumVaccinated { get; set; }
        [Display(Name = "Number of deaths")]
        public int NumDeaths { get; set; }
        [Display(Name = "Number of recoveries")]
        public int NumRecovered { get; set; }
        [Display(Name = "New cases")]
        public int NewCases { get; set; }
    }
}

