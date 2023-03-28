using System.Collections.Generic;
using BookApp.Roles.Dto;

namespace BookApp.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
