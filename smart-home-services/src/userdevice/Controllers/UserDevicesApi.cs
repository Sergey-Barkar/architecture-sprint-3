using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Newtonsoft.Json;
using SmartHomeSystem.Model;
using System.ComponentModel.DataAnnotations;
using SmartHomeSystem.Attributes;
using SmartHomeSystem.Security;
using Microsoft.AspNetCore.Authorization;
using SmartHomeSystem.Context;
using System.Security.Claims;

namespace SmartHomeSystem.Controllers
{ 
    [ApiController]
    public class UserDevicesApiController(UserDeviceContext _context) : ControllerBase
    { 
        [HttpGet]
        [Route("api/v1/user/devices")]
        [Authorize(AuthenticationSchemes = BearerAuthenticationHandler.SchemeName)]
        [ValidateModelState]
        [SwaggerOperation("UserDeviceLinks")]
        [SwaggerResponse(statusCode: 200, type: typeof(UserDevices), description: "ok")]
        [SwaggerResponse(statusCode: 401, type: typeof(Error), description: "Authentication error")]
        [SwaggerResponse(statusCode: 0, type: typeof(Error), description: "Unexpected case")]
        public virtual ActionResult UserDeviceLinks()
        {
            var userId = new Guid(this.User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            return new ObjectResult(_context.UserDevice.Where(w => w.UserId == userId).ToList());
        }
    }
}
