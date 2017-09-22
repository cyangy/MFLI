using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.NetworkInformation;
using zhinst;

namespace MFLI_GUI
{
    public partial class MFLISetting : Form
    {
        public MFLISetting()
        {
            InitializeComponent();
            this.MFLISettingDevicenametextBox.Text = GlobalVars.dev;
        }
        //String device= dev;
        private bool SyncTextBoxAndVariables(ref TextBox txtBox, ref String txtBoxRelateVariablesVar) //同步文本框输入的在合法范围的值
        {
             //正则表达式先检查输入合法性 dev3070
            if (System.Text.RegularExpressions.Regex.IsMatch(txtBox.Text, "^[d][e][v][0-9]{4}$"))
            {
                txtBoxRelateVariablesVar = txtBox.Text;
            }
            else
            {   //如果输入不合法
                MessageBox.Show("请输入正确值设备名\n如dev3070",
                    "输入不合法",
                        MessageBoxButtons.OK,
                               //MessageBoxIcon.Warning // for Warning  
                               MessageBoxIcon.Error // for Error 
                                                    //MessageBoxIcon.Information  // for Information
                                                    //MessageBoxIcon.Question // for Question
                                );
                txtBox.Text = txtBoxRelateVariablesVar;
                return false;
            }
            txtBox.Text = txtBoxRelateVariablesVar;
            return true;
        }
        private void MFLISettingbuttonOK_Click(object sender, EventArgs e)
        {
            if (SyncTextBoxAndVariables(ref MFLISettingDevicenametextBox, ref GlobalVars.dev))
            {
                this.Close();
            }
        }

        private void MFLISettingDevicenametextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) // KeyCode 不能使用,不知道为什么
            {
                if (SyncTextBoxAndVariables(ref MFLISettingDevicenametextBox, ref GlobalVars.dev))
                {
                    this.Close();
                }
            }

        }

        private void MFLISettingDevicenametextBox_Leave(object sender, EventArgs e)
        {
            SyncTextBoxAndVariables(ref MFLISettingDevicenametextBox, ref GlobalVars.dev);
        }
    }
}
