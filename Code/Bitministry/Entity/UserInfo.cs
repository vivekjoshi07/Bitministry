using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace Bitministry.Entity
{
    public class UserInfo
    {
       
        public string UserName { get; set; }
        public Int32 UserID { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }

        public Int32 TransferUserID { get; set; }
    }
}
