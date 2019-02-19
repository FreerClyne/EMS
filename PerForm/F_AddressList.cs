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
    public partial class F_AddressList : Form
    {
        public F_AddressList()
        {
            InitializeComponent();
        }
        DataClass.MyMeans MyDataClass = new EMS.DataClass.MyMeans();
        ModuleClass.MyModule MyModuleClass = new EMS.ModuleClass.MyModule();
        DataSet MyDS_Grid;
        public static string SQLstr = "Select ID,Name as 性名,Gender as 性别,Phone as 电话,WorkPhone as 工作电话,Handset as 手机, QQ as QQ号,E_Mail as 邮箱地址 from tb_AddressBook";
        public static string Find_Field = "";

        public void ShowAll()
        {
            ModuleClass.MyModule.Address_ID = "";
            MyDS_Grid = MyDataClass.getDataSet(SQLstr, "tb_AddressBook");
            dataGridView1.DataSource = MyDS_Grid.Tables[0];
            dataGridView1.Columns[0].Visible = false;
            if (dataGridView1.RowCount > 1)
            {
                btn_Modify.Enabled = true;
                btn_Delete.Enabled = true;
            }
            else
            {
                btn_Modify.Enabled = false;
                btn_Delete.Enabled = false;
            }
        }

        private void F_AddressList_Load(object sender, EventArgs e)
        {
            ShowAll();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            InfoAddForm.F_Address FrmAddress = new EMS.InfoAddForm.F_Address();
            FrmAddress.Text = "通讯录添加";
            FrmAddress.Tag = 1;
            FrmAddress.ShowDialog();
            ShowAll();
        }

        private void btn_Modify_Click(object sender, EventArgs e)
        {
            InfoAddForm.F_Address FrmAddress = new EMS.InfoAddForm.F_Address();
            FrmAddress.Text = "通讯录修改";
            FrmAddress.Tag = 2;
            FrmAddress.ShowDialog(this);
            ShowAll();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DialogResult strAbortRetyrIgnore = MessageBox.Show("确认删除？", "警告", MessageBoxButtons.OKCancel);
            if (strAbortRetyrIgnore.ToString() == "OK")
            {
                MyDataClass.execSQLCmd("Delete tb_AddressBook where ID='" + ModuleClass.MyModule.Address_ID + "'");
                ShowAll();
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount > 1)
            {
                ModuleClass.MyModule.Address_ID = dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
                btn_Modify.Enabled = true;
                btn_Delete.Enabled = true;

            }
            else
            {
                btn_Modify.Enabled = true;
                btn_Delete.Enabled = true;
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            switch (((ComboBox)sender).SelectedIndex)
            {
                case 0:
                    {
                        Find_Field = "Name";
                        break;
                    }
                case 1:
                    {
                        Find_Field = "Gender";
                        break;
                    }
                case 2:
                    {
                        Find_Field = "E_Mail";
                        break;
                    }
            }
        }

        private void btn_Inquiry_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入查询条件。");
                return;
            }
            ModuleClass.MyModule.Address_ID = "";
            MyDS_Grid = MyDataClass.getDataSet(SQLstr + " where " + Find_Field + " like '%" + textBox1.Text.Trim() + "%'", "tb_AddressBook");
            dataGridView1.DataSource = MyDS_Grid.Tables[0];
            dataGridView1.Columns[0].Visible = false;
            if (dataGridView1.RowCount > 1)
            {
                btn_Modify.Enabled = true;
                btn_Delete.Enabled = true;
            }
            else
            {
                btn_Modify.Enabled = false;
                btn_Delete.Enabled = false;
            }
        }

        private void btn_ShowAll_Click(object sender, EventArgs e)
        {
            ShowAll();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
