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
        private int idPerson;
        private bool isActive = true;

        public FormInscription()
        {
            InitializeComponent();
        }

        public FormInscription(int id, int idMatter, int idPerson)
        {
            
        }
    }
}
