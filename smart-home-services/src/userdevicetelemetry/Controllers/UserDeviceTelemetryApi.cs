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
using System.Diagnostics;

namespace SmartHomeSystem.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class UserDeviceTelemetryApiController(UserDeviceTelemetryContext _context) : ControllerBase
    { 
        
        /// <summary>
        /// the method to get array of the user&#x27;s device telemetries
        /// </summary>
        /// <param name="userDeviceId">the id of linked device with the user</param>
        /// <response code="200">ok</response>
        /// <response code="401">Authentication error</response>
        /// <response code="0">Unexpected case</response>
        [HttpGet]
        [Route("api/v1/user/device/{userDeviceId}/telemetry")]
        [Authorize(AuthenticationSchemes = BearerAuthenticationHandler.SchemeName)]
        [ValidateModelState]
        [SwaggerOperation("UserDeviceTelemetries")]
        [SwaggerResponse(statusCode: 200, type: typeof(UserDeviceTelemetries), description: "ok")]
        [SwaggerResponse(statusCode: 401, type: typeof(Error), description: "Authentication error")]
        [SwaggerResponse(statusCode: 0, type: typeof(Error), description: "Unexpected case")]
        public virtual IActionResult UserDeviceTelemetries([FromRoute][Required] Int64? userDeviceId)
        {
            return new ObjectResult(_context.UserDeviceTelemetry.Where(w => w.UserDeviceId == userDeviceId).ToList());
        }

        /// <summary>
        /// the method to get the latest user&#x27;s device telemetry
        /// </summary>
        /// <param name="userDeviceId">the id of linked device with the user</param>
        /// <response code="200">ok</response>
        /// <response code="401">Authentication error</response>
        /// <response code="0">Unexpected case</response>
        [HttpGet]
        [Route("api/v1/user/device/{userDeviceId}/telemetry/latest")]
        [Authorize(AuthenticationSchemes = BearerAuthenticationHandler.SchemeName)]
        [ValidateModelState]
        [SwaggerOperation("UserDeviceTelemetryLatest")]
        [SwaggerResponse(statusCode: 200, type: typeof(UserDeviceTelemetry), description: "ok")]
        [SwaggerResponse(statusCode: 401, type: typeof(Error), description: "Authentication error")]
        [SwaggerResponse(statusCode: 0, type: typeof(Error), description: "Unexpected case")]
        public virtual IActionResult UserDeviceTelemetryLatest([FromRoute][Required] Int64? userDeviceId)
        {
            return new ObjectResult(_context.UserDeviceTelemetry.Where(w => w.UserDeviceId == userDeviceId).OrderByDescending(w => w.CreatedDateTime).FirstOrDefault());
        }
        
        internal UserDeviceTelemetry createTelemetry(Int64 _userDeviceId, UserDeviceTelemetry.ValueTypeEnum _valueType, decimal _value, DateTime _createdDT)
        {
            UserDeviceTelemetry ret = new UserDeviceTelemetry
            {
                UserDeviceId = _userDeviceId,
                ValueType = _valueType,
                Value = _value,
                CreatedDateTime = _createdDT.ToString()
            };

            _context.UserDeviceTelemetry.Add(ret);
            _context.SaveChanges();

            return ret;
        }

        [HttpPost]
        [Route("api/v1/user/device/{userDeviceId}/telemetry")]
        [Authorize(AuthenticationSchemes = BearerAuthenticationHandler.SchemeName)]
        [ValidateModelState]
        [SwaggerOperation("UserDeviceTelemetryAdd")]
        [SwaggerResponse(statusCode: 200, type: typeof(UserDeviceTelemetry), description: "ok")]
        [SwaggerResponse(statusCode: 401, type: typeof(Error), description: "Authentication error")]
        [SwaggerResponse(statusCode: 0, type: typeof(Error), description: "Unexpected case")]
        public virtual IActionResult Add([FromRoute][Required] Int64 userDeviceId)
        {
            UserDeviceTelemetries ret = new UserDeviceTelemetries();
            UserDeviceTelemetry telemetry = this.createTelemetry(userDeviceId, UserDeviceTelemetry.ValueTypeEnum.StatusEnum, 1, DateTime.UtcNow);

            _context.UserDeviceTelemetry.Add(telemetry);
            ret.Add(telemetry);

            telemetry = this.createTelemetry(userDeviceId, UserDeviceTelemetry.ValueTypeEnum.TemperatureEnum, 32, DateTime.UtcNow.AddSeconds(10)); 

            _context.UserDeviceTelemetry.Add(telemetry);
            ret.Add(telemetry);
            _context.SaveChanges();

            return new ObjectResult(ret);
        }
    }
}
