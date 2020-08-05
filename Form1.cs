using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace login
{
    public partial class Form1 : Form
    {
        int fbal;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Form2 m1 = new Form2();
            m1.Show();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=desktop-ikq2ibg\\sqlexpress;Initial Catalog=onlinebanking;Integrated Security=True");
            con.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT balance FROM Table_1 WHERE  balance= (SELECT MIN(balance)  FROM Table_1); ", con);
            fbal = (int)cmd1.ExecuteScalar();
            fbal = fbal - int.Parse(textBox3.Text);
            string sql = "insert into Table_1(acc_id,acc_name,amount,balance) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + fbal + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            int i = cmd.ExecuteNonQuery();
            if (i != 0)
            {
                MessageBox.Show("Transferred Successfully....Avl bal: " + fbal);
            }
            else
            {
                MessageBox.Show("Error");
            }
            cmd.Dispose();
            con.Close();

        }
    }
}
