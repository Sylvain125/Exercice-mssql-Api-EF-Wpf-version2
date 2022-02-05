using AutoMapper;
using Exercice.Dto;
using Exercice.Entity;
using Microsoft.AspNetCore.Mvc;


namespace Exercice.Api.Controllers
{

    // Le controller pour les user
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // Je recup le context et le mapper
        private MyApiContext _context;
        private IMapper _mapper;
        public UserController(MyApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // GETAll: api/<ApiController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            return Ok(_context.UserEntity.Select(user => _mapper.Map<UserDto>(user)));
        }

        // GET api/<User>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // POST api/<ApiController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] UserDto newUserInfo)
        {
            try
            {
                var userInfoEntity = _mapper.Map<UserEntity>(newUserInfo);
                _context.UserEntity.Add(userInfoEntity);
                _context.SaveChanges();
                return Ok(newUserInfo);
                // autre facon : return base.Created(Request.Query.ToString(), userInfoEntity);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // PUT api/<ApiController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, UserDto updateDto)
        {
            try
            {
                var userEntity = _mapper.Map<UserEntity>(updateDto);
                var updateUser = _context.UserEntity.Single(u => u._userId == id);

                updateUser._userFirstName = userEntity._userFirstName;
                updateUser._userLastName = userEntity._userLastName;
                updateUser._emailAddress = userEntity._emailAddress;
                updateDto._address = userEntity._address;
                updateUser._companyName = userEntity._companyName;
                updateUser._phone = userEntity._phone;
                updateUser._imgUrl = userEntity._imgUrl;
                updateUser._role = userEntity._role;

                _context.UserEntity.Update(updateUser);
                _context.SaveChanges();
                return Ok(updateDto);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }



        // DELETE api/<ApiController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            try
            {
                var deleteUser = _context.UserEntity.Single(u => u._userId == id);
                _context.UserEntity.Remove(deleteUser);
                _context.SaveChanges();
                return Ok(deleteUser);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }
    }
}
