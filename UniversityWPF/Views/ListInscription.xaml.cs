﻿using System;
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

namespace UniversityWPF.Views
{
    /// <summary>
    /// Lógica de interacción para ListInscription.xaml
    /// </summary>
    public partial class ListInscription : Window
    {
        public ListInscription()
        {
            InitializeComponent();
        }

        DataBase.Connection con = new DataBase.Connection();
        DataSet ds = new DataSet();

        private void MostrarBtn_Click(object sender, RoutedEventArgs e)
        {
            ds = con.ExecuteQueryDS("SelectAllInscription", true, con.ConnectionStringdbUniversity());
            DataTable dt = new DataTable();
            dt.Load(ds.CreateDataReader());
            datagridInscription.ItemsSource = dt.DefaultView;
        }

        private void BuscarBtn_Click(object sender, RoutedEventArgs e)
        {
            string id = idBuscar.Text;
            con.AddParameters("id", id, SqlDbType.BigInt);
            ds = con.ExecuteQueryDS("SelectAllInscription", true, con.ConnectionStringdbUniversity());
            DataTable dt = new DataTable();
            dt.Load(ds.CreateDataReader());
            datagridInscription.ItemsSource = dt.DefaultView;
        }
    }
}
