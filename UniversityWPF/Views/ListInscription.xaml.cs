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
        

        public ListInscription()
        {
            InitializeComponent();
            ds = con.ExecuteQueryDS("SelectAllInscription", true, con.ConnectionStringdbUniversity());
            dt.Load(ds.CreateDataReader());
            allIns = ins.getInscription(dt);
            datagridInscription.DataContext = allIns;
            datagridInscription.ItemsSource = allIns;

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            //pasar datos al formulario y guardar
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            //cambiar isActive en base de datos
            try
            {
                ins = (Class.Iscription)datagridInscription.SelectedItem;

                int idI = ins.IdInscription;

                con.AddParameters("@idIscription", idI.ToString(), SqlDbType.BigInt);

                ds = con.ExecuteQueryDS("DeleteInscription", true, con.ConnectionStringdbUniversity());

                if (ds.Tables.Count > 0)
                {
                    dt.Load(ds.CreateDataReader());

                    if (dt.TableName == "Error")
                    {
                        string errors = "";

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            errors = errors + dt.Rows[i].ToString() + "<->";

                        }

                        MessageBox.Show("HA OCURRIDO UN ERROR: " + errors);
                    }
                }
                else
                {

                    ds = con.ExecuteQueryDS("SelectAllInscription", true, con.ConnectionStringdbUniversity());
                    dt.Load(ds.CreateDataReader());
                    allIns = ins.getInscription(dt);
                    datagridInscription.DataContext = allIns;
                    MessageBox.Show("ELIMINACION DE DATOS EXITOSA");
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("HA OCURRIDO ALGO NO ESPERADO: " + ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Forms.FormInscription formIns = new Forms.FormInscription();
            formIns.Owner = this;
            formIns.ShowDialog();
        }

        public void Limpiar()
        {

            con.ClearListParameter();
        }
    }
}
