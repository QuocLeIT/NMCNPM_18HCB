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
    public class CoachContext: DataContext
    {
        [Function(Name = "[Coachs.Getlist]")]
        public IEnumerable<CoachEntity> Getlist(string CoachCode)
        {
            var result = this.ExecuteMethodCall(this, (MethodInfo)MethodBase.GetCurrentMethod(), CoachCode);
            var list = (IEnumerable<CoachEntity>) result.ReturnValue;
            return list;
        }
        [Function(Name = "[Coachs.Getlist]")]
        public DataTable GetDataTable(string CoachCode)
        {
            var dt = ExecuteDatatable((MethodInfo)MethodBase.GetCurrentMethod(), CoachCode);
            return dt;
        }
        [Function(Name = "[Coachs.Getlist]")]
        public DataSet GetDataSet(string CoachCode)
        {
            return ExecuteDataset((MethodInfo)MethodBase.GetCurrentMethod(), CoachCode);
        }
    }
}
