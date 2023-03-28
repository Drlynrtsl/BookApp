using System.Collections.Generic;
using BookApp.Roles.Dto;

namespace BookApp.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}