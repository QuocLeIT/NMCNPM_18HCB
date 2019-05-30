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
    public class PackageService
    {
        

        public static List<PackageEntity> GetAll()
        {
            using (var db = new DataContext())
            {
                return (from u in db.Packages select u).ToList();
            }
        }

        public static DataTable GetAll(string PackageCode)
        {
            using (var db = new PackageContext())
            {
                return db.GetDataTable(PackageCode);
            }
        }

        public static DataTable GetAll_2()
        {
            DataProvider dp = new DataProvider();
            return dp.Fillbang("select ID, Name, Price, ThoiGian, GhiChu from DMGoiTap order by Name");
        }

        public static void Insert(ref PackageEntity newUser)
        {
            using (var db = new DataContext())
            {
                newUser.ID = 0;
                db.Packages.InsertOnSubmit(newUser);
                db.SubmitChanges();
            }
        }

        public static void Update(PackageEntity UpdateInfo)
        {
            using (var db = new DataContext())
            {
                var UserUpdate = (from u in db.Packages where u.ID == UpdateInfo.ID select u).FirstOrDefault();
                if (UserUpdate != null)
                {
                    UserUpdate.Name = UpdateInfo.Name;
                    UserUpdate.ThoiGian = UpdateInfo.ThoiGian;
                    UserUpdate.Price = UpdateInfo.Price;
                    UserUpdate.GhiChu = UpdateInfo.GhiChu;
                  
                    db.SubmitChanges();
                }
            }
        }

        public static void Update_2(PackageEntity Info)
        {
            DataProvider dp = new DataProvider();
            dp.MyExecuteNonQuery("update DMGoiTap set Name = N'" + Info.Name + "', ThoiGian = " + Info.ThoiGian.ToString() + ", Price = " + Info.Price.ToString() + ", GhiChu = N'" + Info.GhiChu + "' where ID = " + Info.ID.ToString());
        }

        public static PackageEntity Delete(int UserId)
        {
          

            using (var db = new DataContext())
            {
                var UserDelete = (from u in db.Packages where u.ID == UserId select u).FirstOrDefault();
                if (UserDelete != null)
                {
                    db.Packages.DeleteOnSubmit(UserDelete);
                }
                db.SubmitChanges();
                return UserDelete;
            }
        }

        public static int Delete_2(int UserId)
        {
            DataProvider dp = new DataProvider();
            return dp.MyExecuteNonQuery("Delete from DMGoiTap where ID = " + UserId.ToString());   
        }

        public static PackageEntity GetById(int Id)
        {
            using (var db = new DataContext())
            {
                return (from u in db.Packages where u.ID == Id select u).FirstOrDefault();
            }
        }

        public static PackageEntity GetById_2(int Id)
        {
            DataProvider dp = new DataProvider();
            DataTable tb;
            tb = dp.Fillbang("select ID, Name, Price, ThoiGian, GhiChu from DMGoiTap where ID = " + Id.ToString());

            PackageEntity pk = new PackageEntity() { 
                ID = Convert.ToInt16(tb.Rows[0]["ID"].ToString()),
                Name = tb.Rows[0]["Name"].ToString(),
                Price = Convert.ToDecimal(tb.Rows[0]["Price"].ToString()),
                ThoiGian = Convert.ToInt16(tb.Rows[0]["ThoiGian"].ToString()),
                GhiChu = tb.Rows[0]["GhiChu"].ToString(),
            };

            return pk;

        }
    }
}
