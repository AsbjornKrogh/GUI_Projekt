using Projektet_GUI;
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
using Data;


namespace Projektet
{
    /// <summary>
    /// Interaction logic for IndleverEKG.xaml
    /// </summary>
    public partial class IndleverEKG : Window
    {
        MainWindow Main;

        public IndleverEKG(MainWindow main)
        {
            InitializeComponent();
            Main = main;
            IDTB.Focus();
            IDTB.SelectAll();
        }

        private void HentinfoB_Click(object sender, RoutedEventArgs e)
        {
            //foreach(PatientUdlån patient in Main.Patient)
            //{
            //    if (Convert.ToInt64(IDTB.Text) == patient.EKG_ID)
            //    {
            //        IDTB.Text = patient.Navn;
            //        InfoTB.Text = patient.ToString();
            //        break;
            //    }
            //}
        }

        private void IndleverB_Click(object sender, RoutedEventArgs e)
        {
            //foreach (PatientUdlån patient in Main.patient)
            //{
            //    if (Convert.ToInt64(IDTB.Text) == patient.EKG_ID)
            //    {
            //        IDTB.Text = patient.Navn;
            //        InfoTB.Text = patient.ToString();
            //        MessageBox.Show("Indlevering af EKG måler med ID " + patient.EKG_ID + " er gennemført");
            //        Main.patient.Remove(patient);
            //        break;
            //    }
            //}
            Close();
        }

        private void AnnullerB_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void IDTB_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.Return)
            //{
            //    foreach (PatientUdlån patient in Main.Patient)
            //    {
            //        if (Convert.ToInt64(IDTB.Text) == patient.EKG_ID)
            //        {
            //            IDTB.Text = patient.Navn;
            //            InfoTB.Text = patient.ToString();

            //        }
            //    }
            //}
        }
    }
}
