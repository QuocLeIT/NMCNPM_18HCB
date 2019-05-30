using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace Core.Entity
{
    [Table(Name = "DMGoiTap")]
    public class PackageEntity
    {
        [Column(IsDbGenerated = true, CanBeNull = false, IsPrimaryKey = true)]
        public long ID { get; set; }
        [Column(CanBeNull = false)]
        public string Name { get; set; }
        [Column]
        public int? ThoiGian { get; set; }
        [Column]
        public string GhiChu { get; set; }
        [Column]
        public decimal Price { get; set; }

        public PackageEntity()
        {
            ID = -1;
            Name = "";
            ThoiGian = 0;
            GhiChu = "";
            Price = 0;     
        }

        public PackageEntity( string _name, int _thoiGian, string _ghiChu, decimal _Price)
        {
           
            Name = _name;
            ThoiGian = _thoiGian;
            GhiChu = _ghiChu;
            Price = _Price;

        }

        public PackageEntity(long _id, string _name, int _thoiGian, string _ghiChu, decimal _Price)
        {
            ID = _id;
            Name = _name;
            ThoiGian = _thoiGian;
            GhiChu = _ghiChu;
            Price = _Price;
          
        }

    }
}
