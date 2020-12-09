
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
            this.movementTimer = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.txtMouse = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.timerMouseEvent = new System.Windows.Forms.Timer(this.components);
            this.btnPictrue = new System.Windows.Forms.Button();
            this.txtWindowSpace = new System.Windows.Forms.TextBox();
            this.txtFormSpace = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(50, 29);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 66);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "查找窗口";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnMouse
            // 
            this.btnMouse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMouse.BackgroundImage")));
            this.btnMouse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMouse.FlatAppearance.BorderSize = 0;
            this.btnMouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMouse.Location = new System.Drawing.Point(50, 112);
            this.btnMouse.Name = "btnMouse";
            this.btnMouse.Size = new System.Drawing.Size(75, 60);
            this.btnMouse.TabIndex = 1;
            this.btnMouse.Text = "鼠标位置";
            this.btnMouse.UseVisualStyleBackColor = true;
            this.btnMouse.Click += new System.EventHandler(this.btnMouse_Click);
            // 
            // movementTimer
            // 
            this.movementTimer.Tick += new System.EventHandler(this.movementTimer_Tick);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(50, 279);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 56);
            this.button1.TabIndex = 2;
            this.button1.Text = "查看鼠标运行的轨迹";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtMouse
            // 
            this.txtMouse.Location = new System.Drawing.Point(353, 113);
            this.txtMouse.Name = "txtMouse";
            this.txtMouse.Size = new System.Drawing.Size(246, 23);
            this.txtMouse.TabIndex = 3;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(353, 53);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(123, 21);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "查看鼠标运行轨迹";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(353, 276);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "安装钩子";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // timerMouseEvent
            // 
            this.timerMouseEvent.Enabled = true;
            this.timerMouseEvent.Interval = 2000;
            this.timerMouseEvent.Tick += new System.EventHandler(this.timerMouseEvent_Tick);
            // 
            // btnPictrue
            // 
            this.btnPictrue.FlatAppearance.BorderSize = 0;
            this.btnPictrue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPictrue.Location = new System.Drawing.Point(50, 193);
            this.btnPictrue.Name = "btnPictrue";
            this.btnPictrue.Size = new System.Drawing.Size(75, 59);
            this.btnPictrue.TabIndex = 6;
            this.btnPictrue.Text = "获取窗口图片";
            this.btnPictrue.UseVisualStyleBackColor = true;
            this.btnPictrue.Click += new System.EventHandler(this.btnPictrue_Click);
            // 
            // txtWindowSpace
            // 
            this.txtWindowSpace.Location = new System.Drawing.Point(353, 169);
            this.txtWindowSpace.Name = "txtWindowSpace";
            this.txtWindowSpace.Size = new System.Drawing.Size(246, 23);
            this.txtWindowSpace.TabIndex = 7;
            // 
            // txtFormSpace
            // 
            this.txtFormSpace.Location = new System.Drawing.Point(353, 222);
            this.txtFormSpace.Name = "txtFormSpace";
            this.txtFormSpace.Size = new System.Drawing.Size(246, 23);
            this.txtFormSpace.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(353, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "鼠标相对于屏幕左上角的坐标:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(353, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "鼠标相对于窗体左上角的坐标:";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(722, 373);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFormSpace);
            this.Controls.Add(this.txtWindowSpace);
            this.Controls.Add(this.btnPictrue);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.txtMouse);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnMouse);
            this.Controls.Add(this.btnSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "mainForm";
            this.Text = "无限樱饼";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.SizeChanged += new System.EventHandler(this.mainForm_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mainForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnMouse;
        private System.Windows.Forms.Timer movementTimer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtMouse;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timerMouseEvent;
        private System.Windows.Forms.Button btnPictrue;
        private System.Windows.Forms.TextBox txtWindowSpace;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFormSpace;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

