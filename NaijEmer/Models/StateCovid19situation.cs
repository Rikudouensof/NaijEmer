using System;
using System.Collections.Generic;
using System.Text;

namespace NaijEmer.Models
{
    public class StateCovid19situation
    {
        public int id { get; set; }
        public string States { get; set; }
        public string No_of_cases { get; set; }
        public string No_on_admission { get; set; }
        public string No_discharged { get; set; }
        public string No_of_deaths { get; set; }
    }
}
