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
            checkBox3.Checked = Cashier_Main.itis;
            //BinderGridView();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BinderGridView();
        }
        private void BinderGridView()
        {
            if (checkBox3.Checked == true)
            {
                sSql = "select * from Goods where 商品编号 like '%" + textBox1.Text.Trim() + "%'";
                Cashier_Main.itis = checkBox3.Checked;
            }
            else
            {
                sSql = "select * from Goods where 商品编号 like '" + textBox1.Text.Trim() + "%'";
                Cashier_Main.itis = checkBox3.Checked;
            }
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
                textBox1.Text = "";
                textBox1.Focus();
                viewState = this.dataGridView1[0, e.RowIndex].Value.ToString();
                sSql = "select UID,商品编号,商品名称 from goods where uid='" + viewState + "'";
                DataTable dt = AccessHelper.ExecuteDataTable(AccessHelper.conn, sSql, null);
                //dataGridView2.DataSource = dt;
                int index = this.dataGridView2.Rows.Add();
                //MessageBox.Show(dt.Rows[0]["商品编号"].ToString());
                this.dataGridView2.Rows[index].Cells[0].Value = dt.Rows[0]["UID"].ToString();
                this.dataGridView2.Rows[index].Cells[1].Value = dt.Rows[0]["商品编号"].ToString();
                this.dataGridView2.Rows[index].Cells[2].Value = dt.Rows[0]["商品名称"].ToString();
                //this.dataGridView2.Rows[index].Cells["商品名称"].Value = dt.Rows[0]["商品名称"].ToString();

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
            TotalID = Guid.NewGuid().ToString();
            //先向Total合计表里插入此次账单 
            //MessageBox.Show(DateTime.Now.ToShortDateString());
            sSql = "insert into Total (UID,现金结算,刷卡结算,总金额,createDate) values ('" + TotalID + "','" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "','" + Convert.ToDecimal(label3.Text) + "','" + DateTime.Now.ToShortDateString() + "')";
            AccessHelper.ExecuteNonQuery(AccessHelper.conn, sSql, null);


            using (OleDbConnection con = new OleDbConnection(AccessHelper.conn))
            {
                con.Open();
                using (OleDbTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                        {
                            DataGridViewRow row = dataGridView2.Rows[i];
                            string goodsId = row.Cells[0].Value.ToString();
                            string comID = row.Cells[1].Value.ToString();
                            string comName = row.Cells[2].Value.ToString();
                            string comPrice = row.Cells[3].Value.ToString();
                            string comNum = row.Cells[4].Value.ToString();
                            string result = row.Cells[5].Value.ToString();
                            sSql = "insert into Bill (UID,goodsID,商品编号,商品名称,商品单价,商品数量,金额,Total_ID) values ('" + Guid.NewGuid().ToString() + "','" + goodsId + "','" + comID + "','" + comName + "','" + comPrice + "','" + comNum + "','" + result + "','" + TotalID + "')";
                            AccessHelper.ExecuteNonQuery(tran, sSql, null);
                        }
                        tran.Commit();
                        MessageBox.Show("保存成功！", "恭喜！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //关闭窗口释放资源
                        this.Close();
                        this.Dispose();
                        Pay payFrom = new Pay();
                        payFrom.ShowDialog();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                        MessageBox.Show("插入失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpDate();
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                decimal price = 0;
                bool isprice = Decimal.TryParse(this.dataGridView2.CurrentRow.Cells[3].EditedFormattedValue.ToString(), out price);
                int num = 0;
                bool isnum = Int32.TryParse(this.dataGridView2.CurrentRow.Cells[4].EditedFormattedValue.ToString(), out num);
                decimal sum = price * num;
                this.dataGridView2.CurrentRow.Cells[5].Value = sum.ToString();

            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            decimal totalPrice = 0;

            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                DataGridViewRow row = dataGridView2.Rows[i];
                try
                {
                    totalPrice += Convert.ToDecimal(row.Cells[5].Value.ToString());
                }
                catch (Exception)
                {
                    return;
                }

            }
            label3.Text = totalPrice.ToString();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Focus();
            Cashier_Main.itis = checkBox3.Checked;
        }



    }
}
