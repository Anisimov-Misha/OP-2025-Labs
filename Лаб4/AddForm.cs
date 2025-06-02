using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace ComputerStoreApp
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string cpu = textBoxCPU.Text;
            string freq = textBoxFreq.Text;
            string ram = textBoxRAM.Text;
            string hdd = textBoxHDD.Text;
            string gpu = textBoxGPU.Text;
            string sound = textBoxSound.Text;
            string connStr = "server=localhost;user=root;password=37768126;database=ComputerStore;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = @"INSERT INTO Computers 
                                (Name, CPU, Frequency, RAM, HDD, GPU, SoundCard) 
                                VALUES (@name, @cpu, @freq, @ram, @hdd, @gpu, @sound)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@cpu", cpu);
                    cmd.Parameters.AddWithValue("@freq", freq);
                    cmd.Parameters.AddWithValue("@ram", ram);
                    cmd.Parameters.AddWithValue("@hdd", hdd);
                    cmd.Parameters.AddWithValue("@gpu", gpu);
                    cmd.Parameters.AddWithValue("@sound", sound);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Комп'ютер додано!");
            this.Close();
        }
    }
}
