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
                string s;
                WebRequest request = WebRequest.Create("https://www.nbrb.by/api/exrates/rates/298");
                WebResponse response = request.GetResponse();

                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        s = reader.ReadLine();
                        s = s.Substring(134, 4);
                        s = s.Replace(".", ",");

                    }
                }
                response.Close();
                double kurs_Rub = (double.Parse(s) / 100);

                string s_USD;
                 request = WebRequest.Create("https://www.nbrb.by/api/exrates/rates/145");
                 response = request.GetResponse();

                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        s_USD = reader.ReadLine();
                        s_USD = s_USD.Substring(125, 4);
                        s_USD = s_USD.Replace(".", ",");

                    }
                }
                response.Close();

                double kurs_USd = double.Parse(s_USD);
                double kurs = kurs_Rub / kurs_USd;

                string query = "INSERT INTO History (Converted_from, Converted_to) VALUES ('RUB', 'USD')";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
                
                double z = 0;
                z = double.Parse(vhodnie_dannie);
                z *= kurs;
                return z.ToString();
            }

            public string RUB_to_EUR(String vhodnie_dannie)
            {
                string s;
                WebRequest request = WebRequest.Create("https://www.nbrb.by/api/exrates/rates/298");
                WebResponse response = request.GetResponse();

                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        s = reader.ReadLine();
                        s = s.Substring(134, 4);
                        s = s.Replace(".", ",");

                    }
                }
                response.Close();
                double kurs_Rub = (double.Parse(s) / 100);

                string s_eur;
                request = WebRequest.Create("https://www.nbrb.by/api/exrates/rates/292");
                response = request.GetResponse();

                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        s_eur = reader.ReadLine();
                        s_eur = s_eur.Substring(119, 4);
                        s_eur = s_eur.Replace(".", ",");

                    }
                }
                response.Close();

                double kurs_eur = double.Parse(s_eur);
                double kurs = kurs_Rub / kurs_eur;
                kurs = Math.Round(kurs, 4);

                string query = "INSERT INTO History (Converted_from, Converted_to) VALUES ('RUB', 'EUR')";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();

                double z = 0;
                z = double.Parse(vhodnie_dannie);
                z *= kurs;
                z = Math.Round(z, 3);
                return z.ToString();
            }

            public string RUB_to_BLR(String vhodnie_dannie)
            {

                string s;
                WebRequest request = WebRequest.Create("https://www.nbrb.by/api/exrates/rates/298");
                WebResponse response = request.GetResponse();

                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        s = reader.ReadLine();
                        s = s.Substring(134, 4);
                        s = s.Replace(".", ",");

                    }
                }
                response.Close();

                string query = "INSERT INTO History (Converted_from, Converted_to) VALUES ('RUB', 'BYN')";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();

                double kurs = (double.Parse(s) / 100);
                double z = 0;
                z = double.Parse(vhodnie_dannie);
                z *= kurs;
                return z.ToString();
            }

            public string USD_to_RUB(String vhodnie_dannie)
            {
                string s;
                WebRequest request = WebRequest.Create("https://www.nbrb.by/api/exrates/rates/298");
                WebResponse response = request.GetResponse();

                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        s = reader.ReadLine();
                        s = s.Substring(134, 4);
                        s = s.Replace(".", ",");

                    }
                }
                response.Close();
                double kurs_Rub = (double.Parse(s) / 100);

                string s_USD;
                request = WebRequest.Create("https://www.nbrb.by/api/exrates/rates/145");
                response = request.GetResponse();

                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        s_USD = reader.ReadLine();
                        s_USD = s_USD.Substring(125, 4);
                        s_USD = s_USD.Replace(".", ",");

                    }
                }
                response.Close();

                double kurs_USd = double.Parse(s_USD);
                double kurs = kurs_USd / kurs_Rub;
                kurs = Math.Round(kurs, 4);

                string query = "INSERT INTO History (Converted_from, Converted_to) VALUES ('USD', 'RUB')";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();

                double z = 0;
                z = double.Parse(vhodnie_dannie);
                z *= kurs;
                z = Math.Round(z, 3);
                return z.ToString();
            }

            public string USD_to_BLR(String vhodnie_dannie)
            {
                string s_BYN_USD;
                WebRequest request = WebRequest.Create("https://www.nbrb.by/api/exrates/rates/145");
                WebResponse response = request.GetResponse();

                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        s_BYN_USD = reader.ReadLine();
                        s_BYN_USD = s_BYN_USD.Substring(125, 4);
                        s_BYN_USD = s_BYN_USD.Replace(".", ",");

                    }
                }
                response.Close();

                string query = "INSERT INTO History (Converted_from, Converted_to) VALUES ('USD', 'BYN')";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
                
                double kurs_BYN_USD = double.Parse(s_BYN_USD);
                double z = 0;
                z = double.Parse(vhodnie_dannie);
                z *= kurs_BYN_USD;
                return z.ToString();
            }

            public string USD_to_EUR(String vhodnie_dannie)
            {
                string s;
                WebRequest request = WebRequest.Create("https://www.nbrb.by/api/exrates/rates/292");
                WebResponse response = request.GetResponse();

                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        s = reader.ReadLine();
                        s = s.Substring(119, 4);
                        s = s.Replace(".", ",");

                    }
                }
                response.Close();
                double kurs_Eur = double.Parse(s) ;

                string s_USD;
                request = WebRequest.Create("https://www.nbrb.by/api/exrates/rates/145");
                response = request.GetResponse();

                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        s_USD = reader.ReadLine();
                        s_USD = s_USD.Substring(125, 4);
                        s_USD = s_USD.Replace(".", ",");

                    }
                }
                response.Close();

                double kurs_USd = double.Parse(s_USD);
                double kurs = kurs_USd / kurs_Eur;
                kurs = Math.Round(kurs, 4);

                string query = "INSERT INTO History (Converted_from, Converted_to) VALUES ('USD', 'EUR')";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();

                double z = 0;
                z = double.Parse(vhodnie_dannie);
                z *= kurs;
                z = Math.Round(z, 3);
                return z.ToString();
            }

            public string BLR_to_USD(String vhodnie_dannie)
            {
               string s_BYN_USD;
                WebRequest request = WebRequest.Create("https://www.nbrb.by/api/exrates/rates/145");
                WebResponse response = request.GetResponse();

                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        s_BYN_USD = reader.ReadLine();
                        s_BYN_USD = s_BYN_USD.Substring(125, 4);
                        s_BYN_USD = s_BYN_USD.Replace(".", ",");

                    }
                }
                response.Close();

                string query = "INSERT INTO History (Converted_from, Converted_to) VALUES ('BYN', 'USD')";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();

                double kurs_BYN_USD = (1/double.Parse(s_BYN_USD));
                double kurs = Math.Round(kurs_BYN_USD, 4);
                double z = 0;
                z = double.Parse(vhodnie_dannie);
                z =z* kurs;
                z = Math.Round(z, 3);
                return z.ToString();
            }

            public string BLR_to_EUR(String vhodnie_dannie)
            {
                string s;
                WebRequest request = WebRequest.Create("https://www.nbrb.by/api/exrates/rates/292");
                WebResponse response = request.GetResponse();

                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        s = reader.ReadLine();
                        s = s.Substring(119, 4);
                        s = s.Replace(".", ",");

                    }
                }
                response.Close();


                string query = "INSERT INTO History (Converted_from, Converted_to) VALUES ('BYN', 'EUR')";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();

                double kurs = (1/double.Parse(s));
                kurs = Math.Round(kurs, 4);
                double z = 0;
                z = double.Parse(vhodnie_dannie);
                z *= kurs;
                z = Math.Round(z, 3);
                return z.ToString();
            }

            public string BLR_to_RUB(String vhodnie_dannie)
            {
                string s;
                WebRequest request = WebRequest.Create("https://www.nbrb.by/api/exrates/rates/298");
                WebResponse response = request.GetResponse();

                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        s = reader.ReadLine();
                        s = s.Substring(134, 4);
                        s = s.Replace(".", ",");

                    }
                }
                response.Close();

                double kurs_RUB = (1/(double.Parse(s) / 100));
                double kurs = Math.Round(kurs_RUB, 4);


                string query = "INSERT INTO History (Converted_from, Converted_to) VALUES ('BYN', 'RUB')";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();

                
                double z = 0;
                z = double.Parse(vhodnie_dannie);
                z *= kurs;
                z = Math.Round(z, 3);
                return z.ToString();
            }

            public string EUR_to_USD(String vhodnie_dannie)
            {
                string s;
                WebRequest request = WebRequest.Create("https://www.nbrb.by/api/exrates/rates/292");
                WebResponse response = request.GetResponse();

                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        s = reader.ReadLine();
                        s = s.Substring(119, 4);
                        s = s.Replace(".", ",");

                    }
                }
                response.Close();
                double kurs_Eur = double.Parse(s);

                string s_USD;
                request = WebRequest.Create("https://www.nbrb.by/api/exrates/rates/145");
                response = request.GetResponse();

                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        s_USD = reader.ReadLine();
                        s_USD = s_USD.Substring(125, 4);
                        s_USD = s_USD.Replace(".", ",");

                    }
                }
                response.Close();

                double kurs_USd = double.Parse(s_USD);
                double kurs = kurs_Eur / kurs_USd;
                kurs = Math.Round(kurs, 4);

                string query = "INSERT INTO History (Converted_from, Converted_to) VALUES ('EUR', 'USD')";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();

                double z = 0;
                z = double.Parse(vhodnie_dannie);
                z *= kurs;
                z = Math.Round(z, 3);
                return z.ToString();
            }

            public string EUR_to_BLR(String vhodnie_dannie)
            {
                string s;
                WebRequest request = WebRequest.Create("https://www.nbrb.by/api/exrates/rates/292");
                WebResponse response = request.GetResponse();

                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        s = reader.ReadLine();
                        s = s.Substring(119, 4);
                        s = s.Replace(".", ",");

                    }
                }
                response.Close();

                string query = "INSERT INTO History (Converted_from, Converted_to) VALUES ('EUR', 'BYN')";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();

                double kurs = double.Parse(s);
                double z = 0;
                z = double.Parse(vhodnie_dannie);
                z *= kurs;
                return z.ToString();
            }

            public string EUR_to_RUB(String vhodnie_dannie)
            {
                string s;
                WebRequest request = WebRequest.Create("https://www.nbrb.by/api/exrates/rates/298");
                WebResponse response = request.GetResponse();

                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        s = reader.ReadLine();
                        s = s.Substring(134, 4);
                        s = s.Replace(".", ",");

                    }
                }
                response.Close();
                double kurs_Rub = (double.Parse(s) / 100);

                string s_eur;
                request = WebRequest.Create("https://www.nbrb.by/api/exrates/rates/292");
                response = request.GetResponse();

                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        s_eur = reader.ReadLine();
                        s_eur = s_eur.Substring(119, 4);
                        s_eur = s_eur.Replace(".", ",");

                    }
                }
                response.Close();

                double kurs_eur = double.Parse(s_eur);
                double kurs = kurs_eur / kurs_Rub;
                kurs = Math.Round(kurs, 4);

                string query = "INSERT INTO History (Converted_from, Converted_to) VALUES ('EUR', 'RUB')";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();

                double z = 0;
                z = double.Parse(vhodnie_dannie);
                z *=kurs;
                z = Math.Round(z, 3);
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
                    s=s.Replace(".", ",");

                    MessageBox.Show(s);
                }
            }
            response.Close();
          
        }
    }
}
