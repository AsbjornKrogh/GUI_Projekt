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
    /// Interaction logic for IndleverEKG.xaml
    /// </summary>
    public partial class IndleverEKG : Window
    {
        MainWindow Main;

        private Patient indleverpatient;
        private Logic logicref;

        

        public IndleverEKG(MainWindow main, Logic logicref)
        {
            InitializeComponent();
            Main = main;
            this.logicref = logicref;

            IDTB.Focus();
            IDTB.SelectAll();
        }

        private void HentinfoB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                indleverpatient = logicref.getPatientinfo(Convert.ToInt32(IDTB.Text));

                InfoTB.Text = indleverpatient.EKGID + "              " + indleverpatient.Navn + " " + indleverpatient.Efternavn;
            }
            catch 
            {

                MessageBox.Show("Det indtastede EKG-ID er ugyldigt");
            }

        }

        private void IndleverB_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Er du sikker på du vil indlevere EKG-Måler fra " + indleverpatient.Navn + " " + indleverpatient.Efternavn + " med tilhørende EKG ID: " + indleverpatient.EKGID + "?","Advarsel", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:

                    MessageBox.Show("EKG-Måler med EKGID'et " + indleverpatient.EKGID + " er hermed indleveret");
                    logicref.indleverEkgMåler(indleverpatient.CPR, indleverpatient.EKGID);
                    this.Close();
                    break;

                case MessageBoxResult.No:
                    break;
            }

        }

        private void AnnullerB_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Indlevering annulleret");
            this.Close();
        }


    }

        

}
