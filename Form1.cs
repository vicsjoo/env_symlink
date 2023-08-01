using System;
using System.Collections;
using System.Data;

namespace env_symlink
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            populateGrid();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void populateGrid()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Variable", typeof(string));
            dt.Columns.Add("Value", typeof(string));

            foreach (DictionaryEntry de in Environment.GetEnvironmentVariables())
            {
                if (de.Value.ToString().Contains("\\") ||
                    (de.Value.ToString().Contains("//")))
                {
                    dt.Rows.Add(de.Key, de.Value);
                }
            }

            dataGridView1.DataSource = dt;
        }
        // get all windows path environment variables



    }
}