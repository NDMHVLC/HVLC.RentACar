using HVLC.RentACar.Entities.Dtos;
using Shared.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLC.RentACar.Service.Abstract
{
    public interface ICustomerService
    {
        Result Add(CustomerAddDto customerAddDto);
        Result Update(CustomerUpdateDto customerUpdateDto);
        Result Delete(CustomerDeleteDto customerDeleteDto);
        DataResult<List<CustomerDto>> GetAll();
        DataResult<CustomerDto> Get(CustomerGetDto customerGetDto);
    }
}
