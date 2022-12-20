using HVLC.RentACar.Entities.Dtos;
using Shared.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLC.RentACar.Service.Abstract
{
    public interface ICarServeService
    {
        Result Add(CarServiceAddDto carServiceAddDto);
        Result Update(CarServiceUpdateDto carServiceUpdateDto);
        Result Delete(CarServiceDeleteDto carServiceDeleteDto);
        DataResult<List<CarServiceDto>> GetAll();
        DataResult<CarServiceDto> Get(CarServiceGetDto carServiceGetDto);
    }
}
