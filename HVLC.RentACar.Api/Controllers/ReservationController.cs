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
    public class ReservationController : ControllerBase
    {
        ReservationManager reservationManager;
        public ReservationController()
        {
            reservationManager = new ReservationManager(new UnitOfWork());
        }

        [HttpPost]
        [Route("ReservationList")]
        public DataResult<List<ReservationDto>> ReservationList()
        {
            return reservationManager.GetAll();
        }

        [HttpPost]
        [Route("ReservationGet")]
        public DataResult<ReservationDto> ReservationGet(ReservationGetDto reservationGetDto)
        {
            return reservationManager.Get(reservationGetDto);
        }

        [HttpPost]
        [Route("LastReservationGet")]
        public DataResult<ReservationDto> LastReservationGet()
        {
            return reservationManager.GetLastReservation();
        }

        [HttpPost]
        [Route("ReservationUpdate")]
        public Result ReservationUpdate(ReservationUpdateDto reservationUpdateDto)
        {
            return reservationManager.Update(reservationUpdateDto);
        }

        [HttpPost]
        [Route("ReservationAdd")]
        public Result ReservationAdd(ReservationAddDto reservationAddDto)
        {
            return reservationManager.Add(reservationAddDto);
        }

        [HttpPost]
        [Route("ReservationDelete")]
        public Result ReservationDelete(ReservationDeleteDto reservationDeleteDto)
        {
            return reservationManager.Delete(reservationDeleteDto);
        }


    }
}
