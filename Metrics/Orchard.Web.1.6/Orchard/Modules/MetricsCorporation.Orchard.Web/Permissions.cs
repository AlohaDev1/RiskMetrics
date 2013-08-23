using System.Collections.Generic;
using Orchard.Environment.Extensions.Models;
using Orchard.Security.Permissions;

namespace MetricsCorporation.Orchard.Web {

    public class Permissions : IPermissionProvider {

        public static readonly Permission AdministrationUsers = new Permission { Description = "Administration filelist&masterId", Name = "AdministrationUsers" };
        public static readonly Permission LogReports = new Permission { Description = "Logging reports information", Name = "LogReports" };
        public static readonly Permission SearchSection = new Permission { Description = "Search section", Name = "SearchSection" };

        public virtual Feature Feature { get; set; }

        public IEnumerable<Permission> GetPermissions() {
            return new[] {
                                        AdministrationUsers,
                                        LogReports,
                                        SearchSection
                                    };
        }

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes() {
            return new[] {

                            new PermissionStereotype {
                                Name = "Master",
                                Permissions = new[] { AdministrationUsers, LogReports, SearchSection }
                            },
                         };
        }
    }
}