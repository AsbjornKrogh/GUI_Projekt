using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   public class Person
   {
      public string Navn { get; set;}
      public string Efternavn { get; set;  }
      public string CPR { get; }

      public Person(string CPR,string Navn,string Efternavn)
      {
         this.CPR = CPR; 
         this.Navn = Navn;
         this.Efternavn = Efternavn;
      }
   }
}
