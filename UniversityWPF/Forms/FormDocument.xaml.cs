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
using System.Data;

namespace UniversityWPF.Forms
{
    /// <summary>
    /// Lógica de interacción para FormDocument.xaml
    /// </summary>
    public partial class FormDocument : Window
    {
        DataBase.Connection con = new DataBase.Connection();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        public FormDocument(DataTable dt)
        {
            InitializeComponent();
            this.dt = dt;
            dgDoc.ItemsSource = dt.DefaultView;
        }

        private void DgDoc_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Object doc = dgDoc.SelectedItem;
            MessageBox.Show("info: " + doc);

        }
    }
}
