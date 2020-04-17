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
      Patient_udlån Udlån;
      EKG_Indlevering Indlevering;
     // Patientoversigt

      public List<Person> people;
      public List<PatientUdlån> patient;

      PatientUdlån patient0 = new PatientUdlån(0000000000, "NN", "NN", "´NN", new Dato(1, 1, 2000), DateTime.Now, 0000, "NN");
      Person patient1 = new Person(0103970000, "Ditte", "Eskildsen", "Holdevej 47", new Dato(1, 3, 1997));
      Person patient2 = new Person(2509970000, "Ditte", "Eskildsen", "Holdevej 47", new Dato(25, 9, 1997));
      Person patient3 = new Person(2503980000, "Ditte", "Eskildsen", "Holdevej 47", new Dato(1, 3, 1997));


      public MainWindow()
      {
         InitializeComponent();
         patient = new List<PatientUdlån>();
         people = new List<Person>();

         patient.Add(patient0); people.Add(patient1); people.Add(patient2); people.Add(patient3);

      }
      private void Window_Loaded(object sender, RoutedEventArgs e)
      {
         Udlån = new Patient_udlån(this);
         Indlevering = new EKG_Indlevering(this);
      }

      private void Udlån_EKG_Click(object sender, RoutedEventArgs e)
      {
         Udlån = new Patient_udlån(this);
         Udlån.Show();
      }

      private void Indlevering_af_EKG_Click(object sender, RoutedEventArgs e)
      {
         Indlevering = new EKG_Indlevering(this);
         Indlevering.Show();
      }

      private void Exit_Click(object sender, RoutedEventArgs e)
      {
         Application.Current.Shutdown();
      }

      public List<Person> peoples()
      {
         return people;
      }


   }
}
