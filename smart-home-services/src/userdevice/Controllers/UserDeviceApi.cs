using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using SmartHomeSystem.Attributes;
using SmartHomeSystem.Security;
using Microsoft.AspNetCore.Authorization;
using SmartHomeSystem.Model;
using SmartHomeSystem.Context;
using System.Security.Claims;
using SmartHome.Devices.Kafka;
using static Confluent.Kafka.ConfigPropertyNames;

namespace SmartHomeSystem.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class UserDeviceApiController(UserDeviceContext _context, KafkaProducer _producer) : ControllerBase
    { 
        [HttpPost]
        [Route("api/v1/user/device/{userDeviceId}/action")]
        [Authorize(AuthenticationSchemes = BearerAuthenticationHandler.SchemeName)]
        [ValidateModelState]
        [SwaggerOperation("UserDeviceAction")]
        [SwaggerResponse(statusCode: 200, type: typeof(UserDeviceAction), description: "ok")]
        [SwaggerResponse(statusCode: 401, type: typeof(Error), description: "Authentication error")]
        [SwaggerResponse(statusCode: 0, type: typeof(Error), description: "Unexpected case")]
        public virtual IActionResult UserDeviceAction([FromRoute][Required]Int64 userDeviceId)
        {
            //TODO invoke the action via the communication service, this is beyond the scope of the task
            _producer.registrateAction(userDeviceId, 0, TimeSpan.FromMilliseconds(1000)); // here should be implementation of the result storage into Kafka, dummy
            return StatusCode(200, default(UserDeviceAction));
        }

        [HttpPost]
        [Route("api/v1/user/device")]
        [Authorize(AuthenticationSchemes = BearerAuthenticationHandler.SchemeName)]
        [ValidateModelState]
        [SwaggerOperation("UserDeviceLinkCreate")]
        [SwaggerResponse(statusCode: 200, type: typeof(UserDevice), description: "ok")]
        [SwaggerResponse(statusCode: 401, type: typeof(Error), description: "Authentication error")]
        [SwaggerResponse(statusCode: 0, type: typeof(Error), description: "Unexpected case")]
        public virtual IActionResult UserDeviceLinkCreate([FromBody]int? _deviceId)
        {
            var userId = new Guid(this.User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var ret = new UserDevice
            {
                UserId = userId,
                DeviceId = _deviceId
            };

            _context.UserDevice.Add(ret);
            _context.SaveChanges();
            
            return CreatedAtAction("UserDeviceLinkCreate", ret);
        }

        /// <summary>
        /// the method to delete the specific device
        /// </summary>
        /// <param name="userDeviceId">the id of linked device with the user</param>
        /// <response code="200">ok</response>
        /// <response code="401">Authentication error</response>
        /// <response code="0">Unexpected case</response>
        [HttpDelete]
        [Route("api/v1/user/device/{userDeviceId}")]
        [Authorize(AuthenticationSchemes = BearerAuthenticationHandler.SchemeName)]
        [ValidateModelState]
        [SwaggerOperation("UserDeviceLinkDelete")]
        [SwaggerResponse(statusCode: 401, type: typeof(Error), description: "Authentication error")]
        [SwaggerResponse(statusCode: 0, type: typeof(Error), description: "Unexpected case")]
        public virtual IActionResult UserDeviceLinkDelete([FromRoute][Required]int? userDeviceId)
        {
            var userId = new Guid(this.User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            _context.UserDevice.Remove(new UserDevice { UserId = userId, UserDeviceId = userDeviceId });
            _context.SaveChanges();
            
            return StatusCode(200);
        }
    }
}
