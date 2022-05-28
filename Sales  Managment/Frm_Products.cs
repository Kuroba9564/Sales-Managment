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
    public partial class Frm_Products : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Products()
        {
            InitializeComponent();
        }
        Database db = new Database();
        DataTable tbl = new DataTable();

        //AutoNumber() : ID'de otomatik olarak sayı saysın diye yazdık
        private void AutoNumber()
        {
            tbl.Clear();


            tbl = db.readData("select max(Pro_ID) from Products", "");
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

            txtBarcode.Clear();
            txtProName.Clear();
            txtProNameSearch.Clear();
            NudBuyPrice.Value = 1;
            NudSalePrice.Value = 1;
            NudMinQty.Value = 0;
            NudMaxDiscount.Value = 0;
            NudQty.Value = 0;

            try 
            {
                FillPro();
                CbxProducts.SelectedIndex = 0;
            }
            catch (Exception)
            {

            }

            // Ekleme silme vb. kutular aktifleştirmek için yada iptal etmek için kullanırız.
            //AutoNumber fonk. içine, yeni bir sayı olunca diye burada yazdık.
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnDeleteAll.Enabled = false;
            btnSave.Enabled = false;
            btnNew.Enabled = true;


        }
        int row = 0;
        private void Show()
        {
            tbl.Clear();
            tbl = db.readData("select * from Products", "");

            if (tbl.Rows.Count <= 0)
            {
                MessageBox.Show("Bilgiler alınmadı");

            }

            else
            {

                try
                {
                    txtID.Text = tbl.Rows[row][0].ToString();
                    txtProName.Text = tbl.Rows[row][1].ToString();
                    NudQty.Value = Convert.ToDecimal(tbl.Rows[row][2]);
                    NudBuyPrice.Value = Convert.ToDecimal(tbl.Rows[row][3]);
                    NudSalePrice.Value = Convert.ToDecimal(tbl.Rows[row][4]);
                    txtBarcode.Text = tbl.Rows[row][5].ToString();
                    NudMinQty.Value = Convert.ToDecimal(tbl.Rows[row][6]);
                    NudMaxDiscount.Value = Convert.ToDecimal(tbl.Rows[row][7]);
                }
                catch (Exception)
                {

                }
            }

            btnAdd.Enabled = false;
            btnDelete.Enabled = true;
            btnDeleteAll.Enabled = true;
            btnSave.Enabled = true;
            btnNew.Enabled = true;

        }
        private void FillPro()
        {
            CbxProducts.DataSource = db.readData("select * from Products", "");
            CbxProducts.DisplayMember = "Pro_Name";
            CbxProducts.ValueMember = "Pro_ID";
        }

        private void Frm_Products_Load(object sender, EventArgs e)
        {
            try
            {
                AutoNumber();
            }
            catch (Exception)
            {

            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            row = 0;
            Show();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (row == 0)
            {
                tbl.Clear();
                tbl = db.readData("select count (Pro_ID) from Products", "");
                row = Convert.ToInt32(tbl.Rows[0][0]) - 1;
                Show();
            }
            else
            {
                row--;
                Show();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tbl.Clear();
            tbl = db.readData("select count (Pro_ID) from Products", "");
            if (Convert.ToInt32(tbl.Rows[0][0]) - 1 == row)
            {
                row = 0;
                Show();
            }
            else
            {
                row++;
                Show();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            tbl.Clear();
            tbl = db.readData("select count (Pro_ID) from Products", "");
            row = (Convert.ToInt32(tbl.Rows[0][0]) - 1);
            Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtProName.Text == "")
            {
                MessageBox.Show("Lütfen önce Ürünün Adı giriniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (NudBuyPrice.Value <= 0)
            {
                MessageBox.Show("Satın alma fiyatı 1'dan küçük olamaz tekrar kontorl ediniz!!! ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (NudSalePrice.Value <= 0)
            {
                MessageBox.Show("Satış fiyatı 1'dan küçük olamaz Lütfen tekrar kontorl ediniz!!! ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (NudMaxDiscount.Value >= NudSalePrice.Value)
            {
                MessageBox.Show("Yapılan indirim satış fiyatından daha büyük olamaz Lütfen tekrar kontorl ediniz!!! ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if (NudBuyPrice.Value > NudSalePrice.Value)
            //{
            //    MessageBox.Show("Alış fiyatı, Satış fiyatından daha fazla olamaz Lütfen tekrar kontorl ediniz!!! ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            if (NudMinQty.Value > NudQty.Value)
            {
                MessageBox.Show("Adet Sınırı mevcüt miktardan daha fazla olamaz. Lütfen tekrar kontorl ediniz!!! ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {

                db.exceuteData("insert into Products Values(" + txtID.Text + ", '"+txtProName.Text+"', "+NudQty.Value+", "+NudBuyPrice.Value+", "+NudSalePrice.Value+", '"+txtBarcode.Text+"', "+NudMinQty.Value+", "+NudMaxDiscount.Value+")", "Başarılı bir işlem Gerçekleşti");

                AutoNumber();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AutoNumber();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProName.Text == "")
            {
                MessageBox.Show("Lütfen önce Ürünün Adı giriniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (NudBuyPrice.Value <= 0)
            {
                MessageBox.Show("Satın alma fiyatı 1'dan küçük olamaz tekrar kontorl ediniz!!! ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (NudSalePrice.Value <= 0)
            {
                MessageBox.Show("Satış fiyatı 1'dan küçük olamaz Lütfen tekrar kontorl ediniz!!! ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (NudMaxDiscount.Value >= NudSalePrice.Value)
            {
                MessageBox.Show("Yapılan indirim satış fiyatından daha büyük olamaz Lütfen tekrar kontorl ediniz!!! ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if (NudBuyPrice.Value > NudSalePrice.Value)
            //{
            //    MessageBox.Show("Alış fiyatı, Satış fiyatından daha fazla olamaz Lütfen tekrar kontorl ediniz!!! ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            if (NudMinQty.Value > NudQty.Value)
            {
                MessageBox.Show("Adet Sınırı mevcüt miktardan daha fazla olamaz. Lütfen tekrar kontorl ediniz!!! ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {

                db.readData("update Products set Pro_Name = '" + txtProName.Text + "', Qty = " + NudQty.Value + ", Buy_Price = " + NudBuyPrice.Value + ", Sale_Price = " + NudSalePrice.Value + ", Barcode = '" + txtBarcode.Text + "', MinQty = " + NudMinQty.Value + ", MaxDiscount = " + NudMaxDiscount.Value + " where Pro_ID = '" + txtID.Text + "'", "Başarılı bir işlem Gerçekleşti");

                AutoNumber();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bu bilgileri silmenizden emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.readData("delete from Products where Pro_ID = " + txtID.Text + "", "Bilgiler başarılı bir şekilde silindi");
                AutoNumber();

            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bu bilgileri silmenizden emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.readData("delete from Products", "Bütün bilgiler başarılı bir şekilde silindi");
                AutoNumber();

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtProNameSearch.Text != "")
            {
                DataTable tblSerach = new DataTable();
                tblSerach.Clear();
                tblSerach = db.readData("select * from Products where Pro_Name like '%"+txtProNameSearch.Text+"%'", "");

                if (tblSerach.Rows.Count <= 0)
                {
                    MessageBox.Show("Bilgiler alınmadı");

                }

                else
                {

                    try
                    {
                        txtID.Text = tblSerach.Rows[0][0].ToString();
                        txtProName.Text = tblSerach.Rows[0][1].ToString();
                        NudQty.Value = Convert.ToDecimal(tblSerach.Rows[0][2]);
                        NudBuyPrice.Value = Convert.ToDecimal(tblSerach.Rows[0][3]);
                        NudSalePrice.Value = Convert.ToDecimal(tblSerach.Rows[0][4]);
                        txtBarcode.Text = tblSerach.Rows[0][5].ToString();
                        NudMinQty.Value = Convert.ToDecimal(tblSerach.Rows[0][6]);
                        NudMaxDiscount.Value = Convert.ToDecimal(tblSerach.Rows[0][7]);
                    }
                    catch (Exception)
                    {

                    }
                }

                btnAdd.Enabled = false;
                btnDelete.Enabled = true;
                btnDeleteAll.Enabled = true;
                btnSave.Enabled = true;
                btnNew.Enabled = true;

            }
        }

        private void CbxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void CbxProducts_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CbxProducts.Items.Count >= 1)
            {
                DataTable tblSerach = new DataTable();
                tblSerach.Clear();

                {

                    tblSerach = db.readData("select * from Products where Pro_ID = " + CbxProducts.SelectedValue + "", "");

                    if (tblSerach.Rows.Count <= 0)
                    {
                        MessageBox.Show("Bilgiler alınmadı");

                    }




                    try
                    {
                        txtID.Text = tblSerach.Rows[0][0].ToString();
                        txtProName.Text = tblSerach.Rows[0][1].ToString();
                        NudQty.Value = Convert.ToDecimal(tblSerach.Rows[0][2]);
                        NudBuyPrice.Value = Convert.ToDecimal(tblSerach.Rows[0][3]);
                        NudSalePrice.Value = Convert.ToDecimal(tblSerach.Rows[0][4]);
                        txtBarcode.Text = tblSerach.Rows[0][5].ToString();
                        NudMinQty.Value = Convert.ToDecimal(tblSerach.Rows[0][6]);
                        NudMaxDiscount.Value = Convert.ToDecimal(tblSerach.Rows[0][7]);
                    }
                    catch (Exception)
                    {

                    }
                }

                btnAdd.Enabled = false;
                btnDelete.Enabled = true;
                btnDeleteAll.Enabled = true;
                btnSave.Enabled = true;
                btnNew.Enabled = true;

            
            }
        }
    }
}