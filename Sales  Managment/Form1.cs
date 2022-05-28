using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Sales__Managment
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Thread t;
        public Form1()
        {
            InitializeComponent();
            try
            {
                t = new Thread(new ThreadStart(StartSplash));
                t.Start();
                Thread.Sleep(5000);
                t.Abort();
            }
            catch (Exception)
            {

            }
            
        }

        private void StartSplash()
        {
            try
            {
                Application.Run(new Splash());
            }
            catch (Exception)
            {

            }
        }
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Customer frm = new Frm_Customer();
            frm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Suppliers frm = new Frm_Suppliers();
            frm.ShowDialog();
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_DesservedType frm = new Frm_DesservedType();
            frm.ShowDialog();
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Deserved frm = new Frm_Deserved();
            frm.ShowDialog();
        }

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_DeservedReport frm = new Frm_DeservedReport();
            frm.ShowDialog();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Products frm = new Frm_Products();
            frm.ShowDialog();
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Buy frm = new Frm_Buy();
            frm.ShowDialog();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Setting frm = new Frm_Setting();
            frm.ShowDialog();
        }
    }
}
