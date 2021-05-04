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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "userDBDataSet.User". При необходимости она может быть перемещена или удалена.
            this.userTableAdapter.Fill(this.userDBDataSet.User);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            userBindingSource.EndEdit();
            userTableAdapter.Update(userDBDataSet);
            Form3 form3 = new Form3();
            this.Hide();
            form3.Show();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.Show();
        }
    }
}
