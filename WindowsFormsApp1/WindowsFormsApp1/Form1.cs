using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "userDBDataSet.User". При необходимости она может быть перемещена или удалена.
            this.userTableAdapter.Fill(this.userDBDataSet.User);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1[3, 0].Value.ToString() == textBox1.Text)
            {
                
                MessageBox.Show("   Ok");
                Form2 form = new Form2();
                this.Hide();
                form.Show();
               
            }
            else
                MessageBox.Show("Неверный пароль");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
