using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Ingreso
{
    public partial class listarRegistros : Form
    {
        public listarRegistros()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Código - Nombre - Categoría - Precio";

            Form1 f = new Form1();
            f.con.Open();

            string cadena = "select Código,Nombre,Categoría,Precio from games";
            SqlCommand cmd = new SqlCommand(cadena, f.con);

            SqlDataReader registros = cmd.ExecuteReader();

            while(registros.Read())
            {
                textBox1.AppendText(Environment.NewLine);

                textBox1.AppendText(registros["Código"].ToString());
                textBox1.AppendText(" - ");

                textBox1.AppendText(registros["Nombre"].ToString());
                textBox1.AppendText(" - ");
                
                textBox1.AppendText(registros["Categoría"].ToString());
                textBox1.AppendText(" - ");

                textBox1.AppendText(registros["Precio"].ToString());
            }

            f.con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
