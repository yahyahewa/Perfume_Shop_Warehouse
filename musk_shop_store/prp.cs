using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace musk_shop_store
{
    class prp
    {
        //public static OleDbConnection Connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Environment.CurrentDirectory + "\\db.accdb; Jet OLEDB:Database Password=sawen@07700307070#hi");
        //public static string categoreyName="";      

        OleDbDataReader dataReader;
        public static OleDbConnection Connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+Environment.CurrentDirectory+"\\database.accdb");     
        public static bool query(string query)
        {
            //MessageBox.Show(query);
            try
            {
                Connection.Close();
                Connection.Open();
                OleDbCommand cmd = new OleDbCommand(query, Connection);
                cmd.ExecuteNonQuery();
                Connection.Close();
                return true;
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); return false; }
        }
        ////////////////////////////////////////////////////
        public static int retNum(string query)
        {
            //MessageBox.Show(query);
            int ret = 0;
            try
            {
                Connection.Close();
                Connection.Open();
                OleDbCommand cmd = new OleDbCommand(query, Connection);
                OleDbDataReader dt= cmd.ExecuteReader();
                while(dt.Read())
                {
                    return dt.GetInt32(0);
                }
                Connection.Close();
                return ret;
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString());return ret; }
        }
    }
}
