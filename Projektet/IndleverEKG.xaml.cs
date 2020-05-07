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
        SqlDBDataAccess DBDataAccess;

        private Patient indleverpatient;
        private Logic logicref;

        

        public IndleverEKG(MainWindow main, Logic logicref)
        {
            InitializeComponent();
            Main = main;
            IDTB.Focus();
            IDTB.SelectAll();
            DBDataAccess = new SqlDBDataAccess();
            this.logicref = logicref;

        }

        private void HentinfoB_Click(object sender, RoutedEventArgs e)
        {
            indleverpatient = logicref.getPatientinfo(Convert.ToInt32(IDTB.Text));

            InfoTB.Text = indleverpatient.EKGID + "         " + indleverpatient.Navn + " " + indleverpatient.Efternavn;
        }

        private void IndleverB_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Er du sikker på du vil indlevere EKG-Måler fra" + indleverpatient.Navn + indleverpatient.Efternavn + "med tilhørende EKDID:" + indleverpatient.EKGID + "?","Advarsel", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:

                    MessageBox.Show("EKG-Måler med EKGID'et" + indleverpatient.EKGID + "er hermed indleveret");
                    logicref.indleverEkgMåler(indleverpatient.CPR, indleverpatient.EKGID);

                    break;

                case MessageBoxResult.No:
                    break;
            }

        }

        private void AnnullerB_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void IDTB_KeyDown(object sender, KeyEventArgs e)
        {

        }


    }

        

}
