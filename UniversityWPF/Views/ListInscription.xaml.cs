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
    /// Lógica de interacción para ListInscription.xaml
    /// </summary>
    public partial class ListInscription : Window
    {
        DataBase.Connection con = new DataBase.Connection();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        Class.Iscription ins = new Class.Iscription();
        ObservableCollection<Class.Iscription> allIns = new ObservableCollection<Class.Iscription>();
        Forms.FormInscription formIns = new Forms.FormInscription();

        public ListInscription()
        {
            InitializeComponent();
            ds = con.ExecuteQueryDS("SelectAllInscription", true, con.ConnectionStringdbUniversity());
            dt.Load(ds.CreateDataReader());
            allIns = ins.getInscription(dt);
            datagridInscription.DataContext = allIns;
            datagridInscription.ItemsSource = allIns;

        }

        


        private void EditarBtn_Click(object sender, RoutedEventArgs e)
        {
            //pasar datos al formulario y guardar
        }

        private void EliminarBtn_Click(object sender, RoutedEventArgs e)
        {
            //cambiar isActive en base de datos
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            formIns.Owner = this;
            formIns.ShowDialog();
        }
    }
}
