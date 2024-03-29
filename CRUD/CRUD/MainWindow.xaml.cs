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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CRUD.Clases;
using SQLite;

namespace CRUD
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contactos> contactos;
        public MainWindow()
        {
            InitializeComponent();
            contactos = new List<Contactos>();
            LeerBaseDatos();
        }
        void LeerBaseDatos()
        {
            using (SQLite.SQLiteConnection conn =
                new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Contactos>();
                contactos = (conn.Table<Contactos>().ToList()).
                    OrderBy(c => c.Nombre).ToList();
            }
            if (contactos!=null)
            {
                lvContactos.ItemsSource = contactos;
            }
        }

    }
}
