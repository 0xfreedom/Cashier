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
    public partial class Bill : Form
    {
        private string viewState = "";
        private string sSql = "";
        public Bill()
        {
            InitializeComponent();
        }

        private void Bill_Load(object sender, EventArgs e)
        {
            BinderGridView();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //获得所点击的行的UID
            try
            {
                viewState = this.dataGridView1[0, e.RowIndex].Value.ToString();
            }
            catch (Exception)
            {

            }

            //MessageBox.Show(viewState);
            sSql = "select 商品编号,商品名称,商品单价,商品数量,金额 from Bill where Total_ID='" + viewState + "'";
            DataTable dt = AccessHelper.ExecuteDataTable(AccessHelper.conn, sSql, null);
            dataGridView2.DataSource = dt;
            dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            sSql = "select UID,总金额,createDate as 记录日期 from Total where UID like '%" + textBox1.Text.Trim() + "%'";
            DataTable dt = AccessHelper.ExecuteDataTable(AccessHelper.conn, sSql, null);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void deleteRow_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要删除此条记录吗？", "删除记录", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                sSql = "delete from Bill where Total_ID = '" + viewState + "'";
                int nonNum = AccessHelper.ExecuteNonQuery(AccessHelper.conn, sSql, null);
                sSql = "delete from Total where UID = '" + viewState + "'";
                int nonNum1 = AccessHelper.ExecuteNonQuery(AccessHelper.conn, sSql, null);
                if (nonNum1 == 0 && nonNum == 0)
                {
                    MessageBox.Show("删除失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            BinderGridView();
        }

        private void BinderGridView()
        {
            sSql = "select COUNT(*) from Total";
            label1.Text = "共：" + AccessHelper.ExecuteScalar(AccessHelper.conn, sSql, null).ToString() + " 笔";
            try
            {
                viewState = this.dataGridView1[0, 0].Value.ToString();
            }
            catch (Exception)
            {

            }

            sSql = "select UID,总金额,createDate as 记录日期 from Total order by createDate desc";
            DataTable dt = AccessHelper.ExecuteDataTable(AccessHelper.conn, sSql, null);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }


    }
}
