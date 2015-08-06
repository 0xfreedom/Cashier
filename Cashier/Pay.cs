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
        private string sSql = "";
        private string viewState = "";
        private decimal moneyPay = 0;
        private decimal cardPay = 0;
        private string TotalID = "";
        public Pay()
        {
            InitializeComponent();
        }
        private void Pay_Load(object sender, EventArgs e)
        {
            TotalID = Guid.NewGuid().ToString();
            BinderGridView();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BinderGridView();
        }
        private void BinderGridView()
        {
            sSql = "select * from Goods where 商品编号 like '%" + textBox1.Text.Trim() + "%'";
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true && checkBox2.Checked == false)
            {
                textBox3.Enabled = false;
                textBox3.Text = "0";
            }
            else
            {
                textBox3.Enabled = true;
                textBox3.Text = label3.Text;
                label4.Visible = true;
                button1.Enabled = true;
            }
            if (checkBox1.Checked == true && checkBox2.Checked == true)
            {
                textBox3.Enabled = true;
                textBox2.Enabled = true;
                textBox2.Text = "0";
                textBox3.Text = "0";
            }



            if (checkBox1.Checked == false && checkBox2.Checked == true)
            {
                textBox2.Enabled = false;
                textBox2.Text = "0";
            }
            else
            {
                textBox2.Enabled = true;
                textBox2.Text = label3.Text;
                label4.Visible = true;
                button1.Enabled = true;
            }
            if (checkBox1.Checked == true && checkBox2.Checked == true)
            {
                textBox3.Enabled = true;
                textBox2.Enabled = true;
                textBox2.Text = "0";
                textBox3.Text = "0";
            }
            if (checkBox1.Checked == false && checkBox2.Checked == false)
            {
                textBox3.Enabled = false;
                textBox2.Enabled = false;
                textBox2.Text = "0";
                textBox3.Text = "0";
                label4.Visible = false;
                button1.Enabled = false;

            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false && checkBox2.Checked == true)
            {
                textBox2.Enabled = false;
                textBox2.Text = "0";

            }
            else
            {
                textBox2.Enabled = true;
                textBox2.Text = label3.Text;
                label4.Visible = true;
                button1.Enabled = true;
            }
            if (checkBox1.Checked == true && checkBox2.Checked == true)
            {
                textBox3.Enabled = true;
                textBox2.Enabled = true;
                textBox2.Text = "0";
                textBox3.Text = "0";
            }


            if (checkBox1.Checked == true && checkBox2.Checked == false)
            {
                textBox3.Enabled = false;
                textBox3.Text = "0";

            }
            else
            {
                textBox3.Enabled = true;
                textBox3.Text = label3.Text;
                label4.Visible = true;
                button1.Enabled = true;

            }
            if (checkBox1.Checked == true && checkBox2.Checked == true)
            {
                textBox3.Enabled = true;
                textBox2.Enabled = true;
                textBox2.Text = "0";
                textBox3.Text = "0";
            }

            if (checkBox1.Checked == false && checkBox2.Checked == false)
            {
                textBox3.Enabled = false;
                textBox2.Enabled = false;
                textBox2.Text = "0";
                textBox3.Text = "0";
                label4.Visible = false;
                button1.Enabled = false;

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                moneyPay = Convert.ToDecimal(textBox2.Text);
                try
                {
                    cardPay = Convert.ToDecimal(textBox3.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("金额必须是数字。");
                    textBox3.Focus();
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("金额必须是数字。");
                textBox2.Focus();
                return;
            }

            if (moneyPay + cardPay == Convert.ToDecimal(label3.Text))
            {
                label4.Visible = true;
                button1.Enabled = true;
            }
            else
            {
                label4.Visible = false;
                button1.Enabled = false;
            }
        }

        private void textBox2_MouseEnter(object sender, EventArgs e)
        {
            textBox2.Focus();
            textBox2.SelectAll();
        }

        private void textBox3_MouseEnter(object sender, EventArgs e)
        {
            textBox3.Focus();
            textBox3.SelectAll();
        }
        private void UpDate()
        {
            //先向Total合计表里插入此次账单

            sSql = "insert into Total (UID,总金额,createDate) values ('" + TotalID + "','" + Convert.ToDecimal(label3.Text) + "','" + DateTime.Now + "')";
            AccessHelper.ExecuteNonQuery(AccessHelper.conn, sSql, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpDate();
        }

    }
}
