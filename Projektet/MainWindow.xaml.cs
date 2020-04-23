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
      
  

      public MainWindow()
      {
         InitializeComponent();
      }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ExitM_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

      

        private void UdlånEkgM_Click(object sender, RoutedEventArgs e)
        {

        }

        private void IndleverEkgM_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OversigtM_Click(object sender, RoutedEventArgs e)
        {

        }

     
    }
}
