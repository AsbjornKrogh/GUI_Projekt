﻿using Projektet_GUI;
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
        MainWindow Main;
        SqlDBDataAccess DBDataAccess;

        private List<EKG> EKGmaalereListe;
        private Patient person;
        private Logic logicref;

        public UdlånEKG(MainWindow main, Logic logicref)
        {
            this.logicref = logicref;
            InitializeComponent();
            Main = main;

            DBDataAccess = new SqlDBDataAccess();


        }

        private void Udlån_Loaded(object sender, RoutedEventArgs e)
        {
            logicref.getEKGMålere();
            foreach (EKG item in EKGmaalereListe)
            {
                if (item.Availiable == true)
                {
                    EKGmålerId.Items.Add(item.EKGID);
                }
            }

        }

        private void UdlånB_Click(object sender, RoutedEventArgs e)
        {
            byte besked;
            MessageBoxResult result = MessageBox.Show("Er du sikker på at vil udlåne EKG-måler " + EKGmålerId.SelectedItem + " til " + NavnTB.Text, "Advarsel", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    besked = logicref.getudlånBesked(CPRTB.Text, NavnTB.Text, EfterNavnTB.Text, Convert.ToInt32(EKGmålerId.SelectedItem));
                    if (besked == 2)
                        MessageBox.Show("Patienten oprettet og EKG måler " + EKGmålerId.SelectedItem + "udlånt");
                    if (besked == 1)
                        MessageBox.Show("Patienten findes allerede i DB og har fået EKG måler " + EKGmålerId.SelectedItem + "udlånt");
                    break;

                case MessageBoxResult.No:
                    break;
            }
        }

        private void AnnullerB_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CPRTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                person = logicref.getCPR(CPRTB.Text);

                NavnTB.Text = person.Navn;
                EfterNavnTB.Text = person.Efternavn;
                FødselsdagTB.Text = Convert.ToString(person.CPR);
            }
        }

        private void EKGmåler_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void HentInfoB_Click(object sender, RoutedEventArgs e)
        {
            logicref.getEKGMålere();
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
