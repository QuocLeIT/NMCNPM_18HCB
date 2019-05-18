using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UserContext : DataContext
    {
        [Function(Name = "[User.GetDynamic]")]
        public DataTable GetDynamic(string Username, string Phone, string Email, int? Usertype,int? RowPerPage, int? PageNumber)
        {
            return ExecuteDatatable((MethodInfo)MethodBase.GetCurrentMethod(), Username, Phone, Email, Usertype, RowPerPage, PageNumber);
        }
    }
}
