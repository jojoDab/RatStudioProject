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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using excel = Microsoft.Office.Interop.Excel;

namespace testing
{
    public partial class Add_user : Form
    {
        int selectedRow;
        public Add_user()
        {
            DB.DBconn();
            InitializeComponent();
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("Код_сотрудника", "Номер сотрудника");
            dataGridView1.Columns.Add("ФИО", "ФИО");
            dataGridView1.Columns.Add("Тип_доступа", "Тип_доступа");
            dataGridView1.Columns.Add("Телефон", "Телефон");
            dataGridView1.Columns.Add("Логин", "Логин");
            dataGridView1.Columns.Add("Пароль", "Пароль");
        }
        private void ReadSingleRow(DataGridView dgw3, IDataRecord record)
        {
            dgw3.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5));
        }

        private void RefreshDataGried(DataGridView dgw3)
        {
            dgw3.Rows.Clear();
            string queryString = $"select * from Сотрудники";
            SqlCommand cmd = new SqlCommand(queryString, DB.con);
            SqlDataReader reader1 = cmd.ExecuteReader();
            while (reader1.Read())
            {
                ReadSingleRow(dgw3, reader1);
            }
            reader1.Close();
        }
        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string searchString = $"select * from Сотрудники where concat (Код_сотрудника, Код_категории, ФИО, Тип_доступа, Телефон, Логин, Пароль) like '%" + textBox1.Text + "%'";
            SqlCommand cmd = new SqlCommand(searchString, DB.con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ReadSingleRow(dgw, dr);
            }
            dr.Close();
        }

        private void Add_user_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGried(dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (selectedRow >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];
                textBox2.Text = row.Cells[0].Value.ToString();
                textBox3.Text = row.Cells[1].Value.ToString();
                textBox4.Text = row.Cells[2].Value.ToString();
                textBox5.Text = row.Cells[3].Value.ToString();
                textBox6.Text = row.Cells[4].Value.ToString();
                textBox7.Text = row.Cells[5].Value.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            RefreshDataGried(dataGridView1);    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var add = $"insert into Сотрудники (Код_сотрудника, ФИО, Тип_доступа, Телефон, Логин, Пароль) values('{textBox2.Text}','{textBox3.Text}','{textBox4 .Text}','{textBox5.Text}','{textBox6.Text}','{textBox7.Text}')";
            DB.queryExecute(add);
            RefreshDataGried(dataGridView1);
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox1.Text = "";
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var update = $"update Сотрудники set ФИО = '{textBox3.Text}', Тип_доступа = '{textBox4.Text}', Телефон = '{textBox5.Text}', Логин = '{textBox6.Text}', Пароль = '{textBox7.Text}' where Код_сотрудника = '{textBox2.Text}'";
            DB.queryExecute(update);
            RefreshDataGried(dataGridView1 );
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Вы хотите удалить выбранное поле? Это может за повлечь за собой удаление связанных данных!", "Внимание!", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                var deleteQuery = $"delete from Сотрудники where Код_сотрудника = {textBox2.Text}";
                DB.queryExecute(deleteQuery);
                RefreshDataGried(dataGridView1);
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox1.Text = "";
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DataGridView dgw = dataGridView1;
            excel.Application exapp = new excel.Application();
            exapp.Workbooks.Add();
            excel.Worksheet wsh = (excel.Worksheet)exapp.ActiveSheet;
            int i, j;
            for (i = 0; i <= dgw.RowCount - 1; i++)
            {
                for (j = 0; j <= dgw.ColumnCount - 1; j++)
                {
                    wsh.Cells[i + 1, j + 1] = dgw[j, i].Value.ToString();
                }
            }


            exapp.Visible = true;
        }
    }
}
