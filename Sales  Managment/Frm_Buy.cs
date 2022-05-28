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
    public partial class Frm_Buy : DevExpress.XtraEditors.XtraForm
    {
        private static Frm_Buy frm;
        static void frm_FromClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }
        public static Frm_Buy GetFrm
        {
            get
            {
                if(frm == null)
                {
                    frm = new Frm_Buy();
                    frm.FormClosed += new FormClosedEventHandler(frm_FromClosed);
                }
                return frm;
            }
        }
        public Frm_Buy()
        {
            InitializeComponent();
            if(frm == null)
            {
                frm = this;
            }
        }
        Database db = new Database();
        DataTable tbl = new DataTable();

        //AutoNumber() : ID'de otomatik olarak sayı saysın diye yazdık
        private void AutoNumber()
        {
            tbl.Clear();


            tbl = db.readData("select max(Order_ID) from Buy", "");
            //rows0 0 string'e dönüştür 
            // DBNull null sa boşsa
            //boşsa.değerleri.string'e dönüştür
            if (tbl.Rows[0][0].ToString() == DBNull.Value.ToString())
            {
                //txtID kutusuna 1 yazdır
                txtID.Text = "1";
            }
            else
            {
                //tbl.Rows0 0 datatabel olduğu için ona int bir sayı eklemeyiz o yüzden
                //ilk başta convert.toint32 dönüştürdü.. daha sonra bütün bunları txtID text olduğu için en sonra to string'e döüşütr yazdık
                txtID.Text = ((Convert.ToInt32(tbl.Rows[0][0])) + 1).ToString();
            }
            // bir kişi eklendikten sonra bütün kutular silinir

            DtpDate.Text = DateTime.Now.ToShortDateString();
            DtpAagal.Text = DateTime.Now.ToShortDateString();
            try
            {
                cbxItems.SelectedIndex = 0;
                cbxSupplier.SelectedIndex = 0;
            }
            catch (Exception) { };
            cbxItems.Text = "Ürün Seçin";
            DgvBuy.Rows.Clear();
            rbtnCash.Checked = true;
            txtBarcode.Clear();
            txtBarcode.Focus();
            txtTotal.Clear();
        }
        private void FillItems()
        {
            cbxItems.DataSource = db.readData("select * from Products", "");
            cbxItems.DisplayMember = "Pro_Name";
            cbxItems.ValueMember = "Pro_ID";
        }
        public void FillSuppliers()
        {
            cbxSupplier.DataSource = db.readData("select * from Suppliers", "");
            cbxSupplier.DisplayMember = "Sup_Name";
            cbxSupplier.ValueMember = "Sup_ID";
            
        }
        private void Frm_Buy_Load(object sender, EventArgs e)
        {
            FillItems();
            FillSuppliers();
            try
            {
                AutoNumber();
            }
            catch (Exception)
            {
                
            }
            
        }

        private void cbxType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Frm_Suppliers frm = new Frm_Suppliers();
            frm.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnItems_Click(object sender, EventArgs e)
        {
            if(cbxItems.Text == "Ürün Seçin")
            {
                MessageBox.Show("Lütfen Daha Önce bir ürün seçiniz!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            if(cbxItems.Items.Count <= 0)
            {
                MessageBox.Show("Lütfen Daha Önce bir ürünleri giriniz!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataTable tblItems = new DataTable();
            tblItems.Clear();

            tblItems = db.readData("select * from Products where Pro_ID = "+cbxItems.SelectedValue+"", "");
            if (tblItems.Rows.Count >= 1)
            {
                try
                {
                    string Product_ID = tblItems.Rows[0][0].ToString();
                    string Product_Name = tblItems.Rows[0][1].ToString();
                    decimal Product_Qty = 1;
                    string Product_Price = tblItems.Rows[0][3].ToString();
                    decimal Discount = 0;
                    decimal Total = Product_Qty * Convert.ToDecimal(Product_Price);

                    DgvBuy.Rows.Add(1);
                    int rowindex = DgvBuy.Rows.Count - 1;

                    DgvBuy.Rows[rowindex].Cells[0].Value = Product_ID;
                    DgvBuy.Rows[rowindex].Cells[1].Value = Product_Name;
                    DgvBuy.Rows[rowindex].Cells[2].Value = Product_Qty;
                    DgvBuy.Rows[rowindex].Cells[3].Value = Product_Price;
                    DgvBuy.Rows[rowindex].Cells[4].Value = Discount;
                    DgvBuy.Rows[rowindex].Cells[5].Value = Total;
                }
                catch (Exception) { }

                try
                {
                    //Her bir ürün eklendiğinde fiyatını toplar
                    decimal totalOrder = 0;
                    for(int i = 0; i <= DgvBuy.Rows.Count -1; i++)
                    {
                        totalOrder += Convert.ToDecimal(DgvBuy.Rows[i].Cells[5].Value);
                    }

                    txtTotal.Text = Math.Round(totalOrder).ToString();

                }
                catch (Exception) { }
                //sınıfları saymak için
                lblItemsCount.Text = (DgvBuy.Rows.Count.ToString());

            }




        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if(DgvBuy.Rows.Count >= 1)
            {
                // üstüne tıkldığımız sınıfın index aldık
                int index = DgvBuy.SelectedRows[0].Index;

                DgvBuy.Rows.RemoveAt(index);
                if(DgvBuy.Rows.Count >= 0)
                {
                    txtTotal.Text = "0";
                }
                try
                {
                    //Her bir ürün eklendiğinde fiyatını toplar
                    decimal totalOrder = 0;
                    for (int i = 0; i <= DgvBuy.Rows.Count - 1; i++)
                    {
                        totalOrder += Convert.ToDecimal(DgvBuy.Rows[i].Cells[5].Value);
                    }

                    txtTotal.Text = Math.Round(totalOrder).ToString();

                }
                catch (Exception) { }

            }
        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {


                DataTable tblItems = new DataTable();
                tblItems.Clear();

                tblItems = db.readData("select * from Products where Barcode = '" + txtBarcode.Text + "'", "");
                if (tblItems.Rows.Count >= 1)
                {
                    try
                    {
                        string Product_ID = tblItems.Rows[0][0].ToString();
                        string Product_Name = tblItems.Rows[0][1].ToString();
                        decimal Product_Qty = 1;
                        string Product_Price = tblItems.Rows[0][3].ToString();
                        decimal Discount = 0;
                        decimal Total = Product_Qty * Convert.ToDecimal(Product_Price);

                        DgvBuy.Rows.Add(1);
                        int rowindex = DgvBuy.Rows.Count - 1;

                        DgvBuy.Rows[rowindex].Cells[0].Value = Product_ID;
                        DgvBuy.Rows[rowindex].Cells[1].Value = Product_Name;
                        DgvBuy.Rows[rowindex].Cells[2].Value = Product_Qty;
                        DgvBuy.Rows[rowindex].Cells[3].Value = Product_Price;
                        DgvBuy.Rows[rowindex].Cells[4].Value = Discount;
                        DgvBuy.Rows[rowindex].Cells[5].Value = Total;
                    }
                    catch (Exception) { }

                    try
                    {
                        //Her bir ürün eklendiğinde fiyatını toplar
                        decimal totalOrder = 0;
                        for (int i = 0; i <= DgvBuy.Rows.Count - 1; i++)
                        {
                            totalOrder += Convert.ToDecimal(DgvBuy.Rows[i].Cells[5].Value);
                        }

                        txtTotal.Text = Math.Round(totalOrder).ToString();

                    }
                    catch (Exception) { }
                    //sınıfları saymak için
                    lblItemsCount.Text = (DgvBuy.Rows.Count.ToString());
                }
            }
        }
        private void PayOrder()
        {
            if (DgvBuy.Rows.Count >= 1)
            {
                if (cbxSupplier.Items.Count <= 0)
                {
                    MessageBox.Show("Lütfen Daha önce bir ithilaçı seçiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    string d = DtpDate.Value.ToString("dd/MM/yyyy");

                    db.exceuteData("insert into Buy values (" + txtID.Text + ", '" + d + "', " + cbxSupplier.SelectedValue + ")", "");
                    for (int i = 0; i <= DgvBuy.Rows.Count - 1; i++)
                    {
                        db.exceuteData("insert into Buy_Detalis values (" + txtID.Text + ", " + cbxSupplier.SelectedValue + ", " + DgvBuy.Rows[i].Cells[0].Value + ", '" + d + "', " + DgvBuy.Rows[i].Cells[2].Value + ", '123', " + DgvBuy.Rows[i].Cells[3].Value + ", " + DgvBuy.Rows[i].Cells[4].Value + ", " + DgvBuy.Rows[i].Cells[5].Value + ")", "");
                    }
                    AutoNumber();
                }
                catch (Exception)
                {

                }

            }
        }
        private void UpdateQty()
        {
            if (DgvBuy.Rows.Count >= 1)
            {
                Properties.Settings.Default.Item_Qty = Convert.ToDecimal (DgvBuy.CurrentRow.Cells[2].Value);
                Properties.Settings.Default.Item_BuyPrice = Convert.ToDecimal(DgvBuy.CurrentRow.Cells[3].Value); ;
                Properties.Settings.Default.Item_Discount = Convert.ToDecimal(DgvBuy.CurrentRow.Cells[4].Value); ;

                Properties.Settings.Default.Save();



                Frm_BuyQty frm = new Frm_BuyQty();

                frm.ShowDialog();
            }
        }
        private void Frm_Buy_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F12)
            {
                PayOrder();
            }
            else if(e.KeyCode == Keys.F11)
            {
                UpdateQty();
            }
        }

        private void DgvBuy_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            decimal Item_Qty = 0, Item_BuyPrice = 0, Item_Discount = 0;
            try
            {
                int index = DgvBuy.SelectedRows[0].Index;

                Item_Qty =Convert.ToDecimal( DgvBuy.Rows[index].Cells[2].Value);
                Item_BuyPrice = Convert.ToDecimal(DgvBuy.Rows[index].Cells[3].Value);
                Item_Discount = Convert.ToDecimal(DgvBuy.Rows[index].Cells[4].Value);

                decimal Total = 0;
                Total = (Item_Qty * Item_BuyPrice) - Item_Discount;

                DgvBuy.Rows[index].Cells[5].Value = Total;


                decimal totalOrder = 0;
                for (int i = 0; i <= DgvBuy.Rows.Count - 1; i++)
                {
                    totalOrder += Convert.ToDecimal(DgvBuy.Rows[i].Cells[5].Value);
                }

                txtTotal.Text = Math.Round(totalOrder).ToString();



            }
            catch (Exception)
            {

            }
        }

        private void rbtnCash_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}