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
using Projektet_GUI;
using DTO; 

namespace Projektet
{
   /// <summary>
   /// Interaction logic for Oversigt.xaml
   /// </summary>
   public partial class Oversigt : Window
   {
      MainWindow Main;

      SqlDBDataAccess DBDataAccess;

      private List<EKG> EKGmaalereListe;

      public Oversigt(MainWindow main)
      {
         InitializeComponent();
         Main = main;
         DBDataAccess = new SqlDBDataAccess();
      }

      private void Oversigt1_Loaded(object sender, RoutedEventArgs e)
      {
         EKGmaalereListe = DBDataAccess.EKGMålere();

         foreach (EKG item in EKGmaalereListe)
         {
            if (item.Availiable == true)
            {
               LedigeLB.Items.Add(item.EKGID); 
            }
            else
            {
               UdlånteLB.Items.Add(item.EKGID);
            }
               
         }

      }
   }
}
