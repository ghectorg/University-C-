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
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;

namespace UniversityWPF.Views
{
    /// <summary>
    /// Lógica de interacción para ListPerson.xaml
    /// </summary>
    public partial class ListPerson : Window
    {
        DataBase.Connection con = new DataBase.Connection();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        Class.Person person = new Class.Person();
        ObservableCollection<Class.Person> persons = new ObservableCollection<Class.Person>();

        public ListPerson()
        {
            InitializeComponent();
            ds = con.ExecuteQueryDS("SelectAllPerson", true, con.ConnectionStringdbUniversity());
            dt.Load(ds.CreateDataReader());
            persons = person.getPerson(dt);
            datagridPerson.DataContext = persons;
            //NO MUESTRA LAS FECHAS EN LA TABLA
            
            
        }

        private void CrearBtn_Click_1(object sender, RoutedEventArgs e)
        {

            Forms.FormPerson formPerson = new Forms.FormPerson();
            formPerson.Owner = this;
            formPerson.Show();
            formPerson.Closed += new EventHandler(CloseFormPerson);
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            person = (Class.Person) datagridPerson.SelectedItem;
            //MessageBox.Show("La persona seleccionada es ID: " + person.IdPerson + "Nombre: " + person.Name1);
            Forms.FormPerson formPerson = new Forms.FormPerson(person.IdPerson, person.IdDocument, person.Document, person.Name1, person.Lastname1, person.Name2, person.Lastname2, person.BirthayDay, person.IsActive);
            formPerson.Owner = this;
            formPerson.Show();
            formPerson.Closed += new EventHandler(CloseFormPerson);
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Limpiar();

                person = (Class.Person)datagridPerson.SelectedItem;

                int idPerson = person.IdPerson;

                con.AddParameters("@id", idPerson.ToString(), SqlDbType.BigInt);

                ds = con.ExecuteQueryDS("DeletePerson", true, con.ConnectionStringdbUniversity());

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
                    Limpiar();

                    ds = con.ExecuteQueryDS("SelectAllPerson", true, con.ConnectionStringdbUniversity());
                    dt.Clear();
                    dt.Load(ds.CreateDataReader());
                    persons = person.getPerson(dt);
                    datagridPerson.DataContext = persons;
                    MessageBox.Show("Eliminación de datos exitosa!", "Eliminar");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha sucedido el siguiente error: " + ex.Message, "Eliminar");
                Limpiar();

            }
        }

        public void Limpiar()
        {
            
            con.ClearListParameter();
        }

        void CloseFormPerson(object sender, EventArgs e)
        {
            this.InitializeComponent();
            ds = con.ExecuteQueryDS("SelectAllPerson", true, con.ConnectionStringdbUniversity());
            dt.Load(ds.CreateDataReader());
            persons = person.getPerson(dt);
            datagridPerson.DataContext = persons;
        }

    }
}
