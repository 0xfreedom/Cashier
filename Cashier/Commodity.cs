using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cashier
{
    public partial class Commodity : Form
    {
        string sSql = "";
        public Commodity()
        {
            InitializeComponent();
        }

        private void Commodity_Load(object sender, EventArgs e)
        {
            DataTable dt = AccessHelper.ExecuteDataTable(AccessHelper.conn, "select * from Business", null);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "商家名称";
            comboBox1.ValueMember = "UID";
            BinderGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //验证文本框值
            if (textBox1.Text.Trim() == "")
            {
                textBox1.Focus();
                MessageBox.Show("填写商品编号！");
                return;
            }
            else
            {
                sSql = "select * from goods where 商品编号='" + textBox1.Text.Trim() + "'";
                using (OleDbDataReader oddr = AccessHelper.ExecuteReader(AccessHelper.conn, sSql, null))
                {
                    if (oddr.Read())
                    {
                        MessageBox.Show("商品编号重复！");
                        return;
                    }
                }

            }


            if (textBox2.Text.Trim() == "")
            {
                textBox2.Focus();
                MessageBox.Show("填写商品名称！");
                return;
            }


            //插入货物表
            string comID = textBox1.Text.Trim();
            string comName = textBox2.Text.Trim();
            string comSeller = getBusinessName(comboBox1.SelectedValue.ToString());
            sSql = "insert into goods (uid,Business_ID,商品编号,商品名称,商家名称) values ('" + Guid.NewGuid().ToString() + "','" + comSeller + "','" + comID + "','" + comName + "','" + comSeller + "')";
            int resNum = AccessHelper.ExecuteNonQuery(AccessHelper.conn, sSql, null);
            if (resNum > 0)
            {
                MessageBox.Show("保存成功");
            }
            //调用绑定GridView
            BinderGridView();

        }


        /// <summary>
        /// 绑定GridView数据
        /// </summary>
        private void BinderGridView()
        {
            sSql = "select * from goods";
            DataTable dt = AccessHelper.ExecuteDataTable(AccessHelper.conn, sSql, null);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        //获取商家中文名称
        private string getBusinessName(string businessId)
        {
            sSql = "select 商家名称 from Business where uid='" + businessId + "'";
            string businessName = AccessHelper.ExecuteScalar(AccessHelper.conn, sSql, null).ToString();
            return businessName;
        }


    }
}
