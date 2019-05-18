using Core.Entity;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserTypeService
    {
        public static List<UserTypeEntity> GetAll(int? type)
        {
            using (var db = new DataContext())
            {
                if (type == 1)
                {
                    return (from t in db.UserType where t.Name != "Khách hàng" select t).ToList();
                }
                else if(type == 2)
                {
                    return (from t in db.UserType where t.Name == "Khách hàng" select t).ToList();
                }
                else
                {
                    return db.UserType.ToList();
                }
            }
        }
        public static UserTypeEntity GetById(int UserTypeId)
        {
            using (var db = new DataContext())
            {
                return (from t in db.UserType where t.ID == UserTypeId select t).FirstOrDefault();
            }
        }
    }
}
