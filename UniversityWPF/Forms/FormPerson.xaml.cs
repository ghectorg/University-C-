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
    /// Lógica de interacción para FormPerson.xaml
    /// </summary>
    public partial class FormPerson : Window
    {
        DataBase.Connection con = new DataBase.Connection();
        Class.Person person = new Class.Person();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ObservableCollection<Class.Person> persons = new ObservableCollection<Class.Person>();
        
        private int idPerson;
        public int IdPerson
        {
            get { return idPerson; }
            set { idPerson = value; }
        }
        private int id;

        private int idDoc;

        private string codeDocType;
        
        private string doc;
        
        private string name1;
        
        private string lastname1;
        
        private string name2;
        
        private string lastname2;
        
        private string birthdayDate;
       
        private bool isActive = true; 

        public FormPerson()
        {
            InitializeComponent();
            ds = con.ExecuteQueryDS("SelectAllDocuments", true, con.ConnectionStringdbUniversity());

            var dataIdDoc = (ds.Tables[0] as System.ComponentModel.IListSource).GetList();
            id_txt.ItemsSource = dataIdDoc;
            id_txt.DisplayMemberPath = "code";
            id_txt.SelectedValuePath = "idDocumentType";
            
            editarBtn.Visibility = System.Windows.Visibility.Collapsed;
        }

        public FormPerson(int id, int idDocument, string doc, string name1, string lname1, string name2, string lname2, string birth, bool isActi)
        {
            InitializeComponent();
            this.IdPerson = id;
            //buscar codigo de documento por su id
            //con.AddParameters("@id", idDocument.ToString(), SqlDbType.BigInt);
            //ds = con.ExecuteQueryDS("SelectAllDocuments", true, con.ConnectionStringdbUniversity());
            //dt.Load(ds.CreateDataReader());
            //MessageBox.Show("code; " + dt.Rows[0]["code"].ToString());
            //id_txt.Text = idDocument.ToString();
            doc_txt.Text = doc;
            name1_txt.Text = name1;
            name2_txt.Text = name2;
            lastname1_txt.Text = lname1;
            lastname2_txt.Text = lname2;
            date_txt.Text = birth;
            isActivo_Check.IsChecked = isActi;

            //llenar id_txt con los codigos segun los id de los documentos en DocumentType
            ds = con.ExecuteQueryDS("SelectAllDocuments", true, con.ConnectionStringdbUniversity());
            var dataIdDoc = (ds.Tables[0] as System.ComponentModel.IListSource).GetList();
            id_txt.ItemsSource = dataIdDoc;
            id_txt.DisplayMemberPath = "code";
            id_txt.SelectedValuePath = "code";

            CrearBtn.Visibility = System.Windows.Visibility.Collapsed;


        }

        private void CrearBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (doc_txt.Text == "" || name1_txt.Text == "" || lastname1_txt.Text == "" || date_txt.Text == "")
                {
                    MessageBox.Show("Los siguientes campos son obligatorios: documento, primer nombre, primer apellido y"+
                        " fecha de nacimiento. Por favor, complete los campos que le faltan.",
                        "Crear. Error! Campos incompletos.");

                } else
                {
                    id = -1;
                    codeDocType = id_txt.Text;

                    con.AddParameters("@id", id.ToString(), SqlDbType.BigInt);
                    con.AddParameters("@cd", codeDocType, SqlDbType.VarChar);
                    ds = con.ExecuteQueryDS("SelectAllDocuments", true, con.ConnectionStringdbUniversity());
                    dt.Load(ds.CreateDataReader());
                    con.ClearListParameter();

                    idDoc = Convert.ToInt32(dt.Rows[0]["idDocumentType"]);
                    doc = doc_txt.Text;
                    name1 = name1_txt.Text;
                    name2 = name2_txt.Text;
                    lastname1 = lastname1_txt.Text;
                    lastname2 = lastname2_txt.Text;

                    birthdayDate = date_txt.Text;

                    MessageBox.Show("fecha: " + date_txt.Text);

                    isActive = (bool)isActivo_Check.IsChecked;

                    if (!ValidateData(doc, name1, lastname1, name2, lastname2, birthdayDate))
                    {
                        MessageBox.Show("Ha surgido un error con sus datos ingresados. Intentelo nuevamente." +
                    "Tenga en cuenta que: Documento, nombres y apellidos deben tener menos de 63 caracteres",
                    "Validación. Error en campos");
                        Limpiar();
                    }
                    else
                    {
                        con.AddParameters("@idPerson", id.ToString(), SqlDbType.BigInt);
                        con.AddParameters("@idDoc", idDoc.ToString(), System.Data.SqlDbType.BigInt);
                        con.AddParameters("@doc", doc, System.Data.SqlDbType.VarChar);
                        con.AddParameters("@name1", name1, System.Data.SqlDbType.VarChar);
                        con.AddParameters("@name2", name2, System.Data.SqlDbType.VarChar);
                        con.AddParameters("@lastname1", lastname1, System.Data.SqlDbType.VarChar);
                        con.AddParameters("@lastname2", lastname2, System.Data.SqlDbType.VarChar);
                        con.AddParameters("@birthdayDate", birthdayDate, System.Data.SqlDbType.DateTime);
                        con.AddParameters("@isActive", isActive.ToString(), System.Data.SqlDbType.Bit);

                        ds = con.ExecuteQueryDS("InsertAnsEditR", true, con.ConnectionStringdbUniversity());
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
                Limpiar();

            }

        }

        private void EditarBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (name1_txt.Text == "" || lastname1_txt.Text == "" || date_txt.Text == "")
                {
                    MessageBox.Show("Los siguientes campos son obligatorios: documento, primer nombre, primer apellido y" +
                        " fecha de nacimiento. Por favor, complete los campos que le faltan.",
                        "Editar. Error! Campos incompletos.");
                }
                else
                {
                    id = IdPerson;
                    codeDocType = id_txt.Text;

                    con.AddParameters("@id", id.ToString(), SqlDbType.BigInt);
                    con.AddParameters("@cd", codeDocType, SqlDbType.VarChar);
                    ds = con.ExecuteQueryDS("SelectAllDocuments", true, con.ConnectionStringdbUniversity());
                    dt.Load(ds.CreateDataReader());
                    con.ClearListParameter();

                    idDoc = Convert.ToInt32(dt.Rows[0]["idDocumentType"]);
                    
                    doc = doc_txt.Text;
                    name1 = name1_txt.Text;
                    name2 = name2_txt.Text;
                    lastname1 = lastname1_txt.Text;
                    lastname2 = lastname2_txt.Text;
                    birthdayDate = date_txt.Text;
                    isActive = (bool)isActivo_Check.IsChecked;

                    if(!ValidateData(doc, name1, lastname1, name2, lastname2, birthdayDate))
                    {
                        MessageBox.Show("Ha surgido un error con sus datos ingresados. Intentelo nuevamente." +
                    "Tenga en cuenta que: Documento, nombres y apellidos deben tener menos de 63 caracteres",
                    "Validación. Error en campos");
                        Limpiar();
                    }
                    else
                    {
                        con.AddParameters("@idPerson", id.ToString(), SqlDbType.BigInt);
                        con.AddParameters("@idDoc", idDoc.ToString(), System.Data.SqlDbType.BigInt);
                        con.AddParameters("@doc", doc, System.Data.SqlDbType.VarChar);
                        con.AddParameters("@name1", name1, System.Data.SqlDbType.VarChar);
                        con.AddParameters("@name2", name2, System.Data.SqlDbType.VarChar);
                        con.AddParameters("@lastname1", lastname1, System.Data.SqlDbType.VarChar);
                        con.AddParameters("@lastname2", lastname2, System.Data.SqlDbType.VarChar);
                        con.AddParameters("@birthdayDate", birthdayDate, System.Data.SqlDbType.DateTime);
                        con.AddParameters("@isActive", isActive.ToString(), System.Data.SqlDbType.Bit);

                        ds = con.ExecuteQueryDS("InsertAnsEditR", true, con.ConnectionStringdbUniversity());
                        //VALIDAR RETURN SI ES LISTA DE ERRORES

                        if (ds.Tables.Count > 0)
                        {
                            //dt.Clear();

                            dt.Load(ds.CreateDataReader());

                            if (dt.TableName == "Error")
                            {
                                string errors = "";

                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    errors = errors + i.ToString() + "<->" + dt.Rows[i]["messageError"] + "\n";

                                }

                                MessageBox.Show("Se han conseguido los siguientes errores: " + errors, "Editar. Error!");

                                con.ClearListParameter();

                            }

                        }
                        else
                        {
                            MessageBox.Show("Proceso exitoso!", "Editar");

                            con.ClearListParameter();

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha sucedido el siguiente error: "+ ex.Message, "Editar. Error!");
                con.ClearListParameter();
            }

        }

        public void Limpiar()
        {
            id_txt.Text = "";
            doc_txt.Text = "";
            name1_txt.Text = "";
            name2_txt.Text = "";
            lastname1_txt.Text = "";
            lastname2_txt.Text = "";
            date_txt.Text = "";
            con.ClearListParameter();
        }

        private void LImpiarBtn_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        private bool ValidateData(string doc, string name1, string lastname1, string name2, string lastname2, string cumple)
        {
            /*
             * Return True si la validacion es exitosa
             * falso sino lo es
             */


            if (doc.Length > 63 || name1.Length > 63 || name1 == null || lastname1.Length > 63 || lastname1 == null || name2.Length > 63 || lastname2.Length > 63 || cumple == null)
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
