using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Trabalho_FAISPCar
{
    public partial class Form2 : Form
    {
        string stringdeconexao = "server=localhost;uid=root;pwd=123456;database=faispcar";
        MySql.Data.MySqlClient.MySqlConnection conn;
        string strmensagem;
        public Form2()
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

        private void button1_Click(object sender, EventArgs e)
        {            
            Form1 login = new Form1();
            login.Show();
            Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            for (int x = 1; x <= 36; x++)
            {
                comboBox5.Items.Add(x);
            }
            comboBox3.Items.Add("Gasolina");
            comboBox3.Items.Add("Diesel");
            comboBox3.Items.Add("Flex");
            comboBox3.Items.Add("Elétrico");
            comboBox5.Items.Add("FIAT");
            comboBox5.Items.Add("FORD");
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            string marca = comboBox5.Text;
            if (marca == "FIAT")
            {
                comboBox2.Items.Add("500");
                comboBox2.Items.Add("UNO");
            }
            else if (marca == "FORD")
            {
                comboBox2.Items.Add("KA");
                comboBox2.Items.Add("FUSION");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox12.Text == "" ||
                textBox3.Text == "" || textBox9.Text == "" ||
                textBox5.Text == "" || textBox6.Text == "" ||
                textBox11.Text == "" || textBox8.Text == "" ||
                textBox10.Text == "" || textBox13.Text == "")
            {
                MessageBox.Show("Campos em branco!!!!");
            }
            else
            {
                string strsql = "INSERT INTO carros ( marca, carroceria, ano, quilometragem," +
                    "modelo, placa, versao, valor_compra, valor_venda, lucro, data_compra," +
                    "data_venda, combustivel, cor)" +
                "VALUES (" +
               
                "'" + comboBox5.Text.Trim() + "'" + "," +
                "'" + textBox3.Text.Trim() + "'" + "," +
                "'" + textBox8.Text.Trim() + "'" + "," +
                int.Parse(textBox7.Text.Trim()) + "," +
                "'" + comboBox2.Text.Trim() + "'" + "," +
                "'" + textBox6.Text.Trim() + "'" + "," +
                "'" + textBox5.Text.Trim() + "'" + "," +
                float.Parse(textBox12.Text.Trim()) + "," +
                float.Parse(textBox11.Text.Trim()) + "," +
                float.Parse(textBox10.Text.Trim()) + "," +
                "'" + textBox9.Text.Trim() + "'" + "," +
                "'" + textBox13.Text.Trim() + "'" + "," +
                "'" + comboBox3.Text.Trim() + "'" + "," +
                "'" + comboBox4.Text.Trim() + "'" +
                 ");";

                try
                {
                    MySqlCommand cmd = new MySqlCommand(strsql, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cadastro realizado com sucesso.");
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Campo em branco.");
            }
            else
            {
                int codigo = int.Parse(textBox1.Text.Trim());
                string strsql = "SELECT * FROM carros WHERE cod_car = " + codigo + " and deleted_by is null and " +
                    "deleted_at is null";
                try
                {
                    MySqlCommand cmd = new MySqlCommand(strsql, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        textBox1.Text = Convert.ToString(dt.Rows[0][0]);
                        comboBox5.Text = Convert.ToString(dt.Rows[0][1]);
                        textBox3.Text = Convert.ToString(dt.Rows[0][2]);
                        textBox8.Text = Convert.ToString(dt.Rows[0][3]);
                        textBox7.Text = Convert.ToString(dt.Rows[0][4]);
                        comboBox2.Text = Convert.ToString(dt.Rows[0][5]);
                        textBox6.Text = Convert.ToString(dt.Rows[0][6]);
                        textBox5.Text = Convert.ToString(dt.Rows[0][7]);
                        textBox12.Text = Convert.ToString(dt.Rows[0][8]);
                        textBox11.Text = Convert.ToString(dt.Rows[0][9]);
                        textBox10.Text = Convert.ToString(dt.Rows[0][10]);
                        textBox9.Text = Convert.ToString(dt.Rows[0][11]);
                        textBox13.Text = Convert.ToString(dt.Rows[0][12]);
                        comboBox3.Text = Convert.ToString(dt.Rows[0][13]);
                        comboBox4.Text = Convert.ToString(dt.Rows[0][14]);

                    }
                    else
                    {
                        MessageBox.Show("Não encontrado");
                    }
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Campo em branco.");
            }
            else
            {
                int codigo = int.Parse(textBox1.Text.Trim());
                string strsql = "UPDATE carros set deleted_by = 1," +
                    " deleted_at = now() WHERE cod_car = " + codigo; 
                if (MessageBox.Show("Deseja excluir?","Excluir",MessageBoxButtons.YesNo) == DialogResult.Yes )
                {
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand(strsql,conn);
                        cmd.ExecuteNonQuery(); // Altera a tabela
                        MessageBox.Show("Excluido com sucesso.");
                    }
                    catch(MySqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox5.Text = "";
            textBox3.Text = "";
            textBox8.Text = "";
            textBox7.Text = "";
            comboBox2.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
            textBox12.Text = "";
            textBox11.Text = "";
            textBox10.Text = "";
            textBox9.Text = "";
            textBox13.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox12.Text == "" ||
                textBox3.Text == "" || textBox9.Text == "" ||
                textBox5.Text == "" || textBox6.Text == "" ||
                textBox11.Text == "" || textBox8.Text == "" ||
                textBox10.Text == "" || textBox13.Text == "")
            {
                MessageBox.Show("Campos em branco!!!!");
            }
            else
            {
                int codigo = int.Parse(textBox1.Text);
                string strsql = "UPDATE carros SET " +
                "cod_car = " + "'" + textBox1.Text.Trim() + "'" + "," +
                "marca = " + "'" + comboBox5.Text.Trim() + "'" + "," +
                "carroceria = " + "'" + textBox3.Text.Trim() + "'" + "," +
                "ano = " + "'" + textBox8.Text.Trim() + "'" + "," +
                "quilometragem = " + int.Parse(textBox7.Text.Trim()) + "," +
                "modelo = " + "'" + comboBox2.Text.Trim() + "'" + "," +
                "placa = " + "'" + textBox6.Text.Trim() + "'" + "," +
                "versao = " + "'" + textBox5.Text.Trim() + "'" + "," +
                "valor_compra = " + float.Parse(textBox12.Text.Trim()) + "," +
                "valor_venda = " + float.Parse(textBox11.Text.Trim()) + "," +
                "lucro = " + float.Parse(textBox10.Text.Trim()) + "," +
                "data_compra = " + "'" + textBox9.Text.Trim() + "'" + "," +
                "data_venda = " + "'" + textBox13.Text.Trim() + "'" + "," +
                "combustivel = " + "'" + comboBox3.Text.Trim() + "'" + "," +
                "cor = " + "'" + comboBox4.Text.Trim()  + "'" +
                " WHERE cod_car = " + codigo + ";";


                if (MessageBox.Show("Deseja alterar?", "Alterar", MessageBoxButtons.YesNo)
                    == DialogResult.Yes)
                {
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand(strsql, conn);
                        cmd.ExecuteNonQuery(); // Altera a tabela
                        MessageBox.Show("Alterado com sucesso.");
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }
}
