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
using DTO;

namespace Projektet
{
   /// <summary>
   /// Interaction logic for IndleverEKG.xaml
   /// </summary>
   public partial class IndleverEKG : Window
   {
      MainWindow Main;
      SqlDBDataAccess DBDataAccess;

      private Patient patient;

      public IndleverEKG(MainWindow main)
      {
         InitializeComponent();
         Main = main;
         IDTB.Focus();
         IDTB.SelectAll();
         DBDataAccess = new SqlDBDataAccess();
      }

      private void HentinfoB_Click(object sender, RoutedEventArgs e)
      {
         patient = DBDataAccess.LoadPatient(Convert.ToInt32(IDTB.Text));

         InfoTB.Text = patient.Navn + " " + patient.Efternavn;  
      }

      private void IndleverB_Click(object sender, RoutedEventArgs e)
      {
         DBDataAccess.IndleverEKG(patient.CPR, Convert.ToInt32(IDTB.Text)); 
      }

      private void AnnullerB_Click(object sender, RoutedEventArgs e)
      {
         Application.Current.Shutdown();
      }

      private void IDTB_KeyDown(object sender, KeyEventArgs e)
      {
      }
   }
}
