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
        [Column(IsDbGenerated =true, CanBeNull =false,IsPrimaryKey =true)]
        public long  ID { get; set; }
        [Column(CanBeNull =false)]
        public string Name { get; set; }
        [Column]
        public int? NamSinh { get; set; }
        [Column]
        public string DiaChi { get; set; }
        [Column]
        public string Email { get; set; }
        [Column]
        public string Phone { get; set; }
        [Column(CanBeNull =false)]
        public int IDLoaiUser { get; set; }
        [Column]
        public string Username { get; set; }
        [Column]
        public string Pass { get; set; }
        [Column]
        public decimal Luong { get; set; }

        public UserEntity()
        {
            ID = -1;       
            NamSinh = 0;      
            IDLoaiUser = 0;
            Luong = 0;
            Username = "";
            Pass = "";
        }

        public UserEntity(long _id, string _name, int _namSinh, string _diaChi, string _email, string _phone, int _idLoaiUser, string _usename, decimal _luong)
        {
            ID = _id;
            Name = _name;
            NamSinh = _namSinh;
            DiaChi = _diaChi;
            Email = _email;
            Phone = _phone;
            IDLoaiUser = _idLoaiUser;
            Username = _usename;
            Luong = _luong;
        }
    }
}
