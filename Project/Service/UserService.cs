using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Service
{
    public class UserService
    {
        //linq
        public static List<UserEntity> GetAll()
        {
            using (var db = new DataContext())
            {
                return (from u in db.Users select u).ToList();
            }
        }

        public static UserEntity GetByUsername(string Username)
        {
            using (var db = new DataContext())
            {
                return (from u in db.Users where u.Username == Username select u).FirstOrDefault();
            }
        }
        //public static CoachEntity GetByUsername(string Username)
        //{
        //    using (var db = new DataContext())
        //    {
        //        return (from c in db.Coachs where c.Username == Username select c).FirstOrDefault();
        //    }
        //}
        ////Store Procedure
        //public static List<CoachEntity> GetList(string CoachCode)
        //{
        //    using (var db = new CoachContext())
        //    {
        //        return db.Getlist(CoachCode).ToList();
        //    }
        //}
        //public static DataTable GetDataTable(string CoachCode)
        //{
        //    using (var db = new CoachContext())
        //    {
        //        return db.GetDataTable(CoachCode);
        //    }
        //}
        //public static DataSet GetDataSet(string CoachCode)
        //{
        //    using (var db = new CoachContext())
        //    {
        //        return db.GetDataSet(CoachCode);
        //    }
        //}
    }
}
