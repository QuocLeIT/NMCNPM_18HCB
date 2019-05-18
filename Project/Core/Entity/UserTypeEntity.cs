using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    [Table(Name = "DMLoaiUsers")]
    public class UserTypeEntity
    {
        [Column(IsDbGenerated = true, CanBeNull = false)]
        public int ID { get; set; }
        [Column(CanBeNull =false)]
        public string Name { get; set; }
    }
}
