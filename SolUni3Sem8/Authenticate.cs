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
    public partial class Authenticate : Form
    {
        public Authenticate()
        {
            InitializeComponent();
        }
        private void Authenticate_Load(object sender, EventArgs e)
        {
        }

        int count = 4;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Los campos no pueden estar en blanco");
            }
            else
            {
                SqlConnection conn = new SqlConnection(@"Data Source= DESKTOP-M51EKPM; Initial Catalog= GaqSemana8; Integrated Security= True");
                conn.Open();
                SqlCommand scmd = new SqlCommand("SELECT rut, clave FROM usuarioGaq WHERE rut= @vrut AND clave= @vclave", conn);
                scmd.Parameters.AddWithValue("@vrut", textBox1.Text);
                scmd.Parameters.AddWithValue("@vclave", textBox2.Text);
                SqlDataReader read= scmd.ExecuteReader();

                int attempt = 0;
                while (read.Read())
                {
                    attempt += 1;
                }
                if (attempt >= 1)
                {
                    result4.Text = "Datos Correctos";
                    ClientGaq form = new ClientGaq();
                    form.ShowDialog();
                    conn.Close();
                }
                else
                {
                    if (count == 0)
                    {
                        MessageBox.Show("Has superado el límite de intentos permitidos");
                        Application.Exit();
                    }
                    else
                    {
                        result4.Text = "Datos incorrectos";
                        result5.Text = "Te quedan " + count + " intentos";count--;
                    }
                }
            }
        }
    }
}
