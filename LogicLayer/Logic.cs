using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Data;
using DTO;


namespace LogicLayer
{

   public class Logic
   {
      SqlDBDataAccess DBDataAccess;

      private Patient patient;
      private EKG_Maaling EKGmaaling;

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

      public void gemIoffentligDatabase(int ekgmaaleid, DateTime dato, int antalmaalinger, string sfp_ansvfornavn, string sfp_ansvefternavn, int sfp_ansvmedarbjnr, string sfp_ans_org, string sfp_anskommentar, string borger_fornavn, string borger_efternavn, string borger_beskrivelse, string borger_cprnr)
      {
         DBDataAccess.gemIOffentligDataBase(ekgmaaleid, dato, antalmaalinger, sfp_ansvfornavn, sfp_ansvefternavn, sfp_ansvmedarbjnr, sfp_ans_org, sfp_anskommentar, borger_fornavn, borger_efternavn, borger_beskrivelse, borger_cprnr);
      }

      public EKG_Maaling sygdomsalgoritme_Måling(string cpr, DateTime time)
      {
         //Opjekter og atributter til udregnelse af sygdom. 
         int Tæller = 1;
         int Antal = 0; 
         
         double sample;
         int diff;
         double threshold = 2.1;
         bool belowThreshold = true;

         int[] RTList = new int[20];

         EKGmaaling = DBDataAccess.LoadEKGMaaling(cpr, time);

         foreach (double item in EKGmaaling.EKG_Data)
         {
            if (item > threshold && belowThreshold == true)
            {
               RTList[Antal] = Tæller; 
               Antal++; 
            }
            if (item < threshold)
               belowThreshold = true;
            else
               belowThreshold = false;

            Tæller++; 
         }
         try
         {
            for (int i = 0; i < RTList.Length; i++)
            {
               diff = RTList[i + 1] - RTList[i];

               if (diff > 30) //30 er udvalgt, da vi sampler med 
                  EKGmaaling.Sygdom = true;
            }
         }
         catch
         {
         return EKGmaaling;
         }
      return EKGmaaling;
      }



   }





}
