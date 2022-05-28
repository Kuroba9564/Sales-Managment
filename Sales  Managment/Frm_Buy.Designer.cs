
namespace Sales__Managment
{
    partial class Frm_Buy
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxSupplier = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSupplierBrowes = new DevExpress.XtraEditors.SimpleButton();
            this.cbxItems = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnItems = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeleteItem = new DevExpress.XtraEditors.SimpleButton();
            this.DtpDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.DgvBuy = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblItemsCount = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.rbtnCash = new System.Windows.Forms.RadioButton();
            this.rbtnAagal = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.DtpAagal = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.DgvBuy)).BeginInit();
            this.SuspendLayout();
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(303, 109);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(280, 34);
            this.txtID.TabIndex = 5;
            this.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(12, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 27);
            this.label1.TabIndex = 4;
            this.label1.Text = "Faturanın Numarası:";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(303, 209);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(280, 34);
            this.txtBarcode.TabIndex = 7;
            this.txtBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBarcode_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(12, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 27);
            this.label2.TabIndex = 6;
            this.label2.Text = "Barkodun Numarası:";
            // 
            // cbxSupplier
            // 
            this.cbxSupplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxSupplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxSupplier.FormattingEnabled = true;
            this.cbxSupplier.Location = new System.Drawing.Point(809, 113);
            this.cbxSupplier.Name = "cbxSupplier";
            this.cbxSupplier.Size = new System.Drawing.Size(280, 35);
            this.cbxSupplier.TabIndex = 14;
            this.cbxSupplier.SelectedIndexChanged += new System.EventHandler(this.cbxType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Crimson;
            this.label3.Location = new System.Drawing.Point(650, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 27);
            this.label3.TabIndex = 13;
            this.label3.Text = "İtihlaçı:";
            // 
            // btnSupplierBrowes
            // 
            this.btnSupplierBrowes.Appearance.Font = new System.Drawing.Font("Century", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupplierBrowes.Appearance.Options.UseFont = true;
            this.btnSupplierBrowes.Location = new System.Drawing.Point(1107, 114);
            this.btnSupplierBrowes.Name = "btnSupplierBrowes";
            this.btnSupplierBrowes.Size = new System.Drawing.Size(51, 34);
            this.btnSupplierBrowes.TabIndex = 15;
            this.btnSupplierBrowes.Text = "...";
            this.btnSupplierBrowes.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // cbxItems
            // 
            this.cbxItems.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxItems.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxItems.FormattingEnabled = true;
            this.cbxItems.Location = new System.Drawing.Point(809, 208);
            this.cbxItems.Name = "cbxItems";
            this.cbxItems.Size = new System.Drawing.Size(280, 35);
            this.cbxItems.TabIndex = 17;
            this.cbxItems.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Crimson;
            this.label4.Location = new System.Drawing.Point(650, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 27);
            this.label4.TabIndex = 16;
            this.label4.Text = "Ürün Seç:";
            // 
            // btnItems
            // 
            this.btnItems.Appearance.Font = new System.Drawing.Font("Century", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItems.Appearance.Options.UseFont = true;
            this.btnItems.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnItems.ImageOptions.SvgImage = global::Sales__Managment.Properties.Resources.movedown;
            this.btnItems.Location = new System.Drawing.Point(1107, 183);
            this.btnItems.LookAndFeel.SkinName = "Office 2013 Dark Gray";
            this.btnItems.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnItems.Name = "btnItems";
            this.btnItems.Size = new System.Drawing.Size(159, 81);
            this.btnItems.TabIndex = 18;
            this.btnItems.Text = "F2";
            this.btnItems.Click += new System.EventHandler(this.btnItems_Click);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Appearance.Font = new System.Drawing.Font("Century", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteItem.Appearance.Options.UseFont = true;
            this.btnDeleteItem.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnDeleteItem.ImageOptions.SvgImage = global::Sales__Managment.Properties.Resources.del;
            this.btnDeleteItem.Location = new System.Drawing.Point(1288, 183);
            this.btnDeleteItem.LookAndFeel.SkinName = "Office 2013 Dark Gray";
            this.btnDeleteItem.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(159, 81);
            this.btnDeleteItem.TabIndex = 19;
            this.btnDeleteItem.Text = "Del";
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // DtpDate
            // 
            this.DtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpDate.Location = new System.Drawing.Point(1193, 114);
            this.DtpDate.Name = "DtpDate";
            this.DtpDate.Size = new System.Drawing.Size(254, 34);
            this.DtpDate.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(258, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 29);
            this.label6.TabIndex = 23;
            this.label6.Text = "F1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(182, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(403, 29);
            this.label5.TabIndex = 24;
            this.label5.Text = "Ödemek ve faturyaı saklmak için F12 ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(182, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(439, 29);
            this.label7.TabIndex = 25;
            this.label7.Text = "Miktarı yada İndirmi Düzeltmek için F11";
            // 
            // DgvBuy
            // 
            this.DgvBuy.AllowUserToAddRows = false;
            this.DgvBuy.AllowUserToDeleteRows = false;
            this.DgvBuy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvBuy.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvBuy.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.DgvBuy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvBuy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.DgvBuy.Location = new System.Drawing.Point(17, 282);
            this.DgvBuy.Name = "DgvBuy";
            this.DgvBuy.ReadOnly = true;
            this.DgvBuy.RowHeadersWidth = 62;
            this.DgvBuy.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.DgvBuy.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
            this.DgvBuy.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightGray;
            this.DgvBuy.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.DgvBuy.RowTemplate.Height = 28;
            this.DgvBuy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvBuy.Size = new System.Drawing.Size(1430, 694);
            this.DgvBuy.TabIndex = 26;
            this.DgvBuy.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvBuy_CellValueChanged);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 30F;
            this.Column1.HeaderText = "Ürün NO";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Ürünün Adı";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 25F;
            this.Column3.HeaderText = "Miktar";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 25F;
            this.Column4.HeaderText = "Fiyat";
            this.Column4.MinimumWidth = 8;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 27F;
            this.Column5.HeaderText = "İndirim";
            this.Column5.MinimumWidth = 8;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.FillWeight = 40F;
            this.Column6.HeaderText = "Toplam Fiyat";
            this.Column6.MinimumWidth = 8;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 1019);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(166, 27);
            this.label8.TabIndex = 27;
            this.label8.Text = "Kullanıcın Adı:";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(182, 1019);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(30, 27);
            this.lblUserName.TabIndex = 28;
            this.lblUserName.Text = "...";
            // 
            // lblItemsCount
            // 
            this.lblItemsCount.AutoSize = true;
            this.lblItemsCount.Location = new System.Drawing.Point(195, 1082);
            this.lblItemsCount.Name = "lblItemsCount";
            this.lblItemsCount.Size = new System.Drawing.Size(30, 27);
            this.lblItemsCount.TabIndex = 30;
            this.lblItemsCount.Text = "...";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 1082);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(177, 27);
            this.label11.TabIndex = 29;
            this.label11.Text = "Sınıfların Adeti:";
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Century", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(1023, 1016);
            this.txtTotal.Multiline = true;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(424, 103);
            this.txtTotal.TabIndex = 32;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Crimson;
            this.label12.Location = new System.Drawing.Point(895, 1057);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(122, 33);
            this.label12.TabIndex = 33;
            this.label12.Text = "Toplam:";
            // 
            // rbtnCash
            // 
            this.rbtnCash.AutoSize = true;
            this.rbtnCash.Checked = true;
            this.rbtnCash.Location = new System.Drawing.Point(303, 1019);
            this.rbtnCash.Name = "rbtnCash";
            this.rbtnCash.Size = new System.Drawing.Size(174, 31);
            this.rbtnCash.TabIndex = 34;
            this.rbtnCash.TabStop = true;
            this.rbtnCash.Text = "Nakit Ödeme";
            this.rbtnCash.UseVisualStyleBackColor = true;
            this.rbtnCash.CheckedChanged += new System.EventHandler(this.rbtnCash_CheckedChanged);
            // 
            // rbtnAagal
            // 
            this.rbtnAagal.AutoSize = true;
            this.rbtnAagal.Location = new System.Drawing.Point(303, 1080);
            this.rbtnAagal.Name = "rbtnAagal";
            this.rbtnAagal.Size = new System.Drawing.Size(162, 31);
            this.rbtnAagal.TabIndex = 35;
            this.rbtnAagal.Text = "Borç Ödeme";
            this.rbtnAagal.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Crimson;
            this.label13.Location = new System.Drawing.Point(471, 1086);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(144, 23);
            this.label13.TabIndex = 36;
            this.label13.Text = "Ödeme Tarihi:";
            // 
            // DtpAagal
            // 
            this.DtpAagal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpAagal.Location = new System.Drawing.Point(475, 1123);
            this.DtpAagal.Name = "DtpAagal";
            this.DtpAagal.Size = new System.Drawing.Size(254, 34);
            this.DtpAagal.TabIndex = 37;
            // 
            // Frm_Buy
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1453, 1207);
            this.Controls.Add(this.DtpAagal);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.rbtnAagal);
            this.Controls.Add(this.rbtnCash);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblItemsCount);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.DgvBuy);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DtpDate);
            this.Controls.Add(this.btnDeleteItem);
            this.Controls.Add(this.btnItems);
            this.Controls.Add(this.cbxItems);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSupplierBrowes);
            this.Controls.Add(this.cbxSupplier);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.Name = "Frm_Buy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Satın Alınanlar";
            this.Load += new System.EventHandler(this.Frm_Buy_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Buy_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DgvBuy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btnSupplierBrowes;
        private System.Windows.Forms.ComboBox cbxItems;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton btnItems;
        private DevExpress.XtraEditors.SimpleButton btnDeleteItem;
        private System.Windows.Forms.DateTimePicker DtpDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblItemsCount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton rbtnCash;
        private System.Windows.Forms.RadioButton rbtnAagal;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker DtpAagal;
        public System.Windows.Forms.ComboBox cbxSupplier;
        public System.Windows.Forms.DataGridView DgvBuy;
    }
}