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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SqlConnection _connection;
        SqlCommand command;
        SqlDataAdapter da;

        public Form1()
        {
            InitializeComponent();
        }
        void MusteriGetir()
        {
            _connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=takip;Integrated Security=True;");
            _connection.Open();
            da = new SqlDataAdapter("Select * from musteri",_connection);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
            _connection.Close();

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            MusteriGetir();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Insert into musteri (ad,soyad,dtarih,tel) values (@ad,@soyad,@dtarih,@tel)",_connection);
            command.Parameters.AddWithValue("@ad", tbxad.Text);
            command.Parameters.AddWithValue("@soyad", tbxsoyad.Text);
            command.Parameters.Add("@dtarih", SqlDbType.DateTime).Value = dateTimePicker1.Value;
            command.Parameters.AddWithValue("@tel", tbxtno.Text);
            _connection.Open();
            command.ExecuteNonQuery();
            _connection.Close();
            MusteriGetir();

        } 

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Delete from musteri where mno=@no", _connection);
            command.Parameters.AddWithValue("@no",Convert.ToInt64(tbxmno.Text));
            _connection.Open();
            command.ExecuteNonQuery();
            _connection.Close();
            MusteriGetir();
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand command= new SqlCommand("Update musteri Set ad=@ad,soyad=@soyad,dtarih=@dtarih,tel=@tel where mno=@no",_connection);
            command.Parameters.AddWithValue("@no", tbxmno.Text);
            command.Parameters.AddWithValue("@ad", tbxad.Text);
            command.Parameters.AddWithValue("@soyad", tbxsoyad.Text);
            command.Parameters.AddWithValue("@dtarih", dateTimePicker1.Value);
            command.Parameters.AddWithValue("@tel", tbxtno.Text);
            _connection.Open();
            command.ExecuteNonQuery();
            _connection.Close();
            MusteriGetir();
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxmno.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            tbxad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tbxsoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            tbxtno.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

        }
    }
}
