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
            //VALIDAR DATOS
            Forms.FormDocument formularioDocumentType = new Forms.FormDocument(dc.IdDocument, dc.Code, dc.Name, dc.Description, dc.IsActive);
            formularioDocumentType.Owner = this;
            formularioDocumentType.ShowDialog();
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
                        string errors = "";

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            errors = errors + i.ToString() + "<->" + dt.Rows[i]["messageError"] + "\n";

                        }

                        MessageBox.Show("Se detectaron los siguientes errores: " + errors, "Crear. Error en consulta a Base de Datos");
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Forms.FormDocument formDoc = new Forms.FormDocument();
            formDoc.Owner = this;
            formDoc.ShowDialog();
        }

        public void Limpiar()
        {

            con.ClearListParameter();
        }
    }
}
