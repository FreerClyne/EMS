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
    public partial class F_Log : Form
    {
        public F_Log()
        {
            InitializeComponent();
        }
        DataClass.MyMeans MyDataClass = new EMS.DataClass.MyMeans();
        ModuleClass.MyModule MyModuleClass = new EMS.ModuleClass.MyModule();
        DataSet MyDS_Grid;
        public static string Word_ID = "";
        public static int Word_S = 0;
        public static string SQLstr = "select ID,LogDate as 记事时间,LogType as 记事类别,Theme as 主题,LogContent from tb_Log";

        private void F_Log_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today;
            MyDS_Grid = MyDataClass.getDataSet(SQLstr, "tb_Log");
            dataGridView1.DataSource = MyDS_Grid.Tables[0];
            dataGridView1.AutoGenerateColumns = true;  
            dataGridView1.Columns[1].Width = 80;
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[3].Width = 100;

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[4].Visible = false;

            MyModuleClass.CoPassData(L_Type, "tb_NotePad");
            MyModuleClass.CoPassData(comboBox1, "tb_NotePad");

            MyModuleClass.ED_Button(btn_Add, btn_Modify, btn_Cancel, btn_Save, 1, 1, 0, 0);
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                try
                {
                    L_Date.Value = Convert.ToDateTime(dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value.ToString());
                    L_Type.Text = dataGridView1[2, dataGridView1.CurrentCell.RowIndex].Value.ToString();
                    L_Theme.Text = dataGridView1[3, dataGridView1.CurrentCell.RowIndex].Value.ToString();
                    L_Content.Text = dataGridView1[4, dataGridView1.CurrentCell.RowIndex].Value.ToString();
                    Word_ID = dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
                }
                catch
                {
                    L_Type.Text = "";
                    L_Theme.Text = "";
                    L_Content.Text = "";
                    Word_ID = "";
                }
            }
            else
            {
                MyModuleClass.Clear_Control(groupBox3.Controls);
                Word_ID = "";
                L_Date.Value = Convert.ToDateTime(System.DateTime.Now.ToString());
            }
        }

        private void btn_Inquiry_Click(object sender, EventArgs e)
        {
            string Find_Sql = "";
            if (checkBox1.Checked == true)
                Find_Sql = "(LogDate = '" + (Convert.ToDateTime(dateTimePicker1.Value.ToString())).ToShortDateString() + "')";
            if (checkBox2.Checked == true)
            {
                if((comboBox1.Text.Trim()).Length == 0)
                {
                    MessageBox.Show("请填写查询条件！");
                    return;
                }
                else
                {
                    if (Find_Sql == "")
                        Find_Sql = "(LogType = '" + comboBox1.Text + "')";
                    else
                        Find_Sql = Find_Sql + " AND " + " (LogType = '" + comboBox1.Text + "')";
                }
            }
            if (Find_Sql != "")
                Find_Sql = SQLstr + " where " + Find_Sql;
            else
                Find_Sql = SQLstr;
            MyDS_Grid = MyDataClass.getDataSet(Find_Sql, "tb_Log");
            dataGridView1.DataSource = MyDS_Grid.Tables[0];
            if (MyDS_Grid.Tables[0].Rows.Count < 1)
            {
                L_Type.Text = "";
                L_Theme.Text = "";
                L_Content.Text = "";
                Word_ID = "";
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            MyModuleClass.Clear_Control(groupBox3.Controls);
            MyModuleClass.Clear_Control(groupBox3.Controls);
            L_Date.Value = Convert.ToDateTime(System.DateTime.Now.ToString());
            Word_ID = MyModuleClass.GetAutoCoding("tb_Log", "ID");  
            Word_S = 1;
            MyModuleClass.ED_Button(btn_Add, btn_Modify, btn_Cancel, btn_Save, 1, 0, 1, 1);
        }

        private void btn_Modify_Click(object sender, EventArgs e)
        {
            if (MyDS_Grid.Tables[0].Rows.Count > 0)
            {
                Word_S = 2;
                MyModuleClass.ED_Button(btn_Add, btn_Modify, btn_Cancel, btn_Save, 0, 1, 1, 1);
            }
            else
                MessageBox.Show("当前为空记录，无法进行修改!");
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount < 2)
            {
                MessageBox.Show("数据表为空，不可以删除。");
                return;
            }
            if (Word_ID == "")
            {
                MessageBox.Show("无法删除空记录。");
                return;
            }
            DialogResult strAbortRetyrIgnore = MessageBox.Show("确认删除？", "警告", MessageBoxButtons.OKCancel);
            if (strAbortRetyrIgnore.ToString() == "OK")
            { 
                MyDataClass.execSQLCmd("Delete tb_Log where ID='" + Word_ID + "'");
                btn_Cancel_Click(sender, e);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Word_S = 0;
            MyModuleClass.ED_Button(btn_Add, btn_Modify, btn_Cancel, btn_Save, 1, 1, 0, 0);
            MyDS_Grid = MyDataClass.getDataSet(SQLstr, "tb_DayWordPad");
            dataGridView1.DataSource = MyDS_Grid.Tables[0];
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            string All_Field = "";
            string All_Value = "";

            if (Word_S == 1)
            {
                All_Field = "ID,LogDate,LogType,Theme,LogContent";
                All_Value = "'" + Word_ID + "'," + "'" + Convert.ToDateTime((L_Date.Value.ToString())).ToShortDateString() + "'," + "'" + L_Type.Text + "'," + "'" + L_Theme.Text + "'," + "'" + L_Content.Text + "'";
                MyDataClass.execSQLCmd("insert into tb_Log (" + All_Field + ") values(" + All_Value + ")");
            }
            if (Word_S == 2)
            {
                All_Value = "ID='" + Word_ID + "'," + "LogDate='" + Convert.ToDateTime((L_Date.Value.ToString())).ToShortDateString() + "'," + "LogType='" + L_Type.Text + "'," + "Theme='" + L_Theme.Text + "'," + "LogContent='" + L_Content.Text + "'";
                MyDataClass.execSQLCmd("update tb_Log set " + All_Value + " where ID='" + Word_ID + "'");
            }
            btn_Cancel_Click(sender, e);
        }

    }
}
