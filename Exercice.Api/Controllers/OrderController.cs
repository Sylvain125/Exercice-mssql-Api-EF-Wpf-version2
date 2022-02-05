using AutoMapper;
using Exercice.Dto;
using Exercice.Entity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exercice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        // Je recup le context et le mapper
        private MyApiContext _context;
        private IMapper _mapper;
        public OrderController(MyApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/<ApiController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<OrderDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            return Ok(_context.OrderEntity.Select(user => _mapper.Map<OrderDto>(user)));
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ApiController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(OrderDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] OrderDto newOrder)
        {
            try
            {
                var OrderEntity = _mapper.Map<OrderEntity>(newOrder);
                _context.OrderEntity.Add(OrderEntity);
                _context.SaveChanges();
                return Ok(newOrder);
                // autre facon :  return base.Created(Request.Query.ToString(), userInfoEntity);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }



        // PUT api/<ApiController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, OrderDto updateDto)
        {
            try
            {
                var ProductEntity = _mapper.Map<OrderEntity>(updateDto);
                var updateUser = _context.OrderEntity.Single(u => u._orderId == id);

                updateUser._userInfoId = ProductEntity._userInfoId;
                updateUser._productId = ProductEntity._productId;
                updateUser._productQuantity = ProductEntity._productQuantity;
                updateDto._totalTax = ProductEntity._totalTax;
                updateDto._totalShip = ProductEntity._totalShip;
                updateDto._totalDue = ProductEntity._totalDue;
                updateDto._date = ProductEntity._date;
                updateDto._ip = ProductEntity._ip;

                _context.OrderEntity.Update(updateUser);
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
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(OrderDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            try
            {
                var deleteUser = _context.OrderEntity.Single(u => u._orderId == id);
                _context.OrderEntity.Remove(deleteUser);
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
