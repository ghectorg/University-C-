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
    /// Lógica de interacción para FormInscription.xaml
    /// </summary>
    public partial class FormInscription : Window
    {
        DataBase.Connection con = new DataBase.Connection();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        Class.Iscription ins = new Class.Iscription();
        ObservableCollection<Class.Iscription> allIns = new ObservableCollection<Class.Iscription>();

        private int idInscription;
        public int IdInscription
        {
            get { return idInscription; }
            set { idInscription = value; }
        }

        private int idMatter;
        public int IdMatter
        {
            get { return idMatter; }
            set { idMatter = value; }
        }

        private int idPerson;
        public int IdPerson
        {
            get { return idPerson; }
            set { idPerson = value; }
        }

        private string nameMatter;
        private string namePerson;
        private bool isActive = true;

        public FormInscription()
        {
            InitializeComponent();
            ds = con.ExecuteQueryDS("SelectAllPerson", true, con.ConnectionStringdbUniversity());
            var data = (ds.Tables[0] as System.ComponentModel.IListSource).GetList();
            namePersons_txt.ItemsSource = data;
            namePersons_txt.DisplayMemberPath = "name1";
            namePersons_txt.SelectedValuePath = "name1";
            
        }

        public FormInscription(int id, int idM, int idP, string nameM, string nameP)
        {

            InitializeComponent();
            IdInscription = id;
            IdMatter = idM;
            IdPerson = idP;
            namePersons_txt.Text = nameP;
            namePerson = nameP;
            nameMatter = nameM;
            //MessageBox.Show(nameP);
            nameCursos_txt.Text = nameM;


        }

        private void CrearBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (namePersons_txt.Text == "" || nameCursos_txt.Text == "")
                {
                    MessageBox.Show("DEBE COMPLETAR TODOS LOS CAMPOS | AMBOS CAMPOS SON OBLIGATORIOS");

                }
                else
                {
                    IdInscription = -1;

                    IdPerson = SearchIndexP(namePersons_txt.Text);
                    IdMatter = SearchIndexM(nameCursos_txt.Text);

                    con.AddParameters("@idIscription", IdInscription.ToString(), SqlDbType.BigInt);
                    con.AddParameters("@idMatter", IdMatter.ToString(), System.Data.SqlDbType.BigInt);
                    con.AddParameters("@idPerson", IdPerson.ToString(), System.Data.SqlDbType.BigInt);
                    con.AddParameters("@isActive", isActive.ToString(), System.Data.SqlDbType.Bit);

                    ds = con.ExecuteQueryDS("EditAndCreateInscription", true, con.ConnectionStringdbUniversity());
                    //VALIDAR RETURN SI ES LISTA DE ERRORES

                    if (ds.Tables.Count > 0)
                    {
                        dt.Load(ds.CreateDataReader());

                        if (dt.TableName == "Error")
                        {
                            string errors = "";

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                errors = errors + dt.Rows[i]["messageError"] + "<->";

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

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (namePersons_txt.Text == "" || nameCursos_txt.Text == "")
                {
                    MessageBox.Show("DEBE COMPLETAR TODOS LOS CAMPOS | AMBOS CAMPOS SON OBLIGATORIOS");

                }
                else
                {

                    IdPerson= SearchIndexP(namePerson);
                    IdMatter = SearchIndexM(nameCursos_txt.Text);

                    con.AddParameters("@id", IdInscription.ToString(), SqlDbType.BigInt);
                    con.AddParameters("@idMatter", IdMatter.ToString(), System.Data.SqlDbType.BigInt);
                    con.AddParameters("@idPerson", IdPerson.ToString(), System.Data.SqlDbType.BigInt);
                    con.AddParameters("@isActive", isActive.ToString(), System.Data.SqlDbType.Bit);

                    ds = con.ExecuteQueryDS("EditAndCreateInscription", true, con.ConnectionStringdbUniversity());
                    //VALIDAR RETURN SI ES LISTA DE ERRORES

                    if (ds.Tables.Count > 0)
                    {
                        dt.Load(ds.CreateDataReader());

                        if (dt.TableName == "Error")
                        {
                            string errors = "";

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                errors = errors + dt.Rows[i]["messageError"] + "<->";

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

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        public void Limpiar()
        {
            namePersons_txt.Text = "";
            nameCursos_txt.Text = "";
            
            con.ClearListParameter();
        }

        public int SearchIndexM(string name)
        {
            int index;
            con.AddParameters("name", name, SqlDbType.VarChar);
            ds = con.ExecuteQueryDS("SearchName", true, con.ConnectionStringdbUniversity());

            if (ds.Tables[0].TableName == "Error")
            {
                index = -1;
                con.ClearListParameter();

                return index;
            }
            else if (ds.Tables[0].TableName == "Person")
            {
                index = Convert.ToInt32(ds.Tables[0].Rows[0]["idMatter"]);
                MessageBox.Show("index: " + index);
                con.ClearListParameter();
                return index;
            }
            else
            {
                index = -2;
                return index;
            }
            
        }

        public int SearchIndexP(string name)
        {
            int index;
            con.AddParameters("name", name, SqlDbType.VarChar);
            ds = con.ExecuteQueryDS("SearchNamePerson", true, con.ConnectionStringdbUniversity());

            if (ds.Tables[0].TableName == "Error")
            {
                index = -1;
                con.ClearListParameter();

                return index;
            }
            else if (ds.Tables[0].TableName == "Person")
            {
                index = Convert.ToInt32(ds.Tables[0].Rows[0]["idPerson"]);
                MessageBox.Show("index: " + index);
                con.ClearListParameter();
                return index;
            }
            else
            {
                index = -2;
                return index;
            }
        }

    }
}
