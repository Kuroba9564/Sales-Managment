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
    public partial class Frm_DeservedReport : DevExpress.XtraEditors.XtraForm
    {
        public Frm_DeservedReport()
        {
            InitializeComponent();
        }

        Database db = new Database();
        DataTable tbl = new DataTable();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Frm_DeservedReport_Load(object sender, EventArgs e)
        {
            DtpFrom.Text = DateTime.Now.ToShortDateString();
            DtpTo.Text = DateTime.Now.ToShortDateString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string date1;
            string date2;
            date1 = DtpFrom.Value.ToString("yyyy/MM/dd");
            date2 = DtpTo.Value.ToString("yyyy/MM/dd");
            tbl.Clear();
            tbl = db.readData("select Deserved.Des_ID as 'İşlemin Numarası', Price as 'TRY', Date as 'Tarih', Notes as 'Notlar', Deserved_Type.Name as 'Tür' from Deserved, Deserved_Type where Deserved.Type_ID = Deserved_Type.Des_ID and CONVERT(date, Date, 105) between '"+date1+ "' and '" + date2 + "'", "");
            
            if(tbl.Rows.Count >= 1)
            {
                DgvSearch.DataSource = tbl;
                decimal Sum = 0;

                for(int i = 0; i <= tbl.Rows.Count - 1; i++)
                {
                    Sum += Convert.ToDecimal(tbl.Rows[i][1]);
                }

                txtTotal.Text = Math.Round(Sum, 2).ToString();
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bu bilgileri silmenizden emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string date1;
                string date2;
                date1 = DtpFrom.Value.ToString("yyyy/MM/dd");
                date2 = DtpTo.Value.ToString("yyyy/MM/dd");
                db.readData("delete from Deserved where CONVERT(date, Date, 105) between '" + date1 + "' and '" + date2 + "'", "Bilgiler başarılı bir şekilde silindi");
                txtTotal.Clear();
                tbl.Clear();
            }
        }
    }
}