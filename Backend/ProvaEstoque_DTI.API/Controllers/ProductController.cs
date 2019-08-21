using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProvaEstoque_DTI.Domain.Entity;
using ProvaEstoque_DTI.Domain.Interface;

namespace ProvaEstoque_DTI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        // GET: api/Product
        [HttpGet]
        public IEnumerable<Product> Get([FromServices]IUnitOfWork unitOfWork)
        {

            var products = unitOfWork.Repository<Product>().GetAll();

            return products;
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Product
        [HttpPost]
        public async Task Post([FromServices]IUnitOfWork unitOfWork, [FromBody] Product productRequest)
        {
            Product product = new Product();
            product.Name = productRequest.Name;
            product.Amount = productRequest.Amount;

            await unitOfWork.Repository<Product>().CreateAsync(product);

            await unitOfWork.Commit();

        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Product value, [FromServices] IUnitOfWork unitOfWork)
        {
            var product = await unitOfWork.Repository<Product>().GetByIdAsync(id);

            if (product != null)
            {
                product.Amount = value.Amount;
                product.Price = value.Price;
                product.Name = value.Name;

                await unitOfWork.Repository<Product>().Update(product);
                await unitOfWork.Commit();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete([FromServices]IUnitOfWork unitOfWork, int id)
        {

            var product = await unitOfWork.Repository<Product>().GetByIdAsync(id);

            if (product != null)
            {
                await unitOfWork.Repository<Product>().Delete(product);
                await unitOfWork.Commit();
            }
        }
    }
}
