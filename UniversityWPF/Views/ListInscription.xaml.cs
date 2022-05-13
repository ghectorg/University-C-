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

namespace UniversityWPF.Views
{
    /// <summary>
    /// Lógica de interacción para ListInscription.xaml
    /// </summary>
    public partial class ListInscription : Window
    {
        DataBase.Connection con = new DataBase.Connection();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        Class.Iscription ins = new Class.Iscription();
        ObservableCollection<Class.Iscription> allIns = new ObservableCollection<Class.Iscription>();
        

        public ListInscription()
        {
            InitializeComponent();
            ds = con.ExecuteQueryDS("SelectAllInscription", true, con.ConnectionStringdbUniversity());
            dt.Load(ds.CreateDataReader());
            allIns = ins.getInscription(dt);
            datagridInscription.DataContext = allIns;
            

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            //pasar datos al formulario y guardar

            ins = (Class.Iscription)datagridInscription.SelectedItem;
            Forms.FormInscription formIns = new Forms.FormInscription(ins.IdInscription, ins.IdMatter, ins.IdPerson, ins.NameMatter, ins.NamePerson, ins.IsActive);
            formIns.Owner = this;
            formIns.Show();
            formIns.Closed += new EventHandler(CloseFormIns);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Forms.FormInscription formIns = new Forms.FormInscription();
            formIns.Owner = this;
            formIns.Show();
            formIns.Closed += new EventHandler(CloseFormIns);
        }

        void CloseFormIns(object sender, EventArgs e)
        {
            this.InitializeComponent();
            ds = con.ExecuteQueryDS("SelectAllInscription", true, con.ConnectionStringdbUniversity());
            dt.Clear();
            dt.Load(ds.CreateDataReader());
            allIns = ins.getInscription(dt);
            datagridInscription.DataContext = allIns;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            //cambiar isActive en base de datos
            try
            {
                Limpiar();

                ins = (Class.Iscription)datagridInscription.SelectedItem;

                int idI = ins.IdInscription;

                con.AddParameters("@id", idI.ToString(), SqlDbType.BigInt);

                ds = con.ExecuteQueryDS("DeleteInscription", true, con.ConnectionStringdbUniversity());

                if (ds.Tables.Count > 0)
                {
                    dt.Load(ds.CreateDataReader());

                    if (dt.TableName == "Error")
                    {
                        //string errors = "";

                        /*for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            errors = errors + i.ToString() + "<->" + dt.Rows[i]["message"] + "\n";

                        }*/

                        MessageBox.Show("Ha ocurrido un error en la consulta a base de datos", "Eliminar");
                        Limpiar();
                    }
                }
                else
                {
                    Limpiar();

                    ds = con.ExecuteQueryDS("SelectAllInscription", true, con.ConnectionStringdbUniversity());
                    dt.Clear();
                    dt.Load(ds.CreateDataReader());
                    allIns = ins.getInscription(dt);
                    datagridInscription.DataContext = allIns;
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

        private void BuscarBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (namePersonSearch_txt.Text == "" && nameMatterSearch_txt.Text == "")
                {
                    MessageBox.Show("No puede dejar los campos de busqueda en blanco. Debe rellenar al menos uno.", "Buscar");
                }
                else if (namePersonSearch_txt.Text != "" && nameMatterSearch_txt.Text == "")
                {
                    dt.Clear();
                    con.AddParameters("@id", "-1", SqlDbType.BigInt);
                    con.AddParameters("@namePerson", namePersonSearch_txt.Text, SqlDbType.VarChar);

                    ds = con.ExecuteQueryDS("SelectAllInscription", true, con.ConnectionStringdbUniversity());

                    if (ds.Tables.Count > 0)
                    {
                        dt.Load(ds.CreateDataReader());

                        if (dt.TableName == "Error")
                        {
                            /*string errors = "";

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                errors = errors + i.ToString() + "<->" + dt.Rows[i]["message"] + "\n";

                            }*/

                            MessageBox.Show("Ha ocurrido un error en la consulta a base de datos", "Buscar");

                            Limpiar();

                        }

                        else
                        {

                            allIns = ins.getInscription(dt);
                            if (allIns.Count == 0)
                            {
                                MessageBox.Show("No existe una inscripción en algún curso por: " + namePersonSearch_txt.Text, "Buscar");
                                Limpiar();
                                namePersonSearch_txt.Text = "";
                            }
                            else
                            {
                                datagridInscription.DataContext = allIns;
                                Limpiar();
                                namePersonSearch_txt.Text = "";
                            }

                        }
                    }
                }
                else if (namePersonSearch_txt.Text == "" && nameMatterSearch_txt.Text != "")
                {
                    dt.Clear();
                    con.AddParameters("@id", "-1", SqlDbType.BigInt);
                    con.AddParameters("@nameCurso", nameMatterSearch_txt.Text, SqlDbType.VarChar);
                    ds = con.ExecuteQueryDS("SelectAllInscription", true, con.ConnectionStringdbUniversity());

                    if (ds.Tables.Count > 0)
                    {
                        dt.Load(ds.CreateDataReader());

                        if (dt.TableName == "Error")
                        {
                           /* string errors = "";

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                errors = errors + i.ToString() + "<->" + dt.Rows[i]["message"] + "\n";

                            }*/

                            MessageBox.Show("Ha ocurrido un error en la consulta a base de datos", "Buscar");
                            Limpiar();

                        }

                        else
                        {

                            allIns = ins.getInscription(dt);
                            if (allIns.Count == 0)
                            {
                                MessageBox.Show("No existe la materia: "+nameMatterSearch_txt.Text, "Buscar");
                                Limpiar();
                                nameMatterSearch_txt.Text = "";
                            }
                            else
                            {
                                datagridInscription.DataContext = allIns;
                                Limpiar();
                                nameMatterSearch_txt.Text = "";
                            }

                        }
                    }
                }
                else
                {
                    dt.Clear();
                    con.AddParameters("@id", "-1", SqlDbType.BigInt);
                    con.AddParameters("@name", namePersonSearch_txt.Text, SqlDbType.VarChar);
                    con.AddParameters("@cd", nameMatterSearch_txt.Text, SqlDbType.VarChar);
                    ds = con.ExecuteQueryDS("SelectAllInscription", true, con.ConnectionStringdbUniversity());

                    if (ds.Tables.Count > 0)
                    {
                        dt.Load(ds.CreateDataReader());

                        if (dt.TableName == "Error")
                        {
                            /*string errors = "";

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                errors = errors + i.ToString() + "<->" + dt.Rows[i]["message"] + "\n";

                            }*/

                            MessageBox.Show("Ha ocurrido un error en la consulta a base de datos", "Buscar");

                            Limpiar();

                        }

                        else
                        {

                            allIns = ins.getInscription(dt);
                            if (allIns.Count == 0)
                            {
                                MessageBox.Show("No existe una inscripción en el curso: "+ nameMatterSearch_txt.Text 
                                    +"hecha por: " + namePersonSearch_txt.Text , "Buscar");
                                Limpiar();
                                namePersonSearch_txt.Text = "";
                                nameMatterSearch_txt.Text = "";
                            }
                            else
                            {
                                datagridInscription.DataContext = allIns;
                                Limpiar();
                                namePersonSearch_txt.Text = "";
                                nameMatterSearch_txt.Text = "";
                            }

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha sucedido el siguiente error: " + ex.Message, "Buscar");
                Limpiar();
            }
        }
    }
}
