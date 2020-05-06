﻿using System;
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
    /// Interaction logic for EKGOversigt.xaml
    /// </summary>
    public partial class EKGOversigt : Window
    {
        private List<Patient> PatientListe;
        private Logic logicref;
        private List<EKG_Maaling> MaalingListe;
        public EKGOversigt(Logic logicref)
        {
            InitializeComponent();
            this.logicref = logicref;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PatientListe = logicref.getPatientListe();
            foreach (Patient item in PatientListe)
            {
                
                PatientLB.Items.Add(item.Navn); //HJÆLP!
            }

            fnTB.Text = "Søren";
            EfTB.Text = "Pedersen";
            MedarnrTB.Text = "12435687";
        }

        private void GemB_Click(object sender, RoutedEventArgs e)
        {
            logicref.gemIoffentligDatabase("", Convert.ToDateTime(DatoLB.SelectedItem), "", fnTB.Text, EfTB.Text, Convert.ToInt32(MedarnrTB.Text), orgTB.Text, KommentarTB.Text, "", "", PatientInfoTB.Text, PatCprTB.Text);
            //uploadet alle informationer til EGKmålinger og EKGData (offentlige)
        }

        


        private void PatientLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //cpr, patient beskrivelse vises.
            MaalingListe = logicref.getMaalingListe(PatCprTB.Text);
            foreach (EKG_Maaling item in MaalingListe)
            {
                DatoLB.Items.Add(item.DateTime);
            }
        }

        
        private void DatoLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // EKG-målingen vises.
        }

    }
    
}
