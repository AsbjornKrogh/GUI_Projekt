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
   /// Interaction logic for Oversigt.xaml
   /// </summary>
   public partial class Oversigt : Window
   {
      MainWindow Main;

      public Oversigt(MainWindow main)
      {
         InitializeComponent();
         Main = main;
      }

      private void Oversigt1_Loaded(object sender, RoutedEventArgs e)
      {
         Tilgængelige.Items.Add(1011);
         Tilgængelige.Items.Add(1012);
         Tilgængelige.Items.Add(1013);
         Tilgængelige.Items.Add(1014);

         for (int i = 0; i < 5; ++i)
         {
            foreach (PatientUdlån patient in Main.patient)
               if (patient.EKG_ID == 1010 + i)
                  Tilgængelige.Items.Remove(1010 + i);
                  udlånte.Items.Add(1010 + i); 
         }
      }
   }
}
