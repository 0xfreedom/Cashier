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
    public partial class Pay : Form
    {
        string sSql = "";
        private string viewState = "";
        public Pay()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BinderGridView();
        }
        private void BinderGridView()
        {
            sSql = "select * from goods where 商品编号 like '%" + textBox1.Text.Trim() + "%'";
            DataTable dt = AccessHelper.ExecuteDataTable(AccessHelper.conn, sSql, null);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            try
            {
                viewState = this.dataGridView1[0, 0].Value.ToString();
            }
            catch (Exception)
            {
            }


        }

        private void Pay_Load(object sender, EventArgs e)
        {
            BinderGridView();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                viewState = this.dataGridView1[0, e.RowIndex].Value.ToString();
                //sSql = "select UID,商品编号,商品名称 from goods where uid='" + viewState + "'";
                //DataTable dt = AccessHelper.ExecuteDataTable(AccessHelper.conn, sSql, null);
                //dataGridView2.DataSource = dt;



            }
            catch (Exception)
            {

            }
        }
    }
}
