using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MyLibrary1
{
    public class DBConnect
    {
        SqlConnection con;

        public SqlConnection Con
        {
            get { return con; }
            set { con = value; }
        }
        string strCon;

        public string StrCon
        {
            get { return strCon; }
            set { strCon = value; }
        }
        private DataSet dset;

        public DataSet Dset
        {
            get { return dset; }
            set { dset = value; }
        }

        public DBConnect(string dbName,string sever,string csdl,string user,string pass)
        {
            //DESKTOP-UIRG88N\SQLEXPRESS

            StrCon = @"Data Source ="+sever+";Initial Catalog="+csdl+";User ID="+user+";Password="+pass+"";

            Con = new SqlConnection(StrCon);
            Dset = new DataSet(dbName);
        }
        public DBConnect(string strCon, string dbName)
        {
            StrCon = @strCon;
            Con = new SqlConnection(StrCon);
            Dset = new DataSet(dbName);
        }
        public void openConnection()
        {
            if (Con.State == ConnectionState.Closed)
                Con.Open();
        }
        public void closeConnection()
        {
            if (Con.State == ConnectionState.Open)
                Con.Close();
        }
        public void disposeConnection()
        {
            closeConnection();
            Con.Dispose();
        }
        public void updeteToDB(string strSQL)
        {
            openConnection();
            //them,xoa,sua du lieu
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strSQL;
            cmd.Connection = Con;
            cmd.ExecuteNonQuery();

            closeConnection();

        }
        public int getCount(string strSQL)
        {
            openConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strSQL;
            cmd.Connection = Con;
            int count = (int)cmd.ExecuteScalar();

            closeConnection();

            return count;
        }
        public bool checkForExistence(string strSQL)
        {
            int count = getCount(strSQL);
            if (count > 0)
                return true;
            return false;
        }
        public SqlDataReader getDataReader(string strSQL)
        {
            openConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strSQL;
            cmd.Connection = Con;
            SqlDataReader dr = cmd.ExecuteReader();



            return dr;
        }
        public DataTable getDataTable(string strSQL, string tblName)
        {
            //Trả về 1 table
            openConnection();

            SqlDataAdapter ada = new SqlDataAdapter(strSQL, Con);
            ada.Fill(Dset, tblName);
            closeConnection();

            return Dset.Tables[tblName];
        }
        public SqlDataAdapter getDataAdapter(string strSQL, string tblName)
        {
            //Trả về 1 table
            openConnection();

            SqlDataAdapter ada = new SqlDataAdapter(strSQL, Con);
            ada.Fill(Dset, tblName);
            closeConnection();

            return ada;
        }

        public DataTable getTable(string sql)
        {
            openConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            closeConnection();
            return dt;
        }







    }
}
