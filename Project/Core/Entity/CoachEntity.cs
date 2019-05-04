using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    [Table(Name = "Coachs")]
    public class CoachEntity
    {
        [Column(IsDbGenerated = true, CanBeNull = false)]
        public int Id { get; set; }
        [Column]
        public string CoachCode { get; set; }
        [Column]
        public string CoachName { get; set; }
        [Column]
        public string Username { get; set; }
        [Column]
        public string Password { get; set; }
    }
}
