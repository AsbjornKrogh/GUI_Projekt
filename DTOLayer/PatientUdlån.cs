using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   public class PatientUdlån : Person
   {
      public int EKG_ID { get; set; }
         
      public PatientUdlån(string CPR, string Navn, string Efternavn,string Adresse, int EKG_ID, string Årsag)
        : base(CPR, Navn, Efternavn)
      {
         this.EKG_ID = EKG_ID;
      }
   }
}
