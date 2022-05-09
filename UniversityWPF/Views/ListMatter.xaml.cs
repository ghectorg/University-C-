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
            Forms.FormMatter formMt = new Forms.FormMatter(mt.IdMatter, mt.Name, mt.Description, mt.IsActive);
            formMt.Owner = this;
            formMt.Show();
            formMt.Closed += new EventHandler(CloseFormMatter);

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            //cambiar isActive a false

            try
            {
                Limpiar();

                mt = (Class.Matter)datagridMatter.SelectedItem;

                int idM = mt.IdMatter;

                con.AddParameters("@id", idM.ToString(), SqlDbType.BigInt);

                ds = con.ExecuteQueryDS("DeleteMatter", true, con.ConnectionStringdbUniversity());

                if (ds.Tables.Count > 0)
                {
                    dt.Load(ds.CreateDataReader());

                    if (dt.TableName == "Error")
                    {
                        string errors = "";

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            errors = errors + i.ToString() + "<->" + dt.Rows[i]["messageError"] + "\n";

                        }

                        MessageBox.Show("Se detectaron los siguientes errores: " + errors, "Crear. Error en consulta a Base de Datos");
                    }
                }
                else
                {
                    Limpiar();

                    ds = con.ExecuteQueryDS("SelectAllMatter", true, con.ConnectionStringdbUniversity());
                    dt.Clear();

                    dt.Load(ds.CreateDataReader());
                    cursos = mt.getMatter(dt);
                    datagridMatter.DataContext = cursos;
                    MessageBox.Show("Eliminación de datos exitosa!", "Eliminar");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha sucedido el siguiente error: " + ex.Message, "Eliminar");
                Limpiar();

            }
        }

        private void CrearButton_Click(object sender, RoutedEventArgs e)
        {
            Forms.FormMatter formMt = new Forms.FormMatter();
            formMt.Owner = this;
            formMt.Show();
            formMt.Closed += new EventHandler(CloseFormMatter);

        }

        public void Limpiar()
        {

            con.ClearListParameter();
        }

        void CloseFormMatter(object sender, EventArgs e)
        {
            this.InitializeComponent();
            ds = con.ExecuteQueryDS("SelectAllMatter", true, con.ConnectionStringdbUniversity());
            dt.Clear();
            dt.Load(ds.CreateDataReader());
            cursos = mt.getMatter(dt);
            datagridMatter.DataContext = cursos;
        }

        private void BuscarBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dt.Clear();
                con.AddParameters("@id", "-1", SqlDbType.BigInt);
                con.AddParameters("@name", nameSearch_txt.Text, SqlDbType.VarChar);
                ds = con.ExecuteQueryDS("SelectAllMatter", true, con.ConnectionStringdbUniversity());

                if (ds.Tables.Count > 0)
                {
                    dt.Load(ds.CreateDataReader());

                    if (dt.TableName == "Error")
                    {
                        string errors = "";

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            errors = errors + i.ToString() + "<->" + dt.Rows[i]["messageError"] + "\n";

                        }

                        MessageBox.Show("Se detectaron los siguientes errores: " + errors, "Crear. Error en consulta a Base de Datos");
                        Limpiar();

                    }

                    else
                    {

                        cursos = mt.getMatter(dt);
                        if (cursos.Count == 0)
                        {
                            MessageBox.Show("No existe el curso con el nombre que ha ingresado.", "Buscar");
                            Limpiar();
                            nameSearch_txt.Text = "";
                        }
                        else
                        {
                            datagridMatter.DataContext = cursos;
                            Limpiar();
                            nameSearch_txt.Text = "";
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha sucedido el siguiente error: " + ex.Message, "Buscar");
                Limpiar();
            }
        }
    }
}
