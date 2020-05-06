using System;
using System.Collections.Generic;
using System.Windows;
using Data;
using Projektet;
using LogicLayer;

namespace Projektet_GUI
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      UdlånEKG Udlån;
      IndleverEKG Indlever;
        Logic logicobj;


     

      public MainWindow()
      {
         InitializeComponent();
            logicobj = new Logic();
      }

      private void Window_Loaded(object sender, RoutedEventArgs e)
      {
         Udlån = new UdlånEKG(this, logicobj);
         Indlever = new IndleverEKG(this, logicobj);
         
      }

      private void PatintovM_Click(object sender, RoutedEventArgs e)
      {

      }

      private void IndleverEkgM_Click_1(object sender, RoutedEventArgs e)
      {
         Indlever.ShowDialog();
      }

      private void UdlånEkgM_Click_1(object sender, RoutedEventArgs e)
      {
         Udlån.ShowDialog();
      }

     

      private void EKG_program_Closed(object sender, EventArgs e)
      {
         Application.Current.Shutdown();
      }

      private void ExitM_Click(object sender, RoutedEventArgs e)
      {
         Application.Current.Shutdown();
      }
   }
}
