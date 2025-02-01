using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ingreso
{
    public partial class borrarRegistro : Form
    {

        private Form1 f = new Form1();

        public borrarRegistro()
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
                lblNombre.Text = registro["Nombre"].ToString();
                lblCategoria.Text = registro["Categoría"].ToString();
                lblPrecio.Text = registro["Precio"].ToString();
                btnBorrar.Enabled = true;
            }
            else
            {
                lblNombre.Text = "[Nombre]";
                lblCategoria.Text = "[Categoría]";
                lblPrecio.Text = "[Precio]";
                MessageBox.Show("No existe un artículo con el código ingresado");
            }

            f.con.Close();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            f.con.Open();

            string cod = txtCodigo.Text;

            string cadena = "delete from games where Código=" + cod;
            SqlCommand cmd = new SqlCommand(cadena, f.con);
            int cant = cmd.ExecuteNonQuery();
            
            if (cant == 1)
            {
                lblNombre.Text = "[Nombre]";
                lblCategoria.Text = "[Categoría]";
                lblPrecio.Text = "[Precio]";
                MessageBox.Show("Se borró el artículo");
            }
            else
            {
                MessageBox.Show("No existe un artículo con el código ingresado");
            }
            btnBorrar.Enabled = false;

            f.con.Close();
        }
    }
}
