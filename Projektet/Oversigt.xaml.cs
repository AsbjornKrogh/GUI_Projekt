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
      SqlDBDataAccess DB;

      public Oversigt(MainWindow main)
      {
         InitializeComponent();
         Main = main;
         DB = new SqlDBDataAccess(); 
      }

      private void Oversigt1_Loaded(object sender, RoutedEventArgs e)
      {
         List<string> names = new List<string>(); 
         names = DB.ConnectionTest();

         foreach (var item in names)
         {
            PatienterLB.Items.Add(item); 
         }


      }
   }
}
