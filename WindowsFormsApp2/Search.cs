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

            string query = "SELECT * FROM productlist WHERE item_name LIKE '%' + @itemName + '%'";
            SqlCommand SqlCommand = new SqlCommand(query, con);
            SqlCommand.Parameters.AddWithValue("@itemName", textBox1.Text);

            con.Open();
            SqlDataReader reader = SqlCommand.ExecuteReader();

            while (reader.Read())
            {
                // Process the results here
            }

            reader.Close();
            con.Close();

        }
    }
}
