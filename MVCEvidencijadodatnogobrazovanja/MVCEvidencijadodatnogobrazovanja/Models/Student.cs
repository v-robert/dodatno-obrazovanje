using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVCEvidencijadodatnogobrazovanja.Models
{
    public class Student
    {
        public int ID { get; set; }
        [DisplayName ("Ime i prezime")]
        public string ImeiPrezime { get; set; }
        [DisplayName ("JMBAG")]
        public int JMBAG { get; set; }
        [DisplayName ("Status")]
        public string Status { get; set; }
        [DisplayName ("Datum izdavanja")]
        public DateTime DatumIzdavanja { get; set; }
        [DisplayName ("Email")]
        public string Email { get; set; }
        [DisplayName ("Godina studija")]
        public int GodinaStudija { get; set; }




        public int UstanovaID { get; set; }


        public virtual Ustanova Ustanova { get; set; }
    }
}