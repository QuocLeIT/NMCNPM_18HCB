using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Provider;
using System.Data;

namespace Service
{
    public class UserService
    {
        

        //linq
        public static List<UserEntity> GetAll()
        {
            try
            {
                using (var db = new DataContext())
                {
                    return (from u in db.Users select u).ToList();
                }
            }
            catch (Exception ex)
            {
                return GetAll_2();
            }
            
        }

        public static UserEntity GetByUsername(string Username)
        {
            using (var db = new DataContext())
            {
                return (from u in db.Users where u.Username == Username select u).FirstOrDefault();
            }
        }

        //User DataProvider connect
        public static List<UserEntity> GetAll_2()
        {
            DataProvider dp = new DataProvider();
            List<UserEntity> lus = new List<UserEntity>();

            DataTable tb = dp.Fillbang("select ID, Name, NamSinh, DiaChi, Email, Phone, IDLoaiUser, Username, Pass, Luong from DMUserNames where ID > 1 order by Name ");
            if (tb.Rows.Count > 0)
            {
                UserEntity us = new UserEntity(Int64.Parse(tb.Rows[0]["ID"].ToString()), tb.Rows[0]["Name"].ToString(), int.Parse(tb.Rows[0]["NamSinh"].ToString()), 
                        tb.Rows[0]["DiaChi"].ToString(), tb.Rows[0]["Email"].ToString(),tb.Rows[0]["Phone"].ToString(), int.Parse(tb.Rows[0]["IDLoaiUser"].ToString()),
                        tb.Rows[0]["Username"].ToString(), decimal.Parse(tb.Rows[0]["Luong"].ToString()));

                lus.Add(us);
            }

            return lus;
        }


        public static UserEntity GetByUsername(string Username, string passMD5)
        {
            DataProvider dp = new DataProvider();
            UserEntity us = new UserEntity();
           
            DataTable tb = dp.Fillbang("select ID, Name, NamSinh, DiaChi, Email, Phone, IDLoaiUser, Username, Pass, Luong from DMUserNames where Username = N'"+ Username +"' and Pass = N'"+ passMD5 +"' ");
            if (tb.Rows.Count > 0)
            {           
                us.ID = Int64.Parse(tb.Rows[0]["ID"].ToString());
                us.Name = tb.Rows[0]["Name"].ToString();
                us.IDLoaiUser = int.Parse(tb.Rows[0]["IDLoaiUser"].ToString());
                us.Username = Username;
                us.Pass = tb.Rows[0]["Pass"].ToString();

                us.DiaChi = tb.Rows[0]["DiaChi"].ToString();
                us.Email = tb.Rows[0]["Email"].ToString();
                us.Phone = tb.Rows[0]["Phone"].ToString();

                if (tb.Rows[0]["NamSinh"].ToString() != "")
                {
                    us.NamSinh = int.Parse(tb.Rows[0]["NamSinh"].ToString());
                }

                if (tb.Rows[0]["Luong"].ToString() != "")
                {
                    us.Luong = decimal.Parse(tb.Rows[0]["Luong"].ToString());
                }               
            }
          
            return us;
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
