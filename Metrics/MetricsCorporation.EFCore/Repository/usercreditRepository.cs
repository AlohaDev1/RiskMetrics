using System.Linq;
using MetricsCorporation.Entities;

namespace MetricsCorporation.EFCore.Repository
{
    public partial class usercreditRepository
    {
        public usercredit GetByUserId(int id)
        {
            var item = from p in Items
                       where p.user_id == id
                       select p;

            if (item.Any())
            {
                return item.FirstOrDefault();
            }

            return new usercredit();
        }
    }
}
