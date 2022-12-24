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
    public class CarController : ControllerBase
    {
        CarManager carManager;
        public CarController()
        {
            carManager = new CarManager(new UnitOfWork());
        }


        [HttpPost]
        [Route("CarList")]
        public DataResult<List<CarDto>> CarList()
        {
            return carManager.GetAll();
        }


        [HttpPost]
        [Route("CarGetList")]
        public DataResult<CarDto> CarGetList(CarGetDto carGetDto)
        {           
            return carManager.Get(carGetDto);
        }


        [HttpPost]
        [Route("CarAdd")]
        public Result CarAdd(CarAddDto carAddDto)
        {
            return carManager.Add(carAddDto);
        }


        [HttpPost]
        [Route("CarUpdate")]
        public Result CarUpdate(CarUpdateDto carUpdateDto)
        {
            return carManager.Update(carUpdateDto);
        }


        [HttpPost]
        [Route("CarDelete")]
        public Result CarDelete(CarDeleteDto carDeleteDto)
        {
            return carManager.Delete(carDeleteDto);
        }
    }
}
