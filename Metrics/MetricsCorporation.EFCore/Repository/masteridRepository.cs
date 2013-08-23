using System.Linq;
using MetricsCorporation.Entities;

namespace MetricsCorporation.EFCore.Repository
{
    public partial class masteridRepository
    {
        public masterid Login(string username, string password)
        {
            var item = from p in Items
                       where p.uername == username && p.password == password
                       select p;

            if (item.Any())
            {
                return item.FirstOrDefault();
            }

            return new masterid();
        }

        public masterid GetByUserName(string username)
        {
            var item = from p in Items
                       where p.uername == username
                       select p;

            if (item.Any())
            {
                return item.FirstOrDefault();
            }

            return new masterid();
        }
    }
}
