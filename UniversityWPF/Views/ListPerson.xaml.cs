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
using System.Collections.ObjectModel;

namespace UniversityWPF.Views
{
    /// <summary>
    /// Lógica de interacción para ListPerson.xaml
    /// </summary>
    public partial class ListPerson : Window
    {
        DataBase.Connection con = new DataBase.Connection();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        Class.Person person = new Class.Person();
        ObservableCollection<Class.Person> persons = new ObservableCollection<Class.Person>();
        Forms.FormPerson formPerson = new Forms.FormPerson();

        public ListPerson()
        {
            InitializeComponent();
            ds = con.ExecuteQueryDS("SelectAllPerson", true, con.ConnectionStringdbUniversity());
            dt.Load(ds.CreateDataReader());
            persons = person.getPerson(dt);
            datagridPerson.DataContext = persons;
            datagridPerson.ItemsSource = persons;
        }

        private void EditarBtn_Click(object sender, RoutedEventArgs e)
        {
            //pasar todos los datos al formulario y se efectuen los cambios y guardar
        }

        private void EliminarBtn_Click(object sender, RoutedEventArgs e)
        {
            //cambiar is active a falso, en base de datos y programa
        }


        private void CrearBtn_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Si funcionan los botones ene l combo box");
            
            formPerson.Owner = this;
            formPerson.ShowDialog();
        }
    }
}
