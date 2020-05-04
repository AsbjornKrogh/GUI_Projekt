using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using DTO;


namespace Data
{
   public class SqlDBDataAccess
   {
      #
      //Atributter og objetkter 
      //Connectionsstrings til Lokal og Offentlig Database. 
      private string connetionStringST = @"Data Source=st-i4dab.uni.au.dk;Initial Catalog=F20ST2ITS2201908477;Integrated Security=False;User ID=F20ST2ITS2201908477;Password=F20ST2ITS2201908477;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
      private string ConnetionStringSToffentlig = @"Data Source=st-i4dab.uni.au.dk;Initial Catalog=ST2PRJ2OffEKGDatabase;Integrated Security=False;User ID=ST2PRJ2OffEKGDatabase;Password=ST2PRJ2OffEKGDatabase;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";

      //SQL 
      private SqlConnection connection;
      private SqlCommand command;
      private string sql = null;
      private SqlDataReader dataReader;

      //Atributter
      private List<Patient> PatientListe;
      private List<EKG_Maaling> MaalingListe;
      private List<EKG> EKGmaalereListe;

      private Patient IndleverPatient;
      private EKG_Maaling EKGMaaling;

      public SqlDBDataAccess()
      {
         connection = new SqlConnection(connetionStringST);
      }

      //Metoden udlåner et EKG til en patient og læser ham ind i listen. 
      //Returneres 2 er databasen opdateret med alle informationer 
      //Returneres 1 er databasen updateret med EKGID, da patienten allerede findes i Databasen. 
      public byte UdlaanTilPatient(string CPR, string navn, string efternavn, int EKGid)
      {
         try
         {
            connection.Open();

            string insertStringParam = @"INSERT INTO dbo.EKGPatient (CPR,navn,Efternavn,EKGID) 
                                      VALUES(@CPR, @navn, @efternavn, @EKGid)";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, connection))
            {
               cmd.Parameters.AddWithValue("@CPR", CPR);
               cmd.Parameters.AddWithValue("@navn", navn);
               cmd.Parameters.AddWithValue("@efternavn", efternavn);
               cmd.Parameters.AddWithValue("@EKGid", EKGid);
               cmd.ExecuteReader();
            }

            connection.Close();
            connection.Open();

            insertStringParam = @"UPDATE dbo.EKGDB SET Available = 0 WHERE EKGID = " + EKGid;

            using (SqlCommand cmd = new SqlCommand(insertStringParam, connection))
            {
               cmd.ExecuteReader();
            }

            connection.Close();

            return 2;
         }
         catch
         {
            string insertStringParam = @"UPDATE dbo.EKGPatient SET EKGID = " + EKGid + " WHERE CPR = '" + CPR + "'";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, connection))
            {
               cmd.Parameters.AddWithValue("@EKGid", EKGid);
               cmd.ExecuteReader();
            }

            connection.Close();

            //Ændringer i EKGDB 
            connection.Open();
            insertStringParam = @"UPDATE dbo.EKGDB SET Available = 0 WHERE EKGID = " + EKGid;

            using (SqlCommand cmd = new SqlCommand(insertStringParam, connection))
            {
               cmd.ExecuteReader();
            }

