using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TestUp.Service.Enums;

namespace TestUp.WebApi.Filters;

public class DynamicAuthorizeFilter : IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var userRole = RoleUser.CurrentRole;

        if (userRole == null)
        {
            context.Result = new ForbidResult();
        }

        else if (userRole != RoleUser.Admin)
        {
            context.Result = new ForbidResult();
        }

        else if (userRole != RoleUser.Teacher)
        {
            context.Result = new ForbidResult();
        }

        else if (userRole != RoleUser.AdminTeacher)
        {
            context.Result = new ForbidResult();
        }

        else if(userRole != RoleUser.AdminUser)
        {
            context.Result = new ForbidResult();
        }
    }
}
