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

namespace testing
{ 
    public partial class log_in : Form
    {
        public static bool worker = false;
        public static object FIO;
        public log_in()
        {   
            worker = false;
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            DB.DBconn();
        }

        private void Ent_button_Click(object sender, EventArgs e)
        {          
            string sqlfio = $"select ФИО from Сотрудники where Логин= '{textBox1.Text}' and Пароль = '{textBox2.Text}'";
            SqlCommand command = new SqlCommand(sqlfio, DB.con);
            FIO = command.ExecuteScalar();
            string sql = $"select Тип_доступа from Сотрудники where Логин= '{textBox1.Text}' and Пароль = '{textBox2.Text}'";
            SqlCommand cmd = new SqlCommand(sql,DB.con);
            Object result = cmd.ExecuteScalar();
            
            switch (result)
            {
                case "Администратор":
                    DB.DBclose();
                    this.Hide();
                    Admin formA = new Admin();
                    formA.Show();
                    break;

                case "Сотрудник":
                    DB.DBclose();
                    worker = true; 
                    this.Hide();
                    Admin formW = new Admin();
                    formW.Show();
                    break;

                default:
                    MessageBox.Show("Аккаунта не существует");
                    return;
            }
        }

        private void log_in_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            Anvisible_Box.Visible = false;
            textBox1.MaxLength = 50;
            textBox2.MaxLength = 50;
        }

        private void Visible_Box_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
            Visible_Box.Visible = false;
            Anvisible_Box.Visible=true;
        }

        private void Anvisible_Box_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            Visible_Box.Visible = true;
            Anvisible_Box.Visible = false;
        }

        private void Clear_Box_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void Close_Box_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
