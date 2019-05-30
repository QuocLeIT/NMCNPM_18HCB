using Core.Entity;
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
    public class PackageContext : DataContext
    {
        [Function(Name = "[Package.Getlist]")]
        public DataTable GetDataTable(string PackageCode)
        {
            return ExecuteDatatable((MethodInfo)MethodBase.GetCurrentMethod(), PackageCode);
        }
    }
}