            connection.Close();
            return 1;

         }
      }

      //Metoden som henter alle tilgængelig patinter (ect til en listbox)
      public List<Patient> LoadAllPatient()
      {
         PatientListe = new List<Patient>();

         sql = "Select * from dbo.EKGPatient";

         try
         {
            connection.Open();

            command = new SqlCommand(sql, connection);

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
               PatientListe.Add(new Patient(Convert.ToString(dataReader["CPR"]), Convert.ToString(dataReader["navn"]), Convert.ToString(dataReader["Efternavn"])));
            }

            dataReader.Close();

            command.Dispose();

            connection.Close();

            return PatientListe;
         }
         catch
         {
            return null;
         }
      }

      //Metoden som henter alle "målinger" for patienten som er valgt til en listbox. 
      public List<EKG_Maaling> LoadAllMålinger(string CPR)
      {
         MaalingListe = new List<EKG_Maaling>();

         sql = "Select CPR,tidsstempel from dbo.EKGData Where CPR = '" + CPR + "'";

         try
         {
            connection.Open();
            command = new SqlCommand(sql, connection);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
               MaalingListe.Add(new EKG_Maaling(Convert.ToString(dataReader["CPR"]), Convert.ToDateTime(dataReader["tidsstempel"])));
            }
            dataReader.Close();
            command.Dispose();
            connection.Close();

            return MaalingListe;
         }
         catch
         {
            return null;
         }
      }

      //Henter alle EKGmaåleres ID fra data base, samt om de er ledige eller ej 
      public List<EKG> EKGMålere()
      {
         EKGmaalereListe = new List<EKG>();

         sql = "Select * from dbo.EKGDB";

         try
         {
            connection.Open();

            command = new SqlCommand(sql, connection);

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
               EKGmaalereListe.Add(new EKG(Convert.ToInt32(dataReader["EKGID"]), Convert.ToBoolean(dataReader["Available"])));
            }

            dataReader.Close();

            command.Dispose();

            connection.Close();

            return EKGmaalereListe;
         }
         catch
         {
            return null;
         }
      }

      //Henter 1 patient fra DB, hvor EKGID'et stemmer overens (Bruges i Indlever vinduet) 
      public Patient LoadPatient(int EKGid)
      {
         sql = "Select * from dbo.EKGPatient where EKGID = '" + EKGid + "'";

         try
         {
            connection.Open();

            command = new SqlCommand(sql, connection);

            dataReader = command.ExecuteReader();

            if (dataReader.Read())
            {
               IndleverPatient = new Patient(Convert.ToString(dataReader["CPR"]), Convert.ToString(dataReader["navn"]), Convert.ToString(dataReader["Efternavn"]), Convert.ToInt32(dataReader["EKGID"]));
            }

            dataReader.Close();

            command.Dispose();

            connection.Close();

            return IndleverPatient;
         }
         catch
         {
            return null;
         }

      }

      //Henter 1 patient fra DB, hvor EKGID'et stemmer overens (Bruges i Indlever vinduet) 
      public Patient LoadPatientCPR(string CPR)
      {
         sql = "Select * from dbo.EKGPatient where CPR = '" +  CPR + "'";

         try
         {
            connection.Open();

            command = new SqlCommand(sql, connection);

            dataReader = command.ExecuteReader();

            if (dataReader.Read())
            {
               IndleverPatient = new Patient(Convert.ToString(dataReader["CPR"]), Convert.ToString(dataReader["navn"]), Convert.ToString(dataReader["Efternavn"]));
            }

            dataReader.Close();

            command.Dispose();

            connection.Close();

            return IndleverPatient;
         }
         catch
         {
            return null;
         }

      }

      //Metoden indlevere EKG ved at ændre i EKGPatient og i EKGDB
      public void IndleverEKG(string CPR, int EKGID)
      {
         string insertStringParam = @"UPDATE dbo.EKGPatient SET EKGID = null WHERE CPR = '" + CPR + "'";

         connection.Open(); 

         using (SqlCommand cmd = new SqlCommand(insertStringParam, connection))
         {
            cmd.ExecuteReader();
         }

         connection.Close();
         connection.Open();

         insertStringParam = @"UPDATE dbo.EKGDB SET Available = 1 WHERE EKGID = " + EKGID;

         using (SqlCommand cmd = new SqlCommand(insertStringParam, connection))
         {
            cmd.ExecuteReader();
         }

         connection.Close();
      }




      //Ikke inplementeret
      //metoden skal hente 1 specifik EKG målling som skal vises på GUI char
      //public EKG_Maaling LoadEKGMaaling()
      //{
      //   MaalingListe = new List<EKG_Maaling>();

      //   //sql = "Select CPR, tidsstempel from dbo.EKGData Where tidstempel = '" + CPR + "'";

      //   try
      //   {
      //      connection.Open();

      //      command = new SqlCommand(sql, connection);

      //      dataReader = command.ExecuteReader();

      //      while (dataReader.Read())
      //      {
      //         MaalingListe.Add(new EKG_Maaling(Convert.ToString(dataReader["CPR"]), Convert.ToDateTime(dataReader["tidsstempel"])));
      //      }

      //      dataReader.Close();

      //      command.Dispose();

      //      connection.Close();

      //      return MaalingListe;
      //   }
      //   catch
      //   {
      //      return null;
      //   }
      //   return 
      //}


   }
}

