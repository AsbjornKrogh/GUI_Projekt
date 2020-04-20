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

      private List<Person> people;
      private List<PatientUdlån> patient;
      Person patient1 = new Person(2502950000, "Ditte", "Eskildsen", "Holdevej 47", new Dato(1, 3, 1997));
      Person patient2 = new Person(2509970000, "Ditte", "Eskildsen", "Holdevej 47", new Dato(1, 3, 1997));
      Person patient3 = new Person(2008951234, "Rikke", "Laugesen", "Kaserneboulevarden 31 3.", new Dato(20, 8, 1995));

      public Patient_udlån(MainWindow main)
      {
         InitializeComponent();
         Main = main;
         patient = new List<PatientUdlån>(); 
         people = new List<Person>();
         people.Add(patient1);
         people.Add(patient2);
         people.Add(patient3);
      }

  

      private void Submit_Click(object sender, RoutedEventArgs e)
      {
         MessageBoxResult result = MessageBox.Show("Er du sikker på du vil udlåne EKG-måler " + EKGmåler.SelectedItem + " til " + NavnTB.Text, "Advarsel", MessageBoxButton.YesNo, MessageBoxImage.Warning);
         switch (result)
         {
            case MessageBoxResult.Yes:
               Main.patient.Add(new PatientUdlån(Convert.ToInt64(cprTB.Text), NavnTB.Text, EfternavnTB.Text, "Mangle", new Dato(Convert.ToInt32(dag.Text), Convert.ToInt32(månTB.Text), Convert.ToInt32(årTB.Text)), DateTime.Now, Convert.ToInt32(EKGmåler.SelectedItem), Årsag.Text));
               MessageBox.Show("EKG måler med ID: " + EKGmåler.SelectedItem + "er udlånt til " + NavnTB.Text, "Udlån", MessageBoxButton.OK, MessageBoxImage.Information); 
               Close();
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
         people = sqliteDataAccess.GetPeople();
      }

   

         private void cprTB_KeyDown(object sender, KeyEventArgs e)
         {
            if (e.Key == Key.Return)
            {
               foreach (Person person in people)
               {
               if (Convert.ToInt64(cprTB.Text) == person.CPR)
               {
                  NavnTB.Text = person.Navn;
                  EfternavnTB.Text = person.Efternavn;
                  dag.Text = Convert.ToString(person.Fødselsdato.Dag);
                  månTB.Text = Convert.ToString(person.Fødselsdato.Måned);
                  årTB.Text = Convert.ToString(person.Fødselsdato.År);
               }
           
               }
            }
         }

         private void EKGmåler_Loaded(object sender, RoutedEventArgs e)
         {

         EKGmåler.Items.Add(1011);
         EKGmåler.Items.Add(1012);
         EKGmåler.Items.Add(1013);
         EKGmåler.Items.Add(1014);

         for (int i = 0; i < 5; ++i)
         {
            foreach (PatientUdlån patient in Main.patient)
               if (patient.EKG_ID == 1010 + i)
                  EKGmåler.Items.Remove(1010 + i);
           }

         }


      
   }
}
