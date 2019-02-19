using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMS.PerForm
{
    public partial class F_UserAdd : Form
    {
        public F_UserAdd()
        {
            InitializeComponent();
        }
        DataClass.MyMeans MyDataClass = new EMS.DataClass.MyMeans();
        ModuleClass.MyModule MyMC = new EMS.ModuleClass.MyModule();
        public DataSet DSet;
        public static string AutoID = "";

        private void F_UserAdd_Load(object sender, EventArgs e)
        {
            if ((int)this.Tag == 1)
            {
                txt_Name.Text = "";
                txt_Pwd.Text = "";
            }
            else
            {
                string ID = ModuleClass.MyModule.User_ID;
                DSet = MyDataClass.getDataSet("select Name,Pwd from tb_Login where ID='" + ID + "'", "tb_Login");
                txt_Name.Text = Convert.ToString(DSet.Tables[0].Rows[0][0]);
                txt_Pwd.Text = Convert.ToString(DSet.Tables[0].Rows[0][1]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_Name.Text == "" && txt_Pwd.Text == "")
            {
                MessageBox.Show("请将用户名和密码添加完整。");
                return;
            }
            DSet = MyDataClass.getDataSet("select Name from tb_Login where Name='" + txt_Name.Text + "'", "tb_Login");
            
            if ((int)this.Tag == 2 && txt_Name.Text == ModuleClass.MyModule.User_Name)
            {
                MyDataClass.execSQLCmd("update tb_Login set Name='" + txt_Name.Text + "',Pwd='" + txt_Pwd.Text + "' where ID='" + ModuleClass.MyModule.User_ID + "'");
                if (ModuleClass.MyModule.User_ID == DataClass.MyMeans.Login_ID)
                    DataClass.MyMeans.Login_Name = txt_Name.Text;
                MessageBox.Show("修改成功。");
                this.Close();
            }
            
            if ((int)this.Tag == 1)
            {
                if (DSet.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("当前用户名已存在，请重新输入。");
                    txt_Name.Text = "";
                    txt_Pwd.Text = "";
                    return;
                }
                AutoID = MyMC.GetAutoCoding("tb_Login", "ID");
                MyDataClass.execSQLCmd("insert into tb_Login (ID,Name,Pwd) values('" + AutoID + "','" + txt_Name.Text + "','" + txt_Pwd.Text + "')");
                MyMC.Add_Permission(AutoID, 0);
                MessageBox.Show("添加成功。");
                this.Close();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
