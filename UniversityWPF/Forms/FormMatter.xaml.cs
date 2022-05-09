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
            EditBtn.Visibility = System.Windows.Visibility.Collapsed;
        }

        public FormMatter(int id, string name, string descrip, bool isActiv)
        {
            InitializeComponent();
            IdMatter = id;
            name_txt.Text = name;
            description_txt.Text = descrip;
            isActivo_Check.IsChecked = isActive;

            CrearBtn.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void CrearBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (name_txt.Text == "") {

                    MessageBox.Show("Los siguientes campos son obligatorios: Nombre. Por favor, complete los campos que le faltan.",
                        "Crear. Error! Campos incompletos.");

                }
                else
                {
                    IdMatter = -1;
                    name = name_txt.Text;
                    description = description_txt.Text;
                    isActive = (bool) isActivo_Check.IsChecked;

                    if (!ValidateData(name))
                    {
                        MessageBox.Show("Ha surgido un error con sus datos ingresados. Intentelo nuevamente." +
                       "Tenga en cuenta que: nombre deben tener menos de 63 caracteres",
                       "Validación. Error en campos");
                        Limpiar();
                    }
                    else
                    {
                        con.AddParameters("@id", IdMatter.ToString(), SqlDbType.BigInt);
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
                                    errors = errors + i.ToString() + "<->" + dt.Rows[i]["messageError"] + "\n";

                                }

                                MessageBox.Show("Se detectaron los siguientes errores: " + errors, "Crear. Error en consulta a Base de Datos");

                                Limpiar();

                            }

                        }
                        else
                        {
                            MessageBox.Show("Creación de datos exitosa!", "Crear");

                            Limpiar();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha sucedido el siguiente error: "+ ex.Message, "Crear. Error!");
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
   
            try
            {
                if (name_txt.Text == "")
                {
                    MessageBox.Show("Los siguientes campos son obligatorios: Nombre. Por favor, complete los campos que le faltan.",
                        "Editar. Error! Campos incompletos.");

                }
                else
                {
                    name = name_txt.Text;
                    description = description_txt.Text;
                    isActive = (bool)isActivo_Check.IsChecked;

                    if (!ValidateData(name))
                    {
                        MessageBox.Show("Ha surgido un error con sus datos ingresados. Intentelo nuevamente." +
                       "Tenga en cuenta que: nombre deben tener menos de 63 caracteres", 
                       "Validación. Error en campos");
                        Limpiar();
                    }
                    else
                    {
                        con.AddParameters("@id", IdMatter.ToString(), SqlDbType.BigInt);
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
                                    errors = errors + (i+1).ToString() + "<->" + dt.Rows[i]["messageError"] + "\n";
                                }

                                MessageBox.Show("Se detectaron los siguientes errores: " + errors, "Editar. Error en consulta a Base de Datos");

                                con.ClearListParameter();

                            }

                        }
                        else
                        {
                            MessageBox.Show("Edición de datos exitosa!", "Editar");

                            con.ClearListParameter();

                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha sucedido el siguiente error: " + ex.Message, "Editar. Error!");
                con.ClearListParameter();

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

        private bool ValidateData(string name)
        {
            if (name.Length >= 63 || name == null)
            {
                return false;
            }
            else
            {
                return true;
            }            
        }
    }
}
