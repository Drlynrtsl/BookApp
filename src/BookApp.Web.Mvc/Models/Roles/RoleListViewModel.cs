using System.Collections.Generic;
using BookApp.Roles.Dto;

namespace BookApp.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
