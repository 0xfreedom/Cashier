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
    public partial class Commodity : Form
    {
        public Commodity()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string comID = textBox1.Text.Trim();
            string comName = textBox2.Text.Trim();
            decimal comPrice = Convert.ToDecimal(textBox3.Text.Trim());
            string comSeller = "";
        }

        private void Commodity_Load(object sender, EventArgs e)
        {

        }
    }
}
