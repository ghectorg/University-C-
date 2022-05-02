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
            formPerson.ShowDialog();            
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            person = (Class.Person) datagridPerson.SelectedItem;
            //MessageBox.Show("La persona seleccionada es ID: " + person.IdPerson + "Nombre: " + person.Name1);
            Forms.FormPerson formPerson = new Forms.FormPerson(person.IdPerson, person.IdDocument, person.Document, person.Name1, person.Lastname1, person.Name2, person.Lastname2, person.BirthayDay);
            formPerson.Owner = this;
            formPerson.ShowDialog();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
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
                            errors = errors + dt.Rows[i].ToString() + "<->";

                        }

                        MessageBox.Show("HA OCURRIDO UN ERROR: " + errors);
                    }
                }
                else
                {

                    ds = con.ExecuteQueryDS("SelectAllPerson", true, con.ConnectionStringdbUniversity());
                    dt.Load(ds.CreateDataReader());
                    persons = person.getPerson(dt);
                    datagridPerson.DataContext = persons;
                    MessageBox.Show("ELIMINACION DE DATOS EXITOSA");
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("HA OCURRIDO ALGO NO ESPERADO: " + ex.Message);
            }
        }

        public void Limpiar()
        {
            
            con.ClearListParameter();
        }
    }
}
