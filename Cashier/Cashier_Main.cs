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
            Commodity commodity_From = new Commodity();
            commodity_From.ShowDialog();
            commodity_From.Close();
            commodity_From.Dispose();
        }
    }
}
