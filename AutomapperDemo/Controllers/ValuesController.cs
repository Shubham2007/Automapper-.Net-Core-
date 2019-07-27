using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Models.Dtos;
using Models.Entities;
using AutoMapper;
using System.Web.Http.Description;

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
        [HttpGet("person")]
        [ResponseType(typeof(PersonDto))]
        public IActionResult Get()
        {
            //Assume Person Entity coming from database
            Person person = new Person()
            {
                Firstname = "John",
                Lastname = "Doe",
                Age = 25,
                Sex = "Male",
                Address = new Address()
                {
                    City = "New York City",
                    HouseNumber = "10",
                    State = "NY",
                    ZipCode = "99999"
                }
            };

            PersonDto personDto = _mapper.Map<PersonDto>(person);
            Person person1 = _mapper.Map<Person>(personDto);
            return Ok(personDto);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

    }
}
