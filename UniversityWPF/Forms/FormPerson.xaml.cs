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
            id_txt.DisplayMemberPath = "idDocumentType";
            id_txt.SelectedValuePath = "idDocumentType";
        }

        public FormPerson(int id)
        {
            InitializeComponent();
            this.IdPerson = id;
            
        }

        private void CrearBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (id_txt.Text == "" || doc_txt.Text == "" || name1_txt.Text == "" || lastname1_txt.Text == "" || date_txt.Text == "")
                {
                    MessageBox.Show("DEBE COMPLETAR TODOS LOS CAMPOS | SEGUNDO NOMBRE Y SEGUNDO APELLIDO SON OPCIONALES. LOS DEMAS SON OBLIGATORIOS");

                } else
                {
                    idDoc = Convert.ToInt32(id_txt.Text);
                    doc = doc_txt.Text;
                    name1 = name1_txt.Text;
                    name2 = name2_txt.Text;
                    lastname1 = lastname1_txt.Text;
                    lastname2 = lastname2_txt.Text;
                    birthdayDate = date_txt.Text;

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

                    } else
                    {
                        MessageBox.Show("CARGAR DE DATOS EXITOSA");

                        Limpiar();
                    }
                    

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("HA PASADO ALGO QUE NO DEBIA "+ ex.Message);
            }

        }

        public void Buscar(int id)
        {
            con.AddParameters("@id", id.ToString(), SqlDbType.BigInt);

            ds = con.ExecuteQueryDS("SelectAllPerson", true, con.ConnectionStringdbUniversity());

            dt.Load(ds.CreateDataReader());

            persons = person.getPerson(dt);
        }

        private void EditarBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("CAMBIAR LOS CAMPOS QUE DESEA MODIFICAR Y HACER CLICK AL BOTON EDITAR");

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

    }
}
