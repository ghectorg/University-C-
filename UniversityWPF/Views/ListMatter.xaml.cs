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
using System.Collections.ObjectModel;

namespace UniversityWPF.Views
{
    /// <summary>
    /// Lógica de interacción para ListMatter.xaml
    /// </summary>
    public partial class ListMatter : Window
    {
        DataBase.Connection con = new DataBase.Connection();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        Class.Matter mt = new Class.Matter();
        ObservableCollection<Class.Matter> cursos = new ObservableCollection<Class.Matter>();
        Forms.FormMatter formMt = new Forms.FormMatter();


        public ListMatter()
        {
            InitializeComponent();
            ds = con.ExecuteQueryDS("SelectAllMatter", true, con.ConnectionStringdbUniversity());
            dt.Load(ds.CreateDataReader());
            cursos = mt.getMatter(dt);
            datagridMatter.DataContext = cursos;
            datagridMatter.ItemsSource = cursos;
        }

        private void EditarBtn_Click(object sender, RoutedEventArgs e)
        {
            //pasar info al formulario y guardar cambios despues de editar
        }

        private void EliminarBtn_Click(object sender, RoutedEventArgs e)
        {
            //cambiar isActive a false
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            formMt.Owner = this;
            formMt.ShowDialog();
        }
    }
}
