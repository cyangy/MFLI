//#define DEBUG_TheVariablesOfTheControl //控件值
//#define Debug_InstrumentReturnValue   //仪器返回值
//#define Debug_FileAbout   //文件操作
#if !MFLI_HasConnected

//#define MFLI_HasConnected  //为方便MFLI未连接时更改程序源码
//如果MFLI已经连接到该电脑上取消此行注释,否则保持此行注释
#endif

/*
 * Todo：使用配置文件功能，保存配置
 *       添加sweeper功能(系统自带/用户手动设置)
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using zhinst;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;

//dev 定义在 TheMFLIMainWindow 类之后 使用 public static class 作全局变量
namespace MFLI_GUI
{
    public partial class TheMFLIMainWindow : Form
    {
        public TheMFLIMainWindow()
        {
            InitializeComponent();

            this.SynchronizeVariableWithControls(); //同步原始设置到界面各控件
            //只需在窗口启动时执行一次的内容
            this.IntervalBetweenTwoMeasuretextBox.Text = System.String.Format("{0:F0}", IntervalBetweenTwoMeasure); // 32位整型
            this.OutputAmplitudesChoosecomboBox.SelectedItem = "Vrms";//下拉列表框选择 默认Vrms ，使用Index可以增加灵活性但使用使用 SelectedItem 可以避免错误
            //OutputAmplitudes的值始终为Vpp值，根据用户选择的选项调整 幅度输入文本框内的值
            SyncComboBoxAndVariables(ref this.OutputAmplitudesChoosecomboBox, ref SignalOutputAmplitudesValue);//同步下拉列表选项与幅度文本输入框的值 但不改变变量真正的值，因为变量真正的值一直储存为Vpp
            //设置richTextBox Tab Size
            richTextBoxShow.SelectionTabs = new int[] { 8, 16, 24 };
        }
        

        public MFLISetting theMFLISettingForm = new MFLISetting();
        //输出变量设置
        public long isSignalOutputSwitchOn = 1; //开启输出 灯亮，但不一定有信号输出
        public long isSignalOutputImpendence50 = 1;//50 ohm   1 0
        public double SignalOutputManualRangeValue = 0.500000;//手动档  double number
        public long isSignalOutputAutoRange = 1;//自动档  1 0
        public double SignalOutputOffsetValue = 0;//直流偏置  double number
        public long isSignalOutputAmplitudesEnable = 1;// //信号输出开启 
        public double SignalOutputAmplitudesValue = (0.150*Math.Sqrt(2.00));//  信号幅度 有Vpp Vrms dB 三选项 其实只是三者之间相互转换 例如 Vpp 选择7.07m 时，切换到Vrms会自动转换成0.5m 即所有输入均为峰峰值
        //输入变量
        public double SignalInputManualRangeValue = 0.30000;//手动档  double number
        public long isSignalInputAutoRange = 1;//自动档  1 0
        public double SignalInputScalingValue = 1.000;//缩放因子  double
        public long isSignalInputACCoupling = 1;//是否交流耦合 1 是  0  否
        public long isSignalInput50Ohm = 1;// 1  50ohm  0 10mega ohm
        public long isSignalInputFloatGround = 1; //悬浮地   1  float   0  ground
        //晶振频率设置
        public double theOscillatorsFrequency = 100000.000;

        public double IntervalBetweenTwoMeasure = 3000; //两次测量时间间隔  3000ms  

        //默认设备地址
       // public static String dev = "dev3070";
        //声明设备
        ziDotNET daq = new ziDotNET();
        //内部调用准备
         myMFLI newMFLI = new myMFLI();

        /// <summary>
        /// 选择文件保存位置
        /// </summary>
        /// <returns></returns>
        public bool ChoseWhichFileToSave() //--http://blog.csdn.net/techzero/article/details/27709981
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //打开的文件选择对话框上的标题  
            saveFileDialog.Title = "请选择文件";
            //初始文件夹
            saveFileDialog.InitialDirectory = GlobalVars.SaveMeasureRealustToFile_Directory;
            //默认文件名
            saveFileDialog.FileName = GlobalVars.SaveMeasureRealustToFile_FileName;
            //设置文件类型  
            saveFileDialog.Filter = "文本文件(*.txt)|*.txt|逗号分隔文件(*.csv)|*.csv|所有文件(*.*)|*.*";
            //设置默认文件类型显示顺序  
            saveFileDialog.FilterIndex = 2;
            //保存对话框是否记忆上次打开的目录  
            saveFileDialog.RestoreDirectory = true;
            //按下确定选择的按钮  
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //获得文件路径  
                String localFilePath = saveFileDialog.FileName.ToString();
                //获取文件路径，不带文件名  
                String FilePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\"));  
                //获取文件名，带后缀名，不带路径  
                String  fileNameWithSuffix = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1);
                //去除文件后缀名  
                //String  fileNameWithoutSuffix = fileNameWithSuffix.Substring(0, fileNameWithSuffix.LastIndexOf("."));
                GlobalVars.SaveMeasureRealustToFile_Directory = FilePath;
                GlobalVars.SaveMeasureRealustToFile_FileName = fileNameWithSuffix;
                GlobalVars.SaveMeasureRealustToFile_Whole = GlobalVars.SaveMeasureRealustToFile_Directory +"\\"+ GlobalVars.SaveMeasureRealustToFile_FileName;
            }
            return true;
        }
        public bool SynchronizeVariableWithControls() //更新变量到控件显示
        {
#if DEBUG_TheVariablesOfTheControl  //Debug 文本框
            this.DebugtextBox.Visible = true;
            this.DebugTextBoxLabel.Visible = true;
            this.DebugtextBox.Enabled = true;
#else
            this.DebugtextBox.Visible = false;
            this.DebugTextBoxLabel.Visible = false;
            this.DebugtextBox.Enabled = false;

#endif
            //this.VoltageInputRangetextBox.Text = System.String.Format("{0:E}", SignalInputManualRangeValue); // 0.3000 会输出  3.000000E-001 参考
            //应用 所有变量到 文本框内容
            this.VoltageInputRangetextBox.Text = System.String.Format("{0:F5}", SignalInputManualRangeValue); // 信号输入手动量程值
            this.VoltageInputScalingtextBox.Text = System.String.Format("{0:F1}", SignalInputScalingValue); // 信号输入放大倍数
            this.VoltageOutputRangeValuetextBox.Text = System.String.Format("{0:F5}", SignalOutputManualRangeValue); // 信号输出手动量程值
            this.VoltageOutputOffsettextBox.Text = System.String.Format("{0:F8}", SignalOutputOffsetValue); // 设置偏置
            //this.VoltageOutputAmplitudesValuetextBox.Text= System.String.Format("{0:F11}", SignalOutputAmplitudesValue); // 使用 SyncComboBoxAndVariables 代替
            SyncComboBoxAndVariables(ref this.OutputAmplitudesChoosecomboBox, ref SignalOutputAmplitudesValue, 11);//同步下拉列表选项与幅度文本输入框的值 但不改变变量真正的值，因为变量真正的值一直储存为Vpp
            this.theOscillatorsFrequencytextBox.Text = System.String.Format("{0:F2}", theOscillatorsFrequency); // 频率 显示带有两位小数
            //应用 所有变量到 文本框内容 //所有bool值到checkbox
            this.CheckBoxStatuAdjust(this.VoltageInputAutoRangecheckBox, isSignalInputAutoRange, VoltageInputRangetextBox);// 输入 自动量程？ 
            this.CheckBoxStatuAdjust(this.VoltageInputACCouplingcheckBox, isSignalInputACCoupling);//输入 AC耦合？
            this.CheckBoxStatuAdjust(this.VoltageInputfiftyOhmcheckBox, isSignalInput50Ohm); //输入使用50欧姆？10M
            this.CheckBoxStatuAdjust(this.VoltageInputFloatcheckBox, isSignalInputFloatGround);//输入 使用悬浮地?
            this.CheckBoxStatuAdjust(this.VoltageOutputSwitchOncheckBox, isSignalOutputSwitchOn);//输出开启?
            this.CheckBoxStatuAdjust(this.VoltageOutput50OhmcheckBox, isSignalOutputImpendence50);//输出使用50欧姆?
            this.CheckBoxStatuAdjust(this.OutputAmplitudesEnablecheckBox, isSignalOutputAmplitudesEnable);//输出设置自动量程?
            this.CheckBoxStatuAdjust(this.VoltageOutputAutoRangecheckBox, isSignalOutputAutoRange, VoltageOutputRangeValuetextBox);//信号输出开启?
            //文件操作
            this.SaveMeasureRealustToFile_textBox.Text = GlobalVars.SaveMeasureRealustToFile_Whole;//文件路径到文本框
            this.CheckBoxStatuAdjust(this.SaveMeasureRealustToFile_checkBox, GlobalVars.isSaveToFile,SaveMeasureRealustToFile_textBox,false); //是否输出到文件 textBox 和 checkBox同步
            if (GlobalVars.isSaveToFile == 0) SaveMeasureRealustToFile_button.Enabled = false; else SaveMeasureRealustToFile_button.Enabled = true;
            return true;
        }
        public bool  SynchronizeMFLIDeviceSettingAndLocalSetting(ziDotNET daq,String dev) //同步所有数值设置到本地变量
        {   
            //有理数 值
            SignalInputManualRangeValue=daq.getDouble(newMFLI.SignalInputManualRangePath);//取回信号输入手动量程值
            SignalInputScalingValue=daq.getDouble(newMFLI.SignalInputScalingPath);//取回 信号输入放大倍数
            SignalOutputManualRangeValue =daq.getDouble(newMFLI.SignalOutputManualRangePath);//取回 信号输出手动量程值
            SignalOutputOffsetValue =daq.getDouble(newMFLI.SignalOutputOffsetPath); //取回 设置偏置
            SignalOutputAmplitudesValue =daq.getDouble(newMFLI.SignalOutputAmplitudesValuePath); //取回 设置输出信号
            theOscillatorsFrequency =daq.getDouble(newMFLI.SignalOscillatorsPath); //取回 设置频率
            //bool 值
            isSignalInputAutoRange = daq.getInt(newMFLI.SignalInputAutoRangePath);// 输入 自动量程？
            isSignalInputACCoupling = daq.getInt(newMFLI.SignalInputACCouplingPath);//输入 AC耦合？
            isSignalInput50Ohm = daq.getInt(newMFLI.SignalInputSwitchBetween50And10MegaOhmPath);//输入使用50欧姆？10M
            isSignalInputFloatGround = daq.getInt(newMFLI.SignalInputFloatPath);//输入 使用悬浮地?
            isSignalOutputSwitchOn = daq.getInt(newMFLI.SignalOutputSwitchOnPath);//输出开启?
            isSignalOutputImpendence50 = daq.getInt(newMFLI.SignalOutputImpendence50Path);//输出使用50欧姆?
            isSignalOutputAutoRange = daq.getInt(newMFLI.SignalOutputAutoRangePath);//输出设置自动量程?
            isSignalOutputAmplitudesEnable = daq.getInt(newMFLI.SignalOutputAmplitudesEnablePath);//信号输出开启?
            //同步所有值到控件

            return true;
        }

        /// <summary>
        /// 所有需要随时刷新窗口 状态的放到这里面 总体来说是与 连接状态相关的
        /// </summary>
        private void TheElementreFresh() // 所有需要随时刷新窗口 状态的放到这里面 总体来说是与 连接状态相关的
        {

            // 最低优先级条件 不管 状态如何 先启用所有控件,其它的交给后面来做
            if (!GlobalVars.isResettingDevice)//如果没有正在重置仪器设置,先启用页面所有控件 下一个判断再根据实际情况做具体设定
            {
                DisableOrEnableAllControlsExceptList(this, null, true);//启用控件
            }
            //低优先级条件
            if (!GlobalVars.isMeasuring) //如果正在测量,则不要更新页面控件
            {
                //未执行测量则可以更改仪器连接状态和设备名
                ToolStripMenuItemConnectMFLI.Enabled = true;
                ToolStripMenuItemSettingMFLI.Enabled = true;
                this.ToolStripMenuItemResetMFLISettingToDefault.Enabled = true;
                this.StartMeasure.Enabled = GlobalVars.isMFLIDeviceConnected; //如果连接不成功,测量功能也不可用

                if (GlobalVars.isMFLIDeviceConnected) //设备已连接时需要刷新的
                {
                    //仪器菜单刷新
                    ToolStripMenuItemConnectMFLI.Text = "断开连接";
                    ToolStripMenuItemConnectMFLI.BackColor = Color.Green;
                    this.StartMeasure.Enabled = GlobalVars.isMFLIDeviceConnected; //如果连接不成功,测量功能也不可用    
                    //开始按钮刷新                                                             //测量按钮刷新
                    StartMeasure.Text = "开始测量";//刷新按钮文字
                    this.StartMeasure.BackColor = Color.Green;
                    this.StartMeasure.Enabled = true;
                    //如果仪器未连接则重置功能不可用
                    this.ToolStripMenuItemResetMFLISettingToDefault.Enabled = true;
                }
                else if (!GlobalVars.isMFLIDeviceConnected) //设备断开时需要刷新的
                {
                    //仪器菜单刷新
                    ToolStripMenuItemConnectMFLI.Text = "连接仪器";
                    ToolStripMenuItemConnectMFLI.BackColor = Color.Yellow;
                    //测量按钮刷新
                    this.StartMeasure.Enabled = true; //开启 设置属性
                    this.StartMeasure.Text = "设备断开";
                    this.StartMeasure.BackColor = Color.Yellow;
                    this.StartMeasure.ForeColor = Color.Red;
                    this.StartMeasure.Enabled = false;//设置属性完成后再次 关闭

                    //如果仪器未连接则重置功能不可用
                     this.ToolStripMenuItemResetMFLISettingToDefault.Enabled = false;

                }
            }else
            {
                //测量过程中不得更改仪器连接状态和设备名
                ToolStripMenuItemConnectMFLI.Enabled = false;
                ToolStripMenuItemSettingMFLI.Enabled = false;
                this.ToolStripMenuItemResetMFLISettingToDefault.Enabled = false;
            }
            //文件选择按钮 与文件名显示
            if ( GlobalVars.isSaveToFile == 0 || GlobalVars.isMeasuring)
            {
                this.SaveMeasureRealustToFile_button.Enabled = false;
                this.SaveMeasureRealustToFile_textBox.Enabled = false;
            }else if (GlobalVars.isSaveToFile == 1 &&  !GlobalVars.isMeasuring)
            {
                this.SaveMeasureRealustToFile_button.Enabled = true;
                this.SaveMeasureRealustToFile_textBox.Enabled = true;
            }

            //高优先级条件 不管前面状态如何,最后都禁用所有控件
            if (GlobalVars.isResettingDevice)//如果正在重置仪器设置,禁用页面所有控件
            {
                DisableOrEnableAllControlsExceptList(this, null, false);//禁用控件
            }

        }
        private void  InitMFLIConnect(ziDotNET daq,String dev)
        {
            try
            {
                if (!GlobalVars.isMFLIDeviceConnected && string.IsNullOrEmpty(newMFLI.InitTheDevice(daq, dev)))//尝试初始化连接 版本返回值为null说明没连接上
                {
                    //-https://stackoverflow.com/questions/2109441/how-to-show-error-warning-message-box-in-net-how-to-customize-messagebox
                    //-https://social.msdn.microsoft.com/Forums/vstudio/en-US/b4f8c7b7-c249-4f4c-a182-9157e001569f/create-a-dialog-box-with-yes-no-cancel-options-c?forum=csharpgeneral
                    DialogResult result = MessageBox.Show("MFLI设备未连接,请确认设备电源已开启,USB已连接,LabOne已安装且MFLI USB驱动(MF-Device-Finder64(32).msi)已安装",
                    "未发现设备",
                    MessageBoxButtons.OK,
                    //MessageBoxIcon.Warning // for Warning  
                    MessageBoxIcon.Error // for Error 
                    //MessageBoxIcon.Information  // for Information
                    //MessageBoxIcon.Question // for Question
                     );
                    GlobalVars.isMFLIDeviceConnected = false; //连接标志置为假
                    if (result == DialogResult.OK)
                    {
                        //this.Close();//无设备则关闭窗体
                    }
                                     
                }
                else//如果已连接上
                {
                    SynchronizeMFLIDeviceSettingAndLocalSetting(daq, GlobalVars.dev);//同步所有设备上的设置到本地
                    SynchronizeVariableWithControls();//将设置应用到控件
                    GlobalVars.isMFLIDeviceConnected = true; //连接标志置为真
                                                  //开始操作
                }

            }
            finally
            {

            }
        }

        private BackgroundWorker _worker = null; //background worker---https://stackoverflow.com/questions/27580241/breaking-from-a-loop-with-button-click-c-sharp
        public delegate void SetTextCallback(Control richTextBox,string argText);
        public String MyValueToStringFormat(String theFormat, object value)
        {

            return System.String.Format(theFormat, value);
        }
        //---https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/how-to-make-thread-safe-calls-to-windows-forms-controls
        private void SetrichTextBoxShowTextSafly(Control richTextBox, string argText) //线程安全回调 循环测量在另一单独线程执行,不至于阻断当前窗口的运行
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (richTextBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetrichTextBoxShowTextSafly);
                this.Invoke(d, new object[] { richTextBox,argText });
            }
            else
            {
                richTextBox.Text += argText;
            }
        }
        //找出除某些控件 所有其他Form控件,对除Button外的控件不起作用---https://stackoverflow.com/questions/1676766/getting-controls-in-a-winform-to-disable-them
        public List<Control> GetAllControls(Form form, params Control[] excludeControlList)
        {
            List<Control> controlList = new List<Control>();

                foreach (Control control in form.Controls)
                {
                    if (excludeControlList != null)
                    {
                        if (excludeControlList.SingleOrDefault(expControl => (control == expControl)) != null)
                            continue;
                    }

                    controlList.Add(control);
                }
            

            return controlList;
        }
        //除了某些控件禁用所有其他Form控件  -----------------对richTextBox不起作用
        private void DisableOrEnableAllControlsExceptList(Form form, Control[] excludeControlList, bool trueOrfalseForEnableOrDisable)
        {
            foreach (Control control in form.Controls)
            {
               if (excludeControlList != null)
                {
                    if (excludeControlList.SingleOrDefault(expControl => (control == expControl)) != null)
                        continue;
                }
                control.Enabled = trueOrfalseForEnableOrDisable;
            }
        }

        /// <summary>
        /// 同步选框关联的值到选框状态,如果该选框与对应文本框相关联(互斥或同步),与文本框关系应用
        /// </summary>
        /// <param name="chkBox"> 选框</param>
        /// <param name="ValuecheckOrUncheck">与选框关联的值</param>
        /// <param name="mutuallyExclusiveBox">与选框关联的文本框</param>
        /// <param name="reverse">与选框关联的文本框是互斥(默认) 的还是同状态</param>
        private void  CheckBoxStatuAdjust(CheckBox chkBox,long ValuecheckOrUncheck,TextBox mutuallyExclusiveBox=null,bool reverse =true) //MFLI 定义的真 为 long 1 ,同时设置与其互斥的文本输入框
        {
                if (ValuecheckOrUncheck.Equals(0))
                {
                    chkBox.Checked = false;

                }
                else
                {
                    chkBox.Checked = true;
                }
            if (reverse)
            {
                if (mutuallyExclusiveBox != null)
                {
                    mutuallyExclusiveBox.Enabled = !chkBox.Checked; //checkBox 与文本框互斥
                }
            }else if (!reverse)
            {
                mutuallyExclusiveBox.Enabled = chkBox.Checked; //checkBox 与文本框同步
            }
        }

        /// <summary>
        /// checkbox 改变时将状态应用到变量,同时设置与其关联的的textbox
        /// </summary>
        /// <param name="chkBox"> 选框</param>
        /// <param name="checkBoxRelateVariablesVar">与选框关联的值</param>
        /// <param name="mutuallyExclusiveBox">与选框关联的文本框</param>
        /// <param name="reverse">与选框关联的文本框是互斥(默认) 的还是同状态</param>
        private void  CheckBoxApplyToVariables(CheckBox chkBox, ref long checkBoxRelateVariablesVar,TextBox mutuallyExclusiveBox = null,bool reverse=true)//checkbox 改变时将状态应用到变量,同时设置与其互斥的textbox
        {
            if (chkBox.Checked) //选中
            {
                checkBoxRelateVariablesVar = 1;
            }
            else               // 未选中
            {
                checkBoxRelateVariablesVar = 0;
            }            
           if (mutuallyExclusiveBox != null) {
                if (reverse)
                {
                    mutuallyExclusiveBox.Enabled = !chkBox.Checked;
                }
                else if (!reverse)
                {
                    mutuallyExclusiveBox.Enabled = chkBox.Checked;
                }
            }
        }

        /// <summary>
        /// 同步文本框输入内容并检查合法性到变量
        /// </summary>
        /// <param name="txtBox"></param>
        /// <param name="txtBoxRelateVariablesVar"></param>
        /// <param name="RelativeComboBox"></param>
        /// <param name="digitalNumbersAferDecimalPoint"></param>
        /// <param name="rangeLow"></param>
        /// <param name="rangeUp"></param>
        /// <returns></returns>
        private bool SyncTextBoxAndVariables(ref TextBox txtBox, ref double txtBoxRelateVariablesVar, ComboBox RelativeComboBox = null, int digitalNumbersAferDecimalPoint = 11, double rangeLow = 0, double rangeUp = 0) //同步文本框输入的在合法范围的值到变量
        {
            String stringFormatExpression = "{0:F" + digitalNumbersAferDecimalPoint.ToString() + "}"; //trick for 让String.Format接受参数
            //String previousValueString = System.String.Format(stringFormatExpression, txtBoxRelateVariablesVar);
            //正则表达式先检查输入合法性
            if (System.Text.RegularExpressions.Regex.IsMatch(txtBox.Text, "^[0-9]*[.]{0,1}[0-9]*$") ||  // 任意小数  任意整数
                System.Text.RegularExpressions.Regex.IsMatch(txtBox.Text, "^[0-9]*[.]{0,1}[0-9]*[eE][+-]{0,1}[0-9]*$")     //科学记数法 1.25e+3  1e3  
                )
            {   //如果输入合法 立即解析为double 类型
                double parsedRealust = double.Parse(txtBox.Text);
                //如果有输入范围
                if (rangeLow != rangeUp)
                {
                    if (rangeLow < parsedRealust && rangeUp < parsedRealust)//满足输入范围
                    {
                        if (RelativeComboBox == null) //如果有关联的 ComboBox项,根据关联项显示值
                        {
                            txtBoxRelateVariablesVar = parsedRealust; //return true
                            txtBox.Text = System.String.Format(stringFormatExpression, txtBoxRelateVariablesVar); //更新当前文本框显示
                        }
                        else if (RelativeComboBox != null)
                        {
                            if ((string)RelativeComboBox.SelectedItem == "Vpp")//如果选择的是Vpp 则文本框保持，改变值直接存回
                            {
                                txtBoxRelateVariablesVar = parsedRealust; //return true
                                this.VoltageOutputAmplitudesValuetextBox.Text = System.String.Format(stringFormatExpression, txtBoxRelateVariablesVar); //更新显示

                            }
                            else if ((string)RelativeComboBox.SelectedItem == "Vrms") //如果选择的是Vrms 则文本框中显示的值要乘以sqrt(2)存回
                            {
                                txtBoxRelateVariablesVar = parsedRealust * Math.Sqrt(2.00); //return true
                                                                                            // 文本框显示值保持为Vrms //更新显示
                                this.VoltageOutputAmplitudesValuetextBox.Text = System.String.Format(stringFormatExpression, (txtBoxRelateVariablesVar / Math.Sqrt(2.000)));
                            }

                        }
                    }
                    else//不满足输入范围
                    {
                        String theErrorMessage = "请输入正确的范围\n输入的数字应该在" + rangeLow.ToString() + "~" + rangeUp.ToString() + "之间";
                        MessageBox.Show(theErrorMessage,
                                        "输入不合法",
                                         MessageBoxButtons.OK,
                                        //MessageBoxIcon.Warning // for Warning  
                                        MessageBoxIcon.Error // for Error 
                                                             //MessageBoxIcon.Information  // for Information
                                                             //MessageBoxIcon.Question // for Question
                                        );
                        txtBox.Text = System.String.Format(stringFormatExpression, txtBoxRelateVariablesVar); //输入重置为原值
                        return false;
                    }
                }
                else//没有指定输入范围则直接直接执行
                {
                    if (RelativeComboBox == null) //如果有关联的 ComboBox项,根据关联项显示值
                    {
                        txtBoxRelateVariablesVar = parsedRealust; //return true
                        txtBox.Text = System.String.Format(stringFormatExpression, txtBoxRelateVariablesVar); //更新当前文本框显示
                    }
                    else if (RelativeComboBox != null)
                    {
                        if ((string)RelativeComboBox.SelectedItem == "Vpp")//如果选择的是Vpp 则文本框保持，改变值直接存回
                        {
                            txtBoxRelateVariablesVar = parsedRealust; //return true
                            this.VoltageOutputAmplitudesValuetextBox.Text = System.String.Format(stringFormatExpression, txtBoxRelateVariablesVar); //更新显示

                        }
                        else if ((string)RelativeComboBox.SelectedItem == "Vrms") //如果选择的是Vrms 则文本框中显示的值要乘以sqrt(2)存回
                        {
                            txtBoxRelateVariablesVar = parsedRealust * Math.Sqrt(2.00); //return true
                                                                                        // 文本框显示值保持为Vrms //更新显示
                            this.VoltageOutputAmplitudesValuetextBox.Text = System.String.Format(stringFormatExpression, (txtBoxRelateVariablesVar / Math.Sqrt(2.000)));
                        }

                    }
                }

            }
            else
            {   //如果输入不合法
                MessageBox.Show("请输入正确值,不能含数字和小数外的其他字符 支持的输入形式为\n 10\n 5.2365 \n 1e+2 \n5.2365e+2 \n 5.2365e-2 \n 5.2365e+002 \n5.2365e-0002 \n 等",
                    "输入不合法",
                        MessageBoxButtons.OK,
                               //MessageBoxIcon.Warning // for Warning  
                               MessageBoxIcon.Error // for Error 
                                                    //MessageBoxIcon.Information  // for Information
                                                    //MessageBoxIcon.Question // for Question
                                );
                txtBox.Text = System.String.Format(stringFormatExpression, txtBoxRelateVariablesVar);
                return false;
            }

            return true;
        }
        private bool SyncVariablesToTextBox(ref TextBox txtBox, ref double txtBoxRelateVariablesVar, ComboBox RelativeComboBox = null, int digitalNumbersAferDecimalPoint = 11) //同步文本框输入的在合法范围将变量的值显示到文本输入框
        {
            String stringFormatExpression = "{0:F" + digitalNumbersAferDecimalPoint.ToString() + "}"; //trick for 让String.Format接受参数
            //String previousValueString = System.String.Format(stringFormatExpression, txtBoxRelateVariablesVar);
            //格式化到文本框中           
           txtBox.Text = System.String.Format(stringFormatExpression, txtBoxRelateVariablesVar); //更新当前文本框显示

           return true;           
        }
        public bool SyncComboBoxAndVariables(ref ComboBox cmbBox, ref double txtBoxRelateVariablesVar, int digitalNumbersAferDecimalPoint = 11) //同步下拉列表选项与幅度文本输入框的值 但不改变变量真正的值，因为变量真正的值一直储存为Vpp
        {
            String stringFormatExpression = "{0:F" + digitalNumbersAferDecimalPoint.ToString() + "}"; //trick for 让String.Format接受参数
            if ((string)cmbBox.SelectedItem == "Vpp")//如果选择的是Vpp 则文本框保持
            {
                this.VoltageOutputAmplitudesValuetextBox.Text = System.String.Format(stringFormatExpression, SignalOutputAmplitudesValue);

            }
            else if ((string)cmbBox.SelectedItem == "Vrms") //如果选择的是Vrms 则文本框中显示的值要除以sqrt(2)
            {
                this.VoltageOutputAmplitudesValuetextBox.Text = System.String.Format(stringFormatExpression, (SignalOutputAmplitudesValue / Math.Sqrt(2.000)));
            }
            return true;
        }
        private void TheMFLIMainWindow_Load(object sender, EventArgs e)
        {
            // no smaller than design time size----https://stackoverflow.com/questions/5962595/how-do-you-resize-a-form-to-fit-its-content-automatically
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            //启动时即尝试连接设备
            InitMFLIConnect(daq, GlobalVars.dev); //如果连接成功  isMFLIDeviceConnected = true
            //添加提示
            System.Windows.Forms.ToolTip myMFLIToolTip = new System.Windows.Forms.ToolTip();
            myMFLIToolTip.SetToolTip(this.richTextBoxShow, "MFLI实时测量结果");
            myMFLIToolTip.SetToolTip(this.RangeLabel, "输入量程选择,可输入任意数字\n系统会返回最接近与输入的值最匹配的量程");
            myMFLIToolTip.SetToolTip(this.VoltageInputRangetextBox, myMFLIToolTip.GetToolTip(this.RangeLabel));
            myMFLIToolTip.SetToolTip(this.VoltageInputAutoRangecheckBox, "输入量程由系统自动选择\n同时禁用手动量程");
            myMFLIToolTip.SetToolTip(this.ScalingLabel, "输入信号放大倍数,可输入任意数字\n系统会返回最接近输入值得可接受值");
            myMFLIToolTip.SetToolTip(this.VoltageInputScalingtextBox,myMFLIToolTip.GetToolTip(this.ScalingLabel));
            myMFLIToolTip.SetToolTip(this.ACCouplingLabel,"输入信号使用AC耦合方式");
            myMFLIToolTip.SetToolTip(this.VoltageInputACCouplingcheckBox, myMFLIToolTip.GetToolTip(this.ACCouplingLabel));
            myMFLIToolTip.SetToolTip(this.fifityOhmLabel,"选中此项输入阻抗50Ω,否则为10MΩ");
            myMFLIToolTip.SetToolTip(this.VoltageInputfiftyOhmcheckBox, myMFLIToolTip.GetToolTip(this.fifityOhmLabel));
            myMFLIToolTip.SetToolTip(this.FloatLabel,"是否使用悬浮地");
            myMFLIToolTip.SetToolTip(this.VoltageInputFloatcheckBox, myMFLIToolTip.GetToolTip(this.FloatLabel));
            myMFLIToolTip.SetToolTip(this.SwitchOnLabel,"信号功能开启,但除非 \"信号输出\" 也开启,否则不会输出信号");
            myMFLIToolTip.SetToolTip(this.VoltageOutputSwitchOncheckBox, myMFLIToolTip.GetToolTip(this.SwitchOnLabel));
            myMFLIToolTip.SetToolTip(this.OutPutfifityOhm, "选中此项输出阻抗50Ω");
            myMFLIToolTip.SetToolTip(this.VoltageOutput50OhmcheckBox, myMFLIToolTip.GetToolTip(this.OutPutfifityOhm));
            myMFLIToolTip.SetToolTip(this.OutputRangeLabel, "输出量程选择,可输入任意数字\n系统会返回最接近与输入的值最匹配的量程");
            myMFLIToolTip.SetToolTip(this.VoltageOutputRangeValuetextBox, myMFLIToolTip.GetToolTip(this.RangeLabel));
            myMFLIToolTip.SetToolTip(this.VoltageOutputAutoRangecheckBox, "输出量程由系统自动选择\n同时禁用手动量程");
            myMFLIToolTip.SetToolTip(this.OutputOffsetLabel,"直流偏置");
            myMFLIToolTip.SetToolTip(this.VoltageOutputOffsettextBox, myMFLIToolTip.GetToolTip(this.OutputOffsetLabel));
            myMFLIToolTip.SetToolTip(this.OutputAmplitudeslabel,"输出信号大小,应先从下拉列表中选择要输入的值的类型");
            myMFLIToolTip.SetToolTip(this.VoltageOutputAmplitudesValuetextBox, myMFLIToolTip.GetToolTip(this.OutputAmplitudeslabel));
            myMFLIToolTip.SetToolTip(this.OutputAmplitudesChoosecomboBox,"要输入右边数据输入栏的值的类型,Vpp(峰峰值)/Vrms(有效值)");
            myMFLIToolTip.SetToolTip(this.OutputAmplitudesEnablecheckBox,"信号输出,同时启用该项和上面的 \"输出\" 项启用信号输出");
            myMFLIToolTip.SetToolTip(this.IntervalBetweenTwoMeasurelabel,"连续测量时,相邻两次测量的时间间隔,单位为毫秒(ms)");
            myMFLIToolTip.SetToolTip(this.IntervalBetweenTwoMeasuretextBox, myMFLIToolTip.GetToolTip(this.IntervalBetweenTwoMeasurelabel));
            myMFLIToolTip.SetToolTip(this.theOscillatorsFrequencylabel, "信号频率");
            myMFLIToolTip.SetToolTip(this.theOscillatorsFrequencytextBox, myMFLIToolTip.GetToolTip(this.theOscillatorsFrequencylabel));
            myMFLIToolTip.SetToolTip(this.StartMeasure, "执行连续测量,虽然在测量过程中可以更改其他选项,但最好不要这样做");
            myMFLIToolTip.SetToolTip(this.SaveMeasureRealustToFile_checkBox, "如果选中此项,测量结果将保存到选定的文件中");


            /*
#if !MFLI_HasConnected
                        MessageBox.Show("当前处于无设备编程模式,程序不一能与设备协调工作,要达到最佳效果,请连接MFLI设备并取消\n TheMFLIMainWindow.cs文件的第4行的注释\n #define MFLI_HasConnected ",
                                "无设备编程模式",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning // for Warning  
                                //MessageBoxIcon.Error // for Error 
                                //MessageBoxIcon.Information  // for Information
                                //MessageBoxIcon.Question // for Question
                                 );
#endif
#if MFLI_HasConnected
#endif
            */

        }
        //线程间安全访问--访问不是该线程创建的宽口的控件--https://stackoverflow.com/questions/1110458/winforms-interthread-modification
        public void ControlModifyAndRefresh() //暂时只有一个地方用到,写死
        {
            // use "delegate" instead of "() =>" if .Net version < 3.5
            InvokeOnFormThread(() =>
            {
                StartMeasure.Text = "开始测量"; //变换按钮文字 //不能在该线程访问 form 控件
                this.StartMeasure.BackColor = Color.Green;
                //刷新界面
                this.TheElementreFresh();
            });
        }
        // change Action to MethodInvoker for .Net versions less than 3.5
        private void InvokeOnFormThread(Action behavior)
        {
            if (IsHandleCreated && InvokeRequired)
            {
                Invoke(behavior);
            }
            else
            {
                behavior();
            }
        }
        private void StartMeasure_Click(object sender, EventArgs e)
        {
            if (StartMeasure.Text == "开始测量") //如果按键显示为 开始测量 状态时被按下,开始测量
            {
                //正在执行测量
                GlobalVars.isMeasuring = true;
                //刷新仪器状态
                this.TheElementreFresh();
                //开始测量按钮按下后,不得更改设置的参数
                //Control[] excludeControlList = {richTextBoxShow, StartMeasure };
                //Control[] excludeControlList = { richTextBoxShow };
                //DisableOrEnableAllControlsExceptList(this, excludeControlList, false);
                //停止测量按钮按恢复 禁止设置面板
                //this.VoltageOutputSetPannel.Enabled = false;
                //this.VoltageInputSetPannel.Enabled = false;

                this.StartMeasure.BackColor = Color.Red;
                StartMeasure.Text = "停止测量";//变换按钮文字
                this.richTextBoxShow.Text = ""; //清空显示文本窗口
                                                //先声明一个写入文件流根据情况看是否使用它,因为在if条件块中声明的是局部的，对外不可见
                //将变量在循环外声明
                ZIDemodSample sample; //MFLI 返回的 sample
                String SampleOut; //显示到 richTextBox 中的实时测量信息

                //不论是否要保存文件,都实例化要操作文件，否则不通过编译, 想不到更好的办法解决。但是这样的话不管保存文件与否每次点击测量都会生成一个空文件，只能在测量停止后决定是否删除
                //--http://hovertree.com/hvtart/bjae/jbj59xoe.htm
                //--http://www.cnblogs.com/infly123/archive/2013/05/18/3085872.html
                /*if (GlobalVars.isSaveToFile == 1 && !GlobalVars.isNewStreamWriterCreated)
                {
                    GlobalVars.sw = new StreamWriter(GlobalVars.SaveMeasureRealustToFile_Whole, true, Encoding.Default);//不指定编码或制定为其它编码 用Excel打开文件后不能正确排行
                }*/
                //停止测量时如果测量记数器立即清零，会出现停止测量后又出现 测量次数:0的情况,所以在每次测量前再置零
                GlobalVars.CurrentMeasuretimes = 0;
                  //使用后台同步更新测量结果
                _worker = new BackgroundWorker();
                _worker.WorkerSupportsCancellation = true;
                _worker.DoWork += new DoWorkEventHandler((state, args) =>
                {
                    do                              
                    {
                        if (_worker.CancellationPending)
                        {
                            
                            if(GlobalVars.isSaveToFile == 1 || GlobalVars.isNewStreamWriterCreated) 
                            {
                                GlobalVars.sw.Close();  //如果选择了保存到文件或者创建了文件流 停止测量时都关闭文件
                                GlobalVars.isNewStreamWriterCreated = false;
                                //File.Delete(GlobalVars.SaveMeasureRealustToFile_Whole); 
                            }
                                break;
                        }
//#if MFLI_HasConnected
                        //--http://hovertree.com/hvtart/bjae/jbj59xoe.htm
                        //--http://www.cnblogs.com/infly123/archive/2013/05/18/3085872.html
                        if (GlobalVars.isSaveToFile == 1 && !GlobalVars.isNewStreamWriterCreated ) //根据情况(文件流还没被创建 且 需要保存数据到文件)创建文件,在循环内判断是很低效的方式，但为了能随时在测量过程中保存到文件只能用这种方法
                        {
                            //GlobalVars.sw = new StreamWriter(GlobalVars.SaveMeasureRealustToFile_Whole, true, Encoding.Default);//不指定编码或制定为其它编码 用Excel打开文件后不能正确排行
                            bool isFileLocked = false; //先判断文件是否被锁定
                            try
                            {
                                GlobalVars.sw = new StreamWriter(GlobalVars.SaveMeasureRealustToFile_Whole, true, Encoding.Default);//不指定编码或制定为其它编码 用Excel打开文件后不能正确排行
                            }
                            catch (IOException) //异常发生,文件被锁定
                            {
                                isFileLocked = true;
                            }
                            if (isFileLocked)
                            {
                                GlobalVars.isMeasuring = false;//解除测量标识
                                //StartMeasure.Text = "开始测量"; //变换按钮文字 //不能在该线程访问 form 控件
                                //this.StartMeasure.BackColor = Color.Green;
                                //刷新界面
                                //this.TheElementreFresh();
                                ControlModifyAndRefresh();
                                //显示提示信息
                                MessageBox.Show("其他程序正在使用文件" + GlobalVars.SaveMeasureRealustToFile_Whole + "\n不能打开文件,请关闭文件后再试",
                                                "文件被占用",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error
                                                );
                                _worker.CancelAsync();
                                break;//终止执行

                            }
                            GlobalVars.isNewStreamWriterCreated = !GlobalVars.isNewStreamWriterCreated;//文件流已创建
                            System.Threading.Thread.Sleep(500); //等待500ms 完成文件创建
                        }
                        ++GlobalVars.CurrentMeasuretimes;
                        GlobalVars.CurrentTime = DateTime.Now.ToString("  yyyy-MM-dd###HH:mm:ss.fff  "); //当前时间  可使用 sample.timeStamp÷clockbase  得到 ;  LabOneProgrammingManual 页面搜索 timestamp : The instrument's timestamp of the measured demodulator data uint64. Divide by the instrument's clockbase (/dev123/clockbase) to obtain the time in seconds.
                        System.Threading.Thread.Sleep((Int32)IntervalBetweenTwoMeasure); //两次测量间隔
                        sample = newMFLI.GetDemodSample(daq, GlobalVars.dev);
                        SampleOut = "时间"+ GlobalVars.CurrentTime + "次数:"+MyValueToStringFormat("{0:F0}",GlobalVars.CurrentMeasuretimes).PadLeft(5,' ')+"   频率: " + sample.frequency + "   " + "X值: " + MyValueToStringFormat("{0:E15}", sample.x) + "   " + "Y值: " + MyValueToStringFormat("{0:E15}", sample.y) + "   " +"R值: " + MyValueToStringFormat("{0:E15}", Math.Sqrt(sample.x* sample.x + sample.y*sample.y)) + "   " + "相位: " + MyValueToStringFormat("{0:E15}",sample.phase) + "\n";
                        SetrichTextBoxShowTextSafly(this.richTextBoxShow,SampleOut);
                        //this.richTextBoxShow.Text += SampleOut; //编译不通过，线程不安全
                        if (GlobalVars.isSaveToFile == 1 && GlobalVars.isNewStreamWriterCreated) //如果确认要保存文件,保存文件
                        {
                            //先判断扩展名 (csv 是逗号分隔符,text直接原始输入即可)
                            String fileExtension= Path.GetExtension(GlobalVars.SaveMeasureRealustToFile_Whole);
                            if (fileExtension == ".csv") //csv 文件
                            {
                                SampleOut = GlobalVars.CurrentTime + MyValueToStringFormat("{0:F0}", GlobalVars.CurrentMeasuretimes) + "," + sample.frequency + "," + MyValueToStringFormat("{0:E15}", sample.x) + "," + MyValueToStringFormat("{0:E15}", sample.y) + "," + MyValueToStringFormat("{0:E15}", Math.Sqrt(sample.x * sample.x + sample.y * sample.y)) + "," + MyValueToStringFormat("{0:E15}", sample.phase); //不用在最后加换行,不然会有间隔空行
                                if (1 == GlobalVars.CurrentMeasuretimes) //csv文件第一行
                                {
                                    GlobalVars.sw.WriteLine("时间,次数,频率,X值,Y值,R值,相位");//不用在最后加换行,不然会有多空行
                                    GlobalVars.sw.WriteLine(SampleOut);
                                }
                                else
                                {
                                    GlobalVars.sw.WriteLine(SampleOut);
                                }

                            }else // txt 文件 或其他文件 直接写入
                            {
                                GlobalVars.sw.WriteLine(SampleOut);
                            }
                        }
//#endif
                    } while (true);
                });
                _worker.RunWorkerAsync();
              
            }
            else if (StartMeasure.Text == "停止测量")//如果按键显示为 停止测量 状态时被按下,停止测量
            {

                DialogResult result = MessageBox.Show("是否停止测量?", "提示",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    _worker.CancelAsync(); //停止测量   点击停止时后台进程并不会立即停止，
                                           //后台还会再进行一次测量 因此此处弹出对话框有
                                           //两个目的,1、提示用户 2、给后台进程一点反应时间
                    System.Threading.Thread.Sleep((Int32)(IntervalBetweenTwoMeasure*1.2)); //等待测量间隔1.2倍的时间  数据同步

                    StartMeasure.Text = "开始测量";//变换按钮文字
                    this.StartMeasure.BackColor = Color.Green;

                    //测量已停止
                    GlobalVars.isMeasuring = false;

                    this.TheElementreFresh(); //刷新空间

                    //停止测量时测量记数器要清零                 //在这儿清零会出现停止测量后又出现 测量次数:0的情况,所以在每次测量前再置零
                    //GlobalVars.CurrentMeasuretimes = 0;
                }
                else if (result == DialogResult.No || result == DialogResult.Cancel)
                {
                    //code for No
                }



               

                //System.Threading.Thread.Sleep(1000); //等待1000ms  数据同步
                //停止测量按钮按恢复 设置面板
                //DisableOrEnableAllControlsExcept4(this, null, null, null, null, false);
                //DisableOrEnableAllControlsExceptList(this,null,true);
                //this.VoltageOutputSetPannel.Enabled = true;
                //this.VoltageInputSetPannel.Enabled = true;



            }

        }


        //主窗口关闭时
        private void TheMFLIMainWindow_Closed(object sender, EventArgs e)
        {
            //如果设备已连接,则断开连接,否则不做任何操作
            if (GlobalVars.isMFLIDeviceConnected)
            {
                daq.disconnect();
            }
        }

        private void AutoRangecheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.CheckBoxApplyToVariables(VoltageInputAutoRangecheckBox, ref isSignalInputAutoRange, VoltageInputRangetextBox);
            this.DebugtextBox.Text = System.String.Format("{0:F0}", isSignalInputAutoRange);
            if(GlobalVars.isMFLIDeviceConnected)
            daq.syncSetInt(newMFLI.SignalInputAutoRangePath, isSignalInputAutoRange);//设置自动量程
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SyncTextBoxAndVariables(ref VoltageInputRangetextBox,ref SignalInputManualRangeValue);
            this.DebugtextBox.Text= System.String.Format("{0:F9}", SignalInputManualRangeValue);
        }

        private void OutputAutoRangecheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.CheckBoxApplyToVariables(VoltageOutputAutoRangecheckBox, ref isSignalOutputAutoRange, VoltageOutputRangeValuetextBox);
            this.DebugtextBox.Text = System.String.Format("{0:F0}", isSignalOutputAutoRange);
            if (GlobalVars.isMFLIDeviceConnected)
                daq.syncSetInt(newMFLI.SignalOutputAutoRangePath, isSignalOutputAutoRange);//输出设置自动量程
        }

        private void VoltageInputACCouplingcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.CheckBoxApplyToVariables(VoltageInputACCouplingcheckBox, ref isSignalInputACCoupling);
            this.DebugtextBox.Text = System.String.Format("{0:F0}", isSignalInputACCoupling);
            if (GlobalVars.isMFLIDeviceConnected)
                daq.syncSetInt(newMFLI.SignalInputACCouplingPath, isSignalInputACCoupling);//设置AC耦合
        }

        private void VoltageInputfiftyOhmcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.CheckBoxApplyToVariables(VoltageInputfiftyOhmcheckBox, ref isSignalInput50Ohm);
            this.DebugtextBox.Text = System.String.Format("{0:F0}", isSignalInput50Ohm);
            if (GlobalVars.isMFLIDeviceConnected)
                daq.syncSetInt(newMFLI.SignalInputSwitchBetween50And10MegaOhmPath, isSignalInput50Ohm);//输入使用50欧姆？10M
        }

        private void VoltageInputFloatcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.CheckBoxApplyToVariables(VoltageInputFloatcheckBox, ref isSignalInputFloatGround);
            this.DebugtextBox.Text = System.String.Format("{0:F0}", isSignalInputFloatGround);
            if (GlobalVars.isMFLIDeviceConnected)
                daq.syncSetInt(newMFLI.SignalInputFloatPath, isSignalInputFloatGround);//使用悬浮地?
        }

        private void VoltageOutputSwitchOncheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.CheckBoxApplyToVariables(VoltageOutputSwitchOncheckBox, ref isSignalOutputSwitchOn);
            this.DebugtextBox.Text = System.String.Format("{0:F0}", isSignalOutputSwitchOn);
            if (GlobalVars.isMFLIDeviceConnected)
                daq.syncSetInt(newMFLI.SignalOutputSwitchOnPath, isSignalOutputSwitchOn);//输出开启?
        }

        private void VoltageOutput50OhmcheckBox_CheckedChanged_1(object sender, EventArgs e)
        {
            this.CheckBoxApplyToVariables(VoltageOutput50OhmcheckBox, ref isSignalOutputImpendence50);
            this.DebugtextBox.Text = System.String.Format("{0:F0}", isSignalOutputImpendence50);
            if (GlobalVars.isMFLIDeviceConnected)
                daq.syncSetInt(newMFLI.SignalOutputImpendence50Path, isSignalOutputImpendence50);//输出使用50欧姆
        }

        private void VoltageInputRangetextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter) // KeyCode 不能使用,不知道为什么
            {
                SyncTextBoxAndVariables(ref VoltageInputRangetextBox, ref SignalInputManualRangeValue,null,5);
                this.DebugtextBox.Text = System.String.Format("{0:F9}", SignalInputManualRangeValue);
                if(GlobalVars.isMFLIDeviceConnected)
                    if ((int)isSignalInputAutoRange == 0)  //如果自动量程开启则不必设置手动量程
                    {
                        daq.syncSetDouble(newMFLI.SignalInputManualRangePath, SignalInputManualRangeValue); //默认300mV ,若设置的量程低于实际输入值，系统会自动选择一个合适的量程
                                                                                                            //等待200ms向仪器询问已设定值
                        System.Threading.Thread.Sleep(200);
                        double returnValue = daq.getDouble(newMFLI.SignalInputManualRangePath); //取回返回值
                        SignalInputManualRangeValue = returnValue; //将返回值写回变量
                        SyncVariablesToTextBox(ref VoltageInputRangetextBox, ref SignalInputManualRangeValue,null,5); //同步返回值到输入框
#if Debug_InstrumentReturnValue
                        MessageBox.Show(returnValue.ToString(),
                                            "输入信号量程",
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Information  // for Information
                                            );
#endif                  
                    }
            }
        }

        private void VoltageInputRangetextBox_Leave(object sender, EventArgs e)
        {
            SyncTextBoxAndVariables(ref VoltageInputRangetextBox, ref SignalInputManualRangeValue, null, 5);
            this.DebugtextBox.Text = System.String.Format("{0:F9}", SignalInputManualRangeValue);
            if (GlobalVars.isMFLIDeviceConnected)
                if ((int)isSignalInputAutoRange == 0)  //如果自动量程开启则不必设置手动量程
                {
                    daq.syncSetDouble(newMFLI.SignalInputManualRangePath, SignalInputManualRangeValue); //默认300mV ,若设置的量程低于实际输入值，系统会自动选择一个合适的量程
                                                                                                        //等待200ms向仪器询问已设定值
                    System.Threading.Thread.Sleep(200);
                    double returnValue = daq.getDouble(newMFLI.SignalInputManualRangePath); //取回返回值
                    SignalInputManualRangeValue = returnValue; //将返回值写回变量
                    SyncVariablesToTextBox(ref VoltageInputRangetextBox, ref SignalInputManualRangeValue, null, 5); //同步返回值到输入框
#if Debug_InstrumentReturnValue
                    MessageBox.Show(returnValue.ToString(),
                                        "输入信号量程",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Information  // for Information
                                        );
#endif
                }
        }

        private void AmplitudesOutputEnable_CheckedChanged(object sender, EventArgs e)
        {
            this.CheckBoxApplyToVariables(OutputAmplitudesEnablecheckBox, ref isSignalOutputAmplitudesEnable);
            this.DebugtextBox.Text = System.String.Format("{0:F0}", isSignalOutputAmplitudesEnable);
            if (GlobalVars.isMFLIDeviceConnected)
                daq.syncSetInt(newMFLI.SignalOutputAmplitudesEnablePath, isSignalOutputAmplitudesEnable);//信号输出开启
        }

        private void VoltageInputScalingtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) // KeyCode 不能使用,不知道为什么
            {
                SyncTextBoxAndVariables(ref VoltageInputScalingtextBox, ref SignalInputScalingValue,null,1);
                this.DebugtextBox.Text = System.String.Format("{0:F1}", SignalInputScalingValue);
                if (GlobalVars.isMFLIDeviceConnected)
                    {
                        daq.syncSetDouble(newMFLI.SignalInputScalingPath,SignalInputScalingValue); //设置缩放因子
                    //等待200ms向仪器询问已设定值
                    System.Threading.Thread.Sleep(200);
                    double returnValue = daq.getDouble(newMFLI.SignalInputScalingPath); //取回返回值
                    SignalInputScalingValue = returnValue; //将返回值写回变量
                    SyncVariablesToTextBox(ref VoltageInputScalingtextBox, ref SignalInputScalingValue, null, 1); //同步返回值到输入框
#if Debug_InstrumentReturnValue
                    MessageBox.Show(returnValue.ToString(),
                                        "缩放因子",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Information  // for Information
                                        );
#endif                  
                }
            }
        }

        private void VoltageInputScalingtextBox_Leave(object sender, EventArgs e)
        {
            SyncTextBoxAndVariables(ref VoltageInputScalingtextBox, ref SignalInputScalingValue, null, 1);
            this.DebugtextBox.Text = System.String.Format("{0:F1}", SignalInputScalingValue);
            if (GlobalVars.isMFLIDeviceConnected)
            {
                daq.syncSetDouble(newMFLI.SignalInputScalingPath, SignalInputScalingValue); //设置缩放因子
                                                                                            //等待200ms向仪器询问已设定值
                System.Threading.Thread.Sleep(200);
                double returnValue = daq.getDouble(newMFLI.SignalInputScalingPath); //取回返回值
                SignalInputScalingValue = returnValue; //将返回值写回变量
                SyncVariablesToTextBox(ref VoltageInputScalingtextBox, ref SignalInputScalingValue, null, 1); //同步返回值到输入框
#if Debug_InstrumentReturnValue
                MessageBox.Show(returnValue.ToString(),
                                    "缩放因子",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Information  // for Information
                                    );
#endif
            }
        }

        private void VoltageOutputRangeValuetextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) // KeyCode 不能使用,不知道为什么
            {
                SyncTextBoxAndVariables(ref VoltageOutputRangeValuetextBox, ref SignalOutputManualRangeValue, null, 5);
                this.DebugtextBox.Text = System.String.Format("{0:F9}", SignalOutputManualRangeValue);
                if (GlobalVars.isMFLIDeviceConnected)
                    if ((int)isSignalOutputAutoRange == 0)  //如果自动量程开启则不必设置手动量程
                    {
                        daq.syncSetDouble(newMFLI.SignalOutputManualRangePath, SignalOutputManualRangeValue); //默认150mV ,若设置的量程低于实际输入值，系统会自动选择一个合适的量程
                                                                                                            //等待200ms向仪器询问已设定值
                        System.Threading.Thread.Sleep(200);
                        double returnValue = daq.getDouble(newMFLI.SignalOutputManualRangePath); //取回返回值
                        SignalOutputManualRangeValue = returnValue; //将返回值写回变量
                        SyncVariablesToTextBox(ref VoltageOutputRangeValuetextBox, ref SignalOutputManualRangeValue, null, 5); //同步返回值到输入框
#if Debug_InstrumentReturnValue
                        MessageBox.Show(returnValue.ToString(),
                                            "输出信号量程",
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Information  // for Information
                                            );
#endif                  
                    }

            }
        }

        private void VoltageOutputRangeValuetextBox_Leave(object sender, EventArgs e)
        {
            SyncTextBoxAndVariables(ref VoltageOutputRangeValuetextBox, ref SignalOutputManualRangeValue, null, 5);
            this.DebugtextBox.Text = System.String.Format("{0:F9}", SignalOutputManualRangeValue);
            if (GlobalVars.isMFLIDeviceConnected)
                if ((int)isSignalOutputAutoRange == 0)  //如果自动量程开启则不必设置手动量程
                {
                    daq.syncSetDouble(newMFLI.SignalOutputManualRangePath, SignalOutputManualRangeValue); //默认150mV ,若设置的量程低于实际输入值，系统会自动选择一个合适的量程
                                                                                                          //等待200ms向仪器询问已设定值
                    System.Threading.Thread.Sleep(200);
                    double returnValue = daq.getDouble(newMFLI.SignalOutputManualRangePath); //取回返回值
                    SignalOutputManualRangeValue = returnValue; //将返回值写回变量
                    SyncVariablesToTextBox(ref VoltageOutputRangeValuetextBox, ref SignalOutputManualRangeValue, null, 5); //同步返回值到输入框
#if Debug_InstrumentReturnValue
                    MessageBox.Show(returnValue.ToString(),
                                        "输出信号量程",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Information  // for Information
                                        );
#endif
                }
        }

        private void VoltageOutputOffsettextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) // KeyCode 不能使用,不知道为什么
            {
                SyncTextBoxAndVariables(ref VoltageOutputOffsettextBox, ref SignalOutputOffsetValue,null,8);
                this.DebugtextBox.Text = System.String.Format("{0:F8}", SignalOutputOffsetValue);
                if (GlobalVars.isMFLIDeviceConnected)
                    {
                        daq.syncSetDouble(newMFLI.SignalOutputOffsetPath, SignalOutputOffsetValue); //设置偏置
                                                                                                            //等待200ms向仪器询问已设定值
                        System.Threading.Thread.Sleep(200);
                        double returnValue = daq.getDouble(newMFLI.SignalOutputOffsetPath); //取回返回值
                    SignalOutputOffsetValue = returnValue; //将返回值写回变量
                        SyncVariablesToTextBox(ref VoltageOutputOffsettextBox, ref SignalOutputOffsetValue, null, 8); //同步返回值到输入框
#if Debug_InstrumentReturnValue
                        MessageBox.Show(returnValue.ToString(),
                                            "输出偏置",
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Information  // for Information
                                            );
#endif
                    }
            }
        }

        private void VoltageOutputOffsettextBox_Leave(object sender, EventArgs e)
        {
            SyncTextBoxAndVariables(ref VoltageOutputOffsettextBox, ref SignalOutputOffsetValue, null, 8);
            this.DebugtextBox.Text = System.String.Format("{0:F8}", SignalOutputOffsetValue);
            if (GlobalVars.isMFLIDeviceConnected)
            {
                daq.syncSetDouble(newMFLI.SignalOutputOffsetPath, SignalOutputOffsetValue); //设置偏置
                                                                                            //等待200ms向仪器询问已设定值
                System.Threading.Thread.Sleep(200);
                double returnValue = daq.getDouble(newMFLI.SignalOutputOffsetPath); //取回返回值
                SignalOutputOffsetValue = returnValue; //将返回值写回变量
                SyncVariablesToTextBox(ref VoltageOutputOffsettextBox, ref SignalOutputOffsetValue, null, 8); //同步返回值到输入框
#if Debug_InstrumentReturnValue
                MessageBox.Show(returnValue.ToString(),
                                    "输出偏置",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Information  // for Information
                                    );
#endif
            }
        }

        private void VoltageOutputAmplitudesValuetextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) // KeyCode 不能使用,不知道为什么
            {
                SyncTextBoxAndVariables(ref VoltageOutputAmplitudesValuetextBox, ref SignalOutputAmplitudesValue,this.OutputAmplitudesChoosecomboBox);
                this.DebugtextBox.Text = System.String.Format("{0:F9}", SignalOutputAmplitudesValue);
                if (GlobalVars.isMFLIDeviceConnected)
                {
                    daq.syncSetDouble(newMFLI.SignalOutputAmplitudesValuePath, SignalOutputAmplitudesValue); //设置输出信号
                                                                                                //等待200ms向仪器询问已设定值
                    System.Threading.Thread.Sleep(200);
                    double returnValue = daq.getDouble(newMFLI.SignalOutputAmplitudesValuePath); //取回返回值,由于返回值永远是峰峰值要先判断OutputAmplitudesChoosecomboBox的值，如果当前是Vrms,则要将返回值除以sqrt(2)再写回
                    if((string)this.OutputAmplitudesChoosecomboBox.SelectedItem =="Vrms")
                    {
                        SignalOutputAmplitudesValue = returnValue/Math.Sqrt(2.00); //将返回值写回变量  Vrms
                    }
                    else
                    {
                        SignalOutputAmplitudesValue = returnValue;  //将返回值写回变量 Vpp
                    }
                    SyncVariablesToTextBox(ref VoltageOutputAmplitudesValuetextBox, ref SignalOutputAmplitudesValue,this.OutputAmplitudesChoosecomboBox); //同步返回值到输入框
#if Debug_InstrumentReturnValue
                    MessageBox.Show(returnValue.ToString(),
                                        "输出信号",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Information  // for Information
                                        );
#endif
                }
            }
        }

        private void VoltageOutputAmplitudesValuetextBox_Leave(object sender, EventArgs e)
        {
            SyncTextBoxAndVariables(ref VoltageOutputAmplitudesValuetextBox, ref SignalOutputAmplitudesValue, this.OutputAmplitudesChoosecomboBox);
            this.DebugtextBox.Text = System.String.Format("{0:F9}", SignalOutputAmplitudesValue);
            if (GlobalVars.isMFLIDeviceConnected)
            {
                daq.syncSetDouble(newMFLI.SignalOutputAmplitudesValuePath, SignalOutputAmplitudesValue); //设置输出信号
                                                                                                         //等待200ms向仪器询问已设定值
                System.Threading.Thread.Sleep(200);
                double returnValue = daq.getDouble(newMFLI.SignalOutputAmplitudesValuePath); //取回返回值,由于返回值永远是峰峰值要先判断OutputAmplitudesChoosecomboBox的值，如果当前是Vrms,则要将返回值除以sqrt(2)再写回
                if ((string)this.OutputAmplitudesChoosecomboBox.SelectedItem == "Vrms")
                {
                    SignalOutputAmplitudesValue = returnValue / Math.Sqrt(2.00); //将返回值写回变量  Vrms
                }
                else
                {
                    SignalOutputAmplitudesValue = returnValue;  //将返回值写回变量 Vpp
                }
                SyncVariablesToTextBox(ref VoltageOutputAmplitudesValuetextBox, ref SignalOutputAmplitudesValue, this.OutputAmplitudesChoosecomboBox); //同步返回值到输入框
#if Debug_InstrumentReturnValue
                MessageBox.Show(returnValue.ToString(),
                                    "输出信号",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Information  // for Information
                                    );
#endif
            }
        }

        private void IntervalBetweenTwoMeasuretextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) // KeyCode 不能使用,不知道为什么
            {
                SyncTextBoxAndVariables(ref IntervalBetweenTwoMeasuretextBox, ref IntervalBetweenTwoMeasure,null,0);
                this.DebugtextBox.Text = System.String.Format("{0:F0}", IntervalBetweenTwoMeasure);
            }
        }

        private void IntervalBetweenTwoMeasuretextBox_Leave(object sender, EventArgs e)
        {
            SyncTextBoxAndVariables(ref IntervalBetweenTwoMeasuretextBox, ref IntervalBetweenTwoMeasure,null, 0);
            this.DebugtextBox.Text = System.String.Format("{0:F0}", IntervalBetweenTwoMeasure);
        }

        private void theOscillatorsFrequencytextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) // KeyCode 不能使用,不知道为什么
            {
                SyncTextBoxAndVariables(ref theOscillatorsFrequencytextBox, ref theOscillatorsFrequency,null, 2);
                this.DebugtextBox.Text = System.String.Format("{0:F2}", theOscillatorsFrequency);
                if (GlobalVars.isMFLIDeviceConnected)
                {
                    daq.syncSetDouble(newMFLI.SignalOscillatorsPath, theOscillatorsFrequency); //设置频率
                                                                                                //等待200ms向仪器询问已设定值
                    System.Threading.Thread.Sleep(200);
                    double returnValue = daq.getDouble(newMFLI.SignalOscillatorsPath); //取回返回值
                    theOscillatorsFrequency = returnValue; //将返回值写回变量
                    SyncVariablesToTextBox(ref theOscillatorsFrequencytextBox, ref theOscillatorsFrequency, null, 2); //同步返回值到输入框
#if Debug_InstrumentReturnValue
                    MessageBox.Show(returnValue.ToString(),
                                        "信号频率",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Information  // for Information
                                        );
#endif
                }
            }
        }

        private void theOscillatorsFrequencytextBox_Leave(object sender, EventArgs e)
        {
            SyncTextBoxAndVariables(ref theOscillatorsFrequencytextBox, ref theOscillatorsFrequency, null, 2);
            this.DebugtextBox.Text = System.String.Format("{0:F2}", theOscillatorsFrequency);
            if (GlobalVars.isMFLIDeviceConnected)
            {
                daq.syncSetDouble(newMFLI.SignalOscillatorsPath, theOscillatorsFrequency); //设置频率
                                                                                           //等待200ms向仪器询问已设定值
                System.Threading.Thread.Sleep(200);
                double returnValue = daq.getDouble(newMFLI.SignalOscillatorsPath); //取回返回值
                theOscillatorsFrequency = returnValue; //将返回值写回变量
                SyncVariablesToTextBox(ref theOscillatorsFrequencytextBox, ref theOscillatorsFrequency, null, 2); //同步返回值到输入框
#if Debug_InstrumentReturnValue
                    MessageBox.Show(returnValue.ToString(),
                                        "信号频率",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Information  // for Information
                                        );
#endif
            }
        }

        private void TheMFLIInstruments_DropDownOpening(object sender, EventArgs e)
        {
            //防止突然断开后窗口未刷新
            //检查仪器是否处于连接状态
            if (GlobalVars.isMFLIDeviceConnected)
            {

                if (!newMFLI.isNetWorkDeviceContainStringExsit()  || string.IsNullOrWhiteSpace(daq.getByte("/zi/about/version"))) //如果设备不存在或未返回版本信息,说明仪器未连接,应刷新仪器状态
                {
                    GlobalVars.isMFLIDeviceConnected = false;
                }else
                {
                    SynchronizeMFLIDeviceSettingAndLocalSetting(daq,GlobalVars.dev);  //同步设置信息
                    SynchronizeVariableWithControls();  //应用同步的信息到控件
                }

            }
                this.TheElementreFresh();//刷新窗口状态              
  
        }

        private void ToolStripMenuItemSettingMFLI_Click(object sender, EventArgs e)
        {
            if (GlobalVars.isMFLIDeviceConnected) //先断开设备
            {
                daq.disconnect();
                //连接标志置为假
                GlobalVars.isMFLIDeviceConnected = false;
                // 刷新界面
                this.TheElementreFresh();
            }
            theMFLISettingForm.ShowDialog(); //调用设置窗口
        }

        private void DebugtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) // KeyCode 不能使用,不知道为什么
            {
                this.DebugtextBox.Text ="设备:"+ GlobalVars.dev;
            }
        }

        private void ToolStripMenuItemConnectMFLI_Click(object sender, EventArgs e)
        {
            if (!GlobalVars.isMFLIDeviceConnected)
            {
                //尝试连接设备
                this.InitMFLIConnect(daq, GlobalVars.dev); //如果连接成功  isMFLIDeviceConnected = true
                                                           //ToolStripMenuItemConnectMFLI.Enabled = !GlobalVars.isMFLIDeviceConnected; //立即更新状态
                this.TheElementreFresh(); //刷新窗口状态
            } else   //如果是已连接状态 断开连接
            {
                daq.disconnect();
                GlobalVars.isMFLIDeviceConnected = false;
                this.TheElementreFresh(); //刷新窗口状态
            }
        }

        private void OutputAmplitudesChoosecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SyncComboBoxAndVariables(ref this.OutputAmplitudesChoosecomboBox, ref SignalOutputAmplitudesValue);//同步下拉列表选项与幅度文本输入框的值 但不改变变量真正的值，因为变量真正的值一直储存为Vpp
        }

        private void richTextBoxShow_TextChanged(object sender, EventArgs e)
        {

            //只在显示窗口保留GlobalVars.MaxLinesInRichTextBox个值,使用正则表达式将前面的和后面分割，只保留后面
            if ( (GlobalVars.CurrentMeasuretimes > GlobalVars.MaxLinesInRichTextBox) && (GlobalVars.CurrentMeasuretimes % GlobalVars.MaxLinesInRichTextBox) == 0) // GlobalVars.MaxLinesInRichTextBox 行(Lines)为一组
            {
                
                String splitDelimeter = "\n" + ".*次数:[ ]*" + (GlobalVars.CurrentMeasuretimes - GlobalVars.MaxLinesInRichTextBox).ToString();
                String[] richTextBoxShowTextParts = Regex.Split(this.richTextBoxShow.Text, splitDelimeter);
                this.richTextBoxShow.Text = "次数:"+ MyValueToStringFormat("{0:F0}", (((GlobalVars.CurrentMeasuretimes / GlobalVars.MaxLinesInRichTextBox) - 1) * GlobalVars.MaxLinesInRichTextBox)).PadLeft(5, ' ') +"\t"+richTextBoxShowTextParts[1]; //取后一部分 补上用作正则表达式分隔符的  "次数: "+GlobalVars.CurrentMeasuretimes.ToString()
            }
            //---https://stackoverflow.com/questions/9416608/rich-text-box-scroll-to-the-bottom-when-new-data-is-written-to-it
            // set the current caret position to the end
            this.richTextBoxShow.SelectionStart = this.richTextBoxShow.Text.Length;
            // scroll it automatically
           this.richTextBoxShow.ScrollToCaret();
        }

        private void ToolStripMenuItemResetMFLISettingToDefault_Click(object sender, EventArgs e)
        {
            if (GlobalVars.isMFLIDeviceConnected)
            {
                // 用 GlobalVars.isResettingDevice 冻结所有操作
                GlobalVars.isResettingDevice = true;
                //刷新窗口 确保所有窗口已冻结
                this.TheElementreFresh();
                //给出提示
                MessageBox.Show("正在重置系统为出厂设置,点击  确定  按钮后,请稍后...",
                    "重置系统为出厂设置",
                    MessageBoxButtons.OK,
                    //MessageBoxIcon.Warning // for Warning  
                    //MessageBoxIcon.Error // for Error 
                    MessageBoxIcon.Information  // for Information
                     //MessageBoxIcon.Question // for Question
                     );
                //开始重置操作
                bool rstReasult= newMFLI.resetDeviceToDefault(daq);
                //如果重置成功
                if (rstReasult)
                {
                    //已没有在重置操作中,先更改flag再继续
                    GlobalVars.isResettingDevice = false;
                    //启用所有控件
                    this.TheElementreFresh();
                    //同步回仪器的设置
                    this.SynchronizeMFLIDeviceSettingAndLocalSetting(daq, GlobalVars.dev);
                    //应用设置到控件显示
                    this.SynchronizeVariableWithControls();
                }

            }
        }

        private void SaveMeasureRealustToFile_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            isTextBoxFileNameValid(ref SaveMeasureRealustToFile_textBox, ref GlobalVars.SaveMeasureRealustToFile_Whole);
            this.CheckBoxApplyToVariables(SaveMeasureRealustToFile_checkBox, ref GlobalVars.isSaveToFile,SaveMeasureRealustToFile_textBox,false);
            TheElementreFresh();
        }

        private void SaveMeasureRealustToFile_button_Click(object sender, EventArgs e)
        {
            ChoseWhichFileToSave();
            this.SaveMeasureRealustToFile_textBox.Text = GlobalVars.SaveMeasureRealustToFile_Whole;

        }

        /// <summary>
        /// 检查文件名和路径是否合法,如果合法,更新到变量
        /// </summary>
        /// <param name="txtBox"></param>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public bool isTextBoxFileNameValid(ref TextBox txtBox,ref String inputString)
        {
            bool isPathValid = true;
            bool isFileNameValid = true;
            String tmpStr = txtBox.Text;
            String tmpFilePath = tmpStr.Substring(0, tmpStr.LastIndexOf("\\")); //路径
            String tmpFileName = tmpStr.Substring(tmpFilePath.Length + 1);//文件名
#if Debug_FileAbout
            MessageBox.Show("输入的路径:tmpFilePath=" + tmpFilePath, "Debug信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show("输入的文件名:tmpFileName=" + tmpFileName, "Debug信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
#endif
            Regex regex = new Regex(@"^([a-zA-Z]:\\)?[^\/\:\*\?\""\<\>\|\,]*$");
            Match m = regex.Match(tmpFilePath);
            if (!m.Success) //路径不合法
            {
                isPathValid = false;
                MessageBox.Show("非法的文件保存路径，请重新选择或输入！", "路径错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            regex = new Regex(@"^[^\/\:\*\?\""\<\>\|\,]+$");
            m = regex.Match(tmpFileName);
            if (!m.Success)//文件名不合法
            {
                isFileNameValid = false;
                MessageBox.Show("请勿在文件名中包含\\ / : * ？ \" < > |等字符，请重新输入有效文件名！", "文件名错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (isPathValid && isFileNameValid)
            {
                inputString = txtBox.Text;//合法则将更改应用到变量
            }
            else
            {
                txtBox.Text = inputString;//不合法则显示回原来合法的
            }
            return true;
        }
        
    
        private void SaveMeasureRealustToFile_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        if (e.KeyChar == (char)Keys.Enter) // KeyCode 不能使用,不知道为什么
        {
                isTextBoxFileNameValid(ref SaveMeasureRealustToFile_textBox, ref GlobalVars.SaveMeasureRealustToFile_Whole);
        }

        }

        private void SaveMeasureRealustToFile_textBox_Leave(object sender, EventArgs e)
        {
            isTextBoxFileNameValid(ref SaveMeasureRealustToFile_textBox, ref GlobalVars.SaveMeasureRealustToFile_Whole);
        }
    }

    public static class GlobalVars
    {   //设备名
        public static String dev = "dev3070";
        //设备连接状态
        public static bool isMFLIDeviceConnected = false;
        public static bool isMeasuring= false; //是否正在测量
        public static bool isResettingDevice = false; //是否在重置系统
        public static long  isSaveToFile = 0;//是否保存测量结果到文件 本应为bool 但为了适应 CheckBoxStatuAdjust 函数 将其定义为long
        public static Int32 MaxLinesInRichTextBox = 100;
        public static Int32 CurrentMeasuretimes = 0; //第几次测量
        public static String CurrentTime = null; //第几次测量
        public static String SaveMeasureRealustToFile_Directory = AppDomain.CurrentDomain.BaseDirectory; //保存文件文件夹--https://stackoverflow.com/questions/97312/how-do-i-find-out-what-directory-my-console-app-is-running-in-with-c
        public static String SaveMeasureRealustToFile_FileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-")+"MFLI_Data.csv"; //保存文件文件名
        public static String SaveMeasureRealustToFile_Whole = SaveMeasureRealustToFile_Directory + SaveMeasureRealustToFile_FileName;//完整包含路径文件名
        public static StreamWriter sw=null;//保存文件时使用的文件流,不确定是否使用,默认初始化为null，等使用时再实例化
        public static bool isNewStreamWriterCreated = false;//是否已创建文件流
    }  
}
