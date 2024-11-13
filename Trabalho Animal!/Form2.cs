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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexao = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\20231350265\Documents\bancoanimal.mdf;Integrated Security=True;Connect Timeout=30");
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexao;
                comando.CommandText = "INSERT INTO Animais (animal,raca,especie,cor_predom,nascimento,tutor,email,fone,caracteristicas,data_consulta) values (@animal,@raca,@especie,@cor_predom,@nascimento,@tutor,@email,@fone,@caracteristicas,@data_consulta)";
                comando.Parameters.AddWithValue("@animal", textBox1.Text);
                comando.Parameters.AddWithValue("@raca", textBox2.Text);
                comando.Parameters.AddWithValue("@especie", textBox3.Text);
                comando.Parameters.AddWithValue("@cor_predom", textBox4.Text);
                comando.Parameters.AddWithValue("@nascimento", DateTime.Parse(maskedTextBox1.Text));
                comando.Parameters.AddWithValue("@tutor", textBox6.Text);
                comando.Parameters.AddWithValue("@email", textBox7.Text);
                comando.Parameters.AddWithValue("@fone", textBox8.Text);
                comando.Parameters.AddWithValue("@caracteristicas", textBox9.Text);
                comando.Parameters.AddWithValue("@data_consulta", DateTime.Parse(maskedTextBox2.Text));
                conexao.Open();
                comando.ExecuteNonQuery();
                conexao.Close();
                MessageBox.Show("Registro Inserido com Sucesso!");
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = maskedTextBox1.Text = textBox6.Text = textBox7.Text = textBox8.Text = textBox9.Text = maskedTextBox2.Text = "";
                textBox1.Focus();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao Incluir!==> " + erro.Message);
            }
        }
    }
    
}
