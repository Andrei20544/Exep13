using Second.view;
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

namespace Second
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IllnessWin illnessWin = new IllnessWin();
            illnessWin.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PositionsWin positionsWin = new PositionsWin();
            positionsWin.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MedicinesWin medicinesWin = new MedicinesWin();
            medicinesWin.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            PatientsWin patientsWin = new PatientsWin();
            patientsWin.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            StaffWin staffWin = new StaffWin();
            staffWin.Show();
        }
    }
}
