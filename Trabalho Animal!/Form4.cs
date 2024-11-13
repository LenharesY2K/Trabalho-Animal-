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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string criterio = textBox1.Text.ToString();
            string sqlcomando = "";
            SqlConnection conexao = null;
            SqlDataReader reg = null;
            if (criterio == "")
                MessageBox.Show("Digite a expressão");
            else
                sqlcomando = "SELECT * FROM Animais Where animal LIKE '" + criterio + "%'";

            try
            {
                conexao = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\20231350265\Documents\bancoanimal.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexao;
                comando.CommandText = sqlcomando;
                conexao.Open();
                reg = comando.ExecuteReader();
                button1.Hide();
                button2.Show();
                button3.Show();
                if (reg.Read())
                {

                    textBox2.Text = reg["animal"].ToString();
                    textBox3.Text = reg["raca"].ToString();
                    textBox4.Text = reg["especie"].ToString();
                    textBox5.Text = reg["cor_predom"].ToString();
                    maskedTextBox1.Text = DateTime.Parse(reg["nascimento"].ToString()).ToString("dd/MM/yyyy");
                    textBox6.Text = reg["tutor"].ToString();
                    textBox7.Text = reg["email"].ToString();
                    textBox8.Text = reg["fone"].ToString();
                    textBox9.Text = reg["caractersiticas"].ToString();
                    maskedTextBox2.Text = DateTime.Parse(reg["data_consulta"].ToString()).ToString("dd/MM/yyyy");

                    textBox1.Text = "";
                    textBox2.Focus();

                }
                else
                {
                    MessageBox.Show("Não Existem registros!");
                    textBox1.Text = "";
                    textBox2.Focus();
                    button2.Hide();
                    button3.Hide();
                    button1.Show();

                }
            }
            //Trata a exceção
            catch (SqlException ex)
            {
                MessageBox.Show("Erro na consulta: " + ex.Message);
                textBox1.Text = "";
                textBox2.Focus();
                button2.Hide();
                button3.Hide();
                button1.Show();
            }
            finally
            {
                //fecha a conexao 
                conexao.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexao = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\20231350265\Documents\bancoanimal.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexao;
                comando.CommandText = "UPDATE animais set animal = @animal, raca = @raca, especie = @especie, cor_predom = @cor_predom, nascimento = @nascimento, tutor = @tutor, email = @email, fone = @fone, caracteristicas = @caracteristicas, data_consulta = @data_consulta WHERE animal = @animal;";
                comando.Parameters.AddWithValue("@animal", textBox2.Text);
                comando.Parameters.AddWithValue("@raca", textBox3.Text);
                comando.Parameters.AddWithValue("@especie", textBox4.Text);
                comando.Parameters.AddWithValue("@cor_predom", textBox5.Text);
                comando.Parameters.AddWithValue("@nascimento", DateTime.Parse(maskedTextBox1.Text));
                comando.Parameters.AddWithValue("@tutor", textBox6.Text);
                comando.Parameters.AddWithValue("@email", textBox7.Text);
                comando.Parameters.AddWithValue("@fone", textBox8.Text);
                comando.Parameters.AddWithValue("@caracteristicas", textBox9.Text);
                comando.Parameters.AddWithValue("@data_consulta", DateTime.Parse(maskedTextBox2.Text));
                conexao.Open();
                comando.ExecuteNonQuery();
                conexao.Close();
                MessageBox.Show("Registro Alterado com Sucesso!");
                textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = maskedTextBox1.Text = textBox6.Text = textBox7.Text = textBox8.Text = textBox9.Text = maskedTextBox2.Text =  "";
                textBox1.Focus();
                button2.Hide();
                button3.Hide();
                button1.Show();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao Alterar! -->" + erro.Message);
                textBox5.Text = "";
                textBox5.Focus();
                button2.Hide();
                button3.Hide();
                button1.Show();
            }
        }

        private void Form4_Load_1(object sender, EventArgs e)
        {
            button2.Hide();
            button3.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma exclusão? ", "Excluir", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ExcluirDados();
                //this.Close();
            }
        }
        private void ExcluirDados()
        {
            SqlConnection conexao = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\20231350265\Documents\bancoanimal.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");

            SqlCommand cmdExcluir = new SqlCommand();
            cmdExcluir.Connection = conexao;
            cmdExcluir.Parameters.AddWithValue("@animal", textBox1.Text);
            cmdExcluir.CommandText = "DELETE FROM Animais WHERE animal=@animal";


            try
            {
                conexao.Open();
                cmdExcluir.ExecuteNonQuery();
                MessageBox.Show("Dados Excluídos com sucesso.");
                button2.Hide();
                button3.Hide();
                button1.Show();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                button2.Hide();
                button3.Hide();
                button1.Show();
            }
            finally
            {
                conexao.Close();
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = maskedTextBox1.Text = textBox6.Text = textBox7.Text = textBox8.Text = textBox9.Text = maskedTextBox2.Text ="";
                textBox5.Focus();
                button2.Hide();
                button3.Hide();
                button1.Show();
            }
        }
    }
}
