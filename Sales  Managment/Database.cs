using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;



namespace Sales__Managment
{
    class Database
    {
        //Connection to database
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-164KRHE;Initial Catalog=Sales_System;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        //Read data from database
        //stmt daha sorna girilecek komut database göndermek için kullandık
        //select
        public DataTable readData(string stmt, string message)
        {

            DataTable tbl = new DataTable();
            /*
                try kullanıcı yanlış bir şey girerse programa bir hata çıkar ama ya program kendiliğinden kapatır yada
                kullanıcıya anlaşılmaz bri hata çıkarır programa o yüzden try'daki komutlarda bir hata çıkarsa catch'e gönderir 
            catch'ta isdeiğimiz şeyi yazarız.
             */
            try
            {
                cmd.Connection = conn;
                //burda daha sonra alacağımız stmt komutu database gönderir
                cmd.CommandText = stmt;
                //database açar
                conn.Open();
                //cmd komutu okur ve load to tbl(database)
                tbl.Load(cmd.ExecuteReader());
                // database kapatır..
                conn.Close();

                if (message != "")
                {
                    MessageBox.Show(message, "Onay", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            //ex Exception'den ex'i alırız ve gösterilen hatayı messagebox'ta gösterir
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
    
            return tbl;
        }

        // insert upadte delete
        public bool exceuteData(string stmt, string message)
        {
            try
            {
                cmd.Connection = conn;
                //burda daha sonra alacağımız stmt komutu database gönderir
                cmd.CommandText = stmt;
                //database açar

                conn.Open();

                cmd.ExecuteNonQuery();
                conn.Close();
                if (message != "")
                {
                    MessageBox.Show(message, "Onay", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                return true;

            }
            catch(Exception ex)
            {
                return false;
            }


        }
    }
}
