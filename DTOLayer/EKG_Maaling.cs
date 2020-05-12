using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
   public class EKG_Maaling
   {
      public string CPR { get; set; }
      public DateTime Starttid { get; set; }
      public List<double> EKG_Data { get; set; }
      public bool Sygdom { get; set; }
      public int id { get; set; }

      public double[] EKG_DataArray { get; set; }
      public string Dataformat { get; set; }
      public int Samplerate { get; set; }
      public int Periode { get; set; }
      public string Bin_text { get; set; }
      public string Maaletype { get; set; }
      public int EKGID { get; set; }


      public EKG_Maaling(string CPR, DateTime dateTime, int id)
      {
         this.CPR = CPR;
         Starttid = dateTime;
         this.id = id;
      }

      public EKG_Maaling(string CPR, DateTime dateTime, List<double> eKG_maalingen, int id, bool sygdom)
      {
         this.CPR = CPR;
         Starttid = dateTime;
         EKG_Data = eKG_maalingen;
         this.id = id;
         Sygdom = sygdom;
      }

      public EKG_Maaling(string CPR, List<double> raadata, double[] raadataarr, int samplerate, int periode, string dataformat, string bin_text, string maaletype,  DateTime starttid, int eKGID)
      {
         EKG_Data = raadata; 
         EKG_DataArray = raadataarr;
         this.CPR = CPR;
         Starttid = starttid;
         Dataformat = dataformat;
         Samplerate = samplerate;
         Periode = periode;
         Bin_text = bin_text;
         Maaletype = maaletype;
         EKGID = eKGID;
      }



   }
}
