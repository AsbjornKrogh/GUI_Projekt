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

        public EKGOversigten(Logic logicref)
        {
            InitializeComponent();
            this.logicref = logicref;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PatientListe = logicref.getPatientListe();
            foreach (Patient item in PatientListe)
            {

                PatientLB.Items.Add(item.Navn + " " + item.Efternavn);
            }

            fnTB.Text = "Søren";
            EfTB.Text = "Pedersen";
            MedarnrTB.Text = "12435687";
        }

        private void GemB_Click(object sender, RoutedEventArgs e)
        {
            MaalingListe = logicref.getMaalingListe(PatCprTB.Text);
            patient1 = logicref.getCPR(PatCprTB.Text);

            int antalmaalinger = 0;

            foreach (EKG_Maaling item in MaalingListe)
            {
                antalmaalinger++;
                if (Convert.ToDateTime(DatoLB.SelectedItem) == item.DateTime)
                {
                    
                    logicref.gemIoffentligDatabase(0, Convert.ToDateTime(DatoLB.SelectedItem), antalmaalinger, fnTB.Text, EfTB.Text, Convert.ToInt32(MedarnrTB.Text), orgTB.Text, KommentarTB.Text, patient1.Navn, patient1.Efternavn, PatCprTB.Text);
                    logicref.gemIoffentligDBEKGDATA("a", 2, 3, 4, "a", "a", "a", Convert.ToDateTime(02-02-2020), "a", 10, "a");
                }
            }


           // logicref.gemIoffentligDatabase(null, Convert.ToDateTime(DatoLB.SelectedItem),antalmaalinger, fnTB.Text, EfTB.Text, Convert.ToInt32(MedarnrTB.Text), orgTB.Text, KommentarTB.Text, "", "", PatientInfoTB.Text, PatCprTB.Text);
            //uploadet alle informationer til EGKmålinger og EKGData (offentlige)
        }

        private void PatientLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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
                DatoLB.Items.Add(item.DateTime);
            }

        }

        private void DatoLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (EKG_Maaling item in MaalingListe)
            {
                if (item.DateTime == Convert.ToDateTime(DatoLB.SelectedItem))
                    Maaling = logicref.sygdomsalgoritme_Måling(item.CPR, item.DateTime);
            }

            Ekgvalues = new ChartValues<double>();
            DataContext = this;
            LabelsY = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16" };

            //Kode for at få et ekg op på charen - Det under fungere ikke - i skal selv implementere charen  
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


        }

    }

}
