using Microsoft.AspNetCore.Mvc;
using TestUp.WebApi.Filters;

namespace TestUp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[DynamicAuthorize]
public class BaseController : ControllerBase
{ }
