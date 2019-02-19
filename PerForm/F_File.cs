using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using Word = Microsoft.Office.Interop.Word;

namespace EMS.PerForm
{
    public partial class F_File : Form
    {
        public F_File()
        {
            InitializeComponent();
        }
        DataClass.MyMeans MyDataClass = new EMS.DataClass.MyMeans();
        ModuleClass.MyModule MyModuleClass = new EMS.ModuleClass.MyModule();
        public static DataSet MyDS_Grid;
        public static byte[] imgBytesIn;
        public static int hold_n = 1;
        public static int Img_n = 0;
        public static string tmp_Field = "";
        public static string tmp_Value = "";
        public static string tmp_ID = "";
        public static string Part_ID = "";

        public void ShowData_Image(byte[] DI, PictureBox Img)
        {
            byte[] buffer = DI;
            MemoryStream ms = new MemoryStream(buffer);
            Img.Image = Image.FromStream(ms);
        }

        public void Read_Image(OpenFileDialog openF, PictureBox MyImage)
        {
            openF.Filter = "*.jpg|*.jpg|*.bpm|*.bpm";
            if (openF.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    MyImage.Image = System.Drawing.Image.FromFile(openF.FileName);
                    string strimg = openF.FileName.ToString();
                    FileStream fs = new FileStream(strimg, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    imgBytesIn = br.ReadBytes((int)fs.Length);
                }
                catch
                {
                    MessageBox.Show("您选择的图片不能被读取或文件类型错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    S_Photo.Image = null;
                }
            }
        }

        public void N_btn(object sender, EventArgs e)
        {
            int ColInd = 0;
            if (dataGridView1.CurrentCell.ColumnIndex == -1 || dataGridView1.CurrentCell.ColumnIndex > 1)
                ColInd = 0;
            else
                ColInd = dataGridView1.CurrentCell.ColumnIndex;
            if ((((Button)sender).Name) == "btn_L_First")
            {
                dataGridView1.CurrentCell = this.dataGridView1[ColInd, 0];
                MyModuleClass.ED_Button(btn_L_First, btn_L_Previous, btn_L_Next, btn_L_Last, 0, 0, 1, 1);
            }
            if ((((Button)sender).Name) == "btn_L_Previous")
            {
                if (dataGridView1.CurrentCell.RowIndex == 0)
                {
                    MyModuleClass.ED_Button(btn_L_First, btn_L_Previous, btn_L_Next, btn_L_Last, 0, 0, 1, 1);
                }
                else
                {
                    dataGridView1.CurrentCell = this.dataGridView1[ColInd, dataGridView1.CurrentCell.RowIndex - 1];
                    MyModuleClass.ED_Button(btn_L_First, btn_L_Previous, btn_L_Next, btn_L_Last, 1, 1, 1, 1);
                }
            }
            if ((((Button)sender).Name) == "btn_L_Next")
            {
                if (dataGridView1.CurrentCell.RowIndex == dataGridView1.RowCount - 2)
                {
                    MyModuleClass.ED_Button(btn_L_First, btn_L_Previous, btn_L_Next, btn_L_Last, 1, 1, 0, 0);
                }
                else
                {
                    dataGridView1.CurrentCell = this.dataGridView1[ColInd, dataGridView1.CurrentCell.RowIndex + 1];
                    MyModuleClass.ED_Button(btn_L_First, btn_L_Previous, btn_L_Next, btn_L_Last, 1, 1, 1, 1);
                }
            }
            if ((((Button)sender).Name) == "btn_L_Last")
            {
                dataGridView1.CurrentCell = this.dataGridView1[ColInd, dataGridView1.RowCount - 2];
                MyModuleClass.ED_Button(btn_L_First, btn_L_Previous, btn_L_Next, btn_L_Last, 1, 1, 0, 0);
            }
        }

        public void Grid_Inof(DataGridView DGrid)
        {
            byte[] pic;
            if (DGrid.RowCount > 1)
            {
                S_0.Text = DGrid[0, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_1.Text = DGrid[1, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_2.Text = Convert.ToString(DGrid[2, DGrid.CurrentCell.RowIndex].Value).Trim();
                S_3.Text = MyModuleClass.Date_Format(Convert.ToString(DGrid[3, DGrid.CurrentCell.RowIndex].Value).Trim());
                S_4.Text = Convert.ToString(DGrid[4, DGrid.CurrentCell.RowIndex].Value).Trim();
                S_5.Text = DGrid[5, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_6.Text = DGrid[6, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_7.Text = DGrid[7, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_8.Text = DGrid[8, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_9.Text = DGrid[9, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_10.Text = MyModuleClass.Date_Format(Convert.ToString(DGrid[10, DGrid.CurrentCell.RowIndex].Value).Trim());
                S_11.Text = Convert.ToString(DGrid[11, DGrid.CurrentCell.RowIndex].Value).Trim();
                S_12.Text = DGrid[12, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_13.Text = DGrid[13, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_14.Text = DGrid[14, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_15.Text = DGrid[15, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_16.Text = DGrid[16, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_17.Text = DGrid[17, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_18.Text = DGrid[18, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_19.Text = DGrid[19, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_20.Text = MyModuleClass.Date_Format(Convert.ToString(DGrid[20, DGrid.CurrentCell.RowIndex].Value).Trim());
                S_21.Text = DGrid[21, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_22.Text = DGrid[23, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_23.Text = DGrid[24, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_24.Text = Convert.ToString(DGrid[25, DGrid.CurrentCell.RowIndex].Value).Trim();
                S_25.Text = DGrid[26, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_26.Text = MyModuleClass.Date_Format(Convert.ToString(DGrid[27, DGrid.CurrentCell.RowIndex].Value).Trim());
                S_27.Text = MyModuleClass.Date_Format(Convert.ToString(DGrid[28, DGrid.CurrentCell.RowIndex].Value).Trim());
                S_28.Text = Convert.ToString(DGrid[29, DGrid.CurrentCell.RowIndex].Value).Trim();
                try
                {
                    pic = (byte[])(MyDS_Grid.Tables[0].Rows[DGrid.CurrentCell.RowIndex][22]);
                    MemoryStream ms = new MemoryStream(pic);
                    S_Photo.Image = Image.FromStream(ms);
                }
                catch
                {
                    S_Photo.Image = null;
                }
                tmp_ID = S_0.Text.Trim();
            }
            else
            {
                MyModuleClass.Clear_Control(TC_1.TabPages[0].Controls);
            }
        }

        private void F_File_Load(object sender, EventArgs e)
        {
            MyDS_Grid = MyDataClass.getDataSet(DataClass.MyMeans.Allsql, "tb_StaffBasic");
            dataGridView1.DataSource = MyDS_Grid.Tables[0];
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.Columns[0].Width = 105;
            dataGridView1.Columns[1].Width = 129;

            for (int i = 2; i < dataGridView1.ColumnCount; i++)
                dataGridView1.Columns[i].Visible = false;

            MyModuleClass.MaskedTextBox_Format(S_3);
            MyModuleClass.MaskedTextBox_Format(S_10);
            MyModuleClass.MaskedTextBox_Format(S_20);
            MyModuleClass.MaskedTextBox_Format(S_26);
            MyModuleClass.MaskedTextBox_Format(S_27);

            MyModuleClass.CoPassData(S_2, "tb_Folk");
            MyModuleClass.CoPassData(S_5, "tb_Education");
            MyModuleClass.CoPassData(S_8, "tb_PoliticalStatus");
            MyModuleClass.CoPassData(S_12, "tb_EmployeeGenre");
            MyModuleClass.CoPassData(S_13, "tb_Title");
            MyModuleClass.CoPassData(S_14, "tb_Salary");
            MyModuleClass.CoPassData(S_15, "tb_Dept");
            MyModuleClass.CityInfo(S_22, "select distinct province from tb_City", 0);

            S_22.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            S_22.AutoCompleteSource = AutoCompleteSource.ListItems;

            Grid_Inof(dataGridView1);
            MyModuleClass.ED_Button(btn_Add, btn_Modify, btn_Cancel, btn_Save, 1, 1, 0, 0);
            Img_Save.Enabled = false;
            Img_Clear.Enabled = false;
        }

        public void Condition_Lookup(string C_Value)
        {
            MyDS_Grid = MyDataClass.getDataSet("select * from tb_Staffbasic where " + tmp_Field + " ='" + tmp_Value + "'", "tb_Staffbasic");
            dataGridView1.DataSource = MyDS_Grid.Tables[0];
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            hold_n = 1;
            if (TC_1.SelectedTab.Name == "tabPage1")
            {
                //MyModuleClass.Clear_Control(TC_1.TabPages[0].Controls);
                S_0.Text = MyModuleClass.GetAutoCoding("tb_Staffbasic", "ID");
                MyModuleClass.ED_Button(btn_Add, btn_Modify, btn_Cancel, btn_Save, 0, 0, 1, 1);
                Img_Clear.Enabled = true;
                Img_Save.Enabled = true;
            }

            if (TC_1.SelectedTab.Name == "tabPage2")
            {
                MyModuleClass.Clear_Control(this.tabPage2.Controls);
                Part_ID = MyModuleClass.GetAutoCoding("tb_Resume", "ID");  //自动添加编号;
            }
            if (TC_1.SelectedTab.Name == "tabPage3")
            {
                 MyModuleClass.Clear_Control(this.tabPage3.Controls);
                Part_ID = MyModuleClass.GetAutoCoding("tb_Family", "ID");  //自动添加编号;
            }
            if (TC_1.SelectedTab.Name == "tabPage4")
            {
                MyModuleClass.Clear_Control(this.tabPage4.Controls);
                Part_ID = MyModuleClass.GetAutoCoding("tb_TrainNote", "ID");  //自动添加编号;
            }
            if (TC_1.SelectedTab.Name == "tabPage5")
            {
                MyModuleClass.Clear_Control(this.tabPage5.Controls);
                Part_ID = MyModuleClass.GetAutoCoding("tb_RnP", "ID");  //自动添加编号;
            }
            MyModuleClass.ED_Button(btn_Add, btn_Modify, btn_Cancel, btn_Save, 1, 0, 1, 1);
        }

        private void btn_Modify_Click(object sender, EventArgs e)
        {
            hold_n = 2;
            MyModuleClass.ED_Button(btn_Add, btn_Modify, btn_Cancel, btn_Save, 0, 0, 1, 1);
            if (TC_1.SelectedTab.Name == "tabPage1")
            {
                Img_Clear.Enabled = true;
                Img_Save.Enabled = true;
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (TC_1.SelectedTab.Name == "tabPage1")
            {
                DialogResult strAbortRetyrIgnore = MessageBox.Show("确认删除？", "警告", MessageBoxButtons.OKCancel);
                if (strAbortRetyrIgnore.ToString() == "OK")
                {
                    if (dataGridView1.RowCount < 2)
                    {
                        MessageBox.Show("数据表为空，操作失败！");
                        return;
                    }

                    MyDataClass.getCmd("delete tb_Staffbasic where ID = '" + S_0.Text.Trim() + "'");
                    MyDataClass.getCmd("Delete tb_Resume where Staff_ID='" + S_0.Text.Trim() + "'");
                    MyDataClass.getCmd("Delete tb_Family where Staff_ID='" + S_0.Text.Trim() + "'");
                    MyDataClass.getCmd("Delete tb_TrainNote where Staff_ID='" + S_0.Text.Trim() + "'");
                    MyDataClass.getCmd("Delete tb_RnP where Staff_ID='" + S_0.Text.Trim() + "'");
                    MyDataClass.getCmd("Delete tb_Individual where ID='" + S_0.Text.Trim() + "'");
                }
            }

            else
            {
                DialogResult strAbortRetyrIgnore = MessageBox.Show("确认删除？", "警告", MessageBoxButtons.OKCancel);
                if (strAbortRetyrIgnore.ToString() == "OK")
                {
                    string Delete_Table = "";
                    string Delete_ID = "";
                    if (TC_1.SelectedTab.Name == "tabPage2")
                    {
                        if (dataGridView2.RowCount < 2)
                        {
                            MessageBox.Show("数据表为空，不可以删除。");
                            return;
                        }
                        Delete_ID = dataGridView2[1, dataGridView2.CurrentCell.RowIndex].Value.ToString();
                        Delete_Table = "tb_Resume";
                    }
                    if (TC_1.SelectedTab.Name == "tabPage3")
                    {
                        if (dataGridView3.RowCount < 2)
                        {
                            MessageBox.Show("数据表为空，不可以删除。");
                            return;
                        }
                        Delete_ID = dataGridView3[1, dataGridView3.CurrentCell.RowIndex].Value.ToString();
                        Delete_Table = "tb_Family";
                    }
                    if (TC_1.SelectedTab.Name == "tabPage4")
                    {
                        if (dataGridView4.RowCount < 2)
                        {
                            MessageBox.Show("数据表为空，不可以删除。");
                            return;
                        }
                        Delete_ID = dataGridView4[1, dataGridView4.CurrentCell.RowIndex].Value.ToString();
                        Delete_Table = "tb_TrainNote";
                    }
                    if (TC_1.SelectedTab.Name == "tabPage5")
                    {
                        if (dataGridView5.RowCount < 2)
                        {
                            MessageBox.Show("数据表为空，不可以删除。");
                            return;
                        }
                        Delete_ID = dataGridView5[1, dataGridView5.CurrentCell.RowIndex].Value.ToString();
                        Delete_Table = "tb_RnP";
                    }
                    if ((Delete_ID.Trim()).Length > 0)
                    {
                        MyDataClass.execSQLCmd("Delete " + Delete_Table + " where ID='" + Delete_ID + "'");
                        btn_Cancel_Click(sender, e);
                    }
                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            hold_n = 0;
            if (TC_1.SelectedTab.Name == "tabPage6")
                MyModuleClass.ED_Button(btn_Add, btn_Modify, btn_Cancel, btn_Save, 0, 1, 0, 0);
            else
            {
                if (TC_1.SelectedTab.Name == "tabPage1")
                {
                    MyModuleClass.ED_Button(btn_Add, btn_Modify, btn_Cancel, btn_Save, 1, 1, 0, 0);
                    Img_n = 0;
                    if (tmp_Field == "")
                        btn_G_ShowAll_Click(sender, e);
                    else
                        Condition_Lookup(tmp_Value);
                    Img_Clear.Enabled = false;
                    Img_Save.Enabled = false;
                }

                if (TC_1.SelectedTab.Name == "tabPage2")
                {
                    DataSet RSset = MyDataClass.getDataSet("select Staff_ID,ID,BeginDate as 开始时间,EndDate as 结束时间, Dept as 部门, Title as 职务, WorkUnit as 工作单位 from tb_Resume where Staff_ID='" + tmp_ID + "'", "tb_Resume");
                    MyModuleClass.Correlation_DGV(RSset, dataGridView2);
                }
                if (TC_1.SelectedTab.Name == "tabPage3")
                {
                    DataSet Fset = MyDataClass.getDataSet("select Staff_ID,ID,MemberName as 成员名称,Nexus as 与本人关系, BirthDate as 出生日期, WorkUnit as 工作单位, Title as 职务, PoliticalStatus as 政治面貌, Phone as 电话 from tb_Family where Staff_ID='" + tmp_ID + "'", "tb_Family");
                    MyModuleClass.Correlation_DGV(Fset, dataGridView3);
                }
                if (TC_1.SelectedTab.Name == "tabPage4")
                {
                    DataSet TRset = MyDataClass.getDataSet("select Staff_ID,ID,TrainningMode as 培训方式,BeginDate as 培训开始时间, EndDate as 培训结束时间, Speciality as 培训专业, TrainUnit as 培训单位, TrainningContent as 培训内容, Charge as 费用, Effect as 效果 from tb_TrainNote where Staff_ID='" + tmp_ID + "'", "tb_TrainNote");
                    MyModuleClass.Correlation_DGV(TRset, dataGridView4);
                }
                if (TC_1.SelectedTab.Name == "tabPage5")
                {
                    DataSet RPset = MyDataClass.getDataSet("select Staff_ID,ID,RPKind as 奖惩种类,RPDate as 奖惩时间, SealMan as 批准人, RevokeDate as 撤消时间, RevokeReason as 撤消原因 from tb_RnP where Staff_ID='" + tmp_ID + "'", "tb_RnP");
                    MyModuleClass.Correlation_DGV(RPset, dataGridView5);
                }
                MyModuleClass.ED_Button(btn_Add, btn_Modify, btn_Cancel, btn_Save, 1, 1, 0, 0);
            }
        }

        private void btn_G_ShowAll_Click(object sender, EventArgs e)
        {
            MyDS_Grid = MyDataClass.getDataSet(DataClass.MyMeans.Allsql, "tb_Staffbasic");
            dataGridView1.DataSource = MyDS_Grid.Tables[0];
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.Columns[0].Width = 105;
            dataGridView1.Columns[1].Width = 129;

            for (int i = 2; i < dataGridView1.ColumnCount; i++)
                dataGridView1.Columns[i].Visible = false;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (TC_1.SelectedTab.Name == "tabPage1")
            {
                try
                {
                    string All_Field = "ID,StaffName,Folk,Birthday,Age,Education,Marriage,Gender,PoliticalStatus,IDNo,Workdate,Seniority,Employee,Title,Salary,Dept,Phone,Handset,School,Major,Graduatedate,Address,Province,City,M_Pay,BankNo,Pact_B,Pact_E,Pact_Y";
                    if (hold_n == 1 || hold_n == 2)
                    {
                        ModuleClass.MyModule.ADDs = "";
                        MyModuleClass.Part_SaveClass(All_Field, S_0.Text.Trim(), "", TC_1.TabPages[0].Controls, "S_", "tb_Staffbasic", 30, hold_n);
                    }
                    if (Img_n > 0)
                        MyModuleClass.SaveImage(S_0.Text.Trim(), imgBytesIn);
                }
                catch
                {
                    MessageBox.Show("请输入正确的职工信息！");
                }
            }

            string s = "";
            if (TC_1.SelectedTab.Name == "tabPage2")
            {
                s = "ID,Staff_ID,BeginDate,EndDate,Dept,Title,WorkUnit";
                ModuleClass.MyModule.ADDs = "";
                if (hold_n == 2)
                {
                    if (dataGridView2.RowCount < 2)
                    {
                        MessageBox.Show("数据表为空，不可以修改");
                    }
                    else
                        Part_ID = dataGridView2[1, dataGridView2.CurrentCell.RowIndex].Value.ToString();
                }
                MyModuleClass.Part_SaveClass(s, tmp_ID, Part_ID, this.tabPage2.Controls, "W_", "tb_Resume", 7, hold_n);
            }
            if (TC_1.SelectedTab.Name == "tabPage3")
            {
                s = "ID,Staff_ID,MemberName,Nexus,BirthDate,WorkUnit,Title,PoliticalStatus,Phone";
                ModuleClass.MyModule.ADDs = "";
                if (hold_n == 2)
                {
                    if (dataGridView3.RowCount < 2)
                    {
                        MessageBox.Show("数据表为空，不可以修改");
                    }
                    else
                        Part_ID = dataGridView3[1, dataGridView3.CurrentCell.RowIndex].Value.ToString();
                }
                MyModuleClass.Part_SaveClass(s, tmp_ID, Part_ID, this.tabPage3.Controls, "F_", "tb_Family", 9, hold_n);
            }
            if (TC_1.SelectedTab.Name == "tabPage4")
            {
                s = "ID,Staff_ID,TrainningMode,BeginDate,EndDate,Speciality,TrainUnit,TrainningContent,Charge,Effect";
                ModuleClass.MyModule.ADDs = "";
                if (hold_n == 2)
                {
                    if (dataGridView4.RowCount < 2)
                    {
                        MessageBox.Show("数据表为空，不可以修改");
                    }
                    else
                        Part_ID = dataGridView4[1, dataGridView4.CurrentCell.RowIndex].Value.ToString();
                }
                MyModuleClass.Part_SaveClass(s, tmp_ID, Part_ID, this.tabPage4.Controls, "TR_", "tb_TrainNote", 10, hold_n);
            }
            if (TC_1.SelectedTab.Name == "tabPage5")
            {
                s = "ID,Staff_ID,RPKind,RPDate,SealMan,RevokeDate,RevokeReason";
                ModuleClass.MyModule.ADDs = "";
                if (hold_n == 2)
                {
                    if (dataGridView5.RowCount < 2)
                    {
                        MessageBox.Show("数据表为空，不可以修改");
                    }
                    else
                        Part_ID = dataGridView5[1, dataGridView5.CurrentCell.RowIndex].Value.ToString();
                }
                MyModuleClass.Part_SaveClass(s, tmp_ID, Part_ID, this.tabPage5.Controls, "RP_", "tb_RnP", 7, hold_n);
            }
            if (TC_1.SelectedTab.Name == "tabPage6")
            {
                SqlDataReader Read_Memo = MyDataClass.getCmd("select * from tb_Individual where ID = '" + tmp_ID + "'");
                if (Read_Memo.Read())
                    MyDataClass.execSQLCmd("update tb_Individual set Memo = '" + Ind_Memo.Text + "' where ID = '" + tmp_ID + "'");
                else
                    MyDataClass.execSQLCmd("insert into tb_Individual (ID,Memo) values ('" + tmp_ID + "','" + Ind_Memo.Text + "')");
                btn_Cancel_Click(sender, e);
            }
            if (ModuleClass.MyModule.ADDs != "")
                MyDataClass.execSQLCmd(ModuleClass.MyModule.ADDs);
            btn_Cancel_Click(sender, e);
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Img_Save_Click(object sender, EventArgs e)
        {
            Read_Image(openFileDialog1, S_Photo);
            Img_n = 1;
        }

        private void Img_Clear_Click(object sender, EventArgs e)
        {
            S_Photo.Image = null;
            imgBytesIn = new byte[65536];
            Img_n = 2;
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            btn_Delete.Enabled = true;
            MyModuleClass.ED_Button(btn_Add, btn_Modify, btn_Cancel, btn_Save, 1, 1, 0, 0);
            if (TC_1.SelectedTab.Name == "tabPage1")
            {
                hold_n = 0;
                MyModuleClass.ED_Button(btn_Add, btn_Modify, btn_Cancel, btn_Save, 1, 1, 0, 0);
                Img_n = 0;
                Img_Clear.Enabled = false;
                Img_Save.Enabled = false;
                btn_Word.Enabled = true;
            }
            //else if (TC_1.SelectedTab.Name == "tabPage2")
            //{
            //    MyModuleClass.MaskedTextBox_Format(W_2);
            //    MyModuleClass.MaskedTextBox_Format(W_2);
            //}
            //else if (TC_1.SelectedTab.Name == "tabPage3")
            //{
            //    MyModuleClass.MaskedTextBox_Format(F_4);
            //}
            //else if (TC_1.SelectedTab.Name == "tabPage4")
            //{
            //    MyModuleClass.MaskedTextBox_Format(TR_3);
            //    MyModuleClass.MaskedTextBox_Format(TR_4);
            //}
            else if (TC_1.SelectedTab.Name == "tabPage5")
            {
                //    MyModuleClass.MaskedTextBox_Format(RP_3);
                //    MyModuleClass.MaskedTextBox_Format(RP_5);
                MyModuleClass.CoPassData(RP_2, "tb_RPKind");
            }
            else if (TC_1.SelectedTab.Name == "tabPage6")
            {
                MyModuleClass.ED_Button(btn_Add, btn_Modify, btn_Cancel, btn_Delete, 0, 1, 0, 0);
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.CurrentCell.ColumnIndex > -1)
            {
                Grid_Inof(dataGridView1);
                MyModuleClass.ED_Button(btn_L_First, btn_L_Previous, btn_L_Next, btn_L_Last, 1, 1, 1, 1);

                DataSet RSset = MyDataClass.getDataSet("select Staff_ID,ID,BeginDate as 开始时间,EndDate as 结束时间, Dept as 部门, Title as 职务, WorkUnit as 工作单位 from tb_Resume where Staff_ID='" + tmp_ID + "'", "tb_Resume");
                MyModuleClass.Correlation_DGV(RSset, dataGridView2);
                if (RSset.Tables[0].Rows.Count < 1)
                    MyModuleClass.Clear_Grids(RSset.Tables[0].Columns.Count, tabPage2.Controls, "W_");
                else
                {
                    for (int i = 2; i < dataGridView2.Columns.Count - 1; i++)
                        dataGridView2.Columns[i].Width = 125;
                    dataGridView2.Columns[6].Width = 176;
                }

                DataSet Fset = MyDataClass.getDataSet("select Staff_ID,ID,MemberName as 成员名称,Nexus as 与本人关系, BirthDate as 出生日期, WorkUnit as 工作单位, Title as 职务, PoliticalStatus as 政治面貌, Phone as 电话 from tb_Family where Staff_ID='" + tmp_ID + "'", "tb_Family");
                MyModuleClass.Correlation_DGV(Fset, dataGridView3);
                if (Fset.Tables[0].Rows.Count < 1)
                    MyModuleClass.Clear_Grids(Fset.Tables[0].Columns.Count, tabPage3.Controls, "F_");

                DataSet TRset = MyDataClass.getDataSet("select Staff_ID,ID,TrainningMode as 培训方式,BeginDate as 培训开始时间, EndDate as 培训结束时间, Speciality as 培训专业, TrainUnit as 培训单位, TrainningContent as 培训内容, Charge as 费用, Effect as 效果 from tb_TrainNote where Staff_ID='" + tmp_ID + "'", "tb_TrainNote");
                MyModuleClass.Correlation_DGV(TRset, dataGridView4);
                if (TRset.Tables[0].Rows.Count < 1)
                    MyModuleClass.Clear_Grids(TRset.Tables[0].Columns.Count, tabPage4.Controls, "TR_");

                DataSet RPset = MyDataClass.getDataSet("select Staff_ID,ID,RPKind as 奖惩种类,RPDate as 奖惩时间, SealMan as 批准人, RevokeDate as 撤消时间, RevokeReason as 撤消原因 from tb_RnP where Staff_ID='" + tmp_ID + "'", "tb_RnP");
                MyModuleClass.Correlation_DGV(RPset, dataGridView5);
                if (RPset.Tables[0].Rows.Count < 1)
                    MyModuleClass.Clear_Grids(RPset.Tables[0].Columns.Count, tabPage5.Controls, "RP_");
                else
                {
                    for (int i = 2; i < dataGridView2.Columns.Count - 1; i++)
                        dataGridView5.Columns[i].Width = 125;
                    dataGridView5.Columns[6].Width = 176;
                }

                SqlDataReader Read_Memo = MyDataClass.getCmd("Select * from tb_Individual where ID='" + tmp_ID + "'");
                if (Read_Memo.Read())
                    Ind_Memo.Text = Read_Memo[1].ToString();
                else
                    Ind_Memo.Clear();
            }


        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        MyModuleClass.CityInfo(comboBox2, "select distinct StaffName from tb_Staffbasic", 0);  //职工姓名
                        tmp_Field = "StaffName";
                        break;
                    }
                case 1:  //性别
                    {
                        comboBox2.Items.Clear();
                        comboBox2.Items.Add("男");
                        comboBox2.Items.Add("女");
                        tmp_Field = "Gender";
                        break;

                    }
                case 2:
                    {
                        MyModuleClass.CoPassData(comboBox2, "tb_Folk");  //民族类别
                        tmp_Field = "Folk";
                        break;
                    }
                case 3:
                    {
                        MyModuleClass.CoPassData(comboBox2, "tb_Education");
                        tmp_Field = "Education";
                        break;
                    }
                case 4:
                    {
                        MyModuleClass.CoPassData(comboBox2, "tb_PoliticalStatus");
                        tmp_Field = "PoliticalStatus";
                        break;
                    }
                case 5:
                    {
                        MyModuleClass.CoPassData(comboBox2, "tb_EmployeeGenre");
                        tmp_Field = "Employee";
                        break;
                    }
                case 6:
                    {
                        MyModuleClass.CoPassData(comboBox2, "tb_Title");
                        tmp_Field = "Title";
                        break;
                    }
                case 7:
                    {
                        MyModuleClass.CoPassData(comboBox2, "tb_Dept");
                        tmp_Field = "Dept";
                        break;
                    }
                case 8:
                    {
                        MyModuleClass.CoPassData(comboBox2, "tb_Salary");
                        tmp_Field = "Salary";
                        break;
                    }
            }
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tmp_Value = comboBox2.SelectedItem.ToString();
                Condition_Lookup(tmp_Value);
            }
            catch
            {
                comboBox2.Text = "";
                MessageBox.Show("只能以选择方式查询！");
            }
        }

        private void S_22_TextChanged(object sender, EventArgs e)
        {
            S_23.Items.Clear();
            MyModuleClass.CityInfo(S_23, "select province, city from tb_City where province = '" + S_22.Text.Trim() + "'", 1);
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            MyModuleClass.Show_CGrid(dataGridView2, tabPage2.Controls, "W_");
        }

        private void dataGridView3_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            MyModuleClass.Show_CGrid(dataGridView3, tabPage3.Controls, "F_");
        }

        private void dataGridView4_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            MyModuleClass.Show_CGrid(dataGridView4, tabPage4.Controls, "TR_");
        }

        private void dataGridView5_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            MyModuleClass.Show_CGrid(dataGridView5, tabPage5.Controls, "RP_");
        }

        private void btn_L_First_Click(object sender, EventArgs e)
        {
            N_btn(sender, e);
        }

        private void btn_L_Previous_Click(object sender, EventArgs e)
        {
            N_btn(sender, e);
        }

        private void btn_L_Next_Click(object sender, EventArgs e)
        {
            N_btn(sender, e);
        }

        private void btn_L_Last_Click(object sender, EventArgs e)
        {
            N_btn(sender, e);
        }

        private void btn_Word_Click(object sender, EventArgs e)
        {
            object Nothing = System.Reflection.Missing.Value;
            object missing = System.Reflection.Missing.Value;
            //创建Word文档
            Word.Application wordApp = new Word.ApplicationClass();
            Word.Document wordDoc = wordApp.Documents.Add(ref Nothing, ref Nothing, ref Nothing, ref Nothing);
            wordApp.Visible = true;

            //设置文档宽度
            wordApp.Selection.PageSetup.LeftMargin = wordApp.CentimetersToPoints(float.Parse("2"));
            wordApp.ActiveWindow.ActivePane.HorizontalPercentScrolled = 11;
            wordApp.Selection.PageSetup.RightMargin = wordApp.CentimetersToPoints(float.Parse("2"));

            Object start = Type.Missing;
            Object end = Type.Missing;

            PictureBox pp = new PictureBox();   //新建一个PictureBox控件
            int p1 = 0;
            for (int i = 0; i < MyDS_Grid.Tables[0].Rows.Count; i++)
            {
                try
                {
                    byte[] pic = (byte[])(MyDS_Grid.Tables[0].Rows[i][23]); //将数据库中的图片转换成二进制流
                    MemoryStream ms = new MemoryStream(pic);			//将字节数组存入到二进制流中
                    pp.Image = Image.FromStream(ms);   //二进制流Image控件中显示
                    pp.Image.Save(@"C:\22.bmp");    //将图片存入到指定的路径
                }
                catch
                {
                    p1 = 1;
                }
                object rng = Type.Missing;
                string strInfo = "职工基本信息表" + "(" + MyDS_Grid.Tables[0].Rows[i][1].ToString() + ")";
                start = 0;
                end = 0;
                wordDoc.Range(ref start, ref end).InsertBefore(strInfo);    //插入文本
                wordDoc.Range(ref start, ref end).Font.Name = "Verdana";    //设置字体
                wordDoc.Range(ref start, ref end).Font.Size = 20;   //设置字体大小
                wordDoc.Range(ref start, ref end).ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter; //设置字体局中

                start = strInfo.Length;
                end = strInfo.Length;
                wordDoc.Range(ref start, ref end).InsertParagraphAfter();//插入回车

                object missingValue = Type.Missing;
                object location = strInfo.Length; //如果location超过已有字符的长度将会出错。一定要比"明细表"串多一个字符
                Word.Range rng2 = wordDoc.Range(ref location, ref location);

                wordDoc.Tables.Add(rng2, 14, 6, ref missingValue, ref missingValue);
                wordDoc.Tables[1].Rows.HeightRule = Word.WdRowHeightRule.wdRowHeightAtLeast;
                wordDoc.Tables[1].Rows.Height = wordApp.CentimetersToPoints(float.Parse("0.8"));
                wordDoc.Tables[1].Range.Font.Size = 10;
                wordDoc.Tables[1].Range.Font.Name = "宋体";

                //设置表格样式
                wordDoc.Tables[1].Borders[Word.WdBorderType.wdBorderLeft].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
                wordDoc.Tables[1].Borders[Word.WdBorderType.wdBorderLeft].LineWidth = Word.WdLineWidth.wdLineWidth050pt;
                wordDoc.Tables[1].Borders[Word.WdBorderType.wdBorderLeft].Color = Word.WdColor.wdColorAutomatic;
                wordApp.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;//设置右对齐

                //第5行显示
                wordDoc.Tables[1].Cell(1, 5).Merge(wordDoc.Tables[1].Cell(5, 6));
                //第6行显示
                wordDoc.Tables[1].Cell(6, 5).Merge(wordDoc.Tables[1].Cell(6, 6));
                //第9行显示
                wordDoc.Tables[1].Cell(9, 4).Merge(wordDoc.Tables[1].Cell(9, 6));
                //第12行显示
                wordDoc.Tables[1].Cell(12, 2).Merge(wordDoc.Tables[1].Cell(12, 6));
                //第13行显示
                wordDoc.Tables[1].Cell(13, 2).Merge(wordDoc.Tables[1].Cell(13, 6));
                //第14行显示
                wordDoc.Tables[1].Cell(14, 2).Merge(wordDoc.Tables[1].Cell(14, 6));

                //第1行赋值
                wordDoc.Tables[1].Cell(1, 1).Range.Text = "职工编号：";
                wordDoc.Tables[1].Cell(1, 2).Range.Text = MyDS_Grid.Tables[0].Rows[i][0].ToString();
                wordDoc.Tables[1].Cell(1, 3).Range.Text = "职工姓名：";
                wordDoc.Tables[1].Cell(1, 4).Range.Text = MyDS_Grid.Tables[0].Rows[i][1].ToString();

                //插入图片

                if (p1 == 0)
                {
                    string FileName = @"C:\22.bmp";//图片所在路径
                    object LinkToFile = false;
                    object SaveWithDocument = true;
                    object Anchor = wordDoc.Tables[1].Cell(1, 5).Range;    //指定图片插入的区域
                    //将图片插入到单元格中
                    wordDoc.Tables[1].Cell(1, 5).Range.InlineShapes.AddPicture(FileName, ref LinkToFile, ref SaveWithDocument, ref Anchor);
                }
                p1 = 0;

                //第2行赋值
                wordDoc.Tables[1].Cell(2, 1).Range.Text = "民族类别：";
                wordDoc.Tables[1].Cell(2, 2).Range.Text = MyDS_Grid.Tables[0].Rows[i][2].ToString();
                wordDoc.Tables[1].Cell(2, 3).Range.Text = "出生日期：";
                try
                {
                    wordDoc.Tables[1].Cell(2, 4).Range.Text = Convert.ToString(Convert.ToDateTime(MyDS_Grid.Tables[0].Rows[i][3]).ToShortDateString());
                }
                catch { wordDoc.Tables[1].Cell(2, 4).Range.Text = ""; }
                //Convert.ToString(MyDS_Grid.Tables[0].Rows[i][3]);
                //第3行赋值
                wordDoc.Tables[1].Cell(3, 1).Range.Text = "年龄：";
                wordDoc.Tables[1].Cell(3, 2).Range.Text = Convert.ToString(MyDS_Grid.Tables[0].Rows[i][4]);
                wordDoc.Tables[1].Cell(3, 3).Range.Text = "文化程度：";
                wordDoc.Tables[1].Cell(3, 4).Range.Text = MyDS_Grid.Tables[0].Rows[i][5].ToString();
                //第4行赋值
                wordDoc.Tables[1].Cell(4, 1).Range.Text = "婚姻：";
                wordDoc.Tables[1].Cell(4, 2).Range.Text = MyDS_Grid.Tables[0].Rows[i][6].ToString();
                wordDoc.Tables[1].Cell(4, 3).Range.Text = "性别：";
                wordDoc.Tables[1].Cell(4, 4).Range.Text = MyDS_Grid.Tables[0].Rows[i][7].ToString();
                //第5行赋值
                wordDoc.Tables[1].Cell(5, 1).Range.Text = "政治面貌：";
                wordDoc.Tables[1].Cell(5, 2).Range.Text = MyDS_Grid.Tables[0].Rows[i][8].ToString();
                wordDoc.Tables[1].Cell(5, 3).Range.Text = "单位工作时间：";
                try
                {
                    wordDoc.Tables[1].Cell(5, 4).Range.Text = Convert.ToString(Convert.ToDateTime(MyDS_Grid.Tables[0].Rows[0][10]).ToShortDateString());
                }
                catch { wordDoc.Tables[1].Cell(5, 4).Range.Text = ""; }
                //第6行赋值
                wordDoc.Tables[1].Cell(6, 1).Range.Text = "籍贯：";
                wordDoc.Tables[1].Cell(6, 2).Range.Text = MyDS_Grid.Tables[0].Rows[i][23].ToString();
                wordDoc.Tables[1].Cell(6, 3).Range.Text = MyDS_Grid.Tables[0].Rows[i][24].ToString();
                wordDoc.Tables[1].Cell(6, 4).Range.Text = "身份证：";
                wordDoc.Tables[1].Cell(6, 5).Range.Text = MyDS_Grid.Tables[0].Rows[i][9].ToString();
                //第7行赋值
                wordDoc.Tables[1].Cell(7, 1).Range.Text = "工龄：";
                wordDoc.Tables[1].Cell(7, 2).Range.Text = Convert.ToString(MyDS_Grid.Tables[0].Rows[i][11]);
                wordDoc.Tables[1].Cell(7, 3).Range.Text = "职工类别：";
                wordDoc.Tables[1].Cell(7, 4).Range.Text = MyDS_Grid.Tables[0].Rows[i][12].ToString();
                wordDoc.Tables[1].Cell(7, 5).Range.Text = "职务类别：";
                wordDoc.Tables[1].Cell(7, 6).Range.Text = MyDS_Grid.Tables[0].Rows[i][13].ToString();
                //第8行赋值
                wordDoc.Tables[1].Cell(8, 1).Range.Text = "工资类别：";
                wordDoc.Tables[1].Cell(8, 2).Range.Text = MyDS_Grid.Tables[0].Rows[i][14].ToString();
                wordDoc.Tables[1].Cell(8, 3).Range.Text = "部门类别：";
                wordDoc.Tables[1].Cell(8, 4).Range.Text = MyDS_Grid.Tables[0].Rows[i][15].ToString();
                //第9行赋值
                wordDoc.Tables[1].Cell(9, 1).Range.Text = "月工资：";
                wordDoc.Tables[1].Cell(9, 2).Range.Text = Convert.ToString(MyDS_Grid.Tables[0].Rows[i][25]);
                wordDoc.Tables[1].Cell(9, 3).Range.Text = "银行账号：";
                wordDoc.Tables[1].Cell(9, 4).Range.Text = MyDS_Grid.Tables[0].Rows[i][26].ToString();
                //第10行赋值
                wordDoc.Tables[1].Cell(10, 1).Range.Text = "合同起始日期：";
                try
                {
                    wordDoc.Tables[1].Cell(10, 2).Range.Text = Convert.ToString(Convert.ToDateTime(MyDS_Grid.Tables[0].Rows[i][27]).ToShortDateString());
                }
                catch { wordDoc.Tables[1].Cell(10, 2).Range.Text = ""; }
                //Convert.ToString(MyDS_Grid.Tables[0].Rows[i][28]);
                wordDoc.Tables[1].Cell(10, 3).Range.Text = "合同结束日期：";
                try
                {
                    wordDoc.Tables[1].Cell(10, 4).Range.Text = Convert.ToString(Convert.ToDateTime(MyDS_Grid.Tables[0].Rows[i][28]).ToShortDateString());
                }
                catch { wordDoc.Tables[1].Cell(10, 4).Range.Text = ""; }
                //Convert.ToString(MyDS_Grid.Tables[0].Rows[i][29]);
                wordDoc.Tables[1].Cell(10, 5).Range.Text = "合同年限：";
                wordDoc.Tables[1].Cell(10, 6).Range.Text = Convert.ToString(MyDS_Grid.Tables[0].Rows[i][29]);
                //第11行赋值
                wordDoc.Tables[1].Cell(11, 1).Range.Text = "电话：";
                wordDoc.Tables[1].Cell(11, 2).Range.Text = MyDS_Grid.Tables[0].Rows[i][16].ToString();
                wordDoc.Tables[1].Cell(11, 3).Range.Text = "手机：";
                wordDoc.Tables[1].Cell(11, 4).Range.Text = MyDS_Grid.Tables[0].Rows[i][17].ToString();
                wordDoc.Tables[1].Cell(11, 5).Range.Text = "毕业时间：";
                try
                {
                    wordDoc.Tables[1].Cell(11, 6).Range.Text = Convert.ToString(Convert.ToDateTime(MyDS_Grid.Tables[0].Rows[i][20]).ToShortDateString());
                }
                catch { wordDoc.Tables[1].Cell(11, 6).Range.Text = ""; }
                //Convert.ToString(MyDS_Grid.Tables[0].Rows[i][21]);
                //第12行赋值
                wordDoc.Tables[1].Cell(12, 1).Range.Text = "毕业学校：";
                wordDoc.Tables[1].Cell(12, 2).Range.Text = MyDS_Grid.Tables[0].Rows[i][18].ToString();
                //第13行赋值
                wordDoc.Tables[1].Cell(13, 1).Range.Text = "主修专业：";
                wordDoc.Tables[1].Cell(13, 2).Range.Text = MyDS_Grid.Tables[0].Rows[i][19].ToString();
                //第14行赋值
                wordDoc.Tables[1].Cell(14, 1).Range.Text = "家庭地址：";
                wordDoc.Tables[1].Cell(14, 2).Range.Text = MyDS_Grid.Tables[0].Rows[i][21].ToString();

                wordDoc.Range(ref start, ref end).InsertParagraphAfter();//插入回车
                wordDoc.Range(ref start, ref end).ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter; //设置字体局中
            }

        }
    }
}
