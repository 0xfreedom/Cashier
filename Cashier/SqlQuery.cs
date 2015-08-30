using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cashier
{
    public partial class SqlQuery : Form
    {
        public SqlQuery()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sSql = "";
            sSql = textBox1.Text;
            try
            {
                int n = AccessHelper.ExecuteNonQuery(AccessHelper.conn, sSql, null);
                if (n > 0)
                {
                    MessageBox.Show(n.ToString() + "条被影响");
                }
                else
                {
                    sSql = textBox1.Text;
                    DataTable dt = AccessHelper.ExecuteDataTable(AccessHelper.conn, sSql, null);
                    dataGridView1.DataSource = dt;
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
            }
            catch (Exception)
            {
                return;
            }

        }
    }
}
