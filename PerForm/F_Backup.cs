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

namespace EMS.PerForm
{
    public partial class F_Backup : Form
    {
        public F_Backup()
        {
            InitializeComponent();
        }
        DataClass.MyMeans MyDataClass = new EMS.DataClass.MyMeans();
        ModuleClass.MyModule MyModuleClass = new EMS.ModuleClass.MyModule();

        private void btn_Backup_Click(object sender, EventArgs e)
        {
            string Str_dir = "";
            if (radioButton1.Checked == true)
                Str_dir = System.Environment.CurrentDirectory + "\\bar\\";
            if (radioButton2.Checked == true)
                Str_dir = textBox2.Text + "\\";
            if (textBox2.Text == "" & radioButton2.Checked == true)
            {
                MessageBox.Show("请选择备份数据库文件的路径。");
                return;
            }
            try
            {
                Str_dir = "backup database db_EMS to disk='" + Str_dir + (System.DateTime.Now.ToShortDateString()).ToString() + System.DateTime.Now.ToString() + ".bak" + "'";
                MyDataClass.execSQLCmd(Str_dir);
                MessageBox.Show("数据备份成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Open1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                textBox2.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btn_Restore_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("请选择备份数据库文件的路径。");
                return;
            }
            try
            {
                if (DataClass.MyMeans.My_con.State == ConnectionState.Open)
                {
                    DataClass.MyMeans.My_con.Close();
                }
                string DateStr = "server=DESKTOP-EMH8152;database=db_EMS;uid=DESKTOP-EMH8152\\freer;pwd=;Integrated Security=SSPI;";
                SqlConnection conn = new SqlConnection(DateStr);
                conn.Open();
                //-------------------杀掉所有连接 db_PWMS 数据库的进程--------------
                string strSQL = "select spid from master..sysprocesses where dbid=db_id( 'db_EMS') ";
                SqlDataAdapter Da = new SqlDataAdapter(strSQL, conn);
                DataTable spidTable = new DataTable();
                Da.Fill(spidTable);
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.Connection = conn;
                for (int iRow = 0; iRow < spidTable.Rows.Count; iRow++)
                {
                    Cmd.CommandText = "kill " + spidTable.Rows[iRow][0].ToString();   //强行关闭用户进程 
                    Cmd.ExecuteNonQuery();
                }
                conn.Close();
                conn.Dispose();
                SqlConnection Tem_con = new SqlConnection(DataClass.MyMeans.M_str_sqlcon);
                Tem_con.Open();
                SqlCommand SQLcom = new SqlCommand("backup log db_EMS to disk='"
                    + textBox3.Text.Trim() + "'use master restore database db_EMS from disk='"
                    + textBox3.Text.Trim() + "'", Tem_con);
                SQLcom.ExecuteNonQuery();
                SQLcom.Dispose();
                Tem_con.Close();
                Tem_con.Dispose();
                MessageBox.Show("数据还原成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MyDataClass.conn_Open();
                MyDataClass.conn_Close();
                MessageBox.Show("为了避免数据丢失，在数据库原还后将关闭整个系统。");
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Open2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "*.bak|*.bak";
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                textBox3.Text = openFileDialog1.FileName;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Cancel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
