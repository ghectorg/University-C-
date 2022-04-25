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

namespace UniversityWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PersonBtn_Click(object sender, RoutedEventArgs e)
        {
            Views.ListPerson view1 = new Views.ListPerson();
            view1.Owner = this;
            view1.ShowDialog();
        }

        private void DocumentBtn_Click(object sender, RoutedEventArgs e)
        {
            Views.ListDocument view1 = new Views.ListDocument();
            view1.Owner = this;
            view1.ShowDialog();

        }

        private void MatterBtn_Click(object sender, RoutedEventArgs e)
        {
            Views.ListMatter view1 = new Views.ListMatter();
            view1.Owner = this;
            view1.ShowDialog();
        }

        private void InscriptionBtn_Click(object sender, RoutedEventArgs e)
        {
            Views.ListInscription view1 = new Views.ListInscription();
            view1.Owner = this;
            view1.ShowDialog();
        }
    }
}
