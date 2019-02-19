using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace EMS.DataClass
{
    class MyMeans
    {
        #region Global variable
        public static int Login_n = 0;
        public static string Login_ID = "";
        public static string Login_Name = "";
        public static string M_str_sqlcon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\db_EMS.mdf;Integrated Security=True";
        public static SqlConnection My_con;
        public static string Mean_SQL = "", Mean_Table = "", Mean_Field = "";
        public static string Allsql = "select * from tb_StaffBasic";
        #endregion

        #region Database
        public void conn_Open()
        {
            My_con = new SqlConnection(M_str_sqlcon);
            My_con.Open();
        }
        public void conn_Close()
        {
            if(My_con.State == ConnectionState.Open)
            {
                My_con.Close();
                My_con.Dispose();
            }
        }
        #endregion
  
        #region Read info from tables
        public SqlDataReader getCmd(string SQLstr)
        {
            conn_Open();
            SqlCommand My_cmd = My_con.CreateCommand();
            My_cmd.CommandText = SQLstr;
            SqlDataReader My_read = My_cmd.ExecuteReader();
            return My_read;
        }
        #endregion
        
        #region Execute sql command
        public void execSQLCmd(string SQLstr)
        {
            conn_Open();
            SqlCommand SQLcmd = new SqlCommand(SQLstr, My_con);
            SQLcmd.ExecuteNonQuery();
            SQLcmd.Dispose();
            conn_Close();
        }
        #endregion

        #region Create DataSet
        public DataSet getDataSet(string SQLstr, string tableName)
        {
            conn_Open();
            SqlDataAdapter SQLdata = new SqlDataAdapter(SQLstr, My_con);
            DataSet My_DataSet = new DataSet();
            SQLdata.Fill(My_DataSet, tableName);
            conn_Close();
            return My_DataSet;
        }
        #endregion
    }
}
