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

        [Range(0, int.MaxValue, ErrorMessage = "Cannot be a negative")]
        [Display(Name = "Number of people vaccinated")]
        public int NumVaccinated { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Cannot be a negative")]
        [Display(Name = "Number of deaths")]
        public int NumDeaths { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Cannot be a negative")]
        [Display(Name = "Number of recoveries")]
        public int NumRecovered { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Cannot be a negative")]
        [Display(Name = "New cases")]
        public int NewCases { get; set; }
    }
}

