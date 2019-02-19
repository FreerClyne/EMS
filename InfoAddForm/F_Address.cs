using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMS.InfoAddForm
{
    public partial class F_Address : Form
    {
        public F_Address()
        {
            InitializeComponent();
        }
        DataClass.MyMeans MyDataClass = new EMS.DataClass.MyMeans();
        ModuleClass.MyModule MyModuleClass = new EMS.ModuleClass.MyModule();
        public static DataSet MyDS_Grid;
        public static string Address_ID = "";

        private void F_Address_Load(object sender, EventArgs e)
        {
            if ((int)(this.Tag) == 1)
            {
                Address_ID = MyModuleClass.GetAutoCoding("tb_AddressBook", "ID");
            }
            if ((int)this.Tag == 2)
            {
                MyDS_Grid = MyDataClass.getDataSet("select ID,Name,Gender,Phone,Handset,WorkPhone,QQ,E_Mail from tb_AddressBook where ID='" + ModuleClass.MyModule.Address_ID + "'", "tb_AddressBook");
                Address_ID = MyDS_Grid.Tables[0].Rows[0][0].ToString();
                this.A_1.Text = MyDS_Grid.Tables[0].Rows[0][1].ToString();
                this.A_2.Text = MyDS_Grid.Tables[0].Rows[0][2].ToString();
                this.A_3.Text = MyDS_Grid.Tables[0].Rows[0][3].ToString();
                this.A_4.Text = MyDS_Grid.Tables[0].Rows[0][4].ToString();
                this.A_5.Text = MyDS_Grid.Tables[0].Rows[0][5].ToString();
                this.A_6.Text = MyDS_Grid.Tables[0].Rows[0][6].ToString();
                this.A_7.Text = MyDS_Grid.Tables[0].Rows[0][7].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.A_1.Text != "")
            {
                MyModuleClass.Part_SaveClass("ID,Name,Gender,Phone,Handset,WorkPhone,QQ,E_Mail", Address_ID, "", this.Controls, "A_", "tb_AddressBook", 8, (int)this.Tag);
                MyDataClass.execSQLCmd(ModuleClass.MyModule.ADDs);
                this.Close();
            }
            else
                MessageBox.Show("人员姓名不能为空!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
