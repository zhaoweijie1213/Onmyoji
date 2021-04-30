
namespace WindowsFormsApp
{
    partial class mainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnMouse = new System.Windows.Forms.Button();
            this.txtMouse = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.timerMouseEvent = new System.Windows.Forms.Timer(this.components);
            this.btnPictrue = new System.Windows.Forms.Button();
            this.txtWindowSpace = new System.Windows.Forms.TextBox();
            this.txtFormSpace = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.lblHelp = new System.Windows.Forms.Label();
            this.GameTypeGgroup = new System.Windows.Forms.GroupBox();
            this.YeyuanhuoRadioBtn = new System.Windows.Forms.RadioButton();
            this.YuhunRadioBtn = new System.Windows.Forms.RadioButton();
            this.TimeGroupRadioBtn = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.timeRadioBtn30 = new System.Windows.Forms.RadioButton();
            this.timeRadioBtn22 = new System.Windows.Forms.RadioButton();
            this.timeRadioBtn18 = new System.Windows.Forms.RadioButton();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.GameTypeGgroup.SuspendLayout();
            this.TimeGroupRadioBtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Location = new System.Drawing.Point(91, 74);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(99, 35);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "查找窗口";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnMouse
            // 
            this.btnMouse.BackColor = System.Drawing.Color.Transparent;
            this.btnMouse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMouse.BackgroundImage")));
            this.btnMouse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMouse.FlatAppearance.BorderSize = 0;
            this.btnMouse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMouse.Location = new System.Drawing.Point(91, 157);
            this.btnMouse.Name = "btnMouse";
            this.btnMouse.Size = new System.Drawing.Size(99, 35);
            this.btnMouse.TabIndex = 1;
            this.btnMouse.Text = "鼠标位置";
            this.btnMouse.UseVisualStyleBackColor = false;
            this.btnMouse.Click += new System.EventHandler(this.btnMouse_Click);
            // 
            // txtMouse
            // 
            this.txtMouse.Location = new System.Drawing.Point(340, 193);
            this.txtMouse.Name = "txtMouse";
            this.txtMouse.Size = new System.Drawing.Size(41, 23);
            this.txtMouse.TabIndex = 3;
            this.txtMouse.TextChanged += new System.EventHandler(this.txtMouse_TextChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(91, 301);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 34);
            this.button2.TabIndex = 5;
            this.button2.Text = "安装钩子";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // timerMouseEvent
            // 
            this.timerMouseEvent.Enabled = true;
            this.timerMouseEvent.Interval = 1000;
            this.timerMouseEvent.Tick += new System.EventHandler(this.timerMouseEvent_Tick);
            // 
            // btnPictrue
            // 
            this.btnPictrue.BackColor = System.Drawing.Color.Transparent;
            this.btnPictrue.FlatAppearance.BorderSize = 0;
            this.btnPictrue.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Snow;
            this.btnPictrue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MintCream;
            this.btnPictrue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPictrue.Location = new System.Drawing.Point(91, 238);
            this.btnPictrue.Name = "btnPictrue";
            this.btnPictrue.Size = new System.Drawing.Size(99, 35);
            this.btnPictrue.TabIndex = 6;
            this.btnPictrue.Text = "获取窗口图片";
            this.btnPictrue.UseVisualStyleBackColor = false;
            this.btnPictrue.Click += new System.EventHandler(this.btnPictrue_Click);
            // 
            // txtWindowSpace
            // 
            this.txtWindowSpace.Location = new System.Drawing.Point(444, 193);
            this.txtWindowSpace.Name = "txtWindowSpace";
            this.txtWindowSpace.Size = new System.Drawing.Size(41, 23);
            this.txtWindowSpace.TabIndex = 7;
            // 
            // txtFormSpace
            // 
            this.txtFormSpace.Location = new System.Drawing.Point(544, 193);
            this.txtFormSpace.Name = "txtFormSpace";
            this.txtFormSpace.Size = new System.Drawing.Size(41, 23);
            this.txtFormSpace.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(391, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "总次数:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(491, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "总耗时:";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "无限樱饼";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // lblHelp
            // 
            this.lblHelp.AutoSize = true;
            this.lblHelp.BackColor = System.Drawing.Color.Transparent;
            this.lblHelp.Location = new System.Drawing.Point(291, 30);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(99, 17);
            this.lblHelp.TabIndex = 11;
            this.lblHelp.Text = "*F1开始，F4结束";
            // 
            // GameTypeGgroup
            // 
            this.GameTypeGgroup.BackColor = System.Drawing.Color.Transparent;
            this.GameTypeGgroup.Controls.Add(this.YeyuanhuoRadioBtn);
            this.GameTypeGgroup.Controls.Add(this.YuhunRadioBtn);
            this.GameTypeGgroup.Location = new System.Drawing.Point(291, 50);
            this.GameTypeGgroup.Name = "GameTypeGgroup";
            this.GameTypeGgroup.Size = new System.Drawing.Size(294, 46);
            this.GameTypeGgroup.TabIndex = 19;
            this.GameTypeGgroup.TabStop = false;
            this.GameTypeGgroup.Text = "类型";
            // 
            // YeyuanhuoRadioBtn
            // 
            this.YeyuanhuoRadioBtn.AutoSize = true;
            this.YeyuanhuoRadioBtn.Location = new System.Drawing.Point(77, 19);
            this.YeyuanhuoRadioBtn.Name = "YeyuanhuoRadioBtn";
            this.YeyuanhuoRadioBtn.Size = new System.Drawing.Size(62, 21);
            this.YeyuanhuoRadioBtn.TabIndex = 1;
            this.YeyuanhuoRadioBtn.Text = "业原火";
            this.YeyuanhuoRadioBtn.UseVisualStyleBackColor = true;
            this.YeyuanhuoRadioBtn.CheckedChanged += new System.EventHandler(this.GameType_RadioChanged);
            // 
            // YuhunRadioBtn
            // 
            this.YuhunRadioBtn.AutoSize = true;
            this.YuhunRadioBtn.Checked = true;
            this.YuhunRadioBtn.Location = new System.Drawing.Point(21, 19);
            this.YuhunRadioBtn.Name = "YuhunRadioBtn";
            this.YuhunRadioBtn.Size = new System.Drawing.Size(50, 21);
            this.YuhunRadioBtn.TabIndex = 0;
            this.YuhunRadioBtn.TabStop = true;
            this.YuhunRadioBtn.Text = "御魂";
            this.YuhunRadioBtn.UseVisualStyleBackColor = true;
            this.YuhunRadioBtn.CheckedChanged += new System.EventHandler(this.GameType_RadioChanged);
            // 
            // TimeGroupRadioBtn
            // 
            this.TimeGroupRadioBtn.BackColor = System.Drawing.Color.Transparent;
            this.TimeGroupRadioBtn.Controls.Add(this.label4);
            this.TimeGroupRadioBtn.Controls.Add(this.timeRadioBtn30);
            this.TimeGroupRadioBtn.Controls.Add(this.timeRadioBtn22);
            this.TimeGroupRadioBtn.Controls.Add(this.timeRadioBtn18);
            this.TimeGroupRadioBtn.Controls.Add(this.txtMin);
            this.TimeGroupRadioBtn.Location = new System.Drawing.Point(291, 112);
            this.TimeGroupRadioBtn.Name = "TimeGroupRadioBtn";
            this.TimeGroupRadioBtn.Size = new System.Drawing.Size(294, 52);
            this.TimeGroupRadioBtn.TabIndex = 20;
            this.TimeGroupRadioBtn.TabStop = false;
            this.TimeGroupRadioBtn.Text = "时间(s)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(164, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 23;
            this.label4.Text = "自定义:";
            // 
            // timeRadioBtn30
            // 
            this.timeRadioBtn30.AutoSize = true;
            this.timeRadioBtn30.Location = new System.Drawing.Point(123, 20);
            this.timeRadioBtn30.Name = "timeRadioBtn30";
            this.timeRadioBtn30.Size = new System.Drawing.Size(40, 21);
            this.timeRadioBtn30.TabIndex = 22;
            this.timeRadioBtn30.Text = "30";
            this.timeRadioBtn30.UseVisualStyleBackColor = true;
            this.timeRadioBtn30.CheckedChanged += new System.EventHandler(this.time_RadioChanged);
            // 
            // timeRadioBtn22
            // 
            this.timeRadioBtn22.AutoSize = true;
            this.timeRadioBtn22.Checked = true;
            this.timeRadioBtn22.Location = new System.Drawing.Point(77, 20);
            this.timeRadioBtn22.Name = "timeRadioBtn22";
            this.timeRadioBtn22.Size = new System.Drawing.Size(40, 21);
            this.timeRadioBtn22.TabIndex = 21;
            this.timeRadioBtn22.TabStop = true;
            this.timeRadioBtn22.Text = "22";
            this.timeRadioBtn22.UseVisualStyleBackColor = true;
            this.timeRadioBtn22.CheckedChanged += new System.EventHandler(this.time_RadioChanged);
            // 
            // timeRadioBtn18
            // 
            this.timeRadioBtn18.AutoSize = true;
            this.timeRadioBtn18.Location = new System.Drawing.Point(31, 20);
            this.timeRadioBtn18.Name = "timeRadioBtn18";
            this.timeRadioBtn18.Size = new System.Drawing.Size(40, 21);
            this.timeRadioBtn18.TabIndex = 20;
            this.timeRadioBtn18.Text = "18";
            this.timeRadioBtn18.UseVisualStyleBackColor = true;
            this.timeRadioBtn18.CheckedChanged += new System.EventHandler(this.time_RadioChanged);
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(217, 19);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(30, 23);
            this.txtMin.TabIndex = 19;
            this.txtMin.TextChanged += new System.EventHandler(this.txtMin_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(291, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "单次(s):";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(732, 397);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TimeGroupRadioBtn);
            this.Controls.Add(this.GameTypeGgroup);
            this.Controls.Add(this.lblHelp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFormSpace);
            this.Controls.Add(this.txtWindowSpace);
            this.Controls.Add(this.btnPictrue);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtMouse);
            this.Controls.Add(this.btnMouse);
            this.Controls.Add(this.btnSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "mainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.SizeChanged += new System.EventHandler(this.mainForm_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mainForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mainForm_KeyPress);
            this.GameTypeGgroup.ResumeLayout(false);
            this.GameTypeGgroup.PerformLayout();
            this.TimeGroupRadioBtn.ResumeLayout(false);
            this.TimeGroupRadioBtn.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnMouse;
        private System.Windows.Forms.TextBox txtMouse;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timerMouseEvent;
        private System.Windows.Forms.Button btnPictrue;
        private System.Windows.Forms.TextBox txtWindowSpace;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFormSpace;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.GroupBox GameTypeGgroup;
        private System.Windows.Forms.RadioButton YeyuanhuoRadioBtn;
        private System.Windows.Forms.RadioButton YuhunRadioBtn;
        private System.Windows.Forms.GroupBox TimeGroupRadioBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton timeRadioBtn30;
        private System.Windows.Forms.RadioButton timeRadioBtn22;
        private System.Windows.Forms.RadioButton timeRadioBtn18;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.Label label3;
    }
}

