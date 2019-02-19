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
    public partial class F_Find : Form
    {
        public F_Find()
        {
            InitializeComponent();
        }
        DataClass.MyMeans MyDataClass = new EMS.DataClass.MyMeans();
        ModuleClass.MyModule MyModuleClass = new EMS.ModuleClass.MyModule();
        public static DataSet MyDS_Grid;
        public static string ARsign = " And ";
        public static string SQLstr = "select ID as 编号,StaffName as 职工姓名,Folk as 民族类别,Birthday as 出生日期,Age as 年龄,Education as 文化程度,Marriage as 婚姻,Gender as 性别,PoliticalStatus as 政治面貌,IDNo as 身份证号,Workdate as 单位工作时间,Seniority as 工龄,Employee as 职工类别,Title as 职务类别,Salary as 工资类别,Dept as 部门类别,Phone as 电话,Handset as 手机,School as 毕业学校,Major as 主修专业,GraduateDate as 毕业时间,M_Pay as 月工资,BankNo as 银行帐号,Pact_B as 合同开始时间,Pact_E as 合同结束时间,Pact_Y as 合同年限,Province as 籍贯所在省,City as 籍贯所在市 from tb_Staffbasic";

        private void F_Find_Load(object sender, EventArgs e)
        {
            MyModuleClass.CoPassData(Find_Folk, "tb_Folk");  
            MyModuleClass.CoPassData(Find_Education, "tb_Education");  
            MyModuleClass.CoPassData(Find_PoliticalStatus, "tb_PoliticalStatus");  
            MyModuleClass.CoPassData(Find_Employee, "tb_EmployeeGenre");  
            MyModuleClass.CoPassData(Find_Title, "tb_Title");  
            MyModuleClass.CoPassData(Find_Salary, "tb_Salary");  
            MyModuleClass.CoPassData(Find_Dept, "tb_Dept");  
            MyModuleClass.CityInfo(Find_Province, "select distinct province from tb_City", 0);
            MyModuleClass.CityInfo(Find_School, "select distinct School from tb_Staffbasic", 0);
            MyModuleClass.CityInfo(Find_Major, "select distinct Major from tb_Staffbasic", 0);
            MyModuleClass.MaskedTextBox_Format(Find_Workdate1);  
            MyModuleClass.MaskedTextBox_Format(Find_Workdate2);
            MyDS_Grid = MyDataClass.getDataSet(SQLstr, "tb_Staffbasic");
            dataGridView1.DataSource = MyDS_Grid.Tables[0];
            dataGridView1.AutoGenerateColumns = true;
        }

        private void Find_Province_TextChanged(object sender, EventArgs e)
        {
            Find_City.Items.Clear();
            MyModuleClass.CityInfo(Find_City, "select province,city from tb_City where province='" + Find_Province.Text.Trim() + "'", 1);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ARsign = " And ";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ARsign = " Or ";
        }

        private void btn_Inquiry_Click(object sender, EventArgs e)
        {
            ModuleClass.MyModule.FindValue = "";
            string Find_SQL = SQLstr;
            MyModuleClass.Find_Grids(this.Controls, "Find", ARsign);
            if (MyModuleClass.Date_Format(Find_Workdate1.Text) != "" && MyModuleClass.Date_Format(Find_Workdate2.Text) != "")
            {
                if (ModuleClass.MyModule.FindValue != "")   
                    ModuleClass.MyModule.FindValue = ModuleClass.MyModule.FindValue + ARsign;
                ModuleClass.MyModule.FindValue = ModuleClass.MyModule.FindValue + " (" + "workdate>='" + Find_Workdate1.Text + "' AND workdate<='" + Find_Workdate2.Text + "')";
            }
            if (ModuleClass.MyModule.FindValue != "")   
               
                Find_SQL = Find_SQL + " where " + ModuleClass.MyModule.FindValue;
            MyDS_Grid = MyDataClass.getDataSet(Find_SQL, "tb_Staffbasic");
            dataGridView1.DataSource = MyDS_Grid.Tables[0];
            dataGridView1.AutoGenerateColumns = true;
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            MyModuleClass.Clear_Control(this.Controls);
        }

        private void btn_ShowAll_Click(object sender, EventArgs e)
        {
            MyDS_Grid = MyDataClass.getDataSet(SQLstr, "tb_Staffbasic");
            dataGridView1.DataSource = MyDS_Grid.Tables[0];
            dataGridView1.AutoGenerateColumns = true;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
