using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace TestUp.WebApi.Middlewares;

public class LowercaseControllerModelConvention : IControllerModelConvention
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews(options =>
        {
            options.Conventions.Add(new LowercaseControllerModelConvention());
        });
    }

    public void Apply(ControllerModel controller)
    {
        controller.ControllerName = controller.ControllerName.ToLower();

        foreach (var action in controller.Actions)
            action.ActionName = action.ActionName.ToLower();
    }
}