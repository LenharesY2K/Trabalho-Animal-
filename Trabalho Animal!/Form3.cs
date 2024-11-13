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

namespace Trabalho_Animal_
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                string criterio = textBox1.Text.ToString();
                string sqlcomando = "";

                SqlDataReader reg = null;
                if (criterio == "")
                {
                    MessageBox.Show("Digite a expressão");
                    return;
                }
                else
                    sqlcomando = "SELECT * FROM Animais Where animal LIKE '" + criterio + "%'";
                try
                {
                    SqlConnection conexao = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\20231350265\Documents\bancoanimal.mdf;Integrated Security=True;Connect Timeout=30");
                    SqlCommand comando = new SqlCommand();
                    comando.Connection = conexao;
                    comando.CommandText = sqlcomando;
                    conexao.Open();
                    reg = comando.ExecuteReader();
                    if (reg.Read())
                    {

                        textBox1.Text = reg["animal"].ToString();
                        textBox2.Text = reg["animal"].ToString();
                        textBox3.Text = reg["raca"].ToString();
                        textBox4.Text = reg["especie"].ToString();
                        textBox5.Text = reg["cor_predom"].ToString();
                        maskedTextBox1.Text = Convert.ToDateTime(reg["nascimento"]).ToString("dd/MM/yyyy");
                        textBox7.Text = reg["tutor"].ToString();
                        textBox8.Text = reg["email"].ToString();
                        textBox9.Text = reg["fone"].ToString();
                        textBox10.Text = reg["caracteristicas"].ToString();
                        maskedTextBox2.Text = Convert.ToDateTime(reg["data_consulta"]).ToString("dd/MM/yyyy");




                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Erro na consulta: " + ex.Message);


                }
            }
        }
    }
}
