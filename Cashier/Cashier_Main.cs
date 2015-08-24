using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cashier
{

    public partial class Cashier_Main : Form
    {
        public static bool itis = false;
        public static decimal moneySum = 0;
        public Cashier_Main()
        {
            InitializeComponent();
        }

        private void Cashier_Main_Load(object sender, EventArgs e)
        {

        }

        private void 商品录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessHelper.ExecuteDataTable(AccessHelper.conn, "select * from Business", null).Rows.Count != 0)
            {
                Commodity commodity_From = new Commodity();
                commodity_From.ShowDialog();
                commodity_From.Close();
                commodity_From.Dispose();
            }
            else
            {
                MessageBox.Show("先登记商家！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void 登记商家ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            RegisterBusiness registerBusiness = new RegisterBusiness();
            registerBusiness.ShowDialog();
            registerBusiness.Close();
            registerBusiness.Dispose();

        }

        private void 消费结算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pay payFrom = new Pay();
            payFrom.ShowDialog();
            payFrom.Close();
            payFrom.Dispose();
        }

        private void 账务统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bill billFrom = new Bill();
            billFrom.ShowDialog();
            billFrom.Close();
            billFrom.Dispose();
        }

        private void 统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Statistics statisticsFrom = new Statistics();
            statisticsFrom.ShowDialog();
            statisticsFrom.Close();
            statisticsFrom.Dispose();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
            aboutForm.Close();
            aboutForm.Dispose();
        }

        private void 数据备份ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (File.Exists(AccessHelper.app_path + "\\db.mdb"))
            {


                saveFileDialog1.FileName = "db.mdb";
                saveFileDialog1.Filter = "(*.mdb)|*.mdb";
                saveFileDialog1.DefaultExt = "*.mdb";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    //string newDBName = Guid.NewGuid() + ".mdb";
                    //File.Copy(AccessHelper.app_path + "\\db.mdb", AccessHelper.app_path + "\\" + newDBName);

                    //if (File.Exists(AccessHelper.app_path + "\\" + newDBName))
                    //{

                    // File.Copy(AccessHelper.app_path + "\\" + newDBName, saveFileDialog1.FileName, true);
                    //}
                    if (File.Exists(AccessHelper.app_path + "\\db.mdb"))
                    {
                        File.Copy(AccessHelper.app_path + "\\db.mdb", saveFileDialog1.FileName, true);
                    }

                    MessageBox.Show("备份数据成功！  \n  保存位置是: \n  " + saveFileDialog1.FileName);
                }





            }
        }

        private void 数据还原ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "(*.mdb)|*.mdb";
            openFileDialog1.DefaultExt = "*.mdb";
            openFileDialog1.ShowDialog();

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (File.Exists(openFileDialog1.FileName))
            {
                if (openFileDialog1.FileName.ToString().Contains("db.mdb"))
                {

                    File.Copy(openFileDialog1.FileName, AccessHelper.app_path + "\\db.mdb", true);
                    MessageBox.Show("数据还原成功！ ");
                    return;
                }
            }
            MessageBox.Show("数据还原失败！请检查文件是否为db.mdb文件 ");
        }


    }
}
