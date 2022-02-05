using AutoMapper;
using Exercice.Dto;
using Exercice.Entity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exercice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // Je recup le context et le mapper
        private MyApiContext _context;
        private IMapper _mapper;
        public ProductController(MyApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // GET: api/<ApiController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            return Ok(_context.ProductEntity.Select(user => _mapper.Map<ProductDto>(user)));
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ApiController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProductDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] ProductDto newProduct)
        {
            try
            {
                var productEntity = _mapper.Map<ProductEntity>(newProduct);
                _context.ProductEntity.Add(productEntity);
                _context.SaveChanges();
                return Ok(newProduct);
                // autre facon : return base.Created(Request.Query.ToString(), userInfoEntity);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }



        // PUT api/<ApiController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, ProductDto updateDto)
        {
            try
            {
                var ProductEntity = _mapper.Map<ProductEntity>(updateDto);
                var updateUser = _context.ProductEntity.Single(u => u._productId == id);

                updateUser._name = ProductEntity._name;
                updateUser._price = ProductEntity._price;
                updateUser._description = ProductEntity._description;
                updateDto._image = ProductEntity._image;
               
                _context.ProductEntity.Update(updateUser);
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
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProductDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            try
            {
                var deleteUser = _context.ProductEntity.Single(u => u._productId == id);
                _context.ProductEntity.Remove(deleteUser);
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
