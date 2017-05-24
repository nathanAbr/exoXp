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
        private int jour;
        private int mois;
        private int annee;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void saisieDate_KeyPressed(object sender, TextChangedEventArgs e)
        {

            int nb = saisieDate.Text.Length;
            if (nb == 2)
            {
                saisieDate.Text += "/";
                saisieDate.Focus();
                saisieDate.SelectionStart = saisieDate.Text.Length;
            }
            if (nb == 5)
            {
                saisieDate.Text += "/";
                saisieDate.Focus();
                saisieDate.SelectionStart = saisieDate.Text.Length;
            }
        }
        private void buttonCalcul_Click(object sender, RoutedEventArgs e)
        {
            string textSaisie;    
            textSaisie = saisieDate.Text.ToString();

            this.jour = Int32.Parse(textSaisie.Substring(0, 2));
            this.mois = Int32.Parse(textSaisie.Substring(3, 2));
            this.annee = Int32.Parse(textSaisie.Substring(6, 4));

            this.calcul(jour, mois, annee);
        }

        private void calcul(int jour, int mois, int annee)
        {
            int[] tabMonth = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            string[] tabJour = new string[] { "Dimanche", "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi" };
            int numberDay = 0;
            int nbBisextil = annee / 4;
            int nbBisextilQC = annee / 400;
            int nbBisextilC = annee / 100;
            if (annee > 1)
            {
                numberDay = (annee - 1) * 365 + (nbBisextil - nbBisextilC + nbBisextilQC);
            }
            if ((annee % 4) == 0 && mois > 2 && (annee % 100) != 0)
            {
                numberDay++;
            }
            else if((annee % 400) == 0)
            {
                numberDay++;
            }
            for (int i=0;i < (mois-1);i++)
            {
                numberDay = numberDay + tabMonth[i];
            }
            for(int j=0;j<jour; j++)
            {
                numberDay++;
            }
            resultatCalcul.Text = tabJour[(numberDay % 7)].ToString();
            this.paque(this.annee);
        }

        private void paque(int year)
        {
            int Y = year;
            int a = Y % 19;
            int b = Y / 100;
            int c = Y % 100;
            int d = b / 4;
            int e = b % 4;
            int f = (b + 8) / 25;
            int g = (b - f + 1) / 3;
            int h = (19 * a + b - d - g + 15) % 30;
            int i = c / 4;
            int k = c % 4;
            int L = (32 + 2 * e + 2 * i - h - k) % 7;
            int m = (a + 11 * h + 22 * L) / 451;
            int month = (h + L - 7 * m + 114) / 31;
            int day = ((h + L - 7 * m + 114) % 31) + 1;
            
            DateTime dt = new DateTime(year, month, day);
            DateTime dtA = dt.AddDays(39);
            DateTime dtP = dt.AddDays(49);

            resultatPaques.Text = dt.ToString();
            resultatAscension.Text = dtA.ToString();
            resultatPentecote.Text = dtP.ToString();
        }

        private void verificationAutomatique()
        {
            string[] tabJour = new string[] { "Dimanche", "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi" };
            DateTime an = new DateTime(1, 1, 1);
            DateTime date = new DateTime(this.annee, this.mois, this.jour);
            TimeSpan diff = date - an;

            int total = (int)diff.TotalDays + 1;
            resultatVerifie.Text = tabJour[(total % 7)].ToString();

        }

        private void buttonVerif_Click(object sender, RoutedEventArgs e)
        {
            this.verificationAutomatique();
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            saisieDate.Text = "";
        }
    }
}
