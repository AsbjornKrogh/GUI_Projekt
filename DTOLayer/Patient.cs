using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class Patient
   {
      public string CPR { get; set; }
      public string Navn { get; set;}
      public string Efternavn { get; set; }
      public int EKGID { get; set; }

      public Patient(string CPR, string navn, string efternavn, int EKGID)
      {
         this.CPR = CPR;
         Navn = navn;
         Efternavn = efternavn;
         this.EKGID = EKGID; 
      }

      public Patient(string CPR, string navn, string efternavn)
      {
         this.CPR = CPR;
         Navn = navn;
         Efternavn = efternavn;
      }
   }
}
