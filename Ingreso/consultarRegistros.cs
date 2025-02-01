using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ingreso
{
    public partial class consultarRegistros : Form
    {
        public consultarRegistros()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.con.Open();

            string cod = textBox1.Text;

            string cadena = "select Nombre,Categoría,Precio from games where Código=" + cod;
            SqlCommand cmd = new SqlCommand(cadena, f.con);
            SqlDataReader registro = cmd.ExecuteReader();

            if (registro.Read())
            {
                lblNombre.Text = registro["Nombre"].ToString();
                lblCategoria.Text = registro["Categoría"].ToString();
                lblPrecio.Text = registro["Precio"].ToString();
            }
            else
            {
                MessageBox.Show("No existe un artículo con el código ingresado");
            }

            f.con.Close();
        }
    }
}
