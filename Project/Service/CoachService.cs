using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using System.Data;

namespace Service
{
    public class CoachService
    {
        //linq
        public static List<CoachEntity> GetAll()
        {
            using (var db = new DataContext())
            {
                return (from c in db.Coachs select c).ToList();
            }
        }
        public static CoachEntity GetByUsername(string Username)
        {
            using (var db = new DataContext())
            {
                return (from c in db.Coachs where c.Username == Username select c).FirstOrDefault();
            }
        }
        //Store Procedure
        public static List<CoachEntity> GetList(string CoachCode)
        {
            using (var db = new CoachContext())
            {
                return db.Getlist(CoachCode).ToList();
            }
        }
        public static DataTable GetDataTable(string CoachCode)
        {
            using (var db = new CoachContext())
            {
                return db.GetDataTable(CoachCode);
            }
        }
        public static DataSet GetDataSet(string CoachCode)
        {
            using (var db = new CoachContext())
            {
                return db.GetDataSet(CoachCode);
            }
        }
    }
}
