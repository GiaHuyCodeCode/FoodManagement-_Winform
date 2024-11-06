using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodManagement.DAO
{
    public class DataProvider
    {
        //Tạo ra một Singleton
        private static DataProvider instance; //Ctrl+E+R

        public static DataProvider Instance
        {
            get
            {
                if (instance == null) instance = new DataProvider();
                return DataProvider.instance;
            }

            private set { instance = value; }
        }
        private DataProvider() { }
        private string STR = @"Data Source=DESKTOP-V27PVIS\\SQLEXPRESS;Initial Catalog=QLNH;Integrated Security=True";


        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(STR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                //them Parameter
                if (parameter != null)
                {
                    //cat tung phan tu trong parameter cach nhau bang khoang trang
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }

        //Tra ra so dong thanh cong
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(STR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                //them Parameter
                if (parameter != null)
                {
                    //cat tung phan tu trong parameter cach nhau bang khoang trang
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteNonQuery();


                connection.Close();
            }
            return data;
        }
        //Select COUNT(*)
        public int ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(STR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                //them Parameter
                if (parameter != null)
                {
                    //cat tung phan tu trong parameter cach nhau bang khoang trang
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteScalar();


                connection.Close();
            }
            return Convert.ToInt32(data);
        }

    }
}
