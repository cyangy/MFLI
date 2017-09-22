
using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using zhinst;
namespace MFLI_GUI
{
    partial class MFLISetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()//ref String dev
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MFLISetting));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.MFLISettingDevicenameLabel = new System.Windows.Forms.Label();
            this.MFLISettingDevicenametextBox = new System.Windows.Forms.TextBox();
            this.MFLISettingbuttonOK = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 129F));
            this.tableLayoutPanel1.Controls.Add(this.MFLISettingDevicenameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.MFLISettingDevicenametextBox, 1, 0);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("宋体", 12F);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(34, 84);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(204, 35);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // MFLISettingDevicenameLabel
            // 
            this.MFLISettingDevicenameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MFLISettingDevicenameLabel.AutoSize = true;
            this.MFLISettingDevicenameLabel.Location = new System.Drawing.Point(3, 0);
            this.MFLISettingDevicenameLabel.Name = "MFLISettingDevicenameLabel";
            this.MFLISettingDevicenameLabel.Size = new System.Drawing.Size(69, 36);
            this.MFLISettingDevicenameLabel.TabIndex = 0;
            this.MFLISettingDevicenameLabel.Text = "设备名";
            this.MFLISettingDevicenameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MFLISettingDevicenametextBox
            // 
            this.MFLISettingDevicenametextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MFLISettingDevicenametextBox.Location = new System.Drawing.Point(78, 3);
            this.MFLISettingDevicenametextBox.Name = "MFLISettingDevicenametextBox";
            this.MFLISettingDevicenametextBox.Size = new System.Drawing.Size(123, 30);
            this.MFLISettingDevicenametextBox.TabIndex = 1;
            this.MFLISettingDevicenametextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MFLISettingDevicenametextBox_KeyPress);
            this.MFLISettingDevicenametextBox.Leave += new System.EventHandler(this.MFLISettingDevicenametextBox_Leave);
            // 
            // MFLISettingbuttonOK
            // 
            this.MFLISettingbuttonOK.Font = new System.Drawing.Font("宋体", 12F);
            this.MFLISettingbuttonOK.Location = new System.Drawing.Point(85, 145);
            this.MFLISettingbuttonOK.Name = "MFLISettingbuttonOK";
            this.MFLISettingbuttonOK.Size = new System.Drawing.Size(75, 30);
            this.MFLISettingbuttonOK.TabIndex = 1;
            this.MFLISettingbuttonOK.Text = "确认";
            this.MFLISettingbuttonOK.UseVisualStyleBackColor = true;
            this.MFLISettingbuttonOK.Click += new System.EventHandler(this.MFLISettingbuttonOK_Click);
            // 
            // MFLISetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.MFLISettingbuttonOK);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MFLISetting";
            this.Text = "MFLI设置";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox MFLISettingDevicenametextBox;
        private System.Windows.Forms.Label MFLISettingDevicenameLabel;
        private System.Windows.Forms.Button MFLISettingbuttonOK;
    }
}