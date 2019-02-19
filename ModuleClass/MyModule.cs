using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace EMS.ModuleClass
{
    class MyModule
    {
        #region Global variable
        DataClass.MyMeans MyDataClass = new EMS.DataClass.MyMeans();
        public static string ADDs = "";
        public static string FindValue = "";
        public static string Address_ID = "";
        public static string User_ID = "";
        public static string User_Name = "";
        #endregion

        #region windows call
        public void Show_Form(string FrmName, int n)
        {
            if (n == 1)
            {
                if (FrmName == "员工生日提示")
                {
                    InfoAddForm.F_EventPrompt FrmEventPrompt = new EMS.InfoAddForm.F_EventPrompt();
                    FrmEventPrompt.Text = FrmName;
                    FrmEventPrompt.Tag = 1;
                    FrmEventPrompt.ShowDialog();
                    FrmEventPrompt.Dispose();
                }
                if (FrmName == "员工合同提示")
                {
                    InfoAddForm.F_EventPrompt FrmEventPrompt = new EMS.InfoAddForm.F_EventPrompt();
                    FrmEventPrompt.Text = FrmName;
                    FrmEventPrompt.Tag = 2;
                    FrmEventPrompt.ShowDialog();
                    FrmEventPrompt.Dispose();
                }
                if (FrmName == "人事档案管理")
                {
                    PerForm.F_File FrmFile = new EMS.PerForm.F_File();
                    FrmFile.Text = FrmName;
                    FrmFile.ShowDialog();
                    FrmFile.Dispose();
                }
                if (FrmName == "人事资料查询")
                {
                    PerForm.F_Find FrmFind = new EMS.PerForm.F_Find();
                    FrmFind.Text = FrmName;
                    FrmFind.ShowDialog();
                    FrmFind.Dispose();
                }
                if (FrmName == "人事资料统计")
                {
                    PerForm.F_Statistic FrmStatistic = new EMS.PerForm.F_Statistic();
                    FrmStatistic.Text = FrmName;
                    FrmStatistic.ShowDialog();
                    FrmStatistic.Dispose();
                }             
                if (FrmName == "日常记录")
                {
                    PerForm.F_Log FrmLog = new EMS.PerForm.F_Log();
                    FrmLog.Text = FrmName;
                    FrmLog.ShowDialog();
                    FrmLog.Dispose();
                }
                if (FrmName == "通讯录")
                {
                    PerForm.F_AddressList FrmAddressList = new EMS.PerForm.F_AddressList();
                    FrmAddressList.Text = FrmName;
                    FrmAddressList.ShowDialog();
                    FrmAddressList.Dispose();
                }
                if (FrmName == "备份/还原数据库")
                {
                    PerForm.F_Backup FrmBackup = new EMS.PerForm.F_Backup();
                    FrmBackup.Text = FrmName;
                    FrmBackup.ShowDialog();
                    FrmBackup.Dispose();
                }
                if (FrmName == "清空数据库")
                {
                    PerForm.F_ClearData FrmClearData = new EMS.PerForm.F_ClearData();
                    FrmClearData.Text = FrmName;
                    FrmClearData.ShowDialog();
                    FrmClearData.Dispose();
                }
                if (FrmName == "用户设置")
                {
                    PerForm.F_User FrmUser = new EMS.PerForm.F_User();
                    FrmUser.Text = FrmName;
                    FrmUser.ShowDialog();
                    FrmUser.Dispose();
                }
                if (FrmName == "重新登录")
                {
                    F_Login FrmLogin = new EMS.F_Login();
                    FrmLogin.Tag = 2;
                    FrmLogin.ShowDialog();
                    FrmLogin.Dispose();
                }
                if (FrmName == "帮助")
                {
                    PerForm.F_Help FrmHelp = new EMS.PerForm.F_Help();
                    FrmHelp.Text = FrmName;
                    FrmHelp.ShowDialog();
                    FrmHelp.Dispose();
                }
            }
            if (n == 2)
            {
                string FrmStr = "";
                if (FrmName == "民族类别设置")
                {
                    DataClass.MyMeans.Mean_SQL = "select * from tb_Folk";
                    DataClass.MyMeans.Mean_Table = "tb_Folk";
                    DataClass.MyMeans.Mean_Field = "FolkName";
                    FrmStr = FrmName;
                }
                if (FrmName == "职工类别设置")
                {
                    DataClass.MyMeans.Mean_SQL = "select * from tb_EmployeeGenre";
                    DataClass.MyMeans.Mean_Table = "tb_EmployeeGenre";
                    DataClass.MyMeans.Mean_Field = "EmployeeType";
                    FrmStr = FrmName;
                }
                if (FrmName == "文化程度设置")
                {
                    DataClass.MyMeans.Mean_SQL = "select * from tb_Education";
                    DataClass.MyMeans.Mean_Table = "tb_Education";
                    DataClass.MyMeans.Mean_Field = "EducationLv";
                    FrmStr = FrmName;
                }
                if (FrmName == "政治面貌设置")
                {
                    DataClass.MyMeans.Mean_SQL = "select * from tb_PoliticalStatus";
                    DataClass.MyMeans.Mean_Table = "tb_PoliticalStatus";
                    DataClass.MyMeans.Mean_Field = "PSType";
                    FrmStr = FrmName;
                }
                if (FrmName == "部门类别设置")
                {
                    DataClass.MyMeans.Mean_SQL = "select * from tb_Dept";
                    DataClass.MyMeans.Mean_Table = "tb_Dept";
                    DataClass.MyMeans.Mean_Field = "DeptName";
                    FrmStr = FrmName;
                }
                if (FrmName == "工资类别设置")
                {
                    DataClass.MyMeans.Mean_SQL = "select * from tb_Salary";
                    DataClass.MyMeans.Mean_Table = "tb_Salary";
                    DataClass.MyMeans.Mean_Field = "SalaryType";
                    FrmStr = FrmName;
                }
                if (FrmName == "职务类别设置")
                {
                    DataClass.MyMeans.Mean_SQL = "select * from tb_Title";
                    DataClass.MyMeans.Mean_Table = "tb_Title";
                    DataClass.MyMeans.Mean_Field = "TitleName";
                    FrmStr = FrmName;
                }         
                if (FrmName == "奖惩类别设置")
                {
                    DataClass.MyMeans.Mean_SQL = "select * from tb_RPKind";
                    DataClass.MyMeans.Mean_Table = "tb_RPKind";
                    DataClass.MyMeans.Mean_Field = "RPKind";
                    FrmStr = FrmName;
                }
                if (FrmName == "记事本类别设置")
                {
                    DataClass.MyMeans.Mean_SQL = "select * from tb_NotePad";
                    DataClass.MyMeans.Mean_Table = "tb_NotePad";
                    DataClass.MyMeans.Mean_Field = "DeptNP";
                    FrmStr = FrmName;
                }
                InfoAddForm.F_Basic FrmBasic = new EMS.InfoAddForm.F_Basic();
                FrmBasic.Text = FrmStr;
                FrmBasic.ShowDialog();
                FrmBasic.Dispose();
            }
        }
        #endregion

        #region Disable all menu
        public void MainMenuD(MenuStrip MenuS)
        {
            string Men = "";
            for (int i = 0; i < MenuS.Items.Count; i++)
            {
                Men = ((ToolStripDropDownItem)MenuS.Items[i]).Name;
                if (Men.IndexOf("Menu") == -1)
                    ((ToolStripDropDownItem)MenuS.Items[i]).Enabled = false;
                ToolStripDropDownItem newmenu = (ToolStripDropDownItem)MenuS.Items[i];
                if (newmenu.HasDropDownItems && newmenu.DropDownItems.Count > 0)
                    for (int j = 0; j < newmenu.DropDownItems.Count; j++)
                    {
                        Men = newmenu.DropDownItems[j].Name;
                        if (Men.IndexOf("Menu") == -1)
                            newmenu.DropDownItems[j].Enabled = false;
                        ToolStripDropDownItem newmenu2 = (ToolStripDropDownItem)newmenu.DropDownItems[j];
                        if (newmenu2.HasDropDownItems && newmenu2.DropDownItems.Count > 0)
                            for (int p = 0; p < newmenu2.DropDownItems.Count; p++)
                                newmenu2.DropDownItems[p].Enabled = false;
                    }
            }

        }
        #endregion

        #region Control menu via permission
        public void MainMenuC(MenuStrip MenuS, String UName)
        {
            string Str = "";
            string MenuName = "";
            DataSet DSet = MyDataClass.getDataSet("select ID from tb_Login where Name='" + UName + "'", "tb_Login");    //获取当前登录用户的信息
            string UID = Convert.ToString(DSet.Tables[0].Rows[0][0]);   //获取当前用户编号
            DSet = MyDataClass.getDataSet("select ID,PermissionType,Permission from tb_UserPermission where ID='" + UID + "'", "tb_UserPermission");    //获取当前用户的权限信息
            bool bo = false;
            for (int k = 0; k < DSet.Tables[0].Rows.Count; k++) //遍历当前用户的权限名称
            {
                Str = Convert.ToString(DSet.Tables[0].Rows[k][1]);  //获取权限名称
                if (Convert.ToInt32(DSet.Tables[0].Rows[k][2]) == 1)    //判断权限是否可用
                    bo = true;
                else
                    bo = false;
                for (int i = 0; i < MenuS.Items.Count; i++) //遍历菜单栏中的一级菜单项
                {
                    ToolStripDropDownItem newmenu = (ToolStripDropDownItem)MenuS.Items[i];  //记录当前菜单项下的所有信息
                    if (newmenu.HasDropDownItems && newmenu.DropDownItems.Count > 0)    //如果当前菜单项有子级菜单项
                        for (int j = 0; j < newmenu.DropDownItems.Count; j++)    //遍历二级菜单项
                        {
                            MenuName = newmenu.DropDownItems[j].Name;   //获取当前菜单项的名称
                            if (MenuName.IndexOf(Str) > -1) //如果包含权限名称
                                newmenu.DropDownItems[j].Enabled = bo;  //根据权限设置可用状态
                            ToolStripDropDownItem newmenu2 = (ToolStripDropDownItem)newmenu.DropDownItems[j];   //记录当前菜单项的所有信息
                            if (newmenu2.HasDropDownItems && newmenu2.DropDownItems.Count > 0)  //如果当前菜单项有子级菜单项
                                for (int p = 0; p < newmenu2.DropDownItems.Count; p++)  //遍历三级菜单项
                                {
                                    MenuName = newmenu2.DropDownItems[p].Name;  //获取当前菜单项的名称
                                    if (MenuName.IndexOf(Str) > -1) //如果包含权限名称
                                        newmenu2.DropDownItems[p].Enabled = bo;  //根据权限设置可用状态
                                }
                        }
                }
            }
        }
        #endregion

        #region Fromat maskedtextbox
        public void MaskedTextBox_Format(MaskedTextBox MTBox)
        {
            MTBox.Mask = "0000-00-00";
            MTBox.ValidatingType = typeof(System.DateTime);
        }
        #endregion

        #region Pass data to combobox
        public void CoPassData(ComboBox cobox, string TableName)
        {
            cobox.Items.Clear();
            DataClass.MyMeans MyDataClass = new EMS.DataClass.MyMeans();
            SqlDataReader MyDR = MyDataClass.getCmd("select * from " + TableName);
            if (MyDR.HasRows)
                while (MyDR.Read())
                    if (MyDR[1].ToString() != "" && MyDR[1].ToString() != null)
                        cobox.Items.Add(MyDR[1].ToString());
        }

        public void CityInfo(ComboBox cobox, string SQLstr, int n)
        {
            cobox.Items.Clear();
            DataClass.MyMeans MyDataClass = new EMS.DataClass.MyMeans();
            SqlDataReader MyDR = MyDataClass.getCmd(SQLstr);
            if (MyDR.HasRows)
                while (MyDR.Read())
                    if (MyDR[n].ToString() != "" && MyDR[n].ToString() != null)
                        cobox.Items.Add(MyDR[n].ToString());
        }
        #endregion

        #region Date Format
        public string Date_Format(string NDate)
        {
            string sm, sd;
            int y, m, d;
            try
            {
                y = Convert.ToDateTime(NDate).Year;
                m = Convert.ToDateTime(NDate).Month;
                d = Convert.ToDateTime(NDate).Day;
            }
            catch
            {
                return "";
            }
            if (y == 1900)
                return "";
            if (m < 10)
                sm = "0" + Convert.ToString(m);
            else
                sm = Convert.ToString(m);
            if (d < 10)
                sd = "0" + Convert.ToString(d);
            else
                sd = Convert.ToString(d);
            return Convert.ToString(y) + "-" + sm + "-" + sd;
        }
        #endregion

        #region Clear Toolbox
        public void Clear_Control(Control.ControlCollection Con)
        {
            foreach (Control C in Con)
            {
                if (C.GetType().Name == "TextBox")
                    if (((TextBox)C).Visible == true)
                        ((TextBox)C).Clear();
                if (C.GetType().Name == "MaskedTextBox")
                    if (((MaskedTextBox)C).Visible == true)
                        ((MaskedTextBox)C).Clear();
                if (C.GetType().Name == "ComboBox")
                    if (((ComboBox)C).Visible == true)
                        ((ComboBox)C).Text = "";
                if (C.GetType().Name == "PictureBox")
                    if (((PictureBox)C).Visible == true)
                        ((PictureBox)C).Image = null;
            }
        }
        #endregion

        #region Auto get ID no.
        public string GetAutoCoding(string TableName, string ID)
        {
            SqlDataReader MyDR = MyDataClass.getCmd("select max(" + ID + ") NID from " + TableName);
            int Num = 0;
            if (MyDR.HasRows)
            {
                MyDR.Read();
                if (MyDR[0].ToString() == "")
                    return "0001";
                Num = Convert.ToInt32(MyDR[0].ToString());
                Num++;
                string s = string.Format("{0:0000}", Num);
                return s;
            }
            else
                return "0001";
        }
        #endregion 

        #region Enable/Disable button
        public void ED_Button(Button B1, Button B2, Button B3, Button B4, int n1, int n2, int n3, int n4)
        {
            B1.Enabled = Convert.ToBoolean(n1);
            B2.Enabled = Convert.ToBoolean(n2);
            B3.Enabled = Convert.ToBoolean(n3);
            B4.Enabled = Convert.ToBoolean(n4);
        }
        #endregion 

        #region Save modified data
        public void Part_SaveClass(string Sarr, string ID1, string ID2, Control.ControlCollection Contr, string BoxName, string TableName, int n, int m)
        {
            string tmp_Field = "", tmp_Value = "";
            int p = 2;
            if (m == 1)
            {
                if (ID1 != "" && ID2 == "")
                {
                    tmp_Field = "ID";
                    tmp_Value = "'" + ID1 + "'";
                    p = 1;
                }
                else
                {
                    tmp_Field = "Staff_ID,ID";
                    tmp_Value = "'" + ID1 + "','" + ID2 + "'";
                }
            }
            else
            {
                if (m == 2)
                     if (ID1 != "" && ID2 == "")
                     { //根据参数值判断添加的字段
                        tmp_Value = "ID='" + ID1 + "'";
                        p = 1;
                     }
                    else
                        tmp_Value = "Staff_ID='" + ID1 + "',ID='" + ID2 + "'";
                }
                
            if (m > 0)
            { //生成部份添加、修改语句
                string[] Parr = Sarr.Split(Convert.ToChar(','));
                for (int i = p; i < n; i++)
                {
                    string sID = BoxName + i.ToString();    //通过BoxName参数获取要进行操作的控件名称
                    foreach (Control C in Contr)
                    {   //遍历控件集中的相关控件
                        if (C.GetType().Name == "TextBox" | C.GetType().Name == "MaskedTextBox" | C.GetType().Name == "ComboBox")
                            if (C.Name == sID)
                            { //如果在控件集中找到相应的组件
                                string Ctext = C.Text;
                                if (C.GetType().Name == "MaskedTextBox")    //如果当前是MaskedTextBox控件
                                    Ctext = Date_Format(C.Text);    //对当前控件的值进行格式化
                                if (m == 1)
                                {    //组合SQL语句中insert的相关语句
                                    tmp_Field = tmp_Field + "," + Parr[i];
                                    if (Ctext == "")
                                        tmp_Value = tmp_Value + "," + "NULL";
                                    else
                                        tmp_Value = tmp_Value + "," + "'" + Ctext + "'";
                                }
                                if (m == 2)
                                {    //组合SQL语句中update的相关语句
                                    if (Ctext=="")
                                        tmp_Value = tmp_Value + "," + Parr[i] + "=NULL";
                                    else
                                        tmp_Value = tmp_Value + "," + Parr[i] + "='" + Ctext + "'";
                                }
                            }
                    }
                }
                ADDs = "";
                if (m == 1) //生成SQL的添加语句
                    ADDs = "insert into " + TableName + " (" + tmp_Field + ") values(" + tmp_Value + ")";
                if (m == 2) //生成SQL的修改语句
                    if (ID2 == "")  //根据ID2参数，判断修改语句的条件
                        ADDs = "update " + TableName + " set " + tmp_Value + " where ID='" + ID1 + "'";
                    else
                        ADDs = "update " + TableName + " set " + tmp_Value + " where ID='" + ID2 + "'";
            }
        }
        #endregion

        #region Save picture
        public void SaveImage(string MID, byte[] p)
        {
            MyDataClass.conn_Open();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Staffbasic set Photo=@Photo where ID=" + MID);
            SqlCommand cmd = new SqlCommand(strSql.ToString(), DataClass.MyMeans.My_con);
            cmd.Parameters.Add("@Photo", SqlDbType.Binary).Value = p;
            cmd.ExecuteNonQuery();
            DataClass.MyMeans.My_con.Close();
        }
        #endregion

        #region Display current Grid's data
        public void Show_CGrid(DataGridView CGrid, Control.ControlCollection CBox, string TName)
        {
            string sID = "";
            if (CGrid.RowCount > 0)
            {
                for (int i = 1; i < CGrid.ColumnCount; i++)
                {
                    sID = TName + i.ToString();
                    foreach (Control C in CBox)
                    {
                        if (C.GetType().Name == "TextBox" | C.GetType().Name == "MaskedTextBox" | C.GetType().Name == "ComboBox")
                        {
                            if (C.Name == sID)
                            {
                                if (CGrid.GetType().Name != "MaskedTextBox")
                                    C.Text = CGrid[i, CGrid.CurrentCell.RowIndex].Value.ToString();
                                else
                                    C.Text = Date_Format(Convert.ToString(CGrid[i, CGrid.CurrentCell.RowIndex].Value).Trim());
                            }
                        }
                    }
                }
            }

        }
        #endregion

        #region Control datagridview column
        public void Correlation_DGV(DataSet DS, DataGridView DGV)
        {
            DGV.DataSource = DS.Tables[0];
            DGV.Columns[0].Visible = false;
            DGV.Columns[1].Visible = false;
            DGV.RowHeadersVisible = false;
            DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        #endregion

        #region Clear controls data
        public void Clear_Grids(int n, Control.ControlCollection GBox, string TName)
        {
            string sID = "";
            for (int i = 2; i < n; i++)
            {
                sID = TName + i.ToString();
                foreach (Control C in GBox)
                {
                    if (C.GetType().Name == "TextBox" | C.GetType().Name == "MaskedTextBox" | C.GetType().Name == "ComboBox")
                        if (C.Name == sID)
                        {
                            C.Text = "";
                        }
                }
            }
        }
        #endregion

        #region Combined inquiry
        public void Find_Grids(Control.ControlCollection GBox, string TName, string ARSign)
        {
            string sID = "";    //定义局部变量
            if (FindValue.Length > 0)
                FindValue = FindValue + ARSign;
            foreach (Control C in GBox)
            { //遍历控件集上的所有控件
                if (C.GetType().Name == "TextBox" | C.GetType().Name == "ComboBox")
                { //判断是否要遍历的控件
                    if (C.GetType().Name == "ComboBox" && C.Text != "")
                    {   //当指定控件不为空时
                        sID = C.Name;
                        if (sID.IndexOf(TName) > -1)
                        {    //当TName参数是当前控件名中的部分信息时
                            string[] Astr = sID.Split(Convert.ToChar('_')); //用“_”符号分隔当前控件的名称,获取相应的字段名
                            FindValue = FindValue + "(" + Astr[1] + " = '" + C.Text + "')" + ARSign;   //生成查询条件
                        }
                    }
                    if (C.GetType().Name == "TextBox" && C.Text != "")  //如果当前为TextBox控件，并且控件不为空
                    {
                        sID = C.Name;   //获取当前控件的名称
                        if (sID.IndexOf(TName) > -1)    //判断TName参数值是否为当前控件名的子字符串
                        {
                            string[] Astr = sID.Split(Convert.ToChar('_')); //以“_”为分隔符，将控件名存入到一维数组中
                            string m_Sgin = ""; //用于记录逻辑运算符
                            string mID = "";    //用于记录字段名
                            if (Astr.Length > 2)    //当数组的元素个数大于2时
                                mID = Astr[1] + "_" + Astr[2];  //将最后两个元素组成字段名
                            else
                                mID = Astr[1];  //获取当前条件所对应的字段名称
                            foreach (Control C1 in GBox)    //遍历控件集
                            {
                                if (C1.GetType().Name == "ComboBox")    //判断是否为ComboBox组件
                                    if ((C1.Name).IndexOf(mID) > -1)    //判断当前组件名是否包含条件组件的部分文件名
                                    {
                                        if (C1.Text == "")  //当查询条件为空时
                                            break;  //退出本次循环
                                        else
                                        {
                                            m_Sgin = C1.Text;   //将条件值存储到m_Sgin变量中
                                            break;
                                        }
                                    }
                            }
                            if (m_Sgin != "")   //当该务件不为空时
                                FindValue = FindValue + "(" + mID + m_Sgin + C.Text + ")" + ARSign;    //组合SQL语句的查询条件
                        }
                    }
                }
            }
            if (FindValue.Length > 0)   //当存储查询条的变量不为空时，删除逻辑运算符AND和OR
            {
                if (FindValue.IndexOf("And") > -1)  //判断是否用AND连接条件
                    FindValue = FindValue.Substring(0, FindValue.Length - 4);
                if (FindValue.IndexOf("Or") > -1)  //判断是否用OR连接条件
                    FindValue = FindValue.Substring(0, FindValue.Length - 3);
            }
            else
                FindValue = "";
           
        }
        #endregion

        #region Add user permission
        public void Add_Permission(string ID, int n)
        {
            DataSet Dset;
            Dset = MyDataClass.getDataSet("select PermissionType from tb_Permission", "tb_Permission");
            for (int i = 0; i < Dset.Tables[0].Rows.Count; i++)
                MyDataClass.execSQLCmd("insert into tb_UserPermission (ID,PermissionType,Permission) values('" + ID + "','" + Convert.ToString(Dset.Tables[0].Rows[i][0]) + "'," + n + ")");
        }
        #endregion

        #region Modify user permission
        public void Modify_Permission(Control.ControlCollection GBox, string TID)
        {
            string CheckName = "";
            int tt = 0;
            foreach (Control C in GBox)
            {
                if (C.GetType().Name == "CheckBox")
                {
                    if (((CheckBox)C).Checked)
                        tt = 1;
                    else
                        tt = 0;
                    CheckName = C.Name;
                    string[] Astr = CheckName.Split(Convert.ToChar('_'));
                    MyDataClass.execSQLCmd("update tb_UserPermission set Permission=" + tt + " where (ID='" + TID + "') and (PermissionType='" + Astr[1].Trim() + "')");
                }
            }

        }
        #endregion

        #region Clear table in database
        public void Clear_Table(Control.ControlCollection GBox, string TName)
        {
            string sID = "";
            foreach (Control C in GBox)
            {
                if (C.GetType().Name == "CheckBox")
                {
                    sID = C.Name;
                    if (sID.IndexOf(TName) > 1)
                    {
                        if (((CheckBox)C).Checked == true)
                        {
                            string TableName = "";
                            string[] Astr = sID.Split(Convert.ToChar('_'));
                            TableName = "tb_" + Astr[1];
                            if (Astr[1].ToUpper() == ("Crew").ToUpper())
                                MyDataClass.execSQLCmd("update " + TableName + " set Fate=0,Unlock=0 where ID>0");
                            else
                            {
                                MyDataClass.execSQLCmd("Delete " + TableName);
                                if (Astr[1].ToUpper() == ("Login").ToUpper())
                                {
                                    MyDataClass.execSQLCmd("insert into " + TableName + " (ID,Name,Pwd) values('0001','TSoft','111')");
                                    Add_Permission("0001", 1);
                                }
                            }

                        }
                    }
                }
            }
        }
        #endregion

        #region Display user permission
        public void Show_Pope(Control.ControlCollection GBox, string TID)
        {
            string sID = "";
            string CheckName = "";
            bool t = false;
            DataSet DSet = MyDataClass.getDataSet("select ID,PermissionType,Permission from tb_UserPermission where ID='" + TID + "'", "tb_UserPermission");
            for (int i = 0; i < DSet.Tables[0].Rows.Count; i++)
            {
                sID = Convert.ToString(DSet.Tables[0].Rows[i][1]);
                if ((int)(DSet.Tables[0].Rows[i][2]) == 1)
                    t = true;
                else
                    t = false;
                foreach (Control C in GBox)
                {
                    if (C.GetType().Name == "CheckBox")
                    {
                        CheckName = C.Name;
                        if (CheckName.IndexOf(sID) > -1)
                        {
                            ((CheckBox)C).Checked = t;
                        }
                    }
                }
            }
        }
        #endregion

        #region DeadLine prompt
        public void PactDay(int i)
        {
            DataSet DSet = MyDataClass.getDataSet("select * from tb_Crew where kind=" + i + " and unlock=1", "tb_Crew");
            if (DSet.Tables[0].Rows.Count > 0)
            {
                string Vfield = "";
                string dSQL = "";
                int sday = Convert.ToInt32(DSet.Tables[0].Rows[0][1]);
                if (i == 1)
                {
                    Vfield = "Birthday";
                    dSQL = "select * from tb_Staffbasic where (datediff(day,getdate(),convert(Nvarchar(12),cast (cast (year(getdate()) as char(4))+'-'+ cast(month(" + Vfield + ") as char(2))+'-'+	cast (day(" + Vfield + ") as char(2)) as datetime),110))<=" + sday + ") and (datediff(day,getdate(),convert(Nvarchar(12),cast (cast (year(getdate()) as char(4))+'-'+ cast(month(" + Vfield + ") as char(2))+'-'+cast (day(" + Vfield + ") as char(2)) as datetime),110))>=0)";
                }
                else
                {
                    Vfield = "Pact_E";
                    dSQL = "select * from tb_Staffbasic where ((getdate()-convert(Nvarchar(12)," + Vfield + ",110))>=-" + sday + " and (getdate()-convert(Nvarchar(12)," + Vfield + ",110))<=0)";
                }
                DSet = MyDataClass.getDataSet(dSQL, "tb_Staffbasic");
                if (DSet.Tables[0].Rows.Count > 0)
                {
                    if (i == 1)
                        Vfield = "是否查看" + sday.ToString() + "天内过生日的职工信息？";
                    else
                        Vfield = "是否查看" + sday.ToString() + "天内合同到期的职工信息？";
                    if (MessageBox.Show(Vfield, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        DataClass.MyMeans.Allsql = dSQL;
                        Show_Form("人事档案浏览", 1);
                    }
                }
            }
        }
        #endregion
    }
}
