using Projektet_GUI;
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
using LogicLayer;


namespace Projektet
{
    /// <summary>
    /// Interaction logic for UdlånEKG.xaml
    /// </summary>
    public partial class UdlånEKG : Window
    {
       private  MainWindow Main;

        private List<EKG> EKGmaalereListe;
        private Patient person;
        private Logic logicref;

        public UdlånEKG(MainWindow main, Logic logicref)
        {
            InitializeComponent();
            Main = main;
            this.logicref = logicref;
        }


        private void UdlånB_Click(object sender, RoutedEventArgs e)
        {
            if (CPRTB.Text != null && NavnTB.Text != null && EfterNavnTB.Text != null && FødselsdagTB.Text != null && EKGmålerId.SelectedItem != null)
            {
                byte besked;
                MessageBoxResult result = MessageBox.Show("Er du sikker på at vil udlåne EKG-måler " + EKGmålerId.SelectedItem + " til " + NavnTB.Text, "Advarsel", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                switch (result)
                {
                    case MessageBoxResult.Yes:
                        besked = logicref.getudlånBesked(CPRTB.Text, NavnTB.Text, EfterNavnTB.Text, Convert.ToInt32(EKGmålerId.SelectedItem));
                        if (besked == 2)
                            MessageBox.Show("Patienten er oprettet og EKG måler " + EKGmålerId.SelectedItem + " udlånt");
                        if (besked == 1)
                            MessageBox.Show("Patienten findes allerede i databasen og har fået EKG måler " + EKGmålerId.SelectedItem + " tildelt");
                        break;

                    case MessageBoxResult.No:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Ikke alle felter er udfyldt");

            }
            
        }

        private void AnnullerB_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Udlån af EKG-måler er hermed annulleret");
            this.Close();
        }


        private void HentInfoB_Click(object sender, RoutedEventArgs e)
        {
            Patient patient2 = logicref.getCPR(CPRTB.Text);

            if (patient2.EKGID != 0)
            {
                MessageBox.Show("Denne patient har allerede tilknyttet en EKG-måler");
                this.Close();
            }

            EKGmålerId.Items.Clear();
            Patient patient = logicref.getCPR(CPRTB.Text);
            NavnTB.Text = patient.Navn;
            EfterNavnTB.Text = patient.Efternavn;
            FødselsdagTB.Text = patient.CPR;

            EKGmaalereListe = logicref.getEKGMålere();
            foreach (EKG item in EKGmaalereListe)
            {
                if (item.Availiable == true)
                {
                    EKGmålerId.Items.Add(item.EKGID);
                }
            }
        }

    }

}
