using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;
using DTO;
using LogicLayer;

namespace Projektet_GUI
{
    /// <summary>
    /// Interaction logic for EKGOversigten.xaml
    /// </summary>

    public partial class EKGOversigten : Window
    {
        public ChartValues<double> Ekgvalues { get; set; }
        public string[] LabelsY { get; set; }
        private List<Patient> PatientListe;
        private Logic logicref;
        private List<EKG_Maaling> MaalingListe;
        private EKG_Maaling Maaling;
        private Patient patient1;

        //til grid 
        public Func<double, string> Formatter { get; set; }
        public Func<double, string> Formatter1 { get; set; }
        public Func<double, string> Formatter2 { get; set; }
        public Func<double, string> Formatter3 { get; set; }

        public EKGOversigten(Logic logicref)
        {
            InitializeComponent();
            this.logicref = logicref;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Formatter = value => (50 * value + " ms");
            Formatter1 = value => ("");
            Formatter2 = value => (value + " mv");
            Formatter3 = value => ("");

            PatientListe = logicref.getPatientListe();
            foreach (Patient item in PatientListe)
            {
                PatientLB.Items.Add(item.Navn + " " + item.Efternavn);
            }

            fnTB.Text = "Søren";
            EfTB.Text = "Pedersen";
            MedarnrTB.Text = "123";
           
            Ekgvalues = new ChartValues<double>();
      }

        private void GemB_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("EKG-Målingen er nu afsendt til offentlig database");
            MaalingListe = logicref.getMaalingListe(PatCprTB.Text);
            patient1 = logicref.getCPR(PatCprTB.Text);

            int antalmaalinger = 0;

            foreach (EKG_Maaling item in MaalingListe)
            {
                antalmaalinger++;
                if (Convert.ToDateTime(DatoLB.SelectedItem) == item.Starttid)
                {

                    logicref.gemIoffentligDatabase(Convert.ToDateTime(DatoLB.SelectedItem), antalmaalinger, fnTB.Text, EfTB.Text, Convert.ToInt32(MedarnrTB.Text), orgTB.Text, KommentarTB.Text, patient1.Navn, patient1.Efternavn, PatCprTB.Text, Maaling);

                }
            }

        }

        private void PatientLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DatoLB.Items.Clear();
            foreach (Patient item in PatientListe)
            {
                if (Convert.ToString(PatientLB.SelectedItem) == item.Navn + " " + item.Efternavn)
                {
                    PatCprTB.Text = item.CPR;
                }
            }

            MaalingListe = logicref.getMaalingListe(PatCprTB.Text);

            foreach (EKG_Maaling item in MaalingListe)
            {
                DatoLB.Items.Add(item.Starttid);
            }

        }

        private void DatoLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            Ekgvalues.Clear(); 

            foreach (EKG_Maaling item in MaalingListe)
            {
                if (item.Starttid == Convert.ToDateTime(DatoLB.SelectedItem))
                    Maaling = logicref.sygdomsalgoritme_Måling(item.CPR, item.Starttid);
            }

       
            foreach (double item in Maaling.EKG_Data)
            {
                Ekgvalues.Add(item);
            }

            if (Maaling.Sygdom == true)
            {
                sygdomTB.Text = "Ja";
            }
            else
            {
                sygdomTB.Text = "Nej";
            }

             DataContext = this;
             LabelsY = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16" };


      }

   }

}
