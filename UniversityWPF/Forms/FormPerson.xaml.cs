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
        private string idDoc;
        private string name1;
        private string lastname1;
        private string name2;
        private string lastname2;
        private string birthdayDate;
        private bool isActive = true; 

        public FormPerson()
        {
            InitializeComponent();
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
                    MessageBox.Show("DEBE COMPLETAR TODOS LOS CAMPOS | SEGUNDO NOMBRE Y SEGUNDO APELLIDO SON OPCIONALES");

                } else
                {
                    id = Convert.ToInt32(id_txt.Text);
                    idDoc = doc_txt.Text;
                    name1 = name1_txt.Text;
                    name2 = name2_txt.Text;
                    lastname1 = lastname1_txt.Text;
                    lastname2 = lastname2_txt.Text;
                    birthdayDate = date_txt.Text;

                    con.AddParameters("@idDoc", id.ToString(), System.Data.SqlDbType.BigInt);
                    con.AddParameters("@doc", idDoc, System.Data.SqlDbType.VarChar);
                    con.AddParameters("@name1", name1, System.Data.SqlDbType.VarChar);
                    con.AddParameters("@name2", name2, System.Data.SqlDbType.VarChar);
                    con.AddParameters("@lastname1", lastname1, System.Data.SqlDbType.VarChar);
                    con.AddParameters("@lastname2", lastname2, System.Data.SqlDbType.VarChar);
                    con.AddParameters("@birthdayDate", birthdayDate, System.Data.SqlDbType.DateTime);


                    ds = con.ExecuteQueryDS("CreateNewPerson", true, con.ConnectionStringdbUniversity());
                    //VALIDAR RETURN SI ES LISTA DE ERRORES

                    MessageBox.Show("CARGAR DE DATOS EXITOSA");

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
        }

        private void LImpiarBtn_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
    }
}
