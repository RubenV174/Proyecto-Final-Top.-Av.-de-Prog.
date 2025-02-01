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
    public partial class insertarRegistro : Form
    {
        public insertarRegistro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.con.Open();

            string cod = txtCodigo.Text;
            string nom = txtNombre.Text;
            string cat = txtCategoria.Text;
            string pre = txtPrecio.Text;

            string cadena = "insert into games(Código,Nombre,Categoría,Precio) values ('" + cod + "','" + nom + "','" + cat + "','" + pre + "')";
            SqlCommand cmd = new SqlCommand(cadena, f.con);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Juego registrado correctamente");

            txtCodigo.Clear();
            txtNombre.Clear();
            txtCategoria.Clear();
            txtPrecio.Clear();

            f.con.Close();
        }
    }
}
