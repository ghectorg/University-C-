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
            var dataPerson = (ds.Tables[0] as System.ComponentModel.IListSource).GetList();       
            namePersons_txt.ItemsSource = dataPerson;
            namePersons_txt.DisplayMemberPath = "name1";
            namePersons_txt.SelectedValuePath = "idPerson";

            ds = con.ExecuteQueryDS("SelectAllMatter", true, con.ConnectionStringdbUniversity());
            var dataCursos = (ds.Tables[0] as System.ComponentModel.IListSource).GetList();
            nameCursos_txt.ItemsSource = dataCursos;
            nameCursos_txt.DisplayMemberPath = "name";
            nameCursos_txt.SelectedValuePath = "idMatter";

            editBtn.Visibility = System.Windows.Visibility.Collapsed;
            namePersonBlock_txt.Visibility = System.Windows.Visibility.Collapsed;
                        
        }

        public FormInscription(int id, int idM, int idP, string nameM, string nameP, bool isActi)
        {
            InitializeComponent();
            IdInscription = id;
            IdMatter = idM;
            IdPerson = idP;
            namePersonBlock_txt.Text = nameP;
            namePerson = nameP;
            nameMatter = nameM;
            
            ds = con.ExecuteQueryDS("SelectAllMatter", true, con.ConnectionStringdbUniversity());
            var dataCursos = (ds.Tables[0] as System.ComponentModel.IListSource).GetList();
            nameCursos_txt.ItemsSource = dataCursos;
            nameCursos_txt.DisplayMemberPath = "name";
            nameCursos_txt.SelectedValuePath = "idMatter";

            isActivo_Check.IsChecked = isActi;

            CrearBtn.Visibility = System.Windows.Visibility.Collapsed;
            namePersons_txt.Visibility = System.Windows.Visibility.Collapsed;
            
        }

        private void CrearBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (nameCursos_txt.Text == "" || namePersons_txt.Text == "")
                {
                    MessageBox.Show("Los siguientes campos son obligatorios: Nombre de persona y nombre de curso. Por favor, complete los campos que le faltan.",
                        "Crear. Error! Campos incompletos.");

                }
                else
                {
                    IdInscription = -1;
                    namePerson = namePersons_txt.Text;
                    nameMatter = nameCursos_txt.Text;
                    IdPerson = Convert.ToInt32(namePersons_txt.SelectedValue);
                    IdMatter = Convert.ToInt32(nameCursos_txt.SelectedValue);
                    if (IdMatter == -1)
                    {
                        MessageBox.Show("El curso ingresado no existe. Intentelo nuevamente!", "Crear. Error!");

                    }
                    else
                    {
                        isActive = (bool)isActivo_Check.IsChecked;

                        con.AddParameters("@id", IdInscription.ToString(), SqlDbType.BigInt);
                        con.AddParameters("@idMatter", IdMatter.ToString(), System.Data.SqlDbType.BigInt);
                        con.AddParameters("@idPerson", IdPerson.ToString(), System.Data.SqlDbType.BigInt);
                        con.AddParameters("@isActive", isActive.ToString(), System.Data.SqlDbType.Bit);

                        ds = con.ExecuteQueryDS("EditAndCreateInscription", true, con.ConnectionStringdbUniversity());
                        //VALIDAR RETURN SI ES LISTA DE ERRORES

                        if (ds.Tables.Count > 0)
                        {
                            DataTable tableError = new DataTable();
                            tableError.Load(ds.CreateDataReader());


                            if (tableError.TableName == "Error")
                            {
                                /* string errors = "";

                                 for (int i = 0; i < tableError.Rows.Count; i++)
                                 {
                                     errors = errors + (i + 1).ToString() + " - " + tableError.Rows[i]["message"] + "\n";

                                 }

                                 MessageBox.Show("Se detectaron los siguientes errores: \n" + errors, "Crear. Error en consulta a Base de Datos");*/
                                MessageBox.Show("Ha ocurrido un error en la consulta a base de datos", "Crear");


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
                if (nameCursos_txt.Text == "")
                {
                    MessageBox.Show("Los siguientes campos son obligatorios: Nombre de curso. Por favor, complete los campos que le faltan.",
                        "Editar. Error! Campos incompletos.");
                }
                else
                {
                    //namePerson = namePersons_txt.Text;
                    //MessageBox.Show("id inscription: " + IdInscription);
                    nameMatter = nameCursos_txt.Text;
                    //IdMatter = SearchIDTable(nameMatter, IdMatter, "Matter");
                    IdMatter = Convert.ToInt32(nameCursos_txt.SelectedValue);
                    isActive = (bool)isActivo_Check.IsChecked;
                    
                    con.AddParameters("@id", IdInscription.ToString(), SqlDbType.BigInt);
                    con.AddParameters("@idMatter", IdMatter.ToString(), SqlDbType.BigInt);
                    con.AddParameters("@idPerson", IdPerson.ToString(), SqlDbType.BigInt);
                    con.AddParameters("@isActive", isActive.ToString(), SqlDbType.Bit);

                    ds = con.ExecuteQueryDS("EditAndCreateInscription", true, con.ConnectionStringdbUniversity());
                    //VALIDAR RETURN SI ES LISTA DE ERRORES

                    if (ds.Tables.Count > 0)
                    {
                        DataTable tableError = new DataTable();
                        tableError.Load(ds.CreateDataReader());

                        if (tableError.TableName == "Error")
                        {
                            /*string errors = "";

                            for (int i = 0; i < tableError.Rows.Count; i++)
                            {
                                errors = errors + (i+1).ToString() + " - " + tableError.Rows[i]["message"] + "\n";

                            }

                            MessageBox.Show("Se detectaron los siguientes errores: \n" + errors, "Editar. Error en consulta a Base de Datos");
                            */
                            MessageBox.Show("Ha ocurrido un error en la consulta a base de datos", "Editar");

                            con.ClearListParameter();
                            tableError.Clear();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Edición de datos exitosa!", "Editar");

                        con.ClearListParameter();

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha sucedido el siguiente error: "+ ex.Message, "Editar. Error!");
                con.ClearListParameter();

            }
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        public void Limpiar()
        {
            nameCursos_txt.Text = "";
            isActivo_Check.IsChecked = false;            
            con.ClearListParameter();
        }

    }
}
