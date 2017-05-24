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

        private void calcul(int jour, int mois, int annee)
        {
            int[] tabMonth = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int numberDay = 0;
            int nbBisextil = annee / 4;
            numberDay = (annee - 1) * 365 + nbBisextil;
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
            for(i=1;i<=jour; i++)
            {
                numberDay++;
            }
            resultatCalcul.Text = numberDay.ToString();

        }

        private void buttonCalcul_Click_1(object sender, RoutedEventArgs e)
        {
            this.calcul(24, 05, 2017);
        }

        public static verificationAutomatique()
        {

        }
    }
}
