using HVLC.RentACar.Data.Concrete;
using HVLC.RentACar.Entities.Dtos;
using HVLC.RentACar.Service.Concrete;
using Microsoft.AspNetCore.Mvc;
using Shared.Result;
using System.Collections.Generic;

namespace HVLC.RentACar.Api.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class CustomerController : ControllerBase
    {
        CustomerManager customerManager;

        public CustomerController()
        {
            customerManager = new CustomerManager(new UnitOfWork());
        }

        [HttpPost]
        [Route("CustomerList")]
        public DataResult<List<CustomerDto>> CustomerList()
        {
            return customerManager.GetAll();
        }

        [HttpPost]
        [Route("CustomerGetList")]
        public DataResult<CustomerDto> customerGetList(CustomerGetDto customerGetDto)
        {
            return customerManager.Get(customerGetDto);
        }

        [HttpPost]
        [Route("CustomerAdd")]
        public Result CustomerAdd(CustomerAddDto customerAddDto)
        {
            return customerManager.Add(customerAddDto);
        }

        [HttpPost]
        [Route("CustomerUpdate")]
        public Result CustomerUpdate(CustomerUpdateDto customerUpdateDto)
        {
            return customerManager.Update(customerUpdateDto);
        }

        [HttpPost]
        [Route("CustomerDelete")]
        public Result CustomerDelete(CustomerDeleteDto customerDeleteDto)
        {
            return customerManager.Delete(customerDeleteDto);
        }
    }
}
