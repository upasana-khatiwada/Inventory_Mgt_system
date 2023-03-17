using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.WinForms;
using System.Windows.Forms.Integration;
using static LiveCharts.WinForms.PieChart;
using System.Data.SqlClient;

namespace WindowsFormsApp2


{
    public partial class DashBoard : Form
    {
        public DashBoard()

        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(
            @"Data Source= .\SQLEXPRESS; 
            Initial Catalog= admin;
            user id =sa ; 
            password =kist@123;");

            button3.BackColor = System.Drawing.Color.Transparent;
            button3.Parent = pictureBox1;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;

            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;


            // Connect to your database and retrieve the data that you want to display in the pie chart
            //  SqlConnection conn = new SqlConnection("Data Source=your_server_name;Initial Catalog=your_database_name;Integrated Security=True");
            string query = "SELECT item_name, quantity FROM productlist";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            // Create DataTable to store results
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);


            // Define chart series
            SeriesCollection pieSeries = new SeriesCollection();

            // Create a new instance of the PieChart class from the LiveCharts library
            var pieChart = new LiveCharts.WinForms.PieChart();

            // Define the properties of the pie chart
            pieChart.Size = new System.Drawing.Size(418, 339);
            ////pieChart.Title = "Distribution of Categories";
            pieChart.LegendLocation = LiveCharts.LegendLocation.Right;

            // Add the data that you retrieved from the database to the pie chart
            //while (reader.Read())
            //{
            //    pieChart.Series.Add(new LiveCharts.Wpf.PieSeries
            //    {
            //        Title = reader["category"].ToString(),
            //        Values = new LiveCharts.ChartValues<int> { int.Parse(reader["total"].ToString()) },
            //        DataLabels = true
            //    });
            //}


            // Iterate through DataTable rows and add data to chart
            foreach (DataRow row in dataTable.Rows)
            {
                string itemName = row["item_name"].ToString();
                int quantity = int.Parse(row["quantity"].ToString());

                pieSeries.Add(new PieSeries
                {
                    Title = itemName,
                    Values = new ChartValues<int> { quantity },
                    DataLabels = true
                });
            }

            // Bind series to chart control
            pieChart.Series = pieSeries;


            // Display the pie chart on your user interface
            chart1.Controls.Add(pieChart);
            con.Close();
           
          
            //// Close database connection
            //reader.Close();


        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form3 DashBoard = new Form3();
            DashBoard.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductOut DashBoard = new ProductOut();
            DashBoard.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductIn DashBoard = new ProductIn();
            DashBoard.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            products DashBoard = new products();
            DashBoard.ShowDialog();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            LowStock DashBoard = new LowStock();
            DashBoard.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            AllTransactions DashBoard = new AllTransactions();
            DashBoard.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Setting DashBoard = new Setting();
            DashBoard.ShowDialog();
        }
    }
}

