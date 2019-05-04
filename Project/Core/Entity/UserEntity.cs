using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace Core.Entity
{
    [Table(Name = "DMUserNames")]
    public class UserEntity
    {
        [Column(IsDbGenerated =true, CanBeNull =false)]
        public long  ID { get; set; }
        [Column(CanBeNull =false)]
        public string Name { get; set; }
        [Column]
        public int NamSinh { get; set; }
        [Column]
        public string DiaChi { get; set; }
        [Column]
        public string Email { get; set; }
        [Column]
        public string Phone { get; set; }
        [Column]
        public int IDLoaiUser { get; set; }
        [Column]
        public string Username { get; set; }
        [Column]
        public string Pass { get; set; }
        [Column]
        public decimal Luong { get; set; }
    }
}
