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


        public ListMatter()
        {
            InitializeComponent();
            ds = con.ExecuteQueryDS("SelectAllMatter", true, con.ConnectionStringdbUniversity());
            dt.Load(ds.CreateDataReader());
            cursos = mt.getMatter(dt);
            datagridMatter.DataContext = cursos;
            
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            //pasar info al formulario y guardar cambios despues de editar
            mt = (Class.Matter)datagridMatter.SelectedItem;
            Forms.FormMatter formMt = new Forms.FormMatter(mt.IdMatter, mt.Name, mt.Description);
            formMt.Owner = this;
            formMt.ShowDialog();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            //cambiar isActive a false

            try
            {
                mt = (Class.Matter)datagridMatter.SelectedItem;

                int idM = mt.IdMatter;

                con.AddParameters("@idDocumentType", idM.ToString(), SqlDbType.BigInt);

                ds = con.ExecuteQueryDS("DeleteMatter", true, con.ConnectionStringdbUniversity());

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

                    ds = con.ExecuteQueryDS("SelectAllDocuments", true, con.ConnectionStringdbUniversity());
                    dt.Load(ds.CreateDataReader());
                    cursos = mt.getMatter(dt);
                    datagridMatter.DataContext = cursos;
                    MessageBox.Show("ELIMINACION DE DATOS EXITOSA");
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("HA OCURRIDO ALGO NO ESPERADO: " + ex.Message);
            }
        }

        private void CrearButton_Click(object sender, RoutedEventArgs e)
        {
            Forms.FormMatter formMt = new Forms.FormMatter();
            formMt.Owner = this;
            formMt.ShowDialog();
        }

        public void Limpiar()
        {

            con.ClearListParameter();
        }
    }
}
