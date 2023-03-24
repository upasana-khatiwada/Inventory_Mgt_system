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
using System.Xml.Linq;

namespace WindowsFormsApp2
{
    public partial class Search : Form
    {
        SqlConnection con = new SqlConnection(
         @"Data Source= .\SQLEXPRESS; 
            Initial Catalog= admin;
            user id =sa ; 
            password =kist@123;");
        public Search()
        {
            
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //string query = "SELECT * FROM productlist WHERE item_name LIKE '%' + @itemName + '%'";
            //SqlCommand SqlCommand = new SqlCommand(query, con);
            //SqlCommand.Parameters.AddWithValue("@itemName", textBox1.Text);

            //con.Open();
            //SqlDataReader reader = SqlCommand.ExecuteReader();

            //while (reader.Read())
            //{
            //    // Process the results here
            //}

            //reader.Close();
            //con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //string query = "SELECT * FROM productlist WHERE item_name LIKE '%' + @itemName + '%'";
            //SqlCommand SqlCommand = new SqlCommand(query, con);
            //SqlCommand.Parameters.AddWithValue("@itemName", textBox1.Text);
            //SqlDataAdapter adapter = new SqlDataAdapter("SELECT Count(*) FROM employees1 WHERE name='" + textBox1.Text + "' and password='" + textBox2.Text + "' ", con);

            // string query ="SELECT * FROM productlist WHERE item_name='"+textBox1.Text +"'";
            //// SqlCommand SqlCommand = new SqlCommand(query, con);
            // DataTable dt = new DataTable();
            // SqlDataAdapter adapter = new SqlDataAdapter(query,con);
            // adapter.Fill(dt);
            // if (dt.Rows[0][0].ToString() == "1")
            // {
            //     this.Hide(); //hides the first form 
            //     //Form3 menu = new Form3();
            //     //menu.ShowDialog();
            //     MessageBox.Show("matched");


            // }
            // else
            // {
            //     MessageBox.Show("details didn't matched");

            // }





            //con.Open();

            //try
            //{
            //    DataTable dt = new DataTable();
            //    string query = "SELECT * FROM productlist WHERE item_name=@itemName";
            //    using (SqlCommand SqlCommand = new SqlCommand(query, con))
            //    {

            //        SqlCommand.Parameters.AddWithValue("itemName", textBox1.Text);

            //        SqlDataAdapter adapter = new SqlDataAdapter(SqlCommand);
            //        adapter.Fill(dt);
            //        if (dt.Rows[0][0].ToString() == "1")
            //        {
            //            this.Hide(); //hides the first form 
            //                         //Form3 menu = new Form3();
            //                         //menu.ShowDialog();
            //            MessageBox.Show("matched");


            //        }

            //    }
            //}
            //catch
            //{


            //        MessageBox.Show("details didn't matched");


            //}
            //con.Close();







            // SqlDataReader reader = SqlCommand.ExecuteReader();

            //while (reader.Read())
            //{
            //    if(textBox1.Text==)
            //}

            //reader.Close();





            //// 1. Connect to the database

            //con.Open();

            //// 2. Build a query
            //string query = "SELECT item_name,quantity FROM productlist WHERE item_name LIKE @itemName";

            //// 3. Execute the query
            //SqlCommand command = new SqlCommand(query, con);
            //command.Parameters.AddWithValue("@itemName", "%" + textBox1.Text + "%");
            //SqlDataReader reader = command.ExecuteReader();

            //// 4. Check for matches
            //if (reader.HasRows)
            //{
            //    // 5. Display the results
            //    string message = "The item was found:\n";
            //    while (reader.Read())
            //    {
            //        message += "- " + reader.GetString(0) + "\n";
            //    }
            //    MessageBox.Show(message);
            //}
            //else
            //{
            //    MessageBox.Show("No items were found.");
            //}

            //// Close the reader and connection
            //reader.Close();
            //con.Close();
           
            string itemName = textBox1.Text;
            string query = "SELECT quantity FROM productlist WHERE item_name = @ItemName";
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@ItemName", itemName);

            con.Open();
            object result = command.ExecuteScalar();
            con.Close();

            if (result != null)
            {
                int quantity = Convert.ToInt32(result);

               // int quantity = (int)result;
                MessageBox.Show("The quantity of " + itemName + " is " + quantity);
            }
            else
            {
                MessageBox.Show("No item found.");
            }
           

        }
    }
}
