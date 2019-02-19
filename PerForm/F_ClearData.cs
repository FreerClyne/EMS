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
    public partial class F_ClearData : Form
    {
        public F_ClearData()
        {
            InitializeComponent();
        }
        ModuleClass.MyModule MyModuleClass = new EMS.ModuleClass.MyModule();

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult strAbortRetyrIgnore = MessageBox.Show("确认删除类别所有数据？", "警告", MessageBoxButtons.OKCancel);
            if (strAbortRetyrIgnore.ToString() == "OK")
            {
                MyModuleClass.Clear_Table(groupBox1.Controls, "T_");
            }
        }

        private void checkBox20_MouseDown(object sender, MouseEventArgs e)
        {
            bool tt = false;
            if (((CheckBox)sender).Checked == true)
                tt = false;
            else
                tt = true;
            foreach (Control C in groupBox1.Controls)
            {
                string sID = C.Name;
                if (sID.IndexOf("T_") > -1)
                {
                    ((CheckBox)C).Checked = tt;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void T_1_MouseUp(object sender, MouseEventArgs e)
        {
            if (((CheckBox)sender).Checked == false)
            {
                checkBox20.Checked = false;
            }
        }


    }
}
