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

namespace EMS
{
    public partial class F_Login : Form
    {
        DataClass.MyMeans MyClass = new EMS.DataClass.MyMeans();
        public F_Login()
        {
            InitializeComponent();
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            if ((int)(this.Tag) == 1)
                Application.Exit();
            else
                this.Close();
        }

        private void butLogin_Click(object sender, EventArgs e)
        {
            if (textName.Text != "" & textPwd.Text != "")
            {
                SqlDataReader temDR = MyClass.getCmd("select * from tb_Login where Name='" + textName.Text.Trim() + "' and Pwd='" + textPwd.Text.Trim() + "'");
                bool ifcom = temDR.Read();
                if (ifcom)
                {
                    DataClass.MyMeans.Login_Name = textName.Text.Trim();
                    DataClass.MyMeans.Login_ID = temDR.GetString(0);
                    DataClass.MyMeans.My_con.Close();
                    DataClass.MyMeans.My_con.Dispose();
                    DataClass.MyMeans.Login_n = (int)(this.Tag);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textName.Text = "";
                    textPwd.Text = "";
                }
                MyClass.conn_Close();
            }
            else
                MessageBox.Show("请将登录信息添写完整！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void F_Login_Load(object sender, EventArgs e)
        {
            try
            {
                MyClass.conn_Open();
                MyClass.conn_Close();
            }
            catch
            {
                MessageBox.Show("数据库连接失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

    }
}
