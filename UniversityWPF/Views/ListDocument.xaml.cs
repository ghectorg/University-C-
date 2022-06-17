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
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace UniversityWPF.Views
{
    /// <summary>
    /// Lógica de interacción para ListDocument.xaml
    /// </summary>
   
    public partial class ListDocument : Window
    {
        DataBase.Connection con = new DataBase.Connection();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        Class.Document dc = new Class.Document();
        List<Class.Document> documents = new List<Class.Document>();

        public ListDocument()
        {
            InitializeComponent();
            ds = con.ExecuteQueryDS("SelectAllDocuments", true, con.ConnectionStringdbUniversity());
            dt.Load(ds.CreateDataReader());
            documents = dc.getDocument(dt);
            
            datagridDocuments.DataContext = documents;
        
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            //enviar datos al formulario para editar y guardar cambios
            dc = (Class.Document)datagridDocuments.SelectedItem;
            
            Forms.FormDocument formularioDocumentType = new Forms.FormDocument(dc.IdDocument, dc.Code, dc.Name, dc.Description, dc.IsActive);
            formularioDocumentType.Owner = this;
            formularioDocumentType.Show();
            formularioDocumentType.Closed += new EventHandler(CloseFormDoc);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Forms.FormDocument formDoc = new Forms.FormDocument();
            formDoc.Owner = this;
            formDoc.Show();
            formDoc.Closed += new EventHandler(CloseFormDoc);

        }

        void CloseFormDoc(object sender, EventArgs e)
        {
            this.InitializeComponent();
            ds = con.ExecuteQueryDS("SelectAllDocuments", true, con.ConnectionStringdbUniversity());
            dt.Clear();
            dt.Load(ds.CreateDataReader());
            documents = dc.getDocument(dt);
            datagridDocuments.DataContext = documents;
        }


        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            //cambiar en la base de datos isActive
            try
            {
                Limpiar();

                dc = (Class.Document)datagridDocuments.SelectedItem;

                //VALIDAR DATOS

                int idDoc = dc.IdDocument;

                con.AddParameters("@id", idDoc.ToString(), SqlDbType.BigInt);

                ds = con.ExecuteQueryDS("DeleteDocType", true, con.ConnectionStringdbUniversity());

                if (ds.Tables.Count > 0)
                {
                    dt.Load(ds.CreateDataReader());

                    if (dt.TableName == "Error")
                    {
                        //string errors = "";

                        /*for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            errors = errors + i.ToString() + "<->" + dt.Rows[i]["message"] + "\n";

                        }

                        errors += dt.Rows[0]["message"].ToString();

                        MessageBox.Show("Error: " + errors, "Crear. Error Base de Datos");*/
                        MessageBox.Show("Ha ocurrido un error en la consulta a base de datos", "Eliminar");

                    }
                }
                else
                {
                    Limpiar();
                    ds = con.ExecuteQueryDS("SelectAllDocuments", true, con.ConnectionStringdbUniversity());
                    dt.Clear();

                    dt.Load(ds.CreateDataReader());
                    documents = dc.getDocument(dt);
                    datagridDocuments.DataContext = documents;
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
                if (nameSearch_txt.Text == "" && codeSearch_txt.Text == "")
                {
                    MessageBox.Show("No puede dejar los campos de busqueda en blanco. Debe rellenar al menos uno.", "Buscar");
                }
                else if (nameSearch_txt.Text != "" && codeSearch_txt.Text == "")
                {
                    dt.Clear();
                    con.AddParameters("@id", "-1", SqlDbType.BigInt);
                    con.AddParameters("@name", nameSearch_txt.Text, SqlDbType.VarChar);
                    
                    ds = con.ExecuteQueryDS("SelectAllDocuments", true, con.ConnectionStringdbUniversity());

                    if (ds.Tables.Count > 0)
                    {
                        dt.Load(ds.CreateDataReader());

                        if (dt.TableName == "Error")
                        {
                            //string errors = "";

                            /*for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                errors = errors + i.ToString() + "<->" + dt.Rows[i]["message"] + "\n";

                            }

                            errors += dt.Rows[0]["message"].ToString();

                            MessageBox.Show("Error en Base de Datos: " + errors, "Buscar");*/

                            MessageBox.Show("Ha ocurrido un error en la consulta a base de datos", "Buscar");
                            
                            Limpiar();

                        }

                        else
                        {

                            documents = dc.getDocument(dt);
                            if (documents.Count == 0)
                            {
                                MessageBox.Show("No existe el documento con el nombre que ha ingresado.", "Buscar");
                                Limpiar();
                                nameSearch_txt.Text = "";
                            }
                            else
                            {
                                datagridDocuments.DataContext = documents;
                                Limpiar();
                                nameSearch_txt.Text = "";
                            }

                        }
                    }
                }
                else if (nameSearch_txt.Text == "" && codeSearch_txt.Text != "")
                {
                    dt.Clear();
                    con.AddParameters("@id", "-1", SqlDbType.BigInt);
                    con.AddParameters("@code", codeSearch_txt.Text, SqlDbType.VarChar);
                    ds = con.ExecuteQueryDS("SelectAllDocuments", true, con.ConnectionStringdbUniversity());

                    if (ds.Tables.Count > 0)
                    {
                        dt.Load(ds.CreateDataReader());

                        if (dt.TableName == "Error")
                        {
                            /*string errors = "";

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                errors = errors + i.ToString() + "<->" + dt.Rows[i]["message"] + "\n";

                            }

                            errors += dt.Rows[0]["message"].ToString();

                            MessageBox.Show("Error en Base de Datos: " + errors, "Buscar");*/
                            MessageBox.Show("Ha ocurrido un error en la consulta a base de datos", "Buscar");

                            Limpiar();

                        }

                        else
                        {

                            documents = dc.getDocument(dt);
                            if (documents.Count == 0)
                            {
                                MessageBox.Show("No existe el documento con el código que ha ingresado.", "Buscar");
                                Limpiar();
                                codeSearch_txt.Text = "";
                            }
                            else
                            {
                                datagridDocuments.DataContext = documents;
                                Limpiar();
                                codeSearch_txt.Text = "";
                            }

                        }
                    }
                }
                else
                {
                    dt.Clear();
                    con.AddParameters("@id", "-1", SqlDbType.BigInt);
                    con.AddParameters("@name", nameSearch_txt.Text, SqlDbType.VarChar);
                    con.AddParameters("@code", nameSearch_txt.Text, SqlDbType.VarChar);
                    ds = con.ExecuteQueryDS("SelectAllDocuments", true, con.ConnectionStringdbUniversity());

                    if (ds.Tables.Count > 0)
                    {
                        dt.Load(ds.CreateDataReader());

                        if (dt.TableName == "Error")
                        {
                            /*string errors = "";

                             for (int i = 0; i < dt.Rows.Count; i++)
                             {
                                 errors = errors + i.ToString() + "<->" + dt.Rows[i]["message"] + "\n";

                             }

                            errors += dt.Rows[0]["message"].ToString();

                            MessageBox.Show("Error en Base de Datos: " + errors, "Buscar");*/
                            MessageBox.Show("Ha ocurrido un error en la consulta a base de datos", "Buscar");

                            Limpiar();

                        }

                        else
                        {

                            documents = dc.getDocument(dt);
                            if (documents.Count == 0)
                            {
                                MessageBox.Show("No existe el curso con el nombre y código que ha ingresado.", "Buscar");
                                Limpiar();
                                nameSearch_txt.Text = "";
                                codeSearch_txt.Text = "";
                            }
                            else
                            {
                                datagridDocuments.DataContext = documents;
                                Limpiar();
                                nameSearch_txt.Text = "";
                                codeSearch_txt.Text = "";
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
