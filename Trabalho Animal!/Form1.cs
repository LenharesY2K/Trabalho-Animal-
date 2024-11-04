using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabalho_Animal_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Cria uma nova instância de Form2
            Form2 novoForm = new Form2();

            // Exibe o novo formulário
            novoForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Cria uma nova instância de Form2
            Form3 novoForm = new Form3();

            // Exibe o novo formulário
            novoForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Cria uma nova instância de Form2
            Form4 novoForm = new Form4();

            // Exibe o novo formulário
            novoForm.Show();
        }
    }
}
