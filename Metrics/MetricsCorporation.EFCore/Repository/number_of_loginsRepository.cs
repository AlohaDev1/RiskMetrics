using System;
using System.Collections.Generic;
using System.Linq;
using MetricsCorporation.Entities;

namespace MetricsCorporation.EFCore.Repository
{
    public partial class number_of_loginsRepository
    {
        public number_of_logins GetByIdAndDate(int userId, DateTime date)
        {
            var items = from p in Items
                        where p.user_id == userId &&
                        p.login_date.Year == date.Year &&
                        p.login_date.Month == date.Month &&
                        p.login_date.Day == date.Day
                        select p;



            return items.FirstOrDefault();
        }

        public IEnumerable<number_of_logins> GetByUserId(int userId)
        {
            return Items.Where(u => u.user_id == userId);
        }
    }
}
