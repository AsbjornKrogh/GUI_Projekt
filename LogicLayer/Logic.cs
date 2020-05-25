using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Data;
using DTO;


namespace LogicLayer
{

   public class Logic
   {   
      private SqlDBDataAccess DBDataAccess;
      private EKG_Maaling EKGmaaling;
      public string tekst;

      public Logic()
      {
         DBDataAccess = new SqlDBDataAccess();
     
      }

      public List<EKG> getEKGMålere()
      {
         return DBDataAccess.EKGMålere();
      }

      public byte getudlånBesked(string cpr, string navn, string efternavn, int ekgid)
      {
         return DBDataAccess.UdlaanTilPatient(cpr, navn, efternavn, ekgid);
      }

      public Patient getCPR(string cpr)
      {
         return DBDataAccess.LoadPatientCPR(cpr);
      }

      public Patient getPatientinfo(int ekgid)
      {
         return DBDataAccess.LoadPatient(ekgid);
      }

      public void indleverEkgMåler(string cpr, int ekgid)
      {
         DBDataAccess.IndleverEKG(cpr, ekgid);
      }

      public List<Patient> getPatientListe()
      {
         return DBDataAccess.LoadAllPatient();
      }

      public List<EKG_Maaling> getMaalingListe(string cpr)
      {
         return DBDataAccess.LoadAllMålinger(cpr);
      }

      public void gemIoffentligDatabase(DateTime dato, int antalmaalinger, string sfp_ansvfornavn, string sfp_ansvefternavn, int sfp_ansvmedarbjnr, string sfp_ans_org, string sfp_anskommentar, string borger_fornavn, string borger_efternavn, string borger_cprnr, EKG_Maaling maaling)
      {
         DBDataAccess.gemIOffentligDataBase(dato, antalmaalinger, sfp_ansvfornavn, sfp_ansvefternavn, sfp_ansvmedarbjnr, sfp_ans_org, sfp_anskommentar, borger_fornavn, borger_efternavn, borger_cprnr, maaling);
      }

      public EKG_Maaling sygdomsalgoritme_Måling(string cpr, DateTime time)
      {
         //Opjekter og atributter til udregnelse af sygdom. 
         int Tæller = 1;
         int Antal = 0;

         double threshold = 1.75;
         bool belowThreshold = true;

         int[] RTList = new int[20];
         List<int> diff = new List<int>();

         try
         {
            EKGmaaling = DBDataAccess.LoadEKGMaaling(cpr, time);


            int samplerate = EKGmaaling.Samplerate;
            double Sygdomsdiff = (1 * samplerate) * 0.16;

            for (int tæller = 0; tæller < EKGmaaling.EKG_DataArray.Length; tæller++)
            {
               if (EKGmaaling.EKG_DataArray[tæller] > threshold && belowThreshold == true)
               {
                  RTList[Antal] = Tæller;
                  Antal++;
               }
               if (EKGmaaling.EKG_DataArray[tæller] < threshold)
                  belowThreshold = true;
               else
                  belowThreshold = false;
               Tæller++;
            }

            for (int i = 0; i < RTList.Length; ++i)
            {
               if (RTList[1 + i] == 0)
                  break;

               diff.Add(RTList[i + 1] - RTList[i]);
            }
            int MaxVal = diff.Max();
            int MinVal = diff.Min();

            if (Sygdomsdiff < MaxVal - MinVal)
               EKGmaaling.Sygdom = true;
         }
         catch
         {

         }
         return EKGmaaling;
      }
   }
}
