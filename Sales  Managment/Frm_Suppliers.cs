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
    public partial class Frm_Suppliers : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Suppliers()
        {
            InitializeComponent();
        }
        Database db = new Database();
        DataTable tbl = new DataTable();

        //AutoNumber() : ID'de otomatik olarak sayı saysın diye yazdık
        private void AutoNumber()
        {
            tbl.Clear();


            tbl = db.readData("select max(Sup_ID) from Suppliers", "");
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
            txtName.Clear();
            txtNote.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            txtSearch.Clear();

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
            tbl = db.readData("select * from Suppliers", "");

            if (tbl.Rows.Count <= 0)
            {
                MessageBox.Show("Bilgiler alınmadı");

            }

            else
            {
                txtID.Text = tbl.Rows[row][0].ToString();
                txtName.Text = tbl.Rows[row][1].ToString();
                txtAddress.Text = tbl.Rows[row][2].ToString();
                txtPhone.Text = tbl.Rows[row][3].ToString();
                txtNote.Text = tbl.Rows[row][4].ToString();
            }


            btnAdd.Enabled = false;
            btnDelete.Enabled = true;
            btnDeleteAll.Enabled = true;
            btnSave.Enabled = true;
            btnNew.Enabled = true;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtPhone.Text == "" || txtAddress.Text == "")
            {
                MessageBox.Show("Lütfen İthilatçının adını, numarasını ve addressini giriniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                db.exceuteData("insert into Suppliers Values(" + txtID.Text + ", '" + txtName.Text + "', '" + txtAddress.Text + "', '" + txtPhone.Text + "', '" + txtNote.Text + "')", "Başarılı bir işlem Gerçekleşti");

                AutoNumber();
            }
        }

        private void Frm_Suppliers_Load(object sender, EventArgs e)
        {
            AutoNumber();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AutoNumber();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            row = 0;
            Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            db.readData("update Suppliers set Sup_Name = '" + txtName.Text + "', Sup_Address = '" + txtAddress.Text + "', Sup_Phone = '" + txtPhone.Text + "', Notes = '" + txtNote.Text + "' where Sup_ID = '" + txtID.Text + "'", "Bilgiler başarılı bir şekilde değiştirildi");
            AutoNumber();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bu bilgileri silmenizden emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.readData("delete from Suppliers where Sup_ID = " + txtID.Text + "", "Bilgiler başarılı bir şekilde silindi");
                AutoNumber();

            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bu bilgileri silmenizden emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.readData("delete from Suppliers", "Bütün bilgiler başarılı bir şekilde silindi");
                AutoNumber();

            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            tbl.Clear();
            tbl = db.readData("select count (Sup_ID) from Suppliers", "");
            row = (Convert.ToInt32(tbl.Rows[0][0]) - 1);
            Show();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tbl.Clear();
            tbl = db.readData("select count (Sup_ID) from Suppliers", "");
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

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (row == 0)
            {
                tbl.Clear();
                tbl = db.readData("select count (Sup_ID) from Suppliers", "");
                row = Convert.ToInt32(tbl.Rows[0][0]) - 1;
                Show();
            }
            else
            {
                row--;
                Show();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable tblSearch = new DataTable();

            tblSearch.Clear();

            tblSearch = db.readData("select * from Suppliers where Sup_Name like '%" + txtSearch.Text + "%' ", "");

            try
            {
                txtID.Text = tblSearch.Rows[0][0].ToString();
                txtName.Text = tblSearch.Rows[0][1].ToString();
                txtAddress.Text = tblSearch.Rows[0][2].ToString();
                txtPhone.Text = tblSearch.Rows[0][3].ToString();
                txtNote.Text = tblSearch.Rows[0][4].ToString();
            }
            catch (Exception)
            {
                btnAdd.Enabled = false;
                btnDelete.Enabled = true;
                btnDeleteAll.Enabled = true;
                btnSave.Enabled = true;
                btnNew.Enabled = true;
            }
        }

        private void Frm_Suppliers_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Frm_Buy.GetFrm.FillSuppliers();
            }
            catch (Exception)
            {

            }
        }
    }
}