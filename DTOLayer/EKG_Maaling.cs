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

      public EKG_Maaling(string CPR, DateTime dateTime)
      {
         this.CPR = CPR; 
         DateTime = dateTime;
      }

      public EKG_Maaling(string CPR, DateTime dateTime, List<double> eKG_maalingen)
      {
         this.CPR = CPR;
         DateTime = dateTime;
         EKG_Data = eKG_maalingen;
      }

   }
}
