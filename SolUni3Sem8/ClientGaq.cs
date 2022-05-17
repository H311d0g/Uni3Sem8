using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SolUni3Sem8
{
    public partial class ClientGaq : Form
    {
        public ClientGaq()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source= DESKTOP-M51EKPM; Initial Catalog= GaqSemana8; Integrated Security= True");
            SqlCommand cmd = new SqlCommand("SELECT nombreCliente, apellido, email, telefono, direccion FROM clienteGaq WHERE rut= @vrut", conn);
            cmd.Parameters.AddWithValue("@vrut", rutBuscar1.Text);
            conn.Open();
            SqlDataReader leer = cmd.ExecuteReader();
            if (leer.Read())
            {
                label3.Text = leer["nombreCliente"].ToString();
                label4.Text = leer["apellido"].ToString();
                label5.Text = leer["email"].ToString();
                label6.Text = leer["telefono"].ToString();
                label7.Text = leer["direccion"].ToString();
            }
            else
            {
                MessageBox.Show("Cliente no encontrado");
            }
            conn.Close();
        }
    }
}
