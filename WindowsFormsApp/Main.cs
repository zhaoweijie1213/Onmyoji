using OnmyojiJob.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class ToolsForm : Form
    {
        public ToolsForm()
        {
            InitializeComponent();
        }

        private void ToolsForm_Load(object sender, EventArgs e)
        {
            IntPtr awin = MouseHookHelper.FindWindow("WeChatMainWndForPC", "微信");
            if (awin == IntPtr.Zero)
            {
                MessageBox.Show("没有找到窗体");
                return;
            }
        }

    }
}
