using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace routing.Controllers
{
    [Route("api/{*.}")]
    public class ApiController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] JObject payload)
        {
            var action = Request.Path.ToString().Replace("/api/", "");
            var typeDict = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => p.GetInterface("IRequest`1") != null)
                .ToDictionary(t => t.FullName.Replace(".", "/"), t => t, StringComparer.OrdinalIgnoreCase);

            Type type = typeDict.GetValueOrDefault(action);
            var req = (IRequest<object>)payload.ToObject(type);

            return Ok(req.Handle());
        }
    }
}