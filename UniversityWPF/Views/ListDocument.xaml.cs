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
        ObservableCollection<Class.Document> documents = new ObservableCollection<Class.Document>();

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
            Forms.FormDocument view1 = new Forms.FormDocument(dc.IdDocument, dc.Name, dc.Code, dc.Description);
            view1.Owner = this;
            view1.ShowDialog();
        }


        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            //cambiar en la base de datos isActive
            try
            {
                dc = (Class.Document)datagridDocuments.SelectedItem;

                int idDoc = dc.IdDocument;

                con.AddParameters("@idDocumentType", idDoc.ToString(), SqlDbType.BigInt);

                ds = con.ExecuteQueryDS("DeleteDocType", true, con.ConnectionStringdbUniversity());

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

                    ds = con.ExecuteQueryDS("SelectAllDocuments", true, con.ConnectionStringdbUniversity());
                    dt.Load(ds.CreateDataReader());
                    documents = dc.getDocument(dt);
                    datagridDocuments.DataContext = documents;
                    MessageBox.Show("ELIMINACION DE DATOS EXITOSA");
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("HA OCURRIDO ALGO NO ESPERADO: " + ex.Message);
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
