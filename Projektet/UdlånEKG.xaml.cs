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
    /// Interaction logic for UdlånEKG.xaml
    /// </summary>
    public partial class UdlånEKG : Window
    {
        MainWindow Main;
        SqlDBDataAccess DBDataAccess; 

        public UdlånEKG(MainWindow main)
        {
            InitializeComponent();
            Main = main;
         DBDataAccess = new SqlDBDataAccess(); 
        }

        private void UdlånB_Click(object sender, RoutedEventArgs e)
        {
         DBDataAccess.savePatient("250997-0000", "Asbjørn", "Krogh", 1011); 




            MessageBoxResult result = MessageBox.Show("Er du sikker på at vil udlåne EKG-måler" + EKGmåler.SelectedItem + "til" + NavnTB.Text, "Advarsel", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    break;
                case MessageBoxResult.No:
                    break;
            }

        }

        private void AnnullerB_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CPRTB_KeyDown(object sender, KeyEventArgs e)
        {
         //    if (e.Key == Key.Return)
         //    {
         //        foreach (Person person in people)
         //        {
         //            if (Convert.ToInt64(CPRTB.Text) == person.CPR)
         //            {
         //                NavnTB.Text = person.Navn;
         //                EfterNavnTB.Text = person.Efternavn;
         //                FødselsdagTB.Text = Convert.ToString(person.Fødselsdato.Dag.Måned.År);
         //                firesidsteTB.Text = Convert.ToString(person.Fødselsdato.cpr);

         //            }

         //        }
         //    }
      }

      private void EKGmåler_Loaded(object sender, RoutedEventArgs e)
        {
            //EKGmåler.Items.Add(1);
            //EKGmåler.Items.Add(2);
            //EKGmåler.Items.Add(3);
            //EKGmåler.Items.Add(4);

            //for (int i = 0; i < 5; ++i)
            //{
            //    //foreach (PatientUdlån patient in Main.patient)
            //    //    if (patient.EKG_ID == 1 + i)
            //    //        EKGmåler.Items.Remove(1 + i);
            //}

        }

        private void HentInfoB_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    
}
