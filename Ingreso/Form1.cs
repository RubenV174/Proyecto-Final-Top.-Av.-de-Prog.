using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ingreso
{
    public partial class Form1 : Form
    {

        private static string bd = "server=localhost\\TADP ; database=Proyecto Final ; integrated security=true";
        
        public SqlConnection con = new SqlConnection(bd);
        

        public Form1()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Admin" && txtClave.Text == "1234")
            {
                Form2 form2 = new Form2();
                form2.Show();
            }
            else
            {
                MessageBox.Show("Usuario o clave incorrecta", "Error");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                txtClave.UseSystemPasswordChar = true;
            }
            else
            {
                txtClave.UseSystemPasswordChar = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {            
            DialogResult res = MessageBox.Show("¿Está seguro que desea salir?", "Confirmación", MessageBoxButtons.YesNo);

            if (res == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
