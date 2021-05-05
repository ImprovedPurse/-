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
using System.Net;
using Newtonsoft.Json;
using System.IO;
 

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public static string ConnectString = "Provider = Microsoft.Jet.OLEDB.4.0; data source=HistoryDb.mdb;";

        private OleDbConnection myConnection;
       
        public Form2()
        {
            InitializeComponent();
           myConnection = new OleDbConnection(ConnectString);
            myConnection.Open();

         
        }

        public class Conve : Form2
        {


            public string RUB_to_USD(String vhodnie_dannie)
            {
                string query = "INSERT INTO History (Converted_from, Converted_to) VALUES ('RUB', 'USD')";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();

                double z = 0;
                z = double.Parse(vhodnie_dannie);
                z *= 0.013;
                return z.ToString();
            }

            public string RUB_to_EUR(String vhodnie_dannie)
            {
                string query = "INSERT INTO History (Converted_from, Converted_to) VALUES ('RUB', 'EUR')";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();

                double z = 0;
                z = double.Parse(vhodnie_dannie);
                z *= 0.011;
                return z.ToString();
            }

            public string RUB_to_BLR(String vhodnie_dannie)
            {

                string query = "INSERT INTO History (Converted_from, Converted_to) VALUES ('RUB', 'BYN')";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();

                double z = 0;
                z = double.Parse(vhodnie_dannie);
                z *= 0.034;
                return z.ToString();
            }

            public string USD_to_RUB(String vhodnie_dannie)
            {
                string query = "INSERT INTO History (Converted_from, Converted_to) VALUES ('USD', 'RUB')";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();

                double z = 0;
                z = double.Parse(vhodnie_dannie);
                z *= 75.09;
                return z.ToString();
            }

            public string USD_to_BLR(String vhodnie_dannie)
            {
                string query = "INSERT INTO History (Converted_from, Converted_to) VALUES ('USD', 'BYN')";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();

                double z = 0;
                z = double.Parse(vhodnie_dannie);
                z *= 2.57;
                return z.ToString();
            }

            public string USD_to_EUR(String vhodnie_dannie)
            {

                string query = "INSERT INTO History (Converted_from, Converted_to) VALUES ('USD', 'EUR')";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();

                double z = 0;
                z = double.Parse(vhodnie_dannie);
                z *= 0.83;
                return z.ToString();
            }

            public string BLR_to_USD(String vhodnie_dannie)
            {
                string query = "INSERT INTO History (Converted_from, Converted_to) VALUES ('BYN', 'USD')";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();

                double z = 0;
                z = double.Parse(vhodnie_dannie);
                z *= 0.39;
                return z.ToString();
            }

            public string BLR_to_EUR(String vhodnie_dannie)
            {
                string query = "INSERT INTO History (Converted_from, Converted_to) VALUES ('BYN', 'EUR')";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();

                double z = 0;
                z = double.Parse(vhodnie_dannie);
                z *= 0.32;
                return z.ToString();
            }

            public string BLR_to_RUB(String vhodnie_dannie)
            {
                string query = "INSERT INTO History (Converted_from, Converted_to) VALUES ('BYN', 'RUB')";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();

                double z = 0;
                z = double.Parse(vhodnie_dannie);
                z *= 29.25;
                return z.ToString();
            }

            public string EUR_to_USD(String vhodnie_dannie)
            {
                string query = "INSERT INTO History (Converted_from, Converted_to) VALUES ('EUR', 'USD')";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();

                double z = 0;
                z = double.Parse(vhodnie_dannie);
                z *= 1.21;
                return z.ToString();
            }

            public string EUR_to_BLR(String vhodnie_dannie)
            {
                string query = "INSERT INTO History (Converted_from, Converted_to) VALUES ('EUR', 'BYN')";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();

                double z = 0;
                z = double.Parse(vhodnie_dannie);
                z *= 3.1;
                return z.ToString();
            }

            public string EUR_to_RUB(String vhodnie_dannie)
            {
                string query = "INSERT INTO History (Converted_from, Converted_to) VALUES ('EUR', 'RUB')";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();

                double z = 0;
                z = double.Parse(vhodnie_dannie);
                z *= 90.47;
                return z.ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conve obj = new Conve();

            if ((comboBox1.SelectedIndex == 0) && (comboBox2.SelectedIndex == 0))
            {
                textBox2.Text = textBox1.Text;

            }

            if ((comboBox1.SelectedIndex == 0) && (comboBox2.SelectedIndex == 1))
            {
               textBox2.Text = obj.USD_to_EUR(textBox1.Text);

            }

            if ((comboBox1.SelectedIndex == 0) && (comboBox2.SelectedIndex == 2))
            {
               textBox2.Text = obj.USD_to_RUB(textBox1.Text);

            }

            if ((comboBox1.SelectedIndex == 0) && (comboBox2.SelectedIndex == 3))
            {
                textBox2.Text = obj.USD_to_BLR(textBox1.Text);

            }

            if ((comboBox1.SelectedIndex == 1) && (comboBox2.SelectedIndex == 0))
            {
               textBox2.Text = obj.EUR_to_USD(textBox1.Text);

            }

            if ((comboBox1.SelectedIndex == 1) && (comboBox2.SelectedIndex == 1))
            {
                textBox2.Text = (textBox1.Text);

            }

            if ((comboBox1.SelectedIndex == 1) && (comboBox2.SelectedIndex == 2))
            {
                textBox2.Text = obj.EUR_to_RUB(textBox1.Text);

            }

            if ((comboBox1.SelectedIndex == 1) && (comboBox2.SelectedIndex == 3))
            {
                textBox2.Text = obj.EUR_to_BLR(textBox1.Text);

            }

            if ((comboBox1.SelectedIndex == 2) && (comboBox2.SelectedIndex == 1))
            {
                textBox2.Text = obj.RUB_to_EUR(textBox1.Text);

            }

            if ((comboBox1.SelectedIndex == 2) && (comboBox2.SelectedIndex == 0))
            {
                textBox2.Text = obj.RUB_to_USD(textBox1.Text);
            }

            if ((comboBox1.SelectedIndex == 2) && (comboBox2.SelectedIndex == 2))
            {
                textBox2.Text = (textBox1.Text);
            }

            if ((comboBox1.SelectedIndex == 2) && (comboBox2.SelectedIndex == 3))
            {
                textBox2.Text = obj.RUB_to_BLR(textBox1.Text);
            }

            if ((comboBox1.SelectedIndex == 3) && (comboBox2.SelectedIndex == 0))
            {
                textBox2.Text = obj.BLR_to_USD(textBox1.Text);
            }

            if ((comboBox1.SelectedIndex == 3) && (comboBox2.SelectedIndex == 1))
            {
                textBox2.Text = obj.BLR_to_EUR(textBox1.Text);
            }

            if ((comboBox1.SelectedIndex == 3) && (comboBox2.SelectedIndex == 2))
            {
                textBox2.Text = obj.BLR_to_RUB(textBox1.Text);
            }

            if ((comboBox1.SelectedIndex == 3) && (comboBox2.SelectedIndex == 3))
            {
                textBox2.Text = (textBox1.Text);
            }

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
               string s;
               WebRequest request = WebRequest.Create("https://www.nbrb.by/api/exrates/rates/145");
               WebResponse response = request.GetResponse();

            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    s = reader.ReadLine();
                    s = s.Substring(125,4);

                    MessageBox.Show(s);
                }
            }
            response.Close();
          
        }
    }
}
