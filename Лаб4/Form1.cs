using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace ComputerStoreApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            string connectionString = "server=localhost;user=root;password=37768126;database=ComputerStore;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Computers";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
                dataGridView1.Columns["Name"].HeaderText = "Назва комп’ютера";
                dataGridView1.Columns["CPU"].HeaderText = "Тип процесора";
                dataGridView1.Columns["Frequency"].HeaderText = "Тактова частота";
                dataGridView1.Columns["RAM"].HeaderText = "Обсяг ОЗУ";
                dataGridView1.Columns["HDD"].HeaderText = "Обсяг вінчестера";
                dataGridView1.Columns["GPU"].HeaderText = "Відеокарта";
                dataGridView1.Columns["SoundCard"].HeaderText = "Звукова карта";
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.FormClosed += (s, args) => LoadData();
            addForm.Show();
        }
    }
}
