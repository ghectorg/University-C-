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
using System.Collections.ObjectModel;

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
        Class.Document dc = new Class.Document();
        ObservableCollection<Class.Document> documents = new ObservableCollection<Class.Document>();
        Forms.FormDocument formDoc = new Forms.FormDocument();

        public ListDocument()
        {
            InitializeComponent();
            ds = con.ExecuteQueryDS("SelectAllDocuments", true, con.ConnectionStringdbUniversity());
            dt.Load(ds.CreateDataReader());
            documents = dc.getDocument(dt);
            datagridDocuments.DataContext = documents;
            datagridDocuments.ItemsSource = documents;
        }

        private void EditarBtn_Click(object sender, RoutedEventArgs e)
        {
            //enviar datos al formulario para editar y guardar cambios
        }


        private void EliminarBtn_Click(object sender, RoutedEventArgs e)
        {
            //cambiar en la base de datos isActive
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            formDoc.Owner = this;
            formDoc.ShowDialog();
        }
    }
}
