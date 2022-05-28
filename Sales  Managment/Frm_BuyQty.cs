using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sales__Managment
{
    public partial class Frm_BuyQty : DevExpress.XtraEditors.XtraForm
    {
        public Frm_BuyQty()
        {
            InitializeComponent();
        }

        private void Frm_BuyQty_Load(object sender, EventArgs e)
        {
            txtQty.Text = Properties.Settings.Default.Item_Qty.ToString();
            txtBuyPrice.Text = Properties.Settings.Default.Item_BuyPrice.ToString();
            txtDiscount.Text = Properties.Settings.Default.Item_Discount.ToString();
            txtDiscount.Focus();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (txtQty.Text == "")
            {
                MessageBox.Show("Lütfen Miktarı giriniz!!", "Onay");
                return;
            }
            if (txtBuyPrice.Text == "")
            {
                MessageBox.Show("Lütfen Fiyatı giriniz!!", "Onay");
                return;
            }
            if (txtDiscount.Text == "")
            {
                MessageBox.Show("Lütfen İndirimi giriniz!!", "Onay");
                return;
            }
            Properties.Settings.Default.Item_Qty =Convert.ToDecimal( txtQty.Text);
            Properties.Settings.Default.Item_Discount = Convert.ToDecimal(txtDiscount.Text);
            Properties.Settings.Default.Item_BuyPrice = Convert.ToDecimal(txtBuyPrice.Text);
            Properties.Settings.Default.Save();

            Close();



        }

        private void Frm_BuyQty_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (txtQty.Text == "")
                {
                    MessageBox.Show("Lütfen Miktarı giriniz!!", "Onay");
                    return;
                }
                if (txtBuyPrice.Text == "")
                {
                    MessageBox.Show("Lütfen Fiyatı giriniz!!", "Onay");
                    return;
                }
                if (txtDiscount.Text == "")
                {
                    MessageBox.Show("Lütfen İndirimi giriniz!!", "Onay");
                    return;
                }
                Properties.Settings.Default.Item_Qty = Convert.ToDecimal(txtQty.Text);
                Properties.Settings.Default.Item_Discount = Convert.ToDecimal(txtDiscount.Text);
                Properties.Settings.Default.Item_BuyPrice = Convert.ToDecimal(txtBuyPrice.Text);
                Properties.Settings.Default.Save();

                Close();
            }
        }

        private void Frm_BuyQty_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                int index = Frm_Buy.GetFrm.DgvBuy.SelectedRows[0].Index;
                Frm_Buy.GetFrm.DgvBuy.Rows[index].Cells[2].Value = Properties.Settings.Default.Item_Qty;
                Frm_Buy.GetFrm.DgvBuy.Rows[index].Cells[3].Value = Properties.Settings.Default.Item_BuyPrice;
                Frm_Buy.GetFrm.DgvBuy.Rows[index].Cells[4].Value = Properties.Settings.Default.Item_Discount;


            }
            catch (Exception)
            {

            }
        }
    }
}