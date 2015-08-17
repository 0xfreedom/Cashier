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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cashier_Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.登记商家ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.商品录入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.消费结算ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.账务统计ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.统计ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据备份ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据还原ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.登记商家ToolStripMenuItem,
            this.商品录入ToolStripMenuItem,
            this.消费结算ToolStripMenuItem,
            this.账务统计ToolStripMenuItem,
            this.统计ToolStripMenuItem,
            this.数据管理ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 登记商家ToolStripMenuItem
            // 
            this.登记商家ToolStripMenuItem.Name = "登记商家ToolStripMenuItem";
            this.登记商家ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.登记商家ToolStripMenuItem.Text = "登记商家";
            this.登记商家ToolStripMenuItem.Click += new System.EventHandler(this.登记商家ToolStripMenuItem_Click);
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
            this.消费结算ToolStripMenuItem.Click += new System.EventHandler(this.消费结算ToolStripMenuItem_Click);
            // 
            // 账务统计ToolStripMenuItem
            // 
            this.账务统计ToolStripMenuItem.Name = "账务统计ToolStripMenuItem";
            this.账务统计ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.账务统计ToolStripMenuItem.Text = "流水记录";
            this.账务统计ToolStripMenuItem.Click += new System.EventHandler(this.账务统计ToolStripMenuItem_Click);
            // 
            // 统计ToolStripMenuItem
            // 
            this.统计ToolStripMenuItem.Name = "统计ToolStripMenuItem";
            this.统计ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.统计ToolStripMenuItem.Text = "统计";
            this.统计ToolStripMenuItem.Click += new System.EventHandler(this.统计ToolStripMenuItem_Click);
            // 
            // 数据管理ToolStripMenuItem
            // 
            this.数据管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据备份ToolStripMenuItem,
            this.数据还原ToolStripMenuItem});
            this.数据管理ToolStripMenuItem.Name = "数据管理ToolStripMenuItem";
            this.数据管理ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.数据管理ToolStripMenuItem.Text = "数据管理";
            // 
            // 数据备份ToolStripMenuItem
            // 
            this.数据备份ToolStripMenuItem.Name = "数据备份ToolStripMenuItem";
            this.数据备份ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.数据备份ToolStripMenuItem.Text = "数据备份";
            this.数据备份ToolStripMenuItem.Click += new System.EventHandler(this.数据备份ToolStripMenuItem_Click);
            // 
            // 数据还原ToolStripMenuItem
            // 
            this.数据还原ToolStripMenuItem.Name = "数据还原ToolStripMenuItem";
            this.数据还原ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.数据还原ToolStripMenuItem.Text = "数据还原";
            this.数据还原ToolStripMenuItem.Click += new System.EventHandler(this.数据还原ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Cashier_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Cashier_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "大为结算";
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
        private System.Windows.Forms.ToolStripMenuItem 登记商家ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据备份ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据还原ToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

