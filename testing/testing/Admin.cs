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
using excel = Microsoft.Office.Interop.Excel;

namespace testing
{
    enum RowState
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }

    public partial class Admin : Form
    {
        int selectedRow;
       public int selrow;
        public Admin()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }



        private void CreateColumnsCategories()
        {
            dataGridView_Categories.Columns.Add("Код_категории", "Категория");
            dataGridView_Categories.Columns.Add("Название_категории", "Название");

        }

        private void CreateColumnsBuyers()
        {
            dataGridView_Buyers.Columns.Add("Код_покупателя", "Номер покупателя");
            dataGridView_Buyers.Columns.Add("ФИО", "ФИО");
            dataGridView_Buyers.Columns.Add("Телефон", "Телефон");
            dataGridView_Buyers.Columns.Add("Название_магазина", "Название");
        }

        private void CreateColumnsComing()
        {
            dataGridView_Coming.Columns.Add("Код_товара", "Номер товара");
            dataGridView_Coming.Columns.Add("Код_категории", "Код категории");
            dataGridView_Coming.Columns.Add("Код_сотрудника", "Код сотрудника");
            dataGridView_Coming.Columns.Add("Название", "Название");
            dataGridView_Coming.Columns.Add("Количество", "Количество");
            dataGridView_Coming.Columns.Add("Единица_измерения", "Измерение");
            dataGridView_Coming.Columns.Add("Дата", "Дата");
        }

        private void CreateColumnsSale()
        {
            dataGridView_Sale.Columns.Add("Код_товара", "Номер товара");
            dataGridView_Sale.Columns.Add("Код_покупателя", "Номер покупателя");
            dataGridView_Sale.Columns.Add("Количество", "Количество");
            dataGridView_Sale.Columns.Add("Цена", "Цена");
        }
        
        private void ReadSingleRowCategories(DataGridView dgw1, IDataRecord record)
        {
            dgw1.Rows.Add(record.GetInt32(0), record.GetString(1));
        }

        private void ReadSingleRowBuyers(DataGridView dgw2, IDataRecord record)
        {
            dgw2.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3));
        }

        private void ReadSingleRowComing(DataGridView dgw3, IDataRecord record)
        {
            dgw3.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetInt32(2), record.GetString(3), record.GetInt32(4), record.GetString(5), record.GetDateTime(6));
        }

        private void ReadSingleRowSale(DataGridView dgw4, IDataRecord record)
        {
            dgw4.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetInt32(2), record.GetInt32(3));
        }

        private void RefreshDataGriedCatrgories(DataGridView dgw1)
        {
            dgw1.Rows.Clear();
            string queryString = $"select * from Категории";
            SqlCommand cmd = new SqlCommand(queryString, DB.con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRowCategories(dgw1, reader);
            }
            reader.Close();
        }

        private void RefreshDataGriedBuyers(DataGridView dgw2)
        {
            dgw2.Rows.Clear();
            string queryString = $"select * from Покупатели";
            SqlCommand cmd = new SqlCommand(queryString, DB.con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRowBuyers(dgw2, reader);
            }
            reader.Close();
        }

        private void RefreshDataGriedComing(DataGridView dgw3)
        {
            dgw3.Rows.Clear();
            string queryString = $"select * from Приход_товара";
            SqlCommand cmd = new SqlCommand(queryString, DB.con);
            SqlDataReader reader1 = cmd.ExecuteReader();
            while (reader1.Read())
            {
                ReadSingleRowComing(dgw3, reader1);
            }
            reader1.Close();
        }

        private void RefreshDataGriedSale(DataGridView dgw4)
        {
            dgw4.Rows.Clear();
            string queryString = $"select * from Продажа";
            SqlCommand cmd = new SqlCommand(queryString, DB.con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRowSale(dgw4, reader);
            }
            reader.Close();
        }

        private void SearchCategories(DataGridView dgw)
        {
            dgw.Rows.Clear();
                string searchString = $"select * from Категории where concat (Код_категории, Название_категории) like '%" + textBox1.Text + "%'";
                SqlCommand cmd = new SqlCommand(searchString, DB.con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ReadSingleRowCategories(dgw, dr);
                }
                dr.Close();
        }

        private void SearchBuyers(DataGridView dgw)
        {
            dgw.Rows.Clear();
            
                string searchString = $"select * from Покупатели where concat (Код_покупателя, ФИО, Телефон, Название_магазина) like '%" + textBox3.Text + "%'";
                SqlCommand cmd = new SqlCommand(searchString, DB.con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ReadSingleRowBuyers(dgw, dr);
                }
                dr.Close();
           
        }

        private void SearchComing(DataGridView dgw)
        {
            dgw.Rows.Clear();
                string searchString = $"select * from Приход_товара where concat (Код_товара, Код_категории, Код_сотрудника, Название, Количество, Единица_измерения, Дата) like '%" + textBox4.Text + "%'";
                SqlCommand cmd = new SqlCommand(searchString, DB.con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ReadSingleRowComing(dgw, dr);
                }
                dr.Close();
        }

        private void SearchSale(DataGridView dgw)
        {
            dgw.Rows.Clear();
                string searchString = $"select * from Продажа where concat (Код_товара, Код_покупателя, Количество, Цена) like '%" + textBox2.Text + "%'";
                SqlCommand cmd = new SqlCommand(searchString, DB.con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ReadSingleRowSale(dgw, dr);
                }
                dr.Close();
        }

        private void Close_Box_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы хотите выйти из приложения?", "Внимание!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DB.DBclose();
                Application.Exit();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы хотите выйти в меню авторизации?", "Внимание!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DB.DBclose();
                this.Close();
                log_in log_In = new log_in();
                log_In.Show();
            }
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            if (log_in.worker) pictureBox2.Hide();
            StartPosition = FormStartPosition.CenterScreen;
            DB.con.Open();
            label1.Text = "Здравствуйте," + log_in.FIO + "!";
            CreateColumnsCategories();
            RefreshDataGriedCatrgories(dataGridView_Categories);
            CreateColumnsBuyers();
            RefreshDataGriedBuyers(dataGridView_Buyers);
            CreateColumnsComing();
            RefreshDataGriedComing(dataGridView_Coming);
            CreateColumnsSale();
            RefreshDataGriedSale(dataGridView_Sale);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DB.DBclose();
            Add_user add_User = new Add_user();
            add_User.Show();
        }

        private void dataGridView_Categories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selrow = selectedRow = e.RowIndex;
            if (selectedRow >= 0)
            {
                DataGridViewRow row = dataGridView_Categories.Rows[selectedRow];
                textBox5.Text = row.Cells[0].Value.ToString();
                textBox6.Text = row.Cells[1].Value.ToString();
            }
        }

        private void dataGridView_Buyers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selrow = selectedRow = e.RowIndex;
            if (selectedRow >= 0)
            {
                DataGridViewRow row = dataGridView_Buyers.Rows[selectedRow];
                textBox7.Text = row.Cells[0].Value.ToString();
                textBox8.Text = row.Cells[1].Value.ToString();
                textBox9.Text = row.Cells[2].Value.ToString();
                textBox10.Text = row.Cells[3].Value.ToString();
            }
        }

        private void dataGridView_Coming_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selrow = selectedRow = e.RowIndex;
            if (selectedRow >= 0)
            {
                DataGridViewRow row = dataGridView_Coming.Rows[selectedRow];
                textBox11.Text = row.Cells[0].Value.ToString();
                textBox12.Text = row.Cells[1].Value.ToString();
                textBox13.Text = row.Cells[2].Value.ToString();
                textBox14.Text = row.Cells[3].Value.ToString();
                textBox15.Text = row.Cells[4].Value.ToString();
                textBox16.Text = row.Cells[5].Value.ToString();
                textBox17.Text = row.Cells[6].Value.ToString();
            }
        }

        private void dataGridView_Sale_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selrow = selectedRow = e.RowIndex;
            if (selectedRow >= 0)
            {
                DataGridViewRow row = dataGridView_Sale.Rows[selectedRow];
                textBox18.Text = row.Cells[0].Value.ToString();
                textBox19.Text = row.Cells[1].Value.ToString();
                textBox20.Text = row.Cells[2].Value.ToString();
                textBox21.Text = row.Cells[3].Value.ToString();
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            RefreshDataGriedCatrgories(dataGridView_Categories);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            RefreshDataGriedBuyers(dataGridView_Buyers);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            RefreshDataGriedComing(dataGridView_Coming);
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            RefreshDataGriedSale(dataGridView_Sale);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SearchCategories(dataGridView_Categories);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            SearchBuyers(dataGridView_Buyers);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            SearchComing(dataGridView_Coming);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            SearchSale(dataGridView_Sale);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Вы хотите удалить выбранное поле? Это может за повлечь за собой удаление связанных данных!", "Внимание!", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                var deleteQuery = $"delete from Категории where Код_категории = {textBox5.Text}";
                DB.queryExecute(deleteQuery);
                RefreshDataGriedCatrgories(dataGridView_Categories);
                textBox5.Text = "";
                textBox6.Text = "";
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Вы хотите удалить выбранное поле? Это может за повлечь за собой удаление связанных данных!", "Внимание!", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                var deleteQuery = $"delete from Продажи where Код_товара = {textBox18.Text}";
                DB.queryExecute(deleteQuery);
                RefreshDataGriedSale(dataGridView_Sale);
                textBox18.Text = "";
                textBox19.Text = "";
                textBox20.Text = "";
                textBox21.Text = "";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Вы хотите удалить выбранное поле? Это может за повлечь за собой удаление связанных данных!", "Внимание!", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                var deleteQuery = $"delete from Покупатели where Код_покупателя = {textBox7.Text}";
                DB.queryExecute(deleteQuery);
                RefreshDataGriedBuyers(dataGridView_Buyers);
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Вы хотите удалить выбранное поле? Это может за повлечь за собой удаление связанных данных!", "Внимание!", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                var deleteQuery = $"delete from Приход_товара where Код_товара = {textBox11.Text}";
                DB.queryExecute(deleteQuery);
                RefreshDataGriedComing(dataGridView_Coming);
                textBox11.Text = "";
                textBox12.Text = "";
                textBox13.Text = "";
                textBox14.Text = "";
                textBox15.Text = "";
                textBox16.Text = "";
                textBox17.Text = "";
            }
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            textBox18.Text = "";
            textBox19.Text = "";
            textBox20.Text = "";
            textBox21.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var add = $"insert into Категории (Код_категории, Название_категории) values('{textBox5.Text}','{textBox6.Text}')";
            DB.queryExecute(add);
            RefreshDataGriedCatrgories(dataGridView_Categories);
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var add = $"insert into Покупатели (Код_покупателя, ФИО, Телефон, Название_магазина) values('{textBox7.Text}','{textBox8.Text}','{textBox9.Text}','{textBox10.Text}')";
            DB.queryExecute(add);
            RefreshDataGriedBuyers(dataGridView_Buyers);
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var add = $"insert into Приход_товара (Код_товара, Код_категории, Код_сотрудника, Название, Количество, Единица_измерения, Дата) values('{textBox11.Text}','{textBox12.Text}','{textBox13.Text}','{textBox14.Text}','{textBox15.Text}','{textBox16.Text}','{textBox17.Text}')";
            DB.queryExecute(add);
            RefreshDataGriedComing(dataGridView_Coming);
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            int i,j,z;
            string sql = $"select Код_товара from Приход_товара where Код_товара= '{textBox18.Text}'";
            SqlCommand cmd = new SqlCommand(sql, DB.con);
            SqlDataReader rdr = cmd.ExecuteReader();
            bool a = rdr.Read();
            
            rdr.Close();
       
            if (a == false)
            {
                string sql2 = $"select Количество from Приход_товара where Код_товара= '{textBox18.Text}'";
                SqlCommand cmd2 = new SqlCommand(sql2, DB.con);
                object result = cmd2.ExecuteScalar();
                z = Convert.ToInt32(result);
                i = Convert.ToInt32(textBox20.Text);
                j = z - i;
                if (j >= 0)
                {
                    var update = $"update Приход_товара set Количество = '{j}' where Код_товара = '{textBox18.Text}'";
                    DB.queryExecute(update);
                    RefreshDataGriedComing(dataGridView_Coming);

                    var add = $"insert into Продажа (Код_товара, Код_покупателя, Количество, Цена) values('{textBox18.Text}','{textBox19.Text}','{textBox20.Text}','{textBox21.Text}')";
                    DB.queryExecute(add);


                    RefreshDataGriedSale(dataGridView_Sale);
                    textBox18.Text = "";
                    textBox19.Text = "";
                    textBox20.Text = "";
                    textBox21.Text = "";
                }
                else MessageBox.Show("Превышен лимит количества товара! Повторите ещё раз изменив значения");
            }
            else MessageBox.Show("Такая запись уже существует! Повторите ещё раз изменив значения");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var update = $"update Категории set Название_категории = '{textBox6.Text}' where Код_категории = '{textBox5.Text}'";
            DB.queryExecute(update);
            RefreshDataGriedCatrgories(dataGridView_Categories);
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var update = $"update Покупатели set ФИО ='{textBox8.Text}' , Телефон ='{textBox9.Text}' , Название_магазина = '{textBox10.Text}' where Код_покупателя = '{textBox7.Text}'";
            DB.queryExecute(update);
            RefreshDataGriedBuyers(dataGridView_Buyers);
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var update = $"update Приход_товара set Код_категории = '{textBox12.Text}', Код_сотрудника = '{textBox13.Text}', Название = '{textBox14.Text}', Количество = '{textBox15.Text}', Единица_измерения = '{textBox16.Text}', Дата = '{textBox17.Text}' where Код_товара = '{textBox11.Text}'";
            DB.queryExecute(update);
            RefreshDataGriedComing(dataGridView_Coming);
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            int i,i1, j, z,z1,j1,i2,j2,z2;
            string sql2 = $"select Количество from Приход_товара where Код_товара= '{textBox18.Text}'";
            SqlCommand cmd2 = new SqlCommand(sql2, DB.con);
            object result2 = cmd2.ExecuteScalar();
            z = Convert.ToInt32(result2);
            i = Convert.ToInt32(textBox20.Text);

            string sql4 = $"select Количество from Продажа where Код_товара= '{textBox18.Text}'";
            SqlCommand cmd4 = new SqlCommand(sql4, DB.con);
            object result4 = cmd4.ExecuteScalar();
            i2 = Convert.ToInt32(result4);
            
            

            j = z - (i-i2);
            if (j >= 0)
            { 
                var update1 = $"update Приход_товара set Количество = '{j}' where Код_товара = '{textBox18.Text}'";
                DB.queryExecute(update1);
                RefreshDataGriedComing(dataGridView_Coming);

                string sql3 = $"select Количество from Продажа where Код_товара= '{textBox18.Text}'";
                SqlCommand cmd3 = new SqlCommand(sql3, DB.con);
                object result1 = cmd3.ExecuteScalar();
                i1 = Convert.ToInt32(result1);
                z1 = Convert.ToInt32(textBox20.Text);
                j1 = i1+(z-i1);

                var update5 = $"update Продажа set Код_покупателя = '{textBox19.Text}', Количество = '{j1}', Цена = '{textBox21.Text}' where Код_товара = '{textBox18.Text}'";
                DB.queryExecute(update5);

                RefreshDataGriedSale(dataGridView_Sale);
                textBox18.Text = "";
                textBox19.Text = "";
                textBox20.Text = "";
                textBox21.Text = "";
            }
            else MessageBox.Show("Превышен лимит количества товара! Повторите ещё раз изменив значения");
        }

        private void excelprint(DataGridView dgw)
        {
            excel.Application exapp = new excel.Application();
            exapp.Workbooks.Add();
            excel.Worksheet wsh = (excel.Worksheet)exapp.ActiveSheet;
            int i, j;
            for (i=0;i<=dgw.RowCount-2; i++)
            {
                for (j = 0; j <= dgw.ColumnCount-1; j++)
                {
                    wsh.Cells[i+1,j+1] = dgw[j,i].Value.ToString();    
                }
            }


            exapp.Visible = true;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            excelprint(dataGridView_Categories);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            excelprint(dataGridView_Buyers);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            excelprint(dataGridView_Coming);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            excelprint(dataGridView_Sale);
        }
    }
}
