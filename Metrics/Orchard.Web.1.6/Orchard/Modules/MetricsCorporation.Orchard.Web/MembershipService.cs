using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.BL.Services;
using MetricsCorporation.Models;
using MetricsCorporation.Orchard.Web.Helpers;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Data;
using Orchard.Environment.Extensions;
using Orchard.Messaging.Services;
using Orchard.Mvc;
using Orchard.Roles.Models;
using Orchard.Roles.Services;
using Orchard.Security;
using Orchard.Services;
using Orchard.Users.Events;
using Orchard.Users.Models;
using Orchard.Users.Services;
using UserService = MetricsCorporation.BL.Services.UserService;

namespace MetricsCorporation.Orchard.Web
{
    [OrchardSuppressDependency("Orchard.Users.Services.MembershipService")]
    public class MetricsMembershipService : MembershipService, IMembershipService
    {
        private readonly IOrchardServices _orchardServices;
        private readonly IMessageManager _messageManager;
        private readonly IEncryptionService _encryptionService;
        private readonly IHttpContextAccessor _accessor;
        private readonly ICrud<UserModel> _userService;
        private readonly ICrud<NumberOfLoginsModel> _numberOfLoginsService;
        
        private readonly IRepository<UserRolesPartRecord> _userRolesRepository;
        private readonly IRoleService _roleService;
        

        public MetricsMembershipService(
            ICrud<UserModel> userService, 
            ICrud<NumberOfLoginsModel> numberOfLoginsService,
            IHttpContextAccessor accessor, 
            IOrchardServices orchardServices, 
            IMessageManager messageManager, 
            IEnumerable<IUserEventHandler> userEventHandlers, 
            IClock clock, 
            IEncryptionService encryptionService,
            IRepository<UserRolesPartRecord> userRolesRepository,
            IRoleService roleService)
            : base(orchardServices, messageManager, userEventHandlers, clock, encryptionService)
        {
            _accessor = accessor;
            _userService = userService;
            _numberOfLoginsService = numberOfLoginsService;
            _userRolesRepository = userRolesRepository;
            _roleService = roleService;
            _orchardServices = orchardServices;
        }



        public new IUser ValidateUser(string userNameOrEmail, string password)
        {

            var user = ((UserService)_userService).Login(userNameOrEmail, password);

            if (user != null && user.Id > 0)
            {
                IUser orchardUser;

                if (GetUser(userNameOrEmail) != null)
                {
                    orchardUser = GetUser(userNameOrEmail);
                }
                else
                {
                    orchardUser = CreateUser(new CreateUserParams(userNameOrEmail, password, user.Email, null, null, true));
                }
                    

                _numberOfLoginsService.Create(new NumberOfLoginsModel() { LoginDate = DateTime.Now, UserId = user.Id });
                
                //save user to session
                var httpSessionStateBase = _accessor.Current().Session;
                if (httpSessionStateBase != null) httpSessionStateBase.Add("CurrentUser", user);

                UpdateUserRoles(orchardUser, user.Roles);

                return orchardUser;
            }

            return null;
        }




        private void UpdateUserRoles(IUser user, IEnumerable<Role> roles)
        {
            var currentUserRoleRecords = _userRolesRepository.Fetch(x => x.UserId == user.Id);
            var currentRoleRecords = currentUserRoleRecords.Select(x => x.Role);
            var targetRoleRecords = _roleService.GetRoles().Where(x => roles.Select(r=>r.Name).Contains(x.Name));

            foreach (var addingRole in targetRoleRecords.Where(x => !currentRoleRecords.Contains(x)))
            {
                _userRolesRepository.Create(new UserRolesPartRecord { UserId = user.Id, Role = addingRole });
            }

            foreach (var removingRole in currentUserRoleRecords.Where(x => !targetRoleRecords.Contains(x.Role)))
            {
                _userRolesRepository.Delete(removingRole);
            }
        }

        private bool ValidatePassword(UserPartRecord partRecord, string password)
        {
            // Note - the password format stored with the record is used
            // otherwise changing the password format on the site would invalidate
            // all logins
            switch (partRecord.PasswordFormat)
            {
                case MembershipPasswordFormat.Clear:
                    return ValidatePasswordClear(partRecord, password);
                case MembershipPasswordFormat.Hashed:
                    return ValidatePasswordHashed(partRecord, password);
                case MembershipPasswordFormat.Encrypted:
                    return ValidatePasswordEncrypted(partRecord, password);
                default:
                    throw new ApplicationException("Unexpected password format value");
            }
        }
        private static bool ValidatePasswordClear(UserPartRecord partRecord, string password)
        {
            return partRecord.Password == password;
        }

        private static bool ValidatePasswordHashed(UserPartRecord partRecord, string password)
        {

            var saltBytes = Convert.FromBase64String(partRecord.PasswordSalt);

            var passwordBytes = Encoding.Unicode.GetBytes(password);

            var combinedBytes = saltBytes.Concat(passwordBytes).ToArray();

            byte[] hashBytes;
            using (var hashAlgorithm = HashAlgorithm.Create(partRecord.HashAlgorithm))
            {
                hashBytes = hashAlgorithm.ComputeHash(combinedBytes);
            }

            return partRecord.Password == Convert.ToBase64String(hashBytes);
        }
        
        private bool ValidatePasswordEncrypted(UserPartRecord partRecord, string password)
        {
            return String.Equals(password, Encoding.UTF8.GetString(_encryptionService.Decode(Convert.FromBase64String(partRecord.Password))), StringComparison.Ordinal);
        }


    }

    //public class MetricsUser : IUser
    //{
    //    public ContentItem ContentItem { get; set; }

    //    public int Id { get; set; }

    //    public string UserName { get; set; }

    //    public string Email { get; set; }

    //}
}