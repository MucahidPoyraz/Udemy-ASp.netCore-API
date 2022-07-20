using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Udemy.WebAPI.Data;
using Udemy.WebAPI.Interfaces;

namespace Udemy.WebAPI.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAC()
        {
            var result = await _productRepository.GetAllAsyncApi();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAC(int id)
        {
            var data = await _productRepository.GetByIdAsyncApi(id);
            if(data == null) { return NotFound(id); }
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAC(Product product)
        {
            var addedProduct = await _productRepository.CreateAsyncApi(product);

            return Created(string.Empty, addedProduct);
        }
        

        [HttpPut]
        public async Task<IActionResult> UpdateAC(Product product)
        {
            var checkProduct = await _productRepository.GetByIdAsyncApi(product.Id);
            if(checkProduct == null) { return NotFound(product.Id); }
            await _productRepository.UpdateAsyncApi(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAC(int id)
        {
            var checkProduct = await _productRepository.GetByIdAsyncApi(id);
            if (checkProduct == null)
            {
                return NotFound(id);
            }
            await _productRepository.RemoveAsyncApi(id);
            return NoContent();
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadAC([FromForm]IFormFile formfile)
        {
            var newName = Guid.NewGuid() + "." + Path.GetExtension(formfile.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", newName);
            var stream = new FileStream(path, FileMode.Create);
            await formfile.CopyToAsync(stream);
            return Created(string.Empty, formfile);
        }
    }
}
        