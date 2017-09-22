using System.Drawing;

namespace MFLI_GUI
{
    partial class TheMFLIMainWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TheMFLIMainWindow));
            this.richTextBoxShow = new System.Windows.Forms.RichTextBox();
            this.ResultOutputTable = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.StartMeasure = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ACCouplingLabel = new System.Windows.Forms.Label();
            this.ScalingLabel = new System.Windows.Forms.Label();
            this.FloatLabel = new System.Windows.Forms.Label();
            this.fifityOhmLabel = new System.Windows.Forms.Label();
            this.VoltageInputRangetextBox = new System.Windows.Forms.TextBox();
            this.VoltageInputScalingtextBox = new System.Windows.Forms.TextBox();
            this.VoltageInputAutoRangecheckBox = new System.Windows.Forms.CheckBox();
            this.VoltageInputACCouplingcheckBox = new System.Windows.Forms.CheckBox();
            this.VoltageInputfiftyOhmcheckBox = new System.Windows.Forms.CheckBox();
            this.VoltageInputFloatcheckBox = new System.Windows.Forms.CheckBox();
            this.RangeLabel = new System.Windows.Forms.Label();
            this.VoltageInputSetPannel = new System.Windows.Forms.Panel();
            this.VoltageInputlabel = new System.Windows.Forms.Label();
            this.SwitchOnLabel = new System.Windows.Forms.Label();
            this.OutPutfifityOhm = new System.Windows.Forms.Label();
            this.OutputRangeLabel = new System.Windows.Forms.Label();
            this.OutputOffsetLabel = new System.Windows.Forms.Label();
            this.OutputAmplitudeslabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.OutputAmplitudesChoosecomboBox = new System.Windows.Forms.ComboBox();
            this.VoltageOutputOffsettextBox = new System.Windows.Forms.TextBox();
            this.VoltageOutputSwitchOncheckBox = new System.Windows.Forms.CheckBox();
            this.VoltageOutput50OhmcheckBox = new System.Windows.Forms.CheckBox();
            this.VoltageOutputAutoRangecheckBox = new System.Windows.Forms.CheckBox();
            this.VoltageOutputRangeValuetextBox = new System.Windows.Forms.TextBox();
            this.OutputAmplitudesEnablecheckBox = new System.Windows.Forms.CheckBox();
            this.VoltageOutputAmplitudesValuetextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.VoltageOutputSetPannel = new System.Windows.Forms.Panel();
            this.IntervalBetweenTwoMeasurelabel = new System.Windows.Forms.Label();
            this.IntervalBetweenTwoMeasuretextBox = new System.Windows.Forms.TextBox();
            this.theOscillatorsFrequencytextBox = new System.Windows.Forms.TextBox();
            this.theOscillatorsFrequencylabel = new System.Windows.Forms.Label();
            this.DebugtextBox = new System.Windows.Forms.TextBox();
            this.DebugTextBoxLabel = new System.Windows.Forms.Label();
            this.ZurichInstrumentsMFInstrumentnotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStripInstruments = new System.Windows.Forms.MenuStrip();
            this.TheMFLIInstruments = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemSettingMFLI = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemResetMFLISettingToDefault = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemConnectMFLI = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveMeasureRealustToFile_textBox = new System.Windows.Forms.TextBox();
            this.SaveMeasureRealustToFile_button = new System.Windows.Forms.Button();
            this.SaveMeasureRealustToFile_label = new System.Windows.Forms.Label();
            this.SaveMeasureRealustToFile_checkBox = new System.Windows.Forms.CheckBox();
            this.SaveMeasureRealustToFile_panel = new System.Windows.Forms.Panel();
            this.ResultOutputTable.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.VoltageInputSetPannel.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.VoltageOutputSetPannel.SuspendLayout();
            this.menuStripInstruments.SuspendLayout();
            this.SaveMeasureRealustToFile_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxShow
            // 
            this.richTextBoxShow.AcceptsTab = true;
            this.richTextBoxShow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxShow.AutoWordSelection = true;
            this.richTextBoxShow.BackColor = System.Drawing.Color.BurlyWood;
            this.richTextBoxShow.EnableAutoDragDrop = true;
            this.richTextBoxShow.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxShow.Name = "richTextBoxShow";
            this.richTextBoxShow.Size = new System.Drawing.Size(1409, 268);
            this.richTextBoxShow.TabIndex = 1;
            this.richTextBoxShow.Text = "MFLI测量实时输出";
            this.richTextBoxShow.TextChanged += new System.EventHandler(this.richTextBoxShow_TextChanged);
            // 
            // ResultOutputTable
            // 
            this.ResultOutputTable.AllowDrop = true;
            this.ResultOutputTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultOutputTable.AutoScroll = true;
            this.ResultOutputTable.AutoSize = true;
            this.ResultOutputTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ResultOutputTable.ColumnCount = 1;
            this.ResultOutputTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ResultOutputTable.Controls.Add(this.richTextBoxShow, 0, 0);
            this.ResultOutputTable.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.ResultOutputTable.Location = new System.Drawing.Point(6, 462);
            this.ResultOutputTable.Name = "ResultOutputTable";
            this.ResultOutputTable.RowCount = 1;
            this.ResultOutputTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ResultOutputTable.Size = new System.Drawing.Size(1415, 274);
            this.ResultOutputTable.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AllowDrop = true;
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(993, 414);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(0, 0);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // StartMeasure
            // 
            this.StartMeasure.AllowDrop = true;
            this.StartMeasure.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StartMeasure.BackColor = System.Drawing.Color.Green;
            this.StartMeasure.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StartMeasure.Location = new System.Drawing.Point(1309, 406);
            this.StartMeasure.Name = "StartMeasure";
            this.StartMeasure.Size = new System.Drawing.Size(112, 53);
            this.StartMeasure.TabIndex = 0;
            this.StartMeasure.Text = "开始测量";
            this.StartMeasure.UseVisualStyleBackColor = false;
            this.StartMeasure.Click += new System.EventHandler(this.StartMeasure_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.ACCouplingLabel, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.ScalingLabel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.FloatLabel, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.fifityOhmLabel, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.VoltageInputRangetextBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.VoltageInputScalingtextBox, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.VoltageInputAutoRangecheckBox, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.VoltageInputACCouplingcheckBox, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.VoltageInputfiftyOhmcheckBox, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.VoltageInputFloatcheckBox, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.RangeLabel, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(351, 168);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // ACCouplingLabel
            // 
            this.ACCouplingLabel.Font = new System.Drawing.Font("宋体", 12F);
            this.ACCouplingLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ACCouplingLabel.Location = new System.Drawing.Point(3, 66);
            this.ACCouplingLabel.Name = "ACCouplingLabel";
            this.ACCouplingLabel.Size = new System.Drawing.Size(109, 30);
            this.ACCouplingLabel.TabIndex = 1;
            this.ACCouplingLabel.Text = "AC耦合";
            this.ACCouplingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ScalingLabel
            // 
            this.ScalingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScalingLabel.Font = new System.Drawing.Font("宋体", 12F);
            this.ScalingLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ScalingLabel.Location = new System.Drawing.Point(3, 33);
            this.ScalingLabel.Name = "ScalingLabel";
            this.ScalingLabel.Size = new System.Drawing.Size(109, 33);
            this.ScalingLabel.TabIndex = 0;
            this.ScalingLabel.Text = "Scaling";
            this.ScalingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FloatLabel
            // 
            this.FloatLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FloatLabel.Font = new System.Drawing.Font("宋体", 12F);
            this.FloatLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.FloatLabel.Location = new System.Drawing.Point(3, 132);
            this.FloatLabel.Name = "FloatLabel";
            this.FloatLabel.Size = new System.Drawing.Size(109, 36);
            this.FloatLabel.TabIndex = 3;
            this.FloatLabel.Text = "Float";
            this.FloatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fifityOhmLabel
            // 
            this.fifityOhmLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fifityOhmLabel.Font = new System.Drawing.Font("宋体", 12F);
            this.fifityOhmLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.fifityOhmLabel.Location = new System.Drawing.Point(3, 99);
            this.fifityOhmLabel.Name = "fifityOhmLabel";
            this.fifityOhmLabel.Size = new System.Drawing.Size(109, 33);
            this.fifityOhmLabel.TabIndex = 2;
            this.fifityOhmLabel.Text = "50Ω";
            this.fifityOhmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VoltageInputRangetextBox
            // 
            this.VoltageInputRangetextBox.Location = new System.Drawing.Point(118, 3);
            this.VoltageInputRangetextBox.Name = "VoltageInputRangetextBox";
            this.VoltageInputRangetextBox.Size = new System.Drawing.Size(114, 30);
            this.VoltageInputRangetextBox.TabIndex = 4;
            this.VoltageInputRangetextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VoltageInputRangetextBox_KeyPress);
            this.VoltageInputRangetextBox.Leave += new System.EventHandler(this.VoltageInputRangetextBox_Leave);
            // 
            // VoltageInputScalingtextBox
            // 
            this.VoltageInputScalingtextBox.Location = new System.Drawing.Point(118, 36);
            this.VoltageInputScalingtextBox.Name = "VoltageInputScalingtextBox";
            this.VoltageInputScalingtextBox.Size = new System.Drawing.Size(114, 30);
            this.VoltageInputScalingtextBox.TabIndex = 5;
            this.VoltageInputScalingtextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VoltageInputScalingtextBox_KeyPress);
            this.VoltageInputScalingtextBox.Leave += new System.EventHandler(this.VoltageInputScalingtextBox_Leave);
            // 
            // VoltageInputAutoRangecheckBox
            // 
            this.VoltageInputAutoRangecheckBox.AutoSize = true;
            this.VoltageInputAutoRangecheckBox.Font = new System.Drawing.Font("宋体", 12F);
            this.VoltageInputAutoRangecheckBox.Location = new System.Drawing.Point(238, 3);
            this.VoltageInputAutoRangecheckBox.Name = "VoltageInputAutoRangecheckBox";
            this.VoltageInputAutoRangecheckBox.Size = new System.Drawing.Size(111, 24);
            this.VoltageInputAutoRangecheckBox.TabIndex = 6;
            this.VoltageInputAutoRangecheckBox.Text = "自动量程";
            this.VoltageInputAutoRangecheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.VoltageInputAutoRangecheckBox.UseVisualStyleBackColor = true;
            this.VoltageInputAutoRangecheckBox.CheckedChanged += new System.EventHandler(this.AutoRangecheckBox_CheckedChanged);
            // 
            // VoltageInputACCouplingcheckBox
            // 
            this.VoltageInputACCouplingcheckBox.Location = new System.Drawing.Point(118, 69);
            this.VoltageInputACCouplingcheckBox.Name = "VoltageInputACCouplingcheckBox";
            this.VoltageInputACCouplingcheckBox.Size = new System.Drawing.Size(18, 27);
            this.VoltageInputACCouplingcheckBox.TabIndex = 7;
            this.VoltageInputACCouplingcheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.VoltageInputACCouplingcheckBox.UseVisualStyleBackColor = true;
            this.VoltageInputACCouplingcheckBox.CheckedChanged += new System.EventHandler(this.VoltageInputACCouplingcheckBox_CheckedChanged);
            // 
            // VoltageInputfiftyOhmcheckBox
            // 
            this.VoltageInputfiftyOhmcheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VoltageInputfiftyOhmcheckBox.Location = new System.Drawing.Point(118, 102);
            this.VoltageInputfiftyOhmcheckBox.Name = "VoltageInputfiftyOhmcheckBox";
            this.VoltageInputfiftyOhmcheckBox.Size = new System.Drawing.Size(114, 27);
            this.VoltageInputfiftyOhmcheckBox.TabIndex = 8;
            this.VoltageInputfiftyOhmcheckBox.UseVisualStyleBackColor = true;
            this.VoltageInputfiftyOhmcheckBox.CheckedChanged += new System.EventHandler(this.VoltageInputfiftyOhmcheckBox_CheckedChanged);
            // 
            // VoltageInputFloatcheckBox
            // 
            this.VoltageInputFloatcheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.VoltageInputFloatcheckBox.Location = new System.Drawing.Point(118, 135);
            this.VoltageInputFloatcheckBox.Name = "VoltageInputFloatcheckBox";
            this.VoltageInputFloatcheckBox.Size = new System.Drawing.Size(18, 30);
            this.VoltageInputFloatcheckBox.TabIndex = 9;
            this.VoltageInputFloatcheckBox.UseVisualStyleBackColor = true;
            this.VoltageInputFloatcheckBox.CheckedChanged += new System.EventHandler(this.VoltageInputFloatcheckBox_CheckedChanged);
            // 
            // RangeLabel
            // 
            this.RangeLabel.Font = new System.Drawing.Font("宋体", 12F);
            this.RangeLabel.Location = new System.Drawing.Point(3, 0);
            this.RangeLabel.Name = "RangeLabel";
            this.RangeLabel.Size = new System.Drawing.Size(103, 33);
            this.RangeLabel.TabIndex = 0;
            this.RangeLabel.Text = "量程(V)";
            this.RangeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VoltageInputSetPannel
            // 
            this.VoltageInputSetPannel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.VoltageInputSetPannel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.VoltageInputSetPannel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VoltageInputSetPannel.Controls.Add(this.tableLayoutPanel2);
            this.VoltageInputSetPannel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.VoltageInputSetPannel.Location = new System.Drawing.Point(25, 77);
            this.VoltageInputSetPannel.Name = "VoltageInputSetPannel";
            this.VoltageInputSetPannel.Size = new System.Drawing.Size(359, 176);
            this.VoltageInputSetPannel.TabIndex = 5;
            // 
            // VoltageInputlabel
            // 
            this.VoltageInputlabel.AutoSize = true;
            this.VoltageInputlabel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.VoltageInputlabel.Font = new System.Drawing.Font("宋体", 18F);
            this.VoltageInputlabel.Location = new System.Drawing.Point(31, 47);
            this.VoltageInputlabel.Name = "VoltageInputlabel";
            this.VoltageInputlabel.Size = new System.Drawing.Size(193, 30);
            this.VoltageInputlabel.TabIndex = 6;
            this.VoltageInputlabel.Text = "VoltageInput";
            // 
            // SwitchOnLabel
            // 
            this.SwitchOnLabel.Location = new System.Drawing.Point(3, 0);
            this.SwitchOnLabel.Name = "SwitchOnLabel";
            this.SwitchOnLabel.Size = new System.Drawing.Size(69, 29);
            this.SwitchOnLabel.TabIndex = 7;
            this.SwitchOnLabel.Text = "输出";
            this.SwitchOnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OutPutfifityOhm
            // 
            this.OutPutfifityOhm.Location = new System.Drawing.Point(3, 29);
            this.OutPutfifityOhm.Name = "OutPutfifityOhm";
            this.OutPutfifityOhm.Size = new System.Drawing.Size(69, 23);
            this.OutPutfifityOhm.TabIndex = 8;
            this.OutPutfifityOhm.Text = "50Ω";
            this.OutPutfifityOhm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OutputRangeLabel
            // 
            this.OutputRangeLabel.Location = new System.Drawing.Point(3, 52);
            this.OutputRangeLabel.Name = "OutputRangeLabel";
            this.OutputRangeLabel.Size = new System.Drawing.Size(82, 33);
            this.OutputRangeLabel.TabIndex = 9;
            this.OutputRangeLabel.Text = "量程(V)";
            this.OutputRangeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OutputOffsetLabel
            // 
            this.OutputOffsetLabel.Location = new System.Drawing.Point(3, 88);
            this.OutputOffsetLabel.Name = "OutputOffsetLabel";
            this.OutputOffsetLabel.Size = new System.Drawing.Size(88, 30);
            this.OutputOffsetLabel.TabIndex = 10;
            this.OutputOffsetLabel.Text = "偏置(V)";
            this.OutputOffsetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OutputAmplitudeslabel
            // 
            this.OutputAmplitudeslabel.Location = new System.Drawing.Point(3, 124);
            this.OutputAmplitudeslabel.Name = "OutputAmplitudeslabel";
            this.OutputAmplitudeslabel.Size = new System.Drawing.Size(88, 40);
            this.OutputAmplitudeslabel.TabIndex = 11;
            this.OutputAmplitudeslabel.Text = "幅度(V)";
            this.OutputAmplitudeslabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.OutputAmplitudesChoosecomboBox, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.VoltageOutputOffsettextBox, 2, 3);
            this.tableLayoutPanel3.Controls.Add(this.SwitchOnLabel, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.VoltageOutputSwitchOncheckBox, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.VoltageOutput50OhmcheckBox, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.VoltageOutputAutoRangecheckBox, 3, 2);
            this.tableLayoutPanel3.Controls.Add(this.VoltageOutputRangeValuetextBox, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.OutputAmplitudesEnablecheckBox, 3, 4);
            this.tableLayoutPanel3.Controls.Add(this.VoltageOutputAmplitudesValuetextBox, 2, 4);
            this.tableLayoutPanel3.Controls.Add(this.OutputRangeLabel, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.OutputOffsetLabel, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.OutPutfifityOhm, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.OutputAmplitudeslabel, 0, 4);
            this.tableLayoutPanel3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(461, 165);
            this.tableLayoutPanel3.TabIndex = 12;
            // 
            // OutputAmplitudesChoosecomboBox
            // 
            this.OutputAmplitudesChoosecomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OutputAmplitudesChoosecomboBox.FormattingEnabled = true;
            this.OutputAmplitudesChoosecomboBox.Items.AddRange(new object[] {
            "Vpp",
            "Vrms"});
            this.OutputAmplitudesChoosecomboBox.Location = new System.Drawing.Point(97, 127);
            this.OutputAmplitudesChoosecomboBox.Name = "OutputAmplitudesChoosecomboBox";
            this.OutputAmplitudesChoosecomboBox.Size = new System.Drawing.Size(80, 28);
            this.OutputAmplitudesChoosecomboBox.TabIndex = 22;
            this.OutputAmplitudesChoosecomboBox.SelectedIndexChanged += new System.EventHandler(this.OutputAmplitudesChoosecomboBox_SelectedIndexChanged);
            // 
            // VoltageOutputOffsettextBox
            // 
            this.VoltageOutputOffsettextBox.Location = new System.Drawing.Point(183, 91);
            this.VoltageOutputOffsettextBox.Name = "VoltageOutputOffsettextBox";
            this.VoltageOutputOffsettextBox.Size = new System.Drawing.Size(155, 30);
            this.VoltageOutputOffsettextBox.TabIndex = 16;
            this.VoltageOutputOffsettextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VoltageOutputOffsettextBox_KeyPress);
            this.VoltageOutputOffsettextBox.Leave += new System.EventHandler(this.VoltageOutputOffsettextBox_Leave);
            // 
            // VoltageOutputSwitchOncheckBox
            // 
            this.VoltageOutputSwitchOncheckBox.AutoSize = true;
            this.VoltageOutputSwitchOncheckBox.Location = new System.Drawing.Point(183, 3);
            this.VoltageOutputSwitchOncheckBox.Name = "VoltageOutputSwitchOncheckBox";
            this.VoltageOutputSwitchOncheckBox.Size = new System.Drawing.Size(18, 17);
            this.VoltageOutputSwitchOncheckBox.TabIndex = 12;
            this.VoltageOutputSwitchOncheckBox.UseVisualStyleBackColor = true;
            this.VoltageOutputSwitchOncheckBox.CheckedChanged += new System.EventHandler(this.VoltageOutputSwitchOncheckBox_CheckedChanged);
            // 
            // VoltageOutput50OhmcheckBox
            // 
            this.VoltageOutput50OhmcheckBox.AutoSize = true;
            this.VoltageOutput50OhmcheckBox.Location = new System.Drawing.Point(183, 32);
            this.VoltageOutput50OhmcheckBox.Name = "VoltageOutput50OhmcheckBox";
            this.VoltageOutput50OhmcheckBox.Size = new System.Drawing.Size(18, 17);
            this.VoltageOutput50OhmcheckBox.TabIndex = 13;
            this.VoltageOutput50OhmcheckBox.UseVisualStyleBackColor = true;
            this.VoltageOutput50OhmcheckBox.CheckedChanged += new System.EventHandler(this.VoltageOutput50OhmcheckBox_CheckedChanged_1);
            // 
            // VoltageOutputAutoRangecheckBox
            // 
            this.VoltageOutputAutoRangecheckBox.AutoSize = true;
            this.VoltageOutputAutoRangecheckBox.Location = new System.Drawing.Point(344, 55);
            this.VoltageOutputAutoRangecheckBox.Name = "VoltageOutputAutoRangecheckBox";
            this.VoltageOutputAutoRangecheckBox.Size = new System.Drawing.Size(111, 24);
            this.VoltageOutputAutoRangecheckBox.TabIndex = 14;
            this.VoltageOutputAutoRangecheckBox.Text = "自动量程";
            this.VoltageOutputAutoRangecheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.VoltageOutputAutoRangecheckBox.UseVisualStyleBackColor = true;
            this.VoltageOutputAutoRangecheckBox.CheckedChanged += new System.EventHandler(this.OutputAutoRangecheckBox_CheckedChanged);
            // 
            // VoltageOutputRangeValuetextBox
            // 
            this.VoltageOutputRangeValuetextBox.Location = new System.Drawing.Point(183, 55);
            this.VoltageOutputRangeValuetextBox.Name = "VoltageOutputRangeValuetextBox";
            this.VoltageOutputRangeValuetextBox.Size = new System.Drawing.Size(155, 30);
            this.VoltageOutputRangeValuetextBox.TabIndex = 15;
            this.VoltageOutputRangeValuetextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VoltageOutputRangeValuetextBox_KeyPress);
            this.VoltageOutputRangeValuetextBox.Leave += new System.EventHandler(this.VoltageOutputRangeValuetextBox_Leave);
            // 
            // OutputAmplitudesEnablecheckBox
            // 
            this.OutputAmplitudesEnablecheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputAmplitudesEnablecheckBox.Location = new System.Drawing.Point(344, 127);
            this.OutputAmplitudesEnablecheckBox.Name = "OutputAmplitudesEnablecheckBox";
            this.OutputAmplitudesEnablecheckBox.Size = new System.Drawing.Size(155, 41);
            this.OutputAmplitudesEnablecheckBox.TabIndex = 17;
            this.OutputAmplitudesEnablecheckBox.Text = "信号输出";
            this.OutputAmplitudesEnablecheckBox.UseVisualStyleBackColor = true;
            this.OutputAmplitudesEnablecheckBox.CheckedChanged += new System.EventHandler(this.AmplitudesOutputEnable_CheckedChanged);
            // 
            // VoltageOutputAmplitudesValuetextBox
            // 
            this.VoltageOutputAmplitudesValuetextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VoltageOutputAmplitudesValuetextBox.Location = new System.Drawing.Point(183, 127);
            this.VoltageOutputAmplitudesValuetextBox.Name = "VoltageOutputAmplitudesValuetextBox";
            this.VoltageOutputAmplitudesValuetextBox.Size = new System.Drawing.Size(155, 30);
            this.VoltageOutputAmplitudesValuetextBox.TabIndex = 16;
            this.VoltageOutputAmplitudesValuetextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VoltageOutputAmplitudesValuetextBox_KeyPress);
            this.VoltageOutputAmplitudesValuetextBox.Leave += new System.EventHandler(this.VoltageOutputAmplitudesValuetextBox_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Brown;
            this.label1.Font = new System.Drawing.Font("宋体", 18F);
            this.label1.Location = new System.Drawing.Point(414, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 30);
            this.label1.TabIndex = 13;
            this.label1.Text = "VoltageOutput";
            // 
            // VoltageOutputSetPannel
            // 
            this.VoltageOutputSetPannel.BackColor = System.Drawing.Color.Brown;
            this.VoltageOutputSetPannel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VoltageOutputSetPannel.Controls.Add(this.tableLayoutPanel3);
            this.VoltageOutputSetPannel.Location = new System.Drawing.Point(410, 76);
            this.VoltageOutputSetPannel.Name = "VoltageOutputSetPannel";
            this.VoltageOutputSetPannel.Size = new System.Drawing.Size(468, 173);
            this.VoltageOutputSetPannel.TabIndex = 14;
            // 
            // IntervalBetweenTwoMeasurelabel
            // 
            this.IntervalBetweenTwoMeasurelabel.AutoSize = true;
            this.IntervalBetweenTwoMeasurelabel.Font = new System.Drawing.Font("宋体", 12F);
            this.IntervalBetweenTwoMeasurelabel.Location = new System.Drawing.Point(21, 328);
            this.IntervalBetweenTwoMeasurelabel.Name = "IntervalBetweenTwoMeasurelabel";
            this.IntervalBetweenTwoMeasurelabel.Size = new System.Drawing.Size(129, 20);
            this.IntervalBetweenTwoMeasurelabel.TabIndex = 15;
            this.IntervalBetweenTwoMeasurelabel.Text = "测量间隔(ms)";
            // 
            // IntervalBetweenTwoMeasuretextBox
            // 
            this.IntervalBetweenTwoMeasuretextBox.Font = new System.Drawing.Font("宋体", 12F);
            this.IntervalBetweenTwoMeasuretextBox.Location = new System.Drawing.Point(156, 323);
            this.IntervalBetweenTwoMeasuretextBox.Name = "IntervalBetweenTwoMeasuretextBox";
            this.IntervalBetweenTwoMeasuretextBox.Size = new System.Drawing.Size(123, 30);
            this.IntervalBetweenTwoMeasuretextBox.TabIndex = 16;
            this.IntervalBetweenTwoMeasuretextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntervalBetweenTwoMeasuretextBox_KeyPress);
            this.IntervalBetweenTwoMeasuretextBox.Leave += new System.EventHandler(this.IntervalBetweenTwoMeasuretextBox_Leave);
            // 
            // theOscillatorsFrequencytextBox
            // 
            this.theOscillatorsFrequencytextBox.Font = new System.Drawing.Font("宋体", 12F);
            this.theOscillatorsFrequencytextBox.Location = new System.Drawing.Point(156, 351);
            this.theOscillatorsFrequencytextBox.Name = "theOscillatorsFrequencytextBox";
            this.theOscillatorsFrequencytextBox.Size = new System.Drawing.Size(123, 30);
            this.theOscillatorsFrequencytextBox.TabIndex = 18;
            this.theOscillatorsFrequencytextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.theOscillatorsFrequencytextBox_KeyPress);
            this.theOscillatorsFrequencytextBox.Leave += new System.EventHandler(this.theOscillatorsFrequencytextBox_Leave);
            // 
            // theOscillatorsFrequencylabel
            // 
            this.theOscillatorsFrequencylabel.AutoSize = true;
            this.theOscillatorsFrequencylabel.Font = new System.Drawing.Font("宋体", 12F);
            this.theOscillatorsFrequencylabel.Location = new System.Drawing.Point(21, 356);
            this.theOscillatorsFrequencylabel.Name = "theOscillatorsFrequencylabel";
            this.theOscillatorsFrequencylabel.Size = new System.Drawing.Size(129, 20);
            this.theOscillatorsFrequencylabel.TabIndex = 17;
            this.theOscillatorsFrequencylabel.Text = "频率设定(Hz)";
            // 
            // DebugtextBox
            // 
            this.DebugtextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DebugtextBox.Cursor = System.Windows.Forms.Cursors.No;
            this.DebugtextBox.Font = new System.Drawing.Font("宋体", 16F);
            this.DebugtextBox.Location = new System.Drawing.Point(328, 316);
            this.DebugtextBox.Name = "DebugtextBox";
            this.DebugtextBox.Size = new System.Drawing.Size(231, 38);
            this.DebugtextBox.TabIndex = 19;
            this.DebugtextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DebugtextBox_KeyPress);
            // 
            // DebugTextBoxLabel
            // 
            this.DebugTextBoxLabel.AutoSize = true;
            this.DebugTextBoxLabel.BackColor = System.Drawing.Color.Aquamarine;
            this.DebugTextBoxLabel.Font = new System.Drawing.Font("宋体", 16F);
            this.DebugTextBoxLabel.Location = new System.Drawing.Point(323, 292);
            this.DebugTextBoxLabel.Name = "DebugTextBoxLabel";
            this.DebugTextBoxLabel.Size = new System.Drawing.Size(147, 27);
            this.DebugTextBoxLabel.TabIndex = 20;
            this.DebugTextBoxLabel.Text = "当前项的值";
            // 
            // ZurichInstrumentsMFInstrumentnotifyIcon
            // 
            this.ZurichInstrumentsMFInstrumentnotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("ZurichInstrumentsMFInstrumentnotifyIcon.Icon")));
            this.ZurichInstrumentsMFInstrumentnotifyIcon.Text = "Zurich Instruments MF Instrument-C# Control";
            this.ZurichInstrumentsMFInstrumentnotifyIcon.Visible = true;
            // 
            // menuStripInstruments
            // 
            this.menuStripInstruments.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripInstruments.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TheMFLIInstruments});
            this.menuStripInstruments.Location = new System.Drawing.Point(0, 0);
            this.menuStripInstruments.Name = "menuStripInstruments";
            this.menuStripInstruments.Size = new System.Drawing.Size(1433, 28);
            this.menuStripInstruments.TabIndex = 21;
            this.menuStripInstruments.Text = "InstrumentsMenuStrip";
            // 
            // TheMFLIInstruments
            // 
            this.TheMFLIInstruments.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemSettingMFLI,
            this.ToolStripMenuItemResetMFLISettingToDefault,
            this.ToolStripMenuItemConnectMFLI});
            this.TheMFLIInstruments.Image = ((System.Drawing.Image)(resources.GetObject("TheMFLIInstruments.Image")));
            this.TheMFLIInstruments.Name = "TheMFLIInstruments";
            this.TheMFLIInstruments.Size = new System.Drawing.Size(95, 24);
            this.TheMFLIInstruments.Text = "仪器      ";
            this.TheMFLIInstruments.DropDownOpening += new System.EventHandler(this.TheMFLIInstruments_DropDownOpening);
            // 
            // ToolStripMenuItemSettingMFLI
            // 
            this.ToolStripMenuItemSettingMFLI.Image = global::MFLI_GUI.Properties.Resources.Settings;
            this.ToolStripMenuItemSettingMFLI.Name = "ToolStripMenuItemSettingMFLI";
            this.ToolStripMenuItemSettingMFLI.Size = new System.Drawing.Size(174, 26);
            this.ToolStripMenuItemSettingMFLI.Text = "仪器设置";
            this.ToolStripMenuItemSettingMFLI.ToolTipText = "设置仪器参数";
            this.ToolStripMenuItemSettingMFLI.Click += new System.EventHandler(this.ToolStripMenuItemSettingMFLI_Click);
            // 
            // ToolStripMenuItemResetMFLISettingToDefault
            // 
            this.ToolStripMenuItemResetMFLISettingToDefault.Image = global::MFLI_GUI.Properties.Resources.Reset;
            this.ToolStripMenuItemResetMFLISettingToDefault.Name = "ToolStripMenuItemResetMFLISettingToDefault";
            this.ToolStripMenuItemResetMFLISettingToDefault.Size = new System.Drawing.Size(174, 26);
            this.ToolStripMenuItemResetMFLISettingToDefault.Text = "重置为默认值";
            this.ToolStripMenuItemResetMFLISettingToDefault.Click += new System.EventHandler(this.ToolStripMenuItemResetMFLISettingToDefault_Click);
            // 
            // ToolStripMenuItemConnectMFLI
            // 
            this.ToolStripMenuItemConnectMFLI.Image = global::MFLI_GUI.Properties.Resources.Connect;
            this.ToolStripMenuItemConnectMFLI.Name = "ToolStripMenuItemConnectMFLI";
            this.ToolStripMenuItemConnectMFLI.Size = new System.Drawing.Size(174, 26);
            this.ToolStripMenuItemConnectMFLI.Text = "连接MFLI";
            this.ToolStripMenuItemConnectMFLI.Click += new System.EventHandler(this.ToolStripMenuItemConnectMFLI_Click);
            // 
            // SaveMeasureRealustToFile_textBox
            // 
            this.SaveMeasureRealustToFile_textBox.Font = new System.Drawing.Font("宋体", 12F);
            this.SaveMeasureRealustToFile_textBox.Location = new System.Drawing.Point(7, 30);
            this.SaveMeasureRealustToFile_textBox.Name = "SaveMeasureRealustToFile_textBox";
            this.SaveMeasureRealustToFile_textBox.Size = new System.Drawing.Size(194, 30);
            this.SaveMeasureRealustToFile_textBox.TabIndex = 22;
            this.SaveMeasureRealustToFile_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SaveMeasureRealustToFile_textBox_KeyPress);
            this.SaveMeasureRealustToFile_textBox.Leave += new System.EventHandler(this.SaveMeasureRealustToFile_textBox_Leave);
            // 
            // SaveMeasureRealustToFile_button
            // 
            this.SaveMeasureRealustToFile_button.Font = new System.Drawing.Font("宋体", 12F);
            this.SaveMeasureRealustToFile_button.Location = new System.Drawing.Point(207, 29);
            this.SaveMeasureRealustToFile_button.Name = "SaveMeasureRealustToFile_button";
            this.SaveMeasureRealustToFile_button.Size = new System.Drawing.Size(75, 31);
            this.SaveMeasureRealustToFile_button.TabIndex = 23;
            this.SaveMeasureRealustToFile_button.Text = "浏览";
            this.SaveMeasureRealustToFile_button.UseVisualStyleBackColor = true;
            this.SaveMeasureRealustToFile_button.Click += new System.EventHandler(this.SaveMeasureRealustToFile_button_Click);
            // 
            // SaveMeasureRealustToFile_label
            // 
            this.SaveMeasureRealustToFile_label.BackColor = System.Drawing.Color.CadetBlue;
            this.SaveMeasureRealustToFile_label.Font = new System.Drawing.Font("宋体", 12F);
            this.SaveMeasureRealustToFile_label.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SaveMeasureRealustToFile_label.Location = new System.Drawing.Point(3, 4);
            this.SaveMeasureRealustToFile_label.Name = "SaveMeasureRealustToFile_label";
            this.SaveMeasureRealustToFile_label.Size = new System.Drawing.Size(111, 23);
            this.SaveMeasureRealustToFile_label.TabIndex = 24;
            this.SaveMeasureRealustToFile_label.Text = "保存到文件";
            // 
            // SaveMeasureRealustToFile_checkBox
            // 
            this.SaveMeasureRealustToFile_checkBox.AutoSize = true;
            this.SaveMeasureRealustToFile_checkBox.Location = new System.Drawing.Point(121, 7);
            this.SaveMeasureRealustToFile_checkBox.Name = "SaveMeasureRealustToFile_checkBox";
            this.SaveMeasureRealustToFile_checkBox.Size = new System.Drawing.Size(18, 17);
            this.SaveMeasureRealustToFile_checkBox.TabIndex = 25;
            this.SaveMeasureRealustToFile_checkBox.UseVisualStyleBackColor = true;
            this.SaveMeasureRealustToFile_checkBox.CheckedChanged += new System.EventHandler(this.SaveMeasureRealustToFile_checkBox_CheckedChanged);
            // 
            // SaveMeasureRealustToFile_panel
            // 
            this.SaveMeasureRealustToFile_panel.Controls.Add(this.SaveMeasureRealustToFile_label);
            this.SaveMeasureRealustToFile_panel.Controls.Add(this.SaveMeasureRealustToFile_checkBox);
            this.SaveMeasureRealustToFile_panel.Controls.Add(this.SaveMeasureRealustToFile_textBox);
            this.SaveMeasureRealustToFile_panel.Controls.Add(this.SaveMeasureRealustToFile_button);
            this.SaveMeasureRealustToFile_panel.Location = new System.Drawing.Point(1046, 171);
            this.SaveMeasureRealustToFile_panel.Name = "SaveMeasureRealustToFile_panel";
            this.SaveMeasureRealustToFile_panel.Size = new System.Drawing.Size(294, 73);
            this.SaveMeasureRealustToFile_panel.TabIndex = 26;
            // 
            // TheMFLIMainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1433, 748);
            this.Controls.Add(this.SaveMeasureRealustToFile_panel);
            this.Controls.Add(this.DebugTextBoxLabel);
            this.Controls.Add(this.DebugtextBox);
            this.Controls.Add(this.theOscillatorsFrequencytextBox);
            this.Controls.Add(this.theOscillatorsFrequencylabel);
            this.Controls.Add(this.IntervalBetweenTwoMeasuretextBox);
            this.Controls.Add(this.IntervalBetweenTwoMeasurelabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VoltageInputlabel);
            this.Controls.Add(this.StartMeasure);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ResultOutputTable);
            this.Controls.Add(this.VoltageOutputSetPannel);
            this.Controls.Add(this.VoltageInputSetPannel);
            this.Controls.Add(this.menuStripInstruments);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripInstruments;
            this.MaximizeBox = false;
            this.Name = "TheMFLIMainWindow";
            this.Text = "Zurich Instruments MF Instrument";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TheMFLIMainWindow_Closed);
            this.Load += new System.EventHandler(this.TheMFLIMainWindow_Load);
            this.ResultOutputTable.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.VoltageInputSetPannel.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.VoltageOutputSetPannel.ResumeLayout(false);
            this.menuStripInstruments.ResumeLayout(false);
            this.menuStripInstruments.PerformLayout();
            this.SaveMeasureRealustToFile_panel.ResumeLayout(false);
            this.SaveMeasureRealustToFile_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBoxShow;
        private System.Windows.Forms.TableLayoutPanel ResultOutputTable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button StartMeasure;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label RangeLabel;
        private System.Windows.Forms.Label ACCouplingLabel;
        private System.Windows.Forms.Label ScalingLabel;
        private System.Windows.Forms.Label FloatLabel;
        private System.Windows.Forms.Label fifityOhmLabel;
        private System.Windows.Forms.TextBox VoltageInputRangetextBox;
        private System.Windows.Forms.TextBox VoltageInputScalingtextBox;
        private System.Windows.Forms.CheckBox VoltageInputAutoRangecheckBox;
        private System.Windows.Forms.CheckBox VoltageInputACCouplingcheckBox;
        private System.Windows.Forms.CheckBox VoltageInputfiftyOhmcheckBox;
        private System.Windows.Forms.CheckBox VoltageInputFloatcheckBox;
        private System.Windows.Forms.Panel VoltageInputSetPannel;
        private System.Windows.Forms.Label VoltageInputlabel;
        private System.Windows.Forms.Label SwitchOnLabel;
        private System.Windows.Forms.Label OutPutfifityOhm;
        private System.Windows.Forms.Label OutputRangeLabel;
        private System.Windows.Forms.Label OutputOffsetLabel;
        private System.Windows.Forms.Label OutputAmplitudeslabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox VoltageOutputAmplitudesValuetextBox;
        private System.Windows.Forms.TextBox VoltageOutputOffsettextBox;
        private System.Windows.Forms.CheckBox VoltageOutputSwitchOncheckBox;
        private System.Windows.Forms.CheckBox VoltageOutput50OhmcheckBox;
        private System.Windows.Forms.CheckBox VoltageOutputAutoRangecheckBox;
        private System.Windows.Forms.TextBox VoltageOutputRangeValuetextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel VoltageOutputSetPannel;
        private System.Windows.Forms.Label IntervalBetweenTwoMeasurelabel;
        private System.Windows.Forms.TextBox IntervalBetweenTwoMeasuretextBox;
        private System.Windows.Forms.TextBox theOscillatorsFrequencytextBox;
        private System.Windows.Forms.Label theOscillatorsFrequencylabel;
        private System.Windows.Forms.TextBox DebugtextBox;
        private System.Windows.Forms.Label DebugTextBoxLabel;
        private System.Windows.Forms.CheckBox OutputAmplitudesEnablecheckBox;
        private System.Windows.Forms.NotifyIcon ZurichInstrumentsMFInstrumentnotifyIcon;
        private System.Windows.Forms.MenuStrip menuStripInstruments;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemConnectMFLI;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSettingMFLI;
        private System.Windows.Forms.ComboBox OutputAmplitudesChoosecomboBox;
        public System.Windows.Forms.ToolStripMenuItem TheMFLIInstruments;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemResetMFLISettingToDefault;
        private System.Windows.Forms.TextBox SaveMeasureRealustToFile_textBox;
        private System.Windows.Forms.Button SaveMeasureRealustToFile_button;
        private System.Windows.Forms.Label SaveMeasureRealustToFile_label;
        private System.Windows.Forms.CheckBox SaveMeasureRealustToFile_checkBox;
        private System.Windows.Forms.Panel SaveMeasureRealustToFile_panel;
    }
}

