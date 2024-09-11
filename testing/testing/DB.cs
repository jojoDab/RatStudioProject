using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace testing
{
    internal class DB
    {
        static string conString = "Server = localhost\\SQLEXPRESS; Database = Складской_учет; Trusted_Connection = true;";
        public static SqlConnection con = new SqlConnection(conString);

        public static SqlDataAdapter queryExecute(string query)
        {
            //try
            //{

                SqlDataAdapter adapter = new SqlDataAdapter(query, DB.con);
                adapter.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Действие выполнено!", "Успех!");
                return adapter;
            //}
            //catch
            //{
            //    MessageBox.Show("Возникла ошибка выполнения запроса. Попробуйте изменить данные или повторить действие позже.", "Ошибка");
            //    return null;
            //}
        }

        public static bool DBconn()
        {
            try
            {
                con.Open();
                return true;
            }
            catch
            {
                MessageBox.Show("Ошибка подключения к базе данных", "Ошибка", MessageBoxButtons.OK);
                return false;
            }
        }

        public static bool DBclose()
        {
            try
            {
                con.Close();
                return true;
            }
            catch
            {
                MessageBox.Show("Ошибка закрытия подключения к базе данных", "Ошибка", MessageBoxButtons.OK);
                return false;
            }
        }
    }
}
