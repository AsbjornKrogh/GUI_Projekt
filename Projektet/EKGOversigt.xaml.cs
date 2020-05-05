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
using DTO;

namespace Projektet
{
    /// <summary>
    /// Interaction logic for EKGOversigt.xaml
    /// </summary>
    public partial class EKGOversigt : Window
    {
        public EKGOversigt()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //adgang til EGKPatient hvor der skal hentes navne og efternavn. 
            // Ansvarliges fornavn, efternavn og medarbejder nummer udfyldes automatisk (default)
        }

        private void GemB_Click(object sender, RoutedEventArgs e)
        {
            //uploadet alle informationer
        }

        // eventhandler for et item er valgt i patientLB
        // adgang til EKGPatient hvor vi henter dato for alle miloinger for den pågældende patient og lægger det ind i DatoLB

        // Eventhandler for et item er valgt i DatoLB.
        // EKG-målingen, cpr, patient beskrivelse vises.




    }
}
