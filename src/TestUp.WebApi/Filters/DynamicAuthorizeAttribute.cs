using Microsoft.AspNetCore.Mvc;
using System;

namespace TestUp.WebApi.Filters;
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class , Inherited = true , AllowMultiple = true)]
public class DynamicAuthorizeAttribute : TypeFilterAttribute
{
    public DynamicAuthorizeAttribute() : base(typeof(DynamicAuthorizeFilter))
    {
    }
}
