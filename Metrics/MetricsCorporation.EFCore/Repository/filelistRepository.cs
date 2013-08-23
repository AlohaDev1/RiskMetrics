using System.Linq;
using MetricsCorporation.Entities;

namespace MetricsCorporation.EFCore.Repository
{
    public partial class filelistRepository
    {
        public filelist Login(string username, string password)
        {
            var item = from p in Items
                       where p.username == username && p.password == password
                       select p;

            if (item.Any())
            {
                return item.FirstOrDefault();
            }

            return new filelist();
        }

        public filelist GetByUserName(string username)
        {
            var item = from p in Items
                       where p.username == username
                       select p;

            if (item.Any())
            {
                return item.FirstOrDefault();
            }

            return new filelist();
        }
    }
}
