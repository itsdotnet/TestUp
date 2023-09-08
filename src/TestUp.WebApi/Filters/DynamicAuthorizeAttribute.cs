using Microsoft.AspNetCore.Mvc;

namespace TestUp.WebApi.Filters;

public class DynamicAuthorizeAttribute : TypeFilterAttribute
{
    public DynamicAuthorizeAttribute() : base(typeof(DynamicAuthorizeFilter))
    {
    }
}
