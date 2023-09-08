using TestUp.Service.Enums;
using TestUp.Service.Interfaces;

namespace TestUp.Service.Services;

public class RolesService : IRolesService
{
    public bool ExchangeRole(UserRolle userRolle)
    {
        RoleUser.CurrentRole = userRolle.ToString();
        
        return true;
    }
}
