using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public static string ConnectString = "Provider = Microsoft.Jet.OLEDB.4.0; data source=HistoryDb.mdb;";

        private OleDbConnection myConnection;
        public Form3()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(ConnectString);
            myConnection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.Show();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Visible = true;
            string query = "SELECT Converted_from, Converted_to, Date_of FROM History ORDER BY Date_of";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            listBox1.Items.Clear();
            while (reader.Read())
            {

                listBox1.Items.Add(reader[0].ToString() + " - " + reader[1].ToString() + "  " + reader[2].ToString());
            }
            reader.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "userDBDataSet.User". При необходимости она может быть перемещена или удалена.
            this.userTableAdapter.Fill(this.userDBDataSet.User);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }
    }
}
