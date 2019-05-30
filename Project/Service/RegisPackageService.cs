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
    public class RegisPackageService
    {
        //Sp_GetAll_RegisPackage
        public static DataTable GetAll()
        {
            DataProvider dp = new DataProvider();
            return dp.ReadDataNoParam("Sp_GetAll_RegisPackage", 100);
        }

        public static void Insert(RegisPackageEntity regis)
        {
            DataProvider dp = new DataProvider();

            string[] str = new string[9];
            object[] val = new object[9];

            str[0] = "@IDUser";
            str[1] = "@IDGoiTap";
            str[2] = "@NgayDK";
            str[3] = "@NgayHH";
            str[4] = "@GhiChu";
            str[5] = "@Price";
            str[6] = "@Quantity";
            str[7] = "@Total";

            val[0] = regis.IDUser;
            val[1] = regis.IDGoiTap;
            val[2] = regis.NgayDK;
            val[3] = regis.NgayHH;
            val[4] = regis.GhiChu;
            val[5] = regis.Price;
            val[6] = regis.Quantity;
            val[7] = regis.Total;

            if (regis.ID > 0)
            {
                //update
                str[8] = "@ID";
                val[8] = regis.ID;

                dp.WriteDataAddParam("sp_UpdateRegisPackage", str, val, 50);
            }
            else
            { 
                //insert
                dp.WriteDataAddParam("sp_InsertRegisPackage", str, val, 50);
            }
        }

        public static void Update(RegisPackageEntity regis)
        {
            Insert(regis);
        }

        public static int Delete(int id)
        {
            DataProvider dp = new DataProvider();
            return dp.MyExecuteNonQuery("Delete from DMDangKyGoiTap where ID = " + id.ToString());
        }

        public static RegisPackageEntity GetById(int Id)
        {
            DataProvider dp = new DataProvider();
            DataTable tb;
            tb = dp.Fillbang("select * from DMDangKyGoiTap where ID = " + Id.ToString());

            RegisPackageEntity pk = new RegisPackageEntity()
            {
                ID = Convert.ToInt16(tb.Rows[0]["ID"].ToString()),

                IDGoiTap = Convert.ToInt16(tb.Rows[0]["IDGoiTap"].ToString()),
                IDUser = Convert.ToInt16(tb.Rows[0]["IDUser"].ToString()),

                NgayDK = DateTime.Parse(tb.Rows[0]["NgayDangKy"].ToString()),
                NgayHH = DateTime.Parse(tb.Rows[0]["NgayHetHan"].ToString()),
                GhiChu = tb.Rows[0]["GhiChu"].ToString(),

                Price = Convert.ToDecimal(tb.Rows[0]["Price"].ToString()),
                Quantity = Convert.ToInt16(tb.Rows[0]["Quantity"].ToString()),
                Total = Convert.ToDecimal(tb.Rows[0]["Total"].ToString()),         
            };

            return pk;

        }
    }
}
