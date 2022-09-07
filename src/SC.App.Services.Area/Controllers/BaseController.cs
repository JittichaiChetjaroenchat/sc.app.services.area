using Microsoft.AspNetCore.Mvc;
using SC.App.Services.Area.Filters;

namespace SC.App.Services.Area.Controllers
{
    [CustomExceptionFilter]
    public class BaseController : ControllerBase
    {
    }
}