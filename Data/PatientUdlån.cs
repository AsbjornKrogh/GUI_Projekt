using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   public class PatientUdlån : Person
   {
      public int EKG_ID { get; set; }
      private DateTime DateTime { get; }
      private string Årsag { get; set; }
         
      public PatientUdlån(long CPR, string Navn, string Efternavn,string Adresse, Dato Fødselsdato, DateTime dateTime, int EKG_ID, string Årsag)
        : base(CPR,Navn,Efternavn,Adresse,Fødselsdato)
      {
         DateTime = dateTime;
         this.EKG_ID = EKG_ID;
         this.Årsag = Årsag;
      }
   }
}
