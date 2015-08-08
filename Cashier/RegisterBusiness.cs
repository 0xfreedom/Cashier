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

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            //MessageBox.Show(this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            DialogResult drt = MessageBox.Show("真的要删除吗？", "删除确认", MessageBoxButtons.OK, MessageBoxIcon.Error);
            switch (drt)
            {
                case DialogResult.Abort:
                    break;
                case DialogResult.Cancel:
                    break;
                case DialogResult.Ignore:
                    break;
                case DialogResult.No:
                    break;
                case DialogResult.None:
                    break;
                case DialogResult.OK:
                    sSql = "delete from Business where UID='" + this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "'";
                    //MessageBox.Show(sSql);
                    int nonNum = AccessHelper.ExecuteNonQuery(AccessHelper.conn, sSql, null);
                    if (nonNum == 0)
                    {
                        MessageBox.Show("删除失败！");
                    }
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Yes:
                    break;
                default:
                    break;
            }
        }






    }
}
