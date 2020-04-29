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
using Projektet_GUI;

namespace Projektet
{
    /// <summary>
    /// Interaction logic for Oversigt.xaml
    /// </summary>
    public partial class Oversigt : Window
    {
        MainWindow Main;
        public Oversigt(MainWindow main)
        {
            InitializeComponent();
            Main = main;
        }

        private void Oversigt1_Loaded(object sender, RoutedEventArgs e)
        {
            LedigeLB.Items.Add(1011);
            LedigeLB.Items.Add(1012);
            LedigeLB.Items.Add(1013);
            LedigeLB.Items.Add(1014);

            for (int i = 0; i < 5; ++i)
            {
                foreach (PatientUdlån patient in Main.patient)
                    if (patient.EKG_ID == 1 + i)
                        LedigeLB.Items.Remove(1 + i);
                UdlånteLB.Items.Add(1 + i);
            }
        }
    }
}
