using System;
using System.Collections.Generic;
using System.Windows;
using Data;
using Projektet;

namespace Projektet_GUI
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      UdlånEKG Udlån;
      IndleverEKG Indlever;
      Oversigt oversigt;


      public MainWindow()
      {
         InitializeComponent();
      }

      private void Window_Loaded(object sender, RoutedEventArgs e)
      {
         Udlån = new UdlånEKG(this);
         Indlever = new IndleverEKG(this);
         oversigt = new Oversigt(this);
      }

      private void ExitM_Click(object sender, RoutedEventArgs e)
      {
         Application.Current.Shutdown();
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

      private void OversigtM_Click_1(object sender, RoutedEventArgs e)
      {
         oversigt.ShowDialog();
      }
   }
}
