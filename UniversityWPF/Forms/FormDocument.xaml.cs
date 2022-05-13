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
    /// Lógica de interacción para FormDocument.xaml
    /// </summary>
    public partial class FormDocument : Window
    {
        DataBase.Connection con = new DataBase.Connection();
        DataSet ds = new DataSet();

        DataTable dt = new DataTable();
        Class.Document doc = new Class.Document();
        ObservableCollection<Class.Document> docs = new ObservableCollection<Class.Document>();

        private int idDocumentType;
        public int IdDocumentType
        {
            get { return idDocumentType; }
            set { idDocumentType = value; }
        }
        private string code;
        private string name;
        private string description;
        private bool isActive = true;

        public FormDocument()
        {
            InitializeComponent();       
            EditBtn.Visibility = System.Windows.Visibility.Collapsed;
        }

        public FormDocument(int id, string cd, string name, string decription, bool isActiv)
        {
            InitializeComponent();
            IdDocumentType = id;
            code_txt.Text = cd;
            name_txt.Text = name;
            description_txt.Text = decription;
            isActivo_Check.IsChecked = isActiv;
            CrearBtn.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (code_txt.Text == "" || name_txt.Text == "")
                {
                    MessageBox.Show("Los siguientes campos son obligatorios: Código y nombre del documento. Por favor, complete los campos que le faltan.",
                        "Editar. Error! Campos incompletos.");

                }
                else
                {
                    code = code_txt.Text;
                    name = name_txt.Text;
                    description = description_txt.Text;
                    isActive = (bool)isActivo_Check.IsChecked;

                    if(!ValidateData(name, code))
                    {
                        MessageBox.Show("Ha surgido un error con sus datos ingresados. Intentelo nuevamente." +
                       " Tenga en cuenta que: nombre deben tener menos de 63 caracteres y código debe tener 3 o menos caracteres",
                       "Validación. Error en campos");
                        Limpiar();
                    }
                    else
                    {

                        con.AddParameters("@id", IdDocumentType.ToString(), SqlDbType.BigInt);
                        con.AddParameters("@code", code, System.Data.SqlDbType.VarChar);
                        con.AddParameters("@name", name, System.Data.SqlDbType.VarChar);
                        con.AddParameters("@description", description, System.Data.SqlDbType.VarChar);
                        con.AddParameters("@isActive", isActive.ToString(), System.Data.SqlDbType.Bit);

                        ds = con.ExecuteQueryDS("EditAndCreateDocument", true, con.ConnectionStringdbUniversity());
                        //VALIDAR RETURN SI ES LISTA DE ERRORES

                        if (ds.Tables.Count > 0)
                        {
                            DataTable tableError = new DataTable();
                            tableError.Load(ds.CreateDataReader());

                            if (tableError.TableName == "Error")
                            {
                                string errors = "";

                                /* for (int i = 0; i < tableError.Rows.Count; i++)
                                 {
                                     errors = errors + (i+1).ToString() + " - " + tableError.Rows[i]["message"] + "\n";

                                 }*/
                                if (tableError.Rows[0]["message"].ToString().Contains("The duplicate key value is (" + code + ")"))
                                {
                                    errors += "No puede duplicar un código ya existente, debe crear uno nuevo.";
                                }
                                else
                                {
                                    errors += "Error: Ha salido mal la consulta a base de datos";
                                }


                                MessageBox.Show("Error: " + errors, "Crear. Error Base de Datos");

                                con.ClearListParameter();
                                ds.Clear();
                                tableError.Clear();

                            }

                        }
                        else
                        {
                            MessageBox.Show("Edición de datos exitosa!", "Editar");
                            ds.Clear();

                            con.ClearListParameter();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha sucedido el siguiente error: "+ ex.Message, "Editar. Error!");
                ds.Clear();

                con.ClearListParameter();

            }
        }

        private void CrearBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (name_txt.Text == "" || code_txt.Text == "")
                {
                    MessageBox.Show("Los siguientes campos son obligatorios: Código y nombre del documento. Por favor, complete los campos que le faltan.",
                        "Editar. Error! Campos incompletos.");

                }
                else
                {
                    idDocumentType = -1;
                    code = code_txt.Text;
                    name = name_txt.Text;
                    description = description_txt.Text;
                    isActive = (bool)isActivo_Check.IsChecked;
                    

                    if (!ValidateData(name, code))
                    {
                        MessageBox.Show("Ha surgido un error con sus datos ingresados. Intentelo nuevamente." +
                        " Tenga en cuenta que: nombre deben tener menos de 63 caracteres y código debe tener 3 o menos caracteres",
                        "Validación. Error en campos");
                        Limpiar();

                    }
                    else
                    {
                        con.ClearListParameter();

                        con.AddParameters("@id", idDocumentType.ToString(), SqlDbType.BigInt);
                        con.AddParameters("@code", code, SqlDbType.VarChar);
                        con.AddParameters("@name", name, SqlDbType.VarChar);
                        con.AddParameters("@description", description, SqlDbType.VarChar);
                        con.AddParameters("@isActive", isActive.ToString(), SqlDbType.Bit);
                        
                        ds = con.ExecuteQueryDS("EditAndCreateDocument", true, con.ConnectionStringdbUniversity());
                        //VALIDAR RETURN SI ES LISTA DE ERRORES

                        if (ds.Tables.Count > 0)
                        {
                            DataTable tableError = new DataTable();
                            tableError.Load(ds.CreateDataReader());

                            if (tableError.TableName == "Error")
                            {
                                string errors = "";

                                /*for (int i = 0; i < tableError.Rows.Count; i++)
                                {
                                    //errors = errors + (i+1).ToString() + " - " + tableError.Rows[i]["message"] + "\n";
                                    if (tableError.Rows[i]["message"].ToString().Contains("The duplicate key value is (" + code + ")"))
                                    {
                                        errors += "No puede duplicar un código ya existente, debe crear uno nuevo.";
                                    }
                                    else
                                    {
                                        errors = errors + (i+1).ToString() + " - " + tableError.Rows[i]["message"] + "\n";
                                    }
                                }*/
                                if (tableError.Rows[0]["message"].ToString().Contains("The duplicate key value is (" + code + ")"))
                                {
                                    errors += "No puede duplicar un código ya existente, debe crear uno nuevo.";
                                }
                                else
                                {
                                    errors += "Error: Ha salido mal la consulta a base de datos";
                                }

                                
                                MessageBox.Show("Error: " + errors, "Crear. Error Base de Datos");

                                Limpiar();
                                con.ClearListParameter();
                                ds.Clear();
                                tableError.Clear();

                            }

                        }
                        else
                        {
                            MessageBox.Show("Creación de datos exitosa!", "Crear");
                            con.ClearListParameter();
                            ds.Clear();

                            Limpiar();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha sucedido el siguiente error: "+ ex.Message, "Crear. Error!");
                ds.Clear();
                con.ClearListParameter();
                Limpiar();
            }

        }

        public void Limpiar()
        {
            code_txt.Text = "";
            name_txt.Text = "";
            description_txt.Text = "";

        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
            con.ClearListParameter();
        }

        private bool ValidateData(string name, string code)
        {
            //MessageBox.Show(name.Length + "---" + code.Length);
            if (name.Length > 63 || code.Length > 3 || name == null || code == null)
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
