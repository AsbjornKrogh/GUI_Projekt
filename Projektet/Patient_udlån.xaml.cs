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
using System.Data.SqlClient;
using Data;

namespace Projektet_GUI
{
   /// <summary>
   /// Interaction logic for Patient_udlån.xaml
   /// </summary>
   public partial class Patient_udlån : Window
   {
      MainWindow Main;

      public Patient_udlån(MainWindow main)
      {
         InitializeComponent();
         Main = main;
    
      }

  

      private void Submit_Click(object sender, RoutedEventArgs e)
      {
         MessageBoxResult result = MessageBox.Show("Er du sikker på du vil udlåne EKG-måler " + EKGmåler.SelectedItem + " til " + NavnTB.Text, "Advarsel", MessageBoxButton.YesNo, MessageBoxImage.Warning);
         switch (result)
         {
            case MessageBoxResult.Yes:
               break;
            case MessageBoxResult.No:
               break;
         }
      }

      private void Annullere_Click(object sender, RoutedEventArgs e)
      {
         Close(); 
      }

      private void Hent_Click(object sender, RoutedEventArgs e)
      {
         
      }

         private void cprTB_KeyDown(object sender, KeyEventArgs e)
         {
         
         }

         private void EKGmåler_Loaded(object sender, RoutedEventArgs e)
         {

         }


      
   }
}
