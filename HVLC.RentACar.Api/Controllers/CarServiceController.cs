using HVLC.RentACar.Data.Concrete;
using HVLC.RentACar.Entities.Dtos;
using HVLC.RentACar.Service.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Result;
using System.Collections.Generic;

namespace HVLC.RentACar.Api.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class CarServiceController : ControllerBase
    {
        CarServiceManager serviceManager;
        public CarServiceController()
        {
            serviceManager = new CarServiceManager(new UnitOfWork());
        }

        [HttpPost]
        [Route("CarServiceAdd")]
        public Result CarServiceAdd(CarServiceAddDto carServiceAddDto)
        {
            return serviceManager.Add(carServiceAddDto);
        }

        [HttpPost]
        [Route("CarServiceUpdate")]
        public Result CarServiceUpdate(CarServiceUpdateDto carServiceUpdateDto)
        {
            return serviceManager.Update(carServiceUpdateDto);
        }

        [HttpPost]
        [Route("CarServiceDelete")]
        public Result CarServiceDelete(CarServiceDeleteDto carServiceDeleteDto)
        {
            return serviceManager.Delete(carServiceDeleteDto);
        }

        [HttpPost]
        [Route("CarServiceList")]
        public DataResult<List<CarServiceDto>> CarServiceList()
        {
            return serviceManager.GetAll();
        }

        [HttpPost]
        [Route("CarServiceGet")]
        public DataResult<CarServiceDto> CarServiceGet(CarServiceGetDto carServiceGetDto)
        {
            return serviceManager.Get(carServiceGetDto);
        }


    }
}
