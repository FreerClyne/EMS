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
    public partial class F_User : Form
    {
        public F_User()
        {
            InitializeComponent();
        }
        DataClass.MyMeans MyDataClass = new EMS.DataClass.MyMeans();

        public static DataSet MyDS_Grid;

        private void F_User_Load(object sender, EventArgs e)
        {
            MyDS_Grid = MyDataClass.getDataSet("select ID as 编号,Name as 用户名 from tb_Login", "tb_Login");
            dataGridView1.DataSource = MyDS_Grid.Tables[0];
            dataGridView1.Columns[0].Width = 105;
            dataGridView1.Columns[1].Width = 110;
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount > 1)
            {
                ModuleClass.MyModule.User_ID = dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
                ModuleClass.MyModule.User_Name = dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value.ToString();
                btn_Modify.Enabled = true;
                btn_Delete.Enabled = true;
                btn_Permission.Enabled = true;
            }
            else
            {
                ModuleClass.MyModule.User_ID = "";
                ModuleClass.MyModule.User_Name = "";
                btn_Modify.Enabled = false;
                btn_Delete.Enabled = false;
                btn_Permission.Enabled = false;
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            PerForm.F_UserAdd FrmUserAdd = new F_UserAdd();
            FrmUserAdd.Tag = 1;
            FrmUserAdd.Text = btn_Add.Text + "用户";
            FrmUserAdd.ShowDialog(this);
        }

        private void btn_Modify_Click(object sender, EventArgs e)
        {
            if (ModuleClass.MyModule.User_ID.Trim() == "0001")
            {
                MessageBox.Show("不能修改超级用户！");
                return;
            }
            PerForm.F_UserAdd FrmUserAdd = new F_UserAdd();
            FrmUserAdd.Tag = 2;
            FrmUserAdd.Text = btn_Modify.Text + "用户";
            FrmUserAdd.ShowDialog(this);
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (ModuleClass.MyModule.User_ID != "")
            {
                if (ModuleClass.MyModule.User_ID.Trim() == "0001")
                {
                    MessageBox.Show("不能删除超级用户！");
                    return;
                }
                DialogResult strAbortRetyrIgnore = MessageBox.Show("确认删除？", "警告", MessageBoxButtons.OKCancel);
                if (strAbortRetyrIgnore.ToString() == "OK")
                {
                    MyDataClass.execSQLCmd("Delete tb_Login where ID='" + ModuleClass.MyModule.User_ID.Trim() + "'");
                    MyDataClass.execSQLCmd("Delete tb_UserPermission where ID='" + ModuleClass.MyModule.User_ID.Trim() + "'");
                    MyDS_Grid = MyDataClass.getDataSet("select ID as 编号,Name as 用户名 from tb_Login", "tb_Login");
                    dataGridView1.DataSource = MyDS_Grid.Tables[0];
                }
            }
            else
                MessageBox.Show("无法删除空数据表！");
        }

        private void btn_Permission_Click(object sender, EventArgs e)
        {
            if (ModuleClass.MyModule.User_ID.Trim() == "0001")
            {
                MessageBox.Show("不能修改超级用户权限。");
                return;
            }
            F_UserPermission FrmUserPermission = new F_UserPermission();
            FrmUserPermission.Text = "用户权限设置";
            FrmUserPermission.ShowDialog(this);
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
