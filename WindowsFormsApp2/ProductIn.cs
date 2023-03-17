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
    public partial class ProductIn : Form
    {
        SqlConnection con = new SqlConnection(
         @"Data Source= .\SQLEXPRESS; 
            Initial Catalog= admin;
            user id =sa ; 
            password =kist@123;");

        public ProductIn()
        {
            InitializeComponent();
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;

            button1.BackColor = System.Drawing.Color.Transparent;
            button1.Parent = pictureBox1;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;

            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;

            label3.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;

            label4.Parent = pictureBox1;
            label4.BackColor = Color.Transparent;

            label5.Parent = pictureBox1;
            label5.BackColor = Color.Transparent;

            label6.Parent = pictureBox1;
            label6.BackColor = Color.Transparent;

        }
        public ProductIn(string value1)
        {
            InitializeComponent();
            textBox1.Text = value1;

            ///

            con.Open();

            ///
            string query = "select * from productlist";

            SqlCommand SqlCommand = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(SqlCommand);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            decimal RowNum = dt.Rows.Count;




            //to fetch the total available stock of the selected item---------------------------------------------------------
            string query1 = "select item_name quantity from productlist";
            SqlCommand Command = new SqlCommand(query1, con);
            Decimal totalQty = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string Item_Name = dt.Rows[i]["item_name"].ToString();

                if (value1 == Item_Name)
                {
                    string Quantity = dt.Rows[i]["Quantity"].ToString();

                    totalQty = totalQty + Convert.ToDecimal(Quantity);
                }







            }

            textBox2.Text = Convert.ToString(totalQty);
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashBoard ProductIn = new DashBoard();
            ProductIn.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            listboxForProductIn showlist1 = new listboxForProductIn();
            showlist1.ShowDialog();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();

            Decimal addedQty = 0;



            string item_selected = textBox1.Text;
            string query = "Select count(*) From productlist WHERE item_name='" + item_selected + "'";


            addedQty = Convert.ToDecimal(textBox3.Text) + Convert.ToDecimal(textBox2.Text);



            string query1 = "UPDATE productlist SET quantity=@qty where item_name  = @item ";
            SqlCommand SqlCommand = new SqlCommand(query1, con);

            SqlCommand.Parameters.AddWithValue("@item", item_selected);



            SqlCommand.Parameters.AddWithValue("@qty", addedQty);
            SqlCommand.ExecuteNonQuery();
            MessageBox.Show("Product Added!!");

            string query2 = "select quantity,category from productlist";
            SqlCommand cmd = new SqlCommand(query2, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            Decimal Product_InHand = 0;
            //Decimal Product_Out = 0;
            //Decimal Product_In = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string Quantity = dt.Rows[i]["Quantity"].ToString();
                Product_InHand = Product_InHand + Convert.ToDecimal(Quantity);

            }
            con.Close();
           /* textBox1.Text = Convert.ToString(Product_In);
            textBox2.Text = Convert.ToString(Product_Out);*/
           string productInHand = Convert.ToString(Product_InHand);

            Decimal productAdded =Convert.ToDecimal(productInHand )+ Convert.ToDecimal(textBox3.Text);


            SqlDataAdapter ada = new SqlDataAdapter();

            string query3 = "INSERT INTO transactionHistory1(product_in) VALUES(@in)";
            con.Open();

            // Prepare the command to be executed on the db
            SqlCommand cmd1 = new SqlCommand(query3, con);

                // Create and set the parameters values 
                // cmd1.Parameters.Add("@inme", SqlDbType.NVarChar).Value = productAdded;
               cmd1.Parameters.AddWithValue("@in", productAdded);
            //cmd1.ExecuteNonQuery();
            //cmd1.Parameters.Add("@id", SqlDbType.NVarChar).Value = textBox2.Text;

            //cmd1.Parameters.Add("@qty", SqlDbType.NVarChar).Value = textBox3.Text;
            //cmd1.Parameters.Add("@cat", SqlDbType.NVarChar).Value = textBox4.Text;

            // Let's ask the db to execute the query
            int rowsAdded = cmd1.ExecuteNonQuery();
            if (rowsAdded > 0)
            {
                MessageBox.Show("Product Added!!");
                this.Hide(); //hides the first form 
                //products LoginForm = new products();
                //LoginForm.ShowDialog();
            }


            else
            {
                // Well this should never really happen
                MessageBox.Show("No Product Added");
            }


            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashBoard ProductIn = new DashBoard();
            ProductIn.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            products ProductIn = new products();
            ProductIn.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            LowStock ProductIn = new LowStock();
            ProductIn.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            AllTransactions ProductIn = new AllTransactions();
            ProductIn.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Setting ProductIn = new Setting();
            ProductIn.ShowDialog();
        }
    }
    }
    

        //  string qu = "Select product_in from transactionHistory";
        // Decimal addedProduct = 0;
        // SqlCommand cmd = new SqlCommand(qu, con);
        //   SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        // sda.Fill(dt);
        //Decimal addedProduct = Convert.ToDecimal(textBox3.Text);

        //string query2 = "UPDATE transactionHistory SET product_in = @in";
        //SqlCommand sqlCommand = new SqlCommand(query2, con);
        //SqlDataAdapter sda =new SqlDataAdapter(sqlCommand);
        //sqlCommand.Parameters.AddWithValue("@in",addedProduct);
        //SqlCommand.ExecuteNonQuery();
        //MessageBox.Show("Product Added!!");



        //con.Close();



    
