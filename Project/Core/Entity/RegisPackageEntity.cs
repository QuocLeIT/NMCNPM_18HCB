using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace Core.Entity
{
     [Table(Name = "DMDangKyGoiTap")]
    public class RegisPackageEntity
    {
        [Column(IsDbGenerated = true, CanBeNull = false, IsPrimaryKey = true)]
        public long ID { get; set; }

        [Column]
        public long IDGoiTap { get; set; }
        [Column]
        public long IDUser { get; set; }
        [Column]
        public DateTime NgayDK { get; set; }
        [Column]
        public DateTime NgayHH { get; set; }
        [Column]
        public string GhiChu { get; set; }

        [Column]
        public bool IsBaoLuu { get; set; }
          [Column]
        public DateTime NgayBaoLuu { get; set; }
     
        [Column]
        public decimal Price { get; set; }
        [Column]
        public int Quantity { get; set; }
        [Column]
        public decimal Total { get; set; }

        public RegisPackageEntity()
        {
            ID = -1;
            IDGoiTap = -1;
            IDUser = -1;

            NgayDK = DateTime.Now.Date;
            GhiChu = "";

            Price = 0;
            Quantity = 0;
            Total = 0;     
        }

        public RegisPackageEntity(long _IDGoiTap, long _IDUser, DateTime _NgayDK, string _GhiChu, decimal _Price, int _Quantity, decimal _Total)
        {
            IDGoiTap = _IDGoiTap;
            IDUser = _IDUser;

            NgayDK = _NgayDK;
            GhiChu = _GhiChu;

            Price = _Price;
            Quantity = _Quantity;
            Total = _Total;  

        }

        public RegisPackageEntity(long _ID, long _IDGoiTap, long _IDUser, DateTime _NgayDK, string _GhiChu, decimal _Price, int _Quantity, decimal _Total)
        {
            ID = _ID;

            IDGoiTap = _IDGoiTap;
            IDUser = _IDUser;

            NgayDK = _NgayDK;
            GhiChu = _GhiChu;

            Price = _Price;
            Quantity = _Quantity;
            Total = _Total; 
        }
    }
}
