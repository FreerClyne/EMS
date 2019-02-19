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
    public partial class F_UserPermission : Form
    {
        public F_UserPermission()
        {
            InitializeComponent();
        }
        DataClass.MyMeans MyDataClass = new EMS.DataClass.MyMeans();
        ModuleClass.MyModule MyModuleClass = new EMS.ModuleClass.MyModule();

        private void F_UserPermission_Shown(object sender, EventArgs e)
        {
            User_ID.Text = ModuleClass.MyModule.User_ID;
            User_Name.Text = ModuleClass.MyModule.User_Name;
            if (User_Name.Text.Trim() == "TSoft")
                btn_OK.Enabled = false;
            MyModuleClass.Show_Pope(groupBox2.Controls, ModuleClass.MyModule.User_ID);
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            MyModuleClass.Modify_Permission(groupBox2.Controls, ModuleClass.MyModule.User_ID);
            if (DataClass.MyMeans.Login_ID == ModuleClass.MyModule.User_ID)
                DataClass.MyMeans.Login_n = 2;
            this.Close();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox20_MouseDown(object sender, MouseEventArgs e)
        {
            bool tt = false;
            if (((CheckBox)sender).Checked == true)
                tt = false;
            else
                tt = true;
            foreach (Control C in groupBox2.Controls)
            {
                string sID = C.Name;
                if (sID.IndexOf("User_") > -1)
                {
                    ((CheckBox)C).Checked = tt;
                }
            }
        }

        private void User_Folk_MouseUp(object sender, MouseEventArgs e)
        {
            if (((CheckBox)sender).Checked == false)
            {
                checkBox20.Checked = false;
            }
        }
        

    }
}
