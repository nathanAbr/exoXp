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
            int numberDay = 0;
            int nbBisextil = (int)Math.Floor((double)(annee / 4));
            int nbBisextilQC = (int)Math.Floor((double)(2017 / 400));
            int nbBisextilC = (int)Math.Floor((double)(2017 / 100));
            numberDay = (annee - 1) * 365 + (nbBisextil - nbBisextilC + nbBisextilQC);
            int i = 1;
            if(mois > 2)
            {
                numberDay++;
            }
            while(i < mois)
            {
                numberDay = numberDay + tabMonth[i];
                i++;
            }
            for(int j=1;j<=jour; j++)
            {
                numberDay++;
            }
            resultatCalcul.Text = numberDay.ToString();
        }

        private void verificationAutomatique()
        {
            DateTime an = new DateTime(1, 1, 1);
            DateTime date = new DateTime(this.annee, this.mois, this.jour);
            TimeSpan diff = date - an;
            int total = (int)diff.TotalDays;
            resultatVerifie.Text = total.ToString();
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
