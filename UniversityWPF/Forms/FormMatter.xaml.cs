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

namespace UniversityWPF.Forms
{
    /// <summary>
    /// Lógica de interacción para FormMatter.xaml
    /// </summary>
    public partial class FormMatter : Window
    {
        DataBase.Connection con = new DataBase.Connection();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        Class.Matter mt = new Class.Matter();
        ObservableCollection<Class.Matter> cursos = new ObservableCollection<Class.Matter>();

        private int idMatter;
        public int IdMatter
        {
            get { return idMatter; }
            set { idMatter = value; }
        }
        private string name;
        private string description;
        private bool isActive = true;

        public FormMatter()
        {
            InitializeComponent();
        }

        public FormMatter(int id, string name, string descrip)
        {
            InitializeComponent();
            IdMatter = id;
            name_txt.Text = name;
            description_txt.Text = descrip;
            MessageBox.Show("CAMBIAR LOS CAMPOS QUE DESEA MODIFICAR Y HACER CLICK AL BOTON EDITAR");
        }

        private void CrearBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (name_txt.Text == "") {

                    MessageBox.Show("DEBE COMPLETAR TODOS LOS CAMPOS | NOMBRE ES OBLIGATORIO");

                }
                else
                {
                    IdMatter = -1;
                    name = name_txt.Text;
                    description = description_txt.Text;

                    con.AddParameters("@idDocumentType", IdMatter.ToString(), SqlDbType.BigInt);
                    con.AddParameters("@name", name, System.Data.SqlDbType.VarChar);
                    con.AddParameters("@description", description, System.Data.SqlDbType.VarChar);
                    con.AddParameters("@isActive", isActive.ToString(), System.Data.SqlDbType.Bit);

                    ds = con.ExecuteQueryDS("EditAndCreateMatter", true, con.ConnectionStringdbUniversity());
                    //VALIDAR RETURN SI ES LISTA DE ERRORES

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

                            Limpiar();

                        }

                    }
                    else
                    {
                        MessageBox.Show("EDICION DE DATOS EXITOSA");

                        Limpiar();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("HA PASADO ALGO QUE NO DEBIA " + ex.Message);
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
   
            try
            {
                if (name_txt.Text == "")
                {
                    MessageBox.Show("DEBE COMPLETAR TODOS LOS CAMPOS | NOMBRE ES OBLIGATORIO");

                }
                else
                {
                    name = name_txt.Text;
                    description = description_txt.Text;

                    con.AddParameters("@idMatter", IdMatter.ToString(), SqlDbType.BigInt);
                    con.AddParameters("@name", name, System.Data.SqlDbType.VarChar);
                    con.AddParameters("@description", description, System.Data.SqlDbType.VarChar);
                    con.AddParameters("@isActive", isActive.ToString(), System.Data.SqlDbType.Bit);

                    ds = con.ExecuteQueryDS("EditAndCreateMatter", true, con.ConnectionStringdbUniversity());
                    //VALIDAR RETURN SI ES LISTA DE ERRORES

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

                            Limpiar();

                        }

                    }
                    else
                    {
                        MessageBox.Show("CARGAR DE DATOS EXITOSA");

                        Limpiar();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("HA PASADO ALGO QUE NO DEBIA " + ex.Message);
            }
        }

        public void Limpiar()
        {
            
            name_txt.Text = "";
            description_txt.Text = "";
            con.ClearListParameter();
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
    }
}
