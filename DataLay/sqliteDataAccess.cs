using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Linq;
using System.Data.SQLite;
using Dapper;
using System.Threading.Tasks;

namespace Data
{
   public class sqliteDataAccess
   {
      //public static List<Person> GetPeople()
      //{
      //   using (IDbConnection cnn = new SQLiteConnection(LoadConnectString()))
      //   {
      //      var Output = cnn.Query<Person>("Select * from Person", new DynamicParameters());
      //      return Output.ToList(); 
      //   }
      //}

      //public static void SavePeople(Person p)
      //{
      //   using (IDbConnection cnn = new SQLiteConnection(LoadConnectString()))
      //   {
      //      cnn.Execute("inser into Patient (CPR, First name, Last Name) values (@CPR, @First Name, @Last Name)", p);
      //   }

      //}

      //private static string LoadConnectString(string ID = "default")
      //{
      //   return ConfigurationManager.ConnectionStrings[ID].ConnectionString;
      //}

   }
}
