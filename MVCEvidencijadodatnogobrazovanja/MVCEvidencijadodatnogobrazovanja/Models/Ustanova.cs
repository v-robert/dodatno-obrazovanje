using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVCEvidencijadodatnogobrazovanja.Models
{
    public class Ustanova
    {
        public int ID { get; set; }
        [DisplayName ("OIB")]
        public int OIB { get; set; }
        [DisplayName ("Podučje rada")]
        public string PodrucjeRada { get; set; }
        [DisplayName ("Vrsta")]
        public string Vrsta { get; set; }





       
        public virtual ICollection<Student> Students { get; set; }
    }
}