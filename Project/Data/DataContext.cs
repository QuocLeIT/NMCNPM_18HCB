using Core.Entity;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public partial class DataContext : BaseDataContext
    {
        public DataContext()
        {

        }
        public DataContext(string ConnectionStrings)
            : base(ConnectionStrings)
        {

        }
        public Table<CoachEntity> Coachs { get { return GetTable<CoachEntity>(); } }
        public Table<UserEntity> Users { get { return GetTable<UserEntity>(); } }
        public Table<UserTypeEntity> UserType { get { return GetTable<UserTypeEntity>(); } }
        public Table<PackageEntity> Packages { get { return GetTable<PackageEntity>(); } }
    }
}
