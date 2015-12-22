using Bitministry.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Bitministry.DataAccess
{

    public class DataAccessClass
    {
        string ConnString = System.Configuration.ConfigurationManager.ConnectionStrings["ConStringName"].ToString();
        public DataAccessClass()
        {
            
        }


        public int DepositeAmount(UserInfo objUserDeatil)
        {
            SqlConnection objcon = new SqlConnection(ConnString);
            objcon.Open();
            string sqlstr = "Insert into [Transaction] values (" + objUserDeatil.UserID + ","+ objUserDeatil.Amount +")";
            SqlCommand objcmd = new SqlCommand(sqlstr, objcon);
            int iresult= objcmd.ExecuteNonQuery();
            objcon.Close();
            return iresult;
        }

        public List<UserInfo> GetAllUser(string flag)
        {
            List<UserInfo> objlstUser = new List<UserInfo>();
           
            SqlConnection objcon = new SqlConnection(ConnString);
            objcon.Open();
            string sqlstr = "Select Username,UserID from BankAccount";
            SqlCommand objcmd = new SqlCommand(sqlstr, objcon);
            using (SqlDataReader reader = objcmd.ExecuteReader())
            {

                while(reader.Read())
                {
                    UserInfo objUsr = new UserInfo();
                    objUsr.UserName = reader["UserName"] is DBNull ? null : reader["UserName"].ToString();
                    objUsr.UserID = reader["UserId"] is DBNull ? 0 : Convert.ToInt32(reader["UserId"].ToString());
                    objlstUser.Add(objUsr);
                }
               
            }
            return objlstUser;
        }

        public decimal GetCurrentBalance(UserInfo objUserDeatil)
        {
            return BalanceAmount(objUserDeatil.UserID);
        }

        public List<UserInfo> GetStatement(UserInfo objUserDeatil)
        {
            List<UserInfo> objlstUser = new List<UserInfo>();

            SqlConnection objcon = new SqlConnection(ConnString);
            objcon.Open();
            string sqlstr = "Select isnull(Amount,0) Amount from [Transaction] where UserId=" + objUserDeatil.UserID  ;
            SqlCommand objcmd = new SqlCommand(sqlstr, objcon);
            using (SqlDataReader reader = objcmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    UserInfo objUsr = new UserInfo();
                    objUsr.Amount = reader["Amount"] is DBNull ? 0 : Convert.ToDecimal(reader["Amount"].ToString());
                    objUsr.Status= Convert.ToDecimal(reader["Amount"].ToString()) >0 ? "Deposit" : "Withdraw" ;
                    objlstUser.Add(objUsr);
                }

            }
            return objlstUser;
        }

        public int TransferAmount(UserInfo objUserDeatil)
        {
            decimal dbalance = BalanceAmount(objUserDeatil.UserID);
            if (dbalance > 0 && dbalance >= objUserDeatil.Amount)
            {
                SqlConnection objcon = new SqlConnection(ConnString);
                objcon.Open();
                decimal amountwithdor = objUserDeatil.Amount * -1;
                string sqlstr = "Insert into [Transaction] values (" + objUserDeatil.UserID + "," + amountwithdor + ")";
                SqlCommand objcmd = new SqlCommand(sqlstr, objcon);
                int iresult = objcmd.ExecuteNonQuery();
                sqlstr = "Insert into [Transaction] values (" + objUserDeatil.TransferUserID + "," + objUserDeatil.Amount + ")";
                objcmd = new SqlCommand(sqlstr, objcon);
                iresult = objcmd.ExecuteNonQuery();
                objcon.Close();
                return iresult;
            }
            else
                return 0;
        }

        private decimal BalanceAmount(int userid)
        {
            SqlConnection objcon = new SqlConnection(ConnString);
            objcon.Open();
            string sqlstr = "Select isnull(sum(Amount),0) from [Transaction] where UserId=" + userid;
            SqlCommand objcmd = new SqlCommand(sqlstr, objcon);
            decimal iresult = (decimal)(objcmd.ExecuteScalar());
            objcon.Close();
            return iresult;
        }

        public int WithdrawAmount(UserInfo objUserDeatil)
        {
             decimal dbalance = BalanceAmount(objUserDeatil.UserID);
             if (dbalance > 0 && dbalance >= objUserDeatil.Amount)
             {
                 SqlConnection objcon = new SqlConnection(ConnString);
                 objcon.Open();
                 decimal amountwithdor = objUserDeatil.Amount * -1;
                 string sqlstr = "Insert into [Transaction] values (" + objUserDeatil.UserID + "," + amountwithdor + ")";
                 SqlCommand objcmd = new SqlCommand(sqlstr, objcon);
                 int iresult = objcmd.ExecuteNonQuery();
                 objcon.Close();
                 return iresult;
             }
             else
                 return 0;
        }
    }
}
