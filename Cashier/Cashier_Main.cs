using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cashier
{
    public partial class Cashier_Main : Form
    {
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
    }
}
