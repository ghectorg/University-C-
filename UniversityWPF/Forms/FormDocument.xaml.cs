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
        }

        public FormDocument(int id, string cd, string name, string decription)
        {
            InitializeComponent();
            IdDocumentType = id;
            code_txt.Text = cd;
            name_txt.Text = name;
            description_txt.Text = decription;
            MessageBox.Show("CAMBIAR LOS CAMPOS QUE DESEA MODIFICAR Y HACER CLICK AL BOTON EDITAR");
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                if (code_txt.Text == "" || name_txt.Text == "")
                {
                    MessageBox.Show("DEBE COMPLETAR TODOS LOS CAMPOS | NOMBRE Y CODIGO SON OBLIGATORIOS");

                }
                else
                {
                    
                    code = code_txt.Text;
                    name = name_txt.Text;
                    description = description_txt.Text;

                    con.AddParameters("@idDocumentType", IdDocumentType.ToString(), SqlDbType.BigInt);
                    con.AddParameters("@code", code, System.Data.SqlDbType.VarChar);
                    con.AddParameters("@name", name, System.Data.SqlDbType.VarChar);
                    con.AddParameters("@description", description, System.Data.SqlDbType.VarChar);
                    con.AddParameters("@isActive", isActive.ToString(), System.Data.SqlDbType.Bit);

                    ds = con.ExecuteQueryDS("EditAndCreateDocument", true, con.ConnectionStringdbUniversity());
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

        private void CrearBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (name_txt.Text == "" || code_txt.Text == "")
                {
                    MessageBox.Show("DEBE COMPLETAR TODOS LOS CAMPOS | NOMBRE Y CODIGO SON OBLIGATORIOS");

                }
                else
                {
                    idDocumentType = -1;
                    code = code_txt.Text;
                    name = name_txt.Text;
                    description = description_txt.Text;

                    con.AddParameters("@idDocumentType", idDocumentType.ToString(), SqlDbType.BigInt);
                    con.AddParameters("@code", code, System.Data.SqlDbType.VarChar);
                    con.AddParameters("@name", name, System.Data.SqlDbType.VarChar);
                    con.AddParameters("@description", description, System.Data.SqlDbType.VarChar);
                    con.AddParameters("@isActive", isActive.ToString(), System.Data.SqlDbType.Bit);

                    ds = con.ExecuteQueryDS("EditAndCreateDocument", true, con.ConnectionStringdbUniversity());
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

        public void Limpiar()
        {
            code_txt.Text = "";
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
