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
        /// <summary>
        /// 按照商家查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = false;
            //comboBox1.SelectedValue.ToString();
            sSql = "select 商品编号,商品名称,SUM(商品数量) as 商品数量,SUM(金额) as 金额 from Bill where goodsID in (select UID from Goods where Business_ID='" + comboBox1.SelectedValue.ToString() + "') group by 商品编号,商品名称 order by 商品编号";
            DataTable dt = AccessHelper.ExecuteDataTable(AccessHelper.conn, sSql, null);
            dataGridView1.DataSource = dt;
            //dataGridView1.Columns[0].Visible = false;
            //dataGridView1.Columns[4].Visible = false;
            //dataGridView1.Columns[5].Visible = false;
            //dataGridView1.Columns[6].Visible = false;
            //dataGridView1.Columns[1].Visible = false;
            //dataGridView1.Columns[9].Visible = false;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

        }
        /// <summary>
        /// 按照支付方式查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = true;
            //MessageBox.Show(comboBox2.SelectedIndex.ToString());
            if (comboBox2.SelectedIndex == 0)
            {
                sSql = "select Total_ID,现金结算 from Bill";
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                sSql = "select Total_ID,刷卡结算 from Bill";
            }
            DataTable dt = AccessHelper.ExecuteDataTable(AccessHelper.conn, sSql, null);
            dataGridView1.DataSource = dt;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            sSql = "select * from Bill where goodsID in (select UID from goods where Business_ID='" + comboBox1.SelectedValue.ToString() + "') and 支付方式='" + comboBox2.SelectedItem.ToString() + "'";
            DataTable dt = AccessHelper.ExecuteDataTable(AccessHelper.conn, sSql, null);
            dataGridView1.DataSource = dt;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            decimal Price = 0;

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                try
                {
                    Price += Convert.ToDecimal(row.Cells[3].Value.ToString());

                }
                catch (Exception)
                {
                    return;
                }
                label8.Text = Price.ToString();

            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            decimal Price = 0;

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                try
                {
                    Price += Convert.ToDecimal(row.Cells[0].Value.ToString());
                }
                catch (Exception)
                {
                    return;
                }
                label8.Text = Price.ToString();

            }
        }
    }
}
