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
using System.Drawing.Printing;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace Sales__Managment
{
    public partial class Frm_Setting : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Setting()
        {
            InitializeComponent();
        }
        Database db = new Database();
        string printerName = "";
        private void Frm_Setting_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                printerName = PrinterSettings.InstalledPrinters[i];
                cbxPrinter.Items.Add(printerName);
            }
            if(Properties.Settings.Default.PrinterName == "")
                cbxPrinter.SelectedIndex = 0;
            else
            cbxPrinter.Text = Properties.Settings.Default.PrinterName;

        }

        private void btnSavePrinter_Click(object sender, EventArgs e)
        {
            if (cbxPrinter.Text == "")
            {
                MessageBox.Show("Lütfen Bir Yazıcı Seçiniz");
                return;
            }

            Properties.Settings.Default.PrinterName = cbxPrinter.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("Bilgiler Kayıt edildi", "Onay", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        string imagePath = "";
        private void btnChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files(*.*) | *.*";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imagePath = openFileDialog.FileName.ToString();
                pictureLogo.Image = null;
                pictureLogo.ImageLocation = imagePath;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            pictureLogo.BackgroundImage = null;
            pictureLogo.Image = null;
            imagePath = "";
        }
        private void saveImage(string stmt, string paramaterNAme, string massagge)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-164KRHE;Initial Catalog=Sales_System;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(stmt);
            cmd.Connection = conn;

            FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);

            byte[] bytestream = new byte[fileStream.Length];
            fileStream.Read(bytestream, 0, bytestream.Length);
            fileStream.Close();

            SqlParameter parameter = new SqlParameter(paramaterNAme, SqlDbType.VarBinary, bytestream.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, bytestream);

            cmd.Parameters.Add(parameter);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show(massagge, "Onay");
        }
        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            if(imagePath == "") 
            {
                MessageBox.Show("Lütfen Logoyu giriniz.", "Onay");
                return; 
            }
            DataTable tbl = new DataTable();
            tbl = db.readData("select * from OrderPrintData", "");
            if (tbl.Rows.Count >= 1)
            {
                saveImage("update OrderPrintData set Logo = @Logo, Name = '" + txtName.Text + "', Address = '" + txtAddress.Text + "', Description = '" + txtDescription.Text + "', Phone1 = '" + txtPhone1.Text + "', Phone2 = '" + txtPhone2.Text + "'", "@Logo", "Doğru Bir Şekilde KAyıt edildi");
            }
            else
            {
                saveImage("insert into OrderPrintData values ( @Logo,  '" + txtName.Text + "',  '" + txtAddress.Text + "',  '" + txtDescription.Text + "',  '" + txtPhone1.Text + "',  '" + txtPhone2.Text + "')", "@Logo", "Doğru Bir Şekilde KAyıt edildi");

            }
            imagePath = "";
        }
    }
}