using HVLC.RentACar.Entities.Dtos;
using Shared.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLC.RentACar.Service.Abstract
{
    public interface IReservationService
    {
        Result Add(ReservationAddDto reservationAddDto);
        Result Update(ReservationUpdateDto reservationUpdateDto);
        Result Delete(ReservationDeleteDto reservationDeleteDto);
        DataResult<List<ReservationDto>> GetAll();
        DataResult<ReservationDto> Get(ReservationGetDto reservationGetDto);
        DataResult<ReservationDto> GetLastReservation();
        DataResult<List<ReservationDto>> GetAllLastReservation(int count);
    }
}
