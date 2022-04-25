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
using System.Data.SqlClient;
using System.Data;

namespace UniversityWPF.Views
{
    /// <summary>
    /// Lógica de interacción para ListPerson.xaml
    /// </summary>
    public partial class ListPerson : Window
    {
        public ListPerson()
        {
            InitializeComponent();
        }

        private void MostrarBtn_Click(object sender, RoutedEventArgs e)
        {
            DataBase.Connection con = new DataBase.Connection();
            DataSet ds = new DataSet();
            ds = con.ExecuteQueryDS("SelectAllPerson", true, con.ConnectionStringdbUniversity());
            DataTable dt = new DataTable();
            dt.Load(ds.CreateDataReader());
            datagridPerson.ItemsSource = dt.DefaultView;
        }
    }
}
