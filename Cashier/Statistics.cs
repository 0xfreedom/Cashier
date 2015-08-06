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
    public partial class Statistics : Form
    {
        string sSql = "";
        public Statistics()
        {
            InitializeComponent();
        }

        private void Statistics_Load(object sender, EventArgs e)
        {
            DataTable dt = AccessHelper.ExecuteDataTable(AccessHelper.conn, "select * from Business", null);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "商家名称";
            comboBox1.ValueMember = "UID";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //comboBox1.SelectedValue.ToString();
            sSql = "select * from Bill where goodsID in (select UID from goods where Business_ID='" + comboBox1.SelectedValue.ToString() + "')";
            DataTable dt = AccessHelper.ExecuteDataTable(AccessHelper.conn, sSql, null);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBox2.SelectedItem.ToString());
            sSql = "select * from Bill where 支付方式='" + comboBox2.SelectedItem.ToString() + "'";
            DataTable dt = AccessHelper.ExecuteDataTable(AccessHelper.conn, sSql, null);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sSql = "select * from Bill where goodsID in (select UID from goods where Business_ID='" + comboBox1.SelectedValue.ToString() + "') and 支付方式='" + comboBox2.SelectedItem.ToString() + "'";
            DataTable dt = AccessHelper.ExecuteDataTable(AccessHelper.conn, sSql, null);
            dataGridView1.DataSource = dt;
        }
    }
}
