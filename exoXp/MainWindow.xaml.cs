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
            int jour;
            int mois;
            int annee;
            
            textSaisie = saisieDate.Text.ToString();

            jour = Int32.Parse(textSaisie.Substring(0, 2));
            mois = Int32.Parse(textSaisie.Substring(3, 2));
            annee = Int32.Parse(textSaisie.Substring(6, 4));
        }
    }
}
