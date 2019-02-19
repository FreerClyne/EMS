using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMS
{
    public partial class F_Main : Form
    {
        DataClass.MyMeans MyClass = new EMS.DataClass.MyMeans();
        ModuleClass.MyModule MyMenu = new EMS.ModuleClass.MyModule();
        public F_Main()
        {
            InitializeComponent();
        }

        private void ctl_Main()
        {
            MyMenu.MainMenuD(menuStrip1);   
            MyMenu.MainMenuC(menuStrip1, DataClass.MyMeans.Login_Name);  
        }

        private void F_Main_Load(object sender, EventArgs e)
        {
            F_Login Frmlogin = new F_Login();
            Frmlogin.Tag = 1;
            Frmlogin.ShowDialog();
            Frmlogin.Dispose();
            if (DataClass.MyMeans.Login_n == 1)
            {
                ctl_Main();   
                MyMenu.PactDay(1);  
                MyMenu.PactDay(2);  
            }
            DataClass.MyMeans.Login_n = 3;  
            Tool_Help.Enabled = true;
            Tool_ShutDown.Enabled = true;
        }

        private void Tool_Folk_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 2);
        }

        private void Tool_EmployeeGenre_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 2);
        }

        private void Tool_Culture_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 2);
        }

        private void Tool_PoliticalStatus_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 2);
        }

        private void Tool_Dept_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 2);
        }

        private void Tool_Salary_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 2);
        }

        private void Tool_Title_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 2);
        }

        private void Tool_PRKind_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 2);
        }

        private void Tool_WordPad_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 2);
        }

        private void Tool_CrewBirthday_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void Tool_CrewContract_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void Tool_CrewFile_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void Tool_CrewFind_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void Tool_CrewSum_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void Tool_Log_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void Tool_AddressList_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void Tool_DBBackup_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void Tool_DataClear_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void Tool_UserSetup_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void Tool_ReLogin_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void Tool_ShutDown_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Tool_Help_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void F_Main_Activated(object sender, EventArgs e)
        {
            if (DataClass.MyMeans.Login_n == 2) 
                ctl_Main();   
            DataClass.MyMeans.Login_n = 3;
        }


    }
}
