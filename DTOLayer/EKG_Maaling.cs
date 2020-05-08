using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
   public class EKG_Maaling
   {
      public string CPR { get; set; }
      public DateTime DateTime { get; set; }
      public List<double> EKG_Data { get; set; }
      public bool Sygdom { get; set; }

      public int id { get; set; }

      public EKG_Maaling(string CPR, DateTime dateTime, int id)
      {
         this.CPR = CPR;
         DateTime = dateTime;
         this.id = id;
      }

      public EKG_Maaling(string CPR, DateTime dateTime, List<double> eKG_maalingen, int id, bool sygdom)
      {
         this.CPR = CPR;
         DateTime = dateTime;
         EKG_Data = eKG_maalingen;
         this.id = id;
         Sygdom = sygdom;
      }

   }
}
