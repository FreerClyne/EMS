using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EMS.InfoAddForm
{
    public partial class F_Basic : Form
    {
        public F_Basic()
        {
            InitializeComponent();
        }
        DataClass.MyMeans MyDataClass = new EMS.DataClass.MyMeans();
        public static string reField = "";
        public static int index = -1;

        private void F_Basic_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            DataSet My_Set = MyDataClass.getDataSet(DataClass.MyMeans.Mean_SQL, DataClass.MyMeans.Mean_Table);
            if (My_Set.Tables[0].Rows.Count > 0)
                for (int i = 0; i < My_Set.Tables[0].Rows.Count; i++ )
                    listBox1.Items.Add(My_Set.Tables[0].Rows[i][1].ToString());
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            bool t = false;
            string tmpField = "";
            if (textBox1.Text != "")
            {
                tmpField = textBox1.Text.Trim();
                SqlDataReader tmpDR = MyDataClass.getCmd("select * from " + DataClass.MyMeans.Mean_Table.Trim() + " where " + DataClass.MyMeans.Mean_Field.Trim() + " = '" + tmpField + "'");
                t = tmpDR.Read();
                if (t == false)
                {
                    MyDataClass.getCmd("insert into " + DataClass.MyMeans.Mean_Table.Trim() + " (" + DataClass.MyMeans.Mean_Field.Trim() + ") values (" + "'" + tmpField + "'" + ")");
                    listBox1.Items.Add(tmpField);
                    textBox1.Text = "";                   
                }
                else
                    MessageBox.Show("民族已存在！");
            }
        }

        private void btn_modify_Click(object sender, EventArgs e)
        {
            bool t = false;
            string tmpField = "";
            if (textBox1.Text != "")
            {
                SqlDataReader tmpDR = MyDataClass.getCmd("select * from " + DataClass.MyMeans.Mean_Table.Trim() + " where " + DataClass.MyMeans.Mean_Field.Trim() + " = '" + reField + "'");
                t = tmpDR.Read();
                if (t == true)
                {
                    tmpField = tmpDR[0].ToString().Trim();
                    MyDataClass.getCmd("update " + DataClass.MyMeans.Mean_Table.Trim() + " set " + DataClass.MyMeans.Mean_Field.Trim() + " = '" + textBox1.Text.Trim() + "' where ID = '" + tmpField + "'");
                    if (index >= 0)
                    {
                        listBox1.Items[index] = textBox1.Text.Trim();
                        textBox1.Text = "";
                    }
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (reField != "" & index >= 0)
            {
                MyDataClass.getCmd("delete from " + DataClass.MyMeans.Mean_Table.Trim() + " where " + DataClass.MyMeans.Mean_Field.Trim() + " = '" + reField + "'");
                listBox1.Items.Remove(listBox1.Items[listBox1.SelectedIndex]);
                listBox1.SelectedIndex = -1;
                index = -1;
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                reField = listBox1.SelectedItem.ToString();
                index = listBox1.SelectedIndex;
            }
        }

    }
}
