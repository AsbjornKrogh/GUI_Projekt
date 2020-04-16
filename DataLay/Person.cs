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
      public string Adresse { get; set; }
      public Dato Fødselsdato { get;  }
      public long CPR { get; }

      public Person(long CPR,string Navn,string Efternavn,string Adresse, Dato Fødselsdato)
      {
         this.CPR = CPR; 
         this.Navn = Navn;
         this.Efternavn = Efternavn;
         this.Adresse = Adresse;
         this.Fødselsdato = Fødselsdato;
         this.Peter = "nice";
      }


      public override string ToString()
      {
         return "Navn: " + Navn + "\nEfternavn: " + Efternavn + "\nAdresse: " + Adresse + "\nfødselsdato: " + Fødselsdato; 
      }
   }
}
