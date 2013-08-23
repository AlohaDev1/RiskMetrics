using System.Collections.Generic;
using System.Linq;
using MetricsCorporation.Entities;

namespace MetricsCorporation.EFCore.Repository
{
    public partial class user_statesRepository
    {
        public List<string> GetStatesByUserId(int userId)
        {
            var items = from p in Items
                        where p.userId == userId
                        select p.state_name;

            return items.ToList();
        }

        public List<user_states> GetUserStatesByUserId(int userId)
        {
            var items = from p in Items
                        where p.userId == userId
                        select p;

            return items.ToList();
        }

        public void DeleteByUserId(int userId)
        {
            var items = from p in Items
                        where p.userId == userId
                        select p.id;

            foreach (int id in items)
            {
                Delete(id);
            }
        }

        public void CreateByUserId(string states, int userId)
        {
            foreach (var state in states.Split(','))
            {
                if (!string.IsNullOrEmpty(state.Trim()))
                {
                    Insert(new user_states {state_name = state, userId = userId});
                }
            }
        }
    }
}
