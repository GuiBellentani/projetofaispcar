using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Trabalho_FAISPCar
{
    public partial class Form1 : Form
    {
        string stringdeconexao = "server=localhost;uid=root;pwd=123456;database=faispcar";
        MySql.Data.MySqlClient.MySqlConnection conn;
        string strmensagem;
        public Form1()
        {
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = stringdeconexao;
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                strmensagem = ex.Message;
                MessageBox.Show(strmensagem);
            }
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {            
            string login = textBox1.Text;
            string senha = textBox2.Text;
            string strsql = "SELECT * FROM clientes WHERE usuario = '" + login + "'";
            try
            {
                MySqlCommand cmd = new MySqlCommand(strsql, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Login incorreto.");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                else
                {
                    string senhacerta = Convert.ToString(dt.Rows[0][8]);
                    if (senha != senhacerta)
                    {
                        MessageBox.Show("Senha incorreta.");
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                    else
                    {
                        Form2 sistema = new Form2();
                        sistema.Show();
                        Hide();
                    }
                }                
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
