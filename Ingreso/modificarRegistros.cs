﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ingreso
{
    public partial class modificarRegistros : Form
    {

        private Form1 f = new Form1();

        public modificarRegistros()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            f.con.Open();

            string cod = txtCodigo.Text;

            string cadena = "select Nombre,Categoría,Precio from games where Código=" + cod;
            SqlCommand cmd = new SqlCommand(cadena, f.con);
            SqlDataReader registro = cmd.ExecuteReader();

            if (registro.Read())
            {
                txtNombre.Text = registro["Nombre"].ToString();
                txtCategoria.Text = registro["Categoría"].ToString();
                txtPrecio.Text = registro["Precio"].ToString();
                btnModificar.Enabled = true;
            }
            else
            {
                MessageBox.Show("No existe un artículo con el código ingresado");
            }

            f.con.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            f.con.Open();

            string cod = txtCodigo.Text;
            string nom = txtNombre.Text;
            string cat = txtCategoria.Text;
            string pre = txtPrecio.Text;

            string cadena = "update games set Nombre='" + nom + "', Categoría='" + cat + "', Precio=" + pre + " where Código=" + cod;
            SqlCommand cmd = new SqlCommand(cadena, f.con);

            int cant = cmd.ExecuteNonQuery();
            if (cant == 1)
            {
                MessageBox.Show("Se modificaron los datos del artículo");
                txtCodigo.Clear();
                txtNombre.Clear();
                txtCategoria.Clear();
                txtPrecio.Clear();
            }
            else
            {
                MessageBox.Show("No existe un artículo con el código ingresado");
                btnModificar.Enabled = false;
            }

            f.con.Close();
        }
    }
}
