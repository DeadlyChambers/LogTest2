using log4net;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LogTest2.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILog _logger;
        public ValuesController()
        {
            _logger = Logger.GetLogger(typeof(ValuesController));
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var dt = DateTime.Now.ToString("G");
            Logger.Debug(id + " - " + dt);
            _logger.Info(id + " - " + dt);
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            var dt = DateTime.Now.ToString("G");
            Logger.Debug(value + " - " + dt);
            _logger.Info(value + " - " + dt);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class SomeRandomClass
    {
        public string Name { get; set; } = "The Name";
    }
}
