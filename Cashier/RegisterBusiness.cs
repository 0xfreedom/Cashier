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
    public partial class RegisterBusiness : Form
    {
        string viewState = "";
        string sSql = "";
        public RegisterBusiness()
        {
            InitializeComponent();
        }
        private void RegisterBusiness_Load(object sender, EventArgs e)
        {
            BinderGridView();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //数据验证
            if (textBox1.Text.Trim() == "")
            {
                textBox1.Focus();
                MessageBox.Show("填写商家名称！");
                return;
            }


            sSql = "insert into Business (UID,商家名称) values ('" + Guid.NewGuid().ToString() + "','" + textBox1.Text.Trim() + "')";
            int resNum = AccessHelper.ExecuteNonQuery(AccessHelper.conn, sSql, null);
            if (resNum > 0)
            {
                textBox1.Text = "";
                textBox1.Focus();
                //Messagebox.show("保存成功");
            }
            BinderGridView();
        }

        private void BinderGridView()
        {
            sSql = "select * from Business";
            DataTable dt = AccessHelper.ExecuteDataTable(AccessHelper.conn, sSql, null);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                viewState = this.dataGridView1[0, e.RowIndex].Value.ToString();
            }
            catch (Exception)
            { }

        }

        private void deleteRow_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要删除此条记录吗？", "删除记录", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                sSql = "delete from Business where UID='" + viewState + "'";
                int nonNum = AccessHelper.ExecuteNonQuery(AccessHelper.conn, sSql, null);
                sSql = "delete from Goods where Business_ID='" + viewState + "'";
                int nonNum1 = AccessHelper.ExecuteNonQuery(AccessHelper.conn, sSql, null);
                if (nonNum1 == 0 && nonNum == 0)
                {
                    MessageBox.Show("删除失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            BinderGridView();
        }










    }
}
