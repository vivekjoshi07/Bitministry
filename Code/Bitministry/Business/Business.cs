using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitministry.Entity;
using Bitministry.DataAccess;

namespace Bitministry.Business
{
    public class BusinessClass
    {
        public int DepositeAmount(UserInfo objUserDeatil)
        {
            DataAccessClass objDataAccess = new DataAccessClass();
            return objDataAccess.DepositeAmount(objUserDeatil);
        }

        public List<UserInfo> GetAllUser(string flag)
        {
            DataAccessClass objDataAccess = new DataAccessClass();
            return objDataAccess.GetAllUser(flag);
        }

        public decimal GetCurrentBalance(UserInfo objUserDeatil)
        {
            DataAccessClass objDataAccess = new DataAccessClass();
            return objDataAccess.GetCurrentBalance(objUserDeatil);
        }

        public List<UserInfo> GetStatement(UserInfo objUserDeatil)
        {
            DataAccessClass objDataAccess = new DataAccessClass();
            return objDataAccess.GetStatement(objUserDeatil);
        }

        public int TransferAmount(UserInfo objUserDeatil)
        {
            DataAccessClass objDataAccess = new DataAccessClass();
            return objDataAccess.TransferAmount(objUserDeatil);
        }

        public int WithdrawAmount(UserInfo objUserDeatil)
        {
            DataAccessClass objDataAccess = new DataAccessClass();
            return objDataAccess.WithdrawAmount(objUserDeatil);
        }
    }
}
