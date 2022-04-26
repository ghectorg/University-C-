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
using System.Data.SqlClient;

namespace UniversityWPF.Views
{
    /// <summary>
    /// Lógica de interacción para ListDocument.xaml
    /// </summary>
    public partial class ListDocument : Window
    {
        DataBase.Connection con = new DataBase.Connection();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        public ListDocument()
        {
            InitializeComponent();
        }

        private void MostrarBtn_Click(object sender, RoutedEventArgs e)
        {
            ds = con.ExecuteQueryDS("SelectAllDocuments", true, con.ConnectionStringdbUniversity());
            dt.Load(ds.CreateDataReader());
            datagridDocuments.ItemsSource = dt.DefaultView;
            
        }

        private void EdicionBtn_Click(object sender, RoutedEventArgs e)
        {
            Forms.FormDocument view1 = new Forms.FormDocument(dt);
            view1.Owner = this;
            view1.ShowDialog();
        }
    }
}
