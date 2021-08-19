using Microsoft.AspNetCore.Mvc;
using Northwind.Models;
using Northwind.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.WebApi.Controllers
{
    [Route("api/Customer")]
    public class CustomerController: Controller
    {
        public readonly IUnitOfWork _unitOfWork;
        public CustomerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unitOfWork.Customer.GetById(id));
        }

        [HttpGet]
        [Route("https://web.postman.co/workspace/My-Workspace~8bb81ec2-6393-41af-8d23-924d28a03027/collection/3053577-84b17fd7-18ae-48bf-b5e5-cbf75c733ea7/{page:int}/{rows:int}")]
        public IActionResult GetPaginateCustomer(int page, int rows)
        {
            return Ok(_unitOfWork.Customer.CustomerPagedList(page, rows));
        }

        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            if (!ModelState.IsValid) return BadRequest();
            return Ok(_unitOfWork.Customer.Insert(customer));
        }


        [HttpPut]
        public IActionResult Put(Customer customer)
        {
            if (ModelState.IsValid && _unitOfWork.Customer.Update(customer))
            {
                Ok(new { message="El Cliente fue actualizado" });
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(Customer customer)
        {
            if (customer.Id > 0)
            {
                return Ok(_unitOfWork.Customer.Delete(customer));
            }
            return BadRequest();
        }
    }
}
