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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace exoXp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void saisieDate_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void calcul(int jour, int mois, int annee)
        {
            int[] tabMonth = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            string[] tabJour = new string[] { "Dimanche", "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi" };
            int numberDay = 0;
            int nbBisextil = (int)Math.Floor((decimal)(annee / 4));
            int nbBisextilQC = (int)Math.Floor((decimal)(annee / 400));
            int nbBisextilC = (int)Math.Floor((decimal)(annee / 100));
            numberDay = (annee - 1) * 365 + (nbBisextil - nbBisextilC + nbBisextilQC);
            if(mois > 2)
            {
                numberDay++;
            }
            for(int i=0;i < (mois-1);i++)
            {
                numberDay = numberDay + tabMonth[i];
            }
            for(int j=1;j<jour; j++)
            {
                numberDay++;
            }
            resultatCalcul.Text = tabJour[(numberDay % 7)].ToString();
        }

        private void buttonCalcul_Click_1(object sender, RoutedEventArgs e)
        {
            this.calcul(5, 6, 2017);
        }

        private void verificationAutomatique()
        {
            string[] tabJour = new string[] { "Dimanche", "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi" };
            DateTime an = new DateTime(1, 1, 1);
            int annee;
            int mois;
            int jour;
            DateTime date = new DateTime(2017, 6, 5);
            TimeSpan diff = date - an;
            int total = (int)diff.TotalDays + 1;
            resultatVerif.Text = tabJour[(total % 7)].ToString();
        }

        private void buttonVerif_Click(object sender, RoutedEventArgs e)
        {
            this.verificationAutomatique();
        }
    }
}
