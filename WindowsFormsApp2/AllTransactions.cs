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

namespace WindowsFormsApp2
{
    public partial class AllTransactions : Form
    {
        SqlConnection con = new SqlConnection(
           @"Data Source= .\SQLEXPRESS; 
            Initial Catalog= admin;
            user id =sa ; 
            password =kist@123;");
        public AllTransactions()
        {
            InitializeComponent();

            button1.BackColor = System.Drawing.Color.Transparent;
            button1.Parent = pictureBox1;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;

            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;

            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;

            label3.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;

            label4.Parent = pictureBox1;
            label4.BackColor = Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 AllTransactions = new Form3();
            AllTransactions.ShowDialog();
        }

       

      
       

        private void AllTransactions_Load(object sender, EventArgs e)
        {
            ///for the stock available -------------------------------------------------
            string query1 = "select quantity,category from productlist";
            SqlCommand SqlCommand = new SqlCommand(query1, con);
            SqlDataAdapter sda = new SqlDataAdapter(SqlCommand);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            Decimal Product_InHand = 0;
           
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string Quantity = dt.Rows[i]["Quantity"].ToString();
                Product_InHand = Product_InHand + Convert.ToDecimal(Quantity);




            }
          
            textBox3.Text = Convert.ToString(Product_InHand);



           
            con.Close();

            string query2 = "select product_in from transactionHistory1";
            SqlCommand SqlCmd = new SqlCommand(query2, con);
            SqlDataAdapter ada = new SqlDataAdapter(SqlCmd);
            DataTable data = new DataTable();
            ada.Fill(data);
            Decimal Product_In = 0;
            for (int i = 0; i < data.Rows.Count; i++)
            {

                string Quantity = data.Rows[i]["product_in"].ToString();
                Product_In = Product_In + Convert.ToDecimal(Quantity);




            }
            textBox1.Text = Convert.ToString(Product_In);
            con.Close();

            string query3 = "select product_out from productOut";
            SqlCommand Cmd = new SqlCommand(query3, con);
            SqlDataAdapter sqlada = new SqlDataAdapter(Cmd);
            DataTable dta = new DataTable();
            sqlada.Fill(dta);
            Decimal Product_Out = 0;
            for (int i = 0; i < dta.Rows.Count; i++)
            {

                string Quantity = dta.Rows[i]["product_out"].ToString();
                Product_Out = Product_Out + Convert.ToDecimal(Quantity);




            }
            textBox2.Text = Convert.ToString(Product_Out);

            con.Close();


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashBoard AllTransactions = new DashBoard();
            AllTransactions.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            products AllTransactions = new products();
            AllTransactions.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            LowStock AllTransactions = new LowStock();
            AllTransactions.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Setting AllTransactions = new Setting();
            AllTransactions.ShowDialog();
        }
    }
}
