using EnrollmentsApi.Models;
using EnrollmentsApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EnrollmentsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly ILogger<UserAccountController> _logger;
        private readonly IMessageProducer _messageProducer;
        public UserAccountController(ILogger<UserAccountController> logger, IMessageProducer messageProducer)
        {
                _logger = logger;
               _messageProducer = messageProducer;
        }
        // GET: api/<UserAccountController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserAccountController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserAccountController>
        [HttpPost]
        public IActionResult Post(UserAccount userAccount)
        {

            _messageProducer.SendingMessage(userAccount);
            return Ok();
        }



        // PUT api/<UserAccountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserAccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
