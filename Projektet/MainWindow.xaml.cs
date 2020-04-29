using System;
using System.Collections.Generic;
using System.Windows;
using Data;

namespace Projektet_GUI
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
   
      SqlDBDataAccess Access;
  

      public MainWindow()
      {
    
         Access = new SqlDBDataAccess(); 
      }
      private void Window_Loaded(object sender, RoutedEventArgs e)
      {

      }

      private void Udlån_EKG_Click(object sender, RoutedEventArgs e)
      {

      }

      private void Indlevering_af_EKG_Click(object sender, RoutedEventArgs e)
      {

      }



      private void Exit_Click(object sender, RoutedEventArgs e)
      {
         Application.Current.Shutdown();
      }

      public List<Person> peoples()
      {
         return null; 
      }

        private void ConnectionB_Click(object sender, RoutedEventArgs e)
        {
         //int i = Access.ConnectionTest();

         //if (i == 1)
         //   Statement.Text = " Den er sku god nok";
         //if (i == 2)
         //   Statement.Text = " Prøv igen makker"; 

        }

      private void patientoversigt_Click(object sender, RoutedEventArgs e)
      {

      }
   }
}
