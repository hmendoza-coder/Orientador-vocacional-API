using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OrientadorVocacionalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ValuesController()
        {
            ValueSamples.Initialize();
        }

        // GET api/values  
        [HttpGet]
        public ActionResult<Dictionary<string, string>> Get()
        {
            return ValueSamples.MyValue;
        }

        // GET api/values/5  
        [HttpGet("{id}")]
        public ActionResult<string> Get(string id)
        {
            return ValueSamples.MyValue.GetValueOrDefault(id);
        }

        // POST api/values  
        [HttpPost]
        public void Post([FromBody] string value)
        {
            var maxKey = ValueSamples.MyValue.Max(x => x.Key);

            ValueSamples.MyValue.Add(maxKey + 1, value);
        }

        // PUT api/values/5  
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] string value)
        {
            ValueSamples.MyValue.Add(id, value);
        }

        // DELETE api/values/5  
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            ValueSamples.MyValue.Remove(id);
        }
    }
}
