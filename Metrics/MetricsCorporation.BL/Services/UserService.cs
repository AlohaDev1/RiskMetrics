using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.BL.Mapping;
using MetricsCorporation.Data;
using MetricsCorporation.Models;

namespace MetricsCorporation.BL.Services
{
    public class UserService : ICrud<UserModel>
    {
        private readonly Data.MetricsEntities _unit;
        private readonly object _locker = new object();
        private readonly IMapper _mapper;

        public UserService(IMapper mapper)
        {
            lock (_locker)
            {
                if (_unit == null)
                {
                    _unit = new Data.MetricsEntities();
                    _mapper = mapper;
                }
            }
        }

        public UserModel Create(UserModel value)
        {
            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
            {
                if (value.States == null) value.States = string.Empty;

                var dbItem = _mapper.Map<UserModel, user>(value);

                if (!string.IsNullOrEmpty(dbItem.email))
                    dbItem.email = dbItem.email;

                if (dbItem.lastName == null) dbItem.lastName = string.Empty;
                if (dbItem.firstName == null) dbItem.firstName = string.Empty;

                //user already exist then return null
                if (_unit.users.FirstOrDefault(u => u.email.ToUpper().Equals(value.Email)) != null) return null;

                _unit.users.AddObject(dbItem);
                _unit.SaveChanges();

                UpdateUserRoles(dbItem, value.Roles);

                return _mapper.Map<user, UserModel>(dbItem);
            }
        }

        public void Update(UserModel value)
        {
            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
            {
                var dbItem = _unit.users.SingleOrDefault(u => u.id == value.Id);
                if (dbItem != null)
                {

                    UpdateUserRoles(dbItem, value.Roles);

                    //PerformUpdate(dbItem, value);
                    dbItem = _mapper.Map<UserModel, Data.user>(value);

                    _unit.users.ApplyCurrentValues(dbItem);

                    _unit.SaveChanges();
                }

            }
        }

        private void UpdateUserRoles(user user, IEnumerable<Role> roles)
        {
            var currentUserRoleRecords = _unit.users.FirstOrDefault(u => u.id == user.id);
            if (currentUserRoleRecords != null)
            {
                var currentRoles = new List<role>(currentUserRoleRecords.roles.ToList());
                foreach (var role in currentRoles)
                {
                    user.roles.Remove(role);
                }
            }

            if (roles != null && roles.Any())
            {
                var ids = roles.Select(r => r.Id);
                var targetRoleRecords = _unit.roles.Where(r => ids.Contains(r.id));
                foreach (var targetRoleRecord in targetRoleRecords)
                {
                    user.roles.Add(targetRoleRecord);
                }

            }

            _unit.SaveChanges();

            //var currentUserRoleRecords = _unit.users.FirstOrDefault(u => u.id == user.id).roles;
            ////var currentRoleRecords = currentUserRoleRecords.Select(x => x.Role);
            //var targetRoleRecords = _mapper.Map<IEnumerable<Role>, IEnumerable<role>>(roles);

            //foreach (var addingRole in targetRoleRecords.Where(x => !currentUserRoleRecords.Contains(x)))
            //{
            //    user.roles.Add(addingRole);
            //    //_userRolesRepository.Create(new UserRolesPartRecord { UserId = user.Id, Role = addingRole });
            //}

            //foreach (var removingRole in currentUserRoleRecords.Where(x => !targetRoleRecords.Contains(x)))
            //{
            //    user.roles.Remove(removingRole);
            //}

            //_unit.SaveChanges();
        }

        public void Delete(int id)
        {
            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
            {
                _unit.users.DeleteObject(_unit.users.FirstOrDefault(i => i.id == id));
                _unit.SaveChanges();
            }
        }

        public IEnumerable<UserModel> GetAll()
        {
            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
            {
                var dbUsers = _unit.users;
                var users = _mapper.Map<IEnumerable<Data.user>, IEnumerable<UserModel>>(dbUsers);
                return users;
            }
        }

        public IEnumerable<UserModel> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel Get(long id)
        {
            throw new NotImplementedException();
        }

        public UserModel Login(string userNameOrEmail, string password)
        {
            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
            {
                var dbItem = _unit.users.FirstOrDefault(u => u.email.ToUpper().Equals(userNameOrEmail) && u.password.ToUpper().Equals(password));
                return _mapper.Map<Data.user, UserModel>(dbItem);
            }

        }

        public UserModel GetByName(string userName)
        {
            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
            {
                var dbItem = _unit.users.FirstOrDefault(u => u.email.ToUpper().Equals(userName));
                return _mapper.Map<Data.user, UserModel>(dbItem);
            }

        }

        public IEnumerable<UserModel> GetByCompanyName(string companyName)
        {
            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
            {
                var items = _unit.users.Where(u => u.companyName.ToUpper().Equals(companyName));
                return _mapper.Map<IEnumerable<Data.user>, IEnumerable<UserModel>>(items);
            }
        }

        public UserModel GetByLinkedInId(string linkedInId)
        {
            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
            {
                var dbItem = _unit.users.FirstOrDefault(u => u.linkedinId.ToUpper().Equals(linkedInId));
                return _mapper.Map<Data.user, UserModel>(dbItem);
            }

        }

        public UserModel UpdateUserWithLinkedId(int userId, string linkedInId)
        {
            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
            {
                var dbItem = _unit.users.FirstOrDefault(u => u.id == userId);

                if (dbItem != null)
                {
                    dbItem.linkedinId = linkedInId;
                    _unit.users.ApplyCurrentValues(dbItem);
                    _unit.SaveChanges();
                    return _mapper.Map<Data.user, UserModel>(dbItem);
                }
            }
            return null;
        }

        public IEnumerable<Role> GetRoles()
        {
            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
            {
                return _mapper.Map<IEnumerable<Data.role>, IEnumerable<Role>>(_unit.roles);
            }
        }
    }
}
