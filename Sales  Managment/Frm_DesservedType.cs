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
    public partial class Frm_DesservedType : DevExpress.XtraEditors.XtraForm
    {
        public Frm_DesservedType()
        {
            InitializeComponent();
        }
        Database db = new Database();
        DataTable tbl = new DataTable();

        //AutoNumber() : ID'de otomatik olarak sayı saysın diye yazdık
        private void AutoNumber()
        {
            tbl.Clear();


            tbl = db.readData("select max(Des_ID) from Deserved_Type", "");
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
            tbl = db.readData("select * from Deserved_Type", "");

            if (tbl.Rows.Count <= 0)
            {
                MessageBox.Show("Bilgiler alınmadı");

            }

            else
            {
                txtID.Text = tbl.Rows[row][0].ToString();
                txtName.Text = tbl.Rows[row][1].ToString();

                
            }


            btnAdd.Enabled = false;
            btnDelete.Enabled = true;
            btnDeleteAll.Enabled = true;
            btnSave.Enabled = true;
            btnNew.Enabled = true;

        }
        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void Frm_DesservedType_Load(object sender, EventArgs e)
        {
            AutoNumber();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Lütfen Masrafın adını giriniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                db.exceuteData("insert into Deserved_Type Values(" + txtID.Text + ", '" + txtName.Text + "')", "Başarılı bir işlem Gerçekleşti");

                AutoNumber();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AutoNumber();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            db.readData("update Deserved_Type set Des_Name = '" + txtName.Text + "' where Sup_ID = '" + txtID.Text + "'", "Bilgiler başarılı bir şekilde değiştirildi");
            AutoNumber();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bu bilgileri silmenizden emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.readData("delete from Deserved_Type where Des_ID = " + txtID.Text + "", "Bilgiler başarılı bir şekilde silindi");
                AutoNumber();

            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            db.readData("delete from Deserved_Type ", "Bilgiler başarılı bir şekilde silindi");
            AutoNumber();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            row = 0;
            Show();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tbl.Clear();
            tbl = db.readData("select count (Des_ID) from Deserved_Type", "");
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
                tbl = db.readData("select count (Des_ID) from Deserved_Type", "");
                row = Convert.ToInt32(tbl.Rows[0][0]) - 1;
                Show();
            }
            else
            {
                row--;
                Show();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            tbl.Clear();
            tbl = db.readData("select count (Des_ID) from Deserved_Type", "");
            row = (Convert.ToInt32(tbl.Rows[0][0]) - 1);
            Show();
        }
    }
}