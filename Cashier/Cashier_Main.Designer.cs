namespace Cashier
{
    partial class Cashier_Main
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.商品录入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.消费结算ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.账务统计ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.统计ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.商品录入ToolStripMenuItem,
            this.消费结算ToolStripMenuItem,
            this.账务统计ToolStripMenuItem,
            this.统计ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 商品录入ToolStripMenuItem
            // 
            this.商品录入ToolStripMenuItem.Name = "商品录入ToolStripMenuItem";
            this.商品录入ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.商品录入ToolStripMenuItem.Text = "商品录入";
            this.商品录入ToolStripMenuItem.Click += new System.EventHandler(this.商品录入ToolStripMenuItem_Click);
            // 
            // 消费结算ToolStripMenuItem
            // 
            this.消费结算ToolStripMenuItem.Name = "消费结算ToolStripMenuItem";
            this.消费结算ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.消费结算ToolStripMenuItem.Text = "消费结算";
            // 
            // 账务统计ToolStripMenuItem
            // 
            this.账务统计ToolStripMenuItem.Name = "账务统计ToolStripMenuItem";
            this.账务统计ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.账务统计ToolStripMenuItem.Text = "流水记录";
            // 
            // 统计ToolStripMenuItem
            // 
            this.统计ToolStripMenuItem.Name = "统计ToolStripMenuItem";
            this.统计ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.统计ToolStripMenuItem.Text = "统计";
            // 
            // Cashier_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Cashier_Main";
            this.Text = "Cashier";
            this.Load += new System.EventHandler(this.Cashier_Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 消费结算ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 账务统计ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 统计ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 商品录入ToolStripMenuItem;
    }
}

