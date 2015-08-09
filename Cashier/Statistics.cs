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
            comboBox2.SelectedIndex = 0;
            DataTable dt = AccessHelper.ExecuteDataTable(AccessHelper.conn, "select * from Business", null);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "商家名称";
            comboBox1.ValueMember = "UID";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            //comboBox1.SelectedValue.ToString();
            sSql = "select * from Bill where goodsID in (select UID from goods where Business_ID='" + comboBox1.SelectedValue.ToString() + "')";
            DataTable dt = AccessHelper.ExecuteDataTable(AccessHelper.conn, sSql, null);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            decimal cardPrice = 0;
            decimal moneyPrice = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                try
                {
                    cardPrice += Convert.ToDecimal(row.Cells[6].Value.ToString());
                    moneyPrice += Convert.ToDecimal(row.Cells[5].Value.ToString());
                }
                catch (Exception)
                {
                    return;
                }
                label2.Text = cardPrice.ToString();
                label6.Text = moneyPrice.ToString();
            }
        }
    }
}
