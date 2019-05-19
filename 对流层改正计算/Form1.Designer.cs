namespace 对流层改正计算
{
    partial class f
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
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.openfile = new System.Windows.Forms.ToolStripMenuItem();
            this.calbtnn = new System.Windows.Forms.ToolStripMenuItem();
            this.rxtx = new System.Windows.Forms.TextBox();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openfile,
            this.calbtnn});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(668, 28);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // openfile
            // 
            this.openfile.Name = "openfile";
            this.openfile.Size = new System.Drawing.Size(51, 24);
            this.openfile.Text = "打开";
            this.openfile.Click += new System.EventHandler(this.FileBtn_Click);
            // 
            // calbtnn
            // 
            this.calbtnn.Name = "calbtnn";
            this.calbtnn.Size = new System.Drawing.Size(51, 24);
            this.calbtnn.Text = "计算";
            this.calbtnn.Click += new System.EventHandler(this.calbtnn_Click);
            // 
            // rxtx
            // 
            this.rxtx.Location = new System.Drawing.Point(12, 31);
            this.rxtx.Multiline = true;
            this.rxtx.Name = "rxtx";
            this.rxtx.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.rxtx.Size = new System.Drawing.Size(656, 586);
            this.rxtx.TabIndex = 1;
            // 
            // f
            // 
            this.ClientSize = new System.Drawing.Size(668, 614);
            this.Controls.Add(this.rxtx);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip2;
            this.Name = "f";
            this.Text = "对流层改正计算";
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileBtn;
        private System.Windows.Forms.ToolStripMenuItem CalBtn;
        private System.Windows.Forms.TextBox Rtxt;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem openfile;
        private System.Windows.Forms.ToolStripMenuItem calbtnn;
        private System.Windows.Forms.TextBox rxtx;
    }
}

