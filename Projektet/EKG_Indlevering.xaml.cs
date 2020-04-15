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

namespace Projektet_GUI
{
   /// <summary>
   /// Interaction logic for Window1.xaml
   /// </summary>
   public partial class EKG_Indlevering : Window
   {

      MainWindow Main; 

      public EKG_Indlevering(MainWindow main)
      {
         InitializeComponent();
         Main = main;
         EKGID.Focus();
         EKGID.SelectAll();
      }

      
      private void EKGID_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.Key == Key.Return)
         {
            foreach (PatientUdlån patient in Main.patient)
            {
               if (Convert.ToInt64(EKGID.Text) == patient.EKG_ID)
               {
                  NavnTB.Text = patient.Navn;
                  infoTB.Text = patient.ToString();

               }
            }
         }
      }

      private void Button_Click(object sender, RoutedEventArgs e)
      {
         foreach (PatientUdlån patient in Main.patient)
         {
            if (Convert.ToInt64(EKGID.Text) == patient.EKG_ID)
            {
               NavnTB.Text = patient.Navn;
               infoTB.Text = patient.ToString();
               MessageBox.Show("Indlevering af EKG måler med ID " + patient.EKG_ID + " er gennemført");
               Main.patient.Remove(patient);
               break; 
            }
         }
         Close(); 
         

      }

      private void Hent_info_Click(object sender, RoutedEventArgs e)
      {
         foreach (PatientUdlån patient in Main.patient)
         {
            if (Convert.ToInt64(EKGID.Text) == patient.EKG_ID)
            {
               NavnTB.Text = patient.Navn;
               infoTB.Text = patient.ToString();
               break;
            }
         }
      }
   }
}
