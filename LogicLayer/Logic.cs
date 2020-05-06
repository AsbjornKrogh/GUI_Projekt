using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using DTO;


namespace LogicLayer
{
    
    public class Logic
    {

        
        SqlDBDataAccess DBDataAccess;
        
        private Patient person;

        public Logic()
        {
            DBDataAccess = new SqlDBDataAccess();
            
        }
        public List<EKG> getEKGMålere()
        {
            return DBDataAccess.EKGMålere();
        }

        public byte getudlånBesked()
        {
            return DBDataAccess.UdlaanTilPatient(person.CPR, person.Navn, person.Efternavn, person.EKGID);
        }

        public Patient getCPR()
        {
            return DBDataAccess.LoadPatientCPR(person.CPR);
        }

        public Patient getPatientinfo()
        {
            return DBDataAccess.LoadPatient(person.EKGID);
        }
        
        public void indleverEkgMåler()
        {
            DBDataAccess.IndleverEKG(person.CPR, person.EKGID);
        }

        public List<Patient> getPatientListe()
        {
            return DBDataAccess.LoadAllPatient();
        }

        public List<EKG_Maaling> getMaalingListe()
        {
            return DBDataAccess.LoadAllMålinger(person.CPR);
        }



    }

    
     


}
