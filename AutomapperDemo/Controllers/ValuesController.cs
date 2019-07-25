using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Models.Dtos;
using Models.Entities;
using AutoMapper;

namespace AutomapperDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMapper _mapper;

        public ValuesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get(UserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);

            //Comment the below line to make api work correctly
            UserDto dto = _mapper.Map<UserDto>(user); //Causes error as we haven't added mapping config in mapping profile class
            return new string[] { user.Name, user.Address, user.PhoneNumber };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
}
