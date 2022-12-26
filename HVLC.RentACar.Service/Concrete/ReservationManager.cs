using HVLC.RentACar.Data.Abstract;
using HVLC.RentACar.Entities.Concrete;
using HVLC.RentACar.Entities.Dtos;
using HVLC.RentACar.Entities.Mapping;
using HVLC.RentACar.Service.Abstract;
using Shared.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLC.RentACar.Service.Concrete
{
    public class ReservationManager : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReservationManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Result Add(ReservationAddDto reservationAddDto)
        {
            try
            {
                _unitOfWork.Reservations.Add(reservationAddDto.ToEntity());
                _unitOfWork.Save();

                return new Result(200, new List<string>() { "Rezervasyon kaydı başarılı bir şekilde eklenmiştir" });
            }
            catch (Exception ex)
            {
                return new Result(500, new List<string>() { "Rezervasyon kaydı eklenirken teknik bir hata oluştu" }, ex);
            }
        }

        public Result Delete(ReservationDeleteDto reservationDeleteDto)
        {
            try
            {
                Reservation currentReservation = _unitOfWork.Reservations.Get(r => r.Id == reservationDeleteDto.Id);
                _unitOfWork.Reservations.HardDelete(currentReservation);
                _unitOfWork.Save();

                return new Result(200, new List<string>() { "Rezervasyon kaydı başarılı bir şekilde silindi." });
            }
            catch (Exception ex)
            {
                return new Result(500, new List<string>() { "Rezervasyon kaydı silinirken teknik bir hata oluştu" }, ex);
            }
        }

        public DataResult<ReservationDto> Get(ReservationGetDto reservationGetDto)
        {
            try
            {
                return new DataResult<ReservationDto>(200, _unitOfWork.Reservations.Get(r => r.Id == reservationGetDto.Id).ToDto(), null);
            }
            catch (Exception ex)
            {
                return new DataResult<ReservationDto>(500, null, new List<string>() { "Teknik bir hata oluştu" }, ex);
            }
        }

        public DataResult<ReservationDto> GetLastReservation()
        {
            try
            {
                var result = _unitOfWork.Reservations.GetLastReservationByDate().ToDto();
                return new DataResult<ReservationDto>(200, result, null);
            }
            catch (Exception ex)
            {
                return new DataResult<ReservationDto>(500, null, new List<string>() { "Teknik bir hata oluştu" }, ex);
            }
        }

        public DataResult<List<ReservationDto>> GetAll()
        {
            var reservation = (from r in _unitOfWork.Reservations.GetAll()
                               join c in _unitOfWork.Cars.GetAll()
                               on r.CarId equals c.Id
                               select new ReservationDto
                               {
                                   Id = r.Id,
                                   RentalDate = r.RentalDate,
                                   DeliveryDate = r.DeliveryDate,
                                   StartingKm = r.StartingKm,
                                   FinishKm = r.FinishKm,
                                   Comment = r.Comment,
                                   CarId = r.CarId,
                                   Car = c.ToDto(),
                               }).ToList();
            if (reservation.Count > 0)
            {
                return new DataResult<List<ReservationDto>>(200, reservation, null);
            }
            else
            {
                return new DataResult<List<ReservationDto>>(200, null, new List<string>() { "Veri tabanında kayıt bulunamadı" }, null);
            }
        }

        public Result Update(ReservationUpdateDto reservationUpdateDto)
        {
            try
            {
                Reservation currentReservation = _unitOfWork.Reservations.Get(r => r.Id == reservationUpdateDto.Id);
                currentReservation.RentalDate = reservationUpdateDto.RentalDate;
                currentReservation.DeliveryDate = reservationUpdateDto.DeliveryDate;
                currentReservation.StartingKm = reservationUpdateDto.StartingKm;
                currentReservation.FinishKm = reservationUpdateDto.FinishKm;
                currentReservation.Comment = reservationUpdateDto.Comment;
                currentReservation.CarId = reservationUpdateDto.CarId;
                currentReservation.ModifedBy = 1;
                currentReservation.ModifedDate = DateTime.Now;

                _unitOfWork.Reservations.Update(currentReservation);
                _unitOfWork.Save();

                return new Result(200, new List<string>() { "Rezervasyon kaydı başarılı bir şekilde güncellenmiştir" });

            }
            catch (Exception ex)
            {
                return new Result(200, new List<string>() { "Rezervasyon kaydı güncellenirken teknik bir hata oluştu" }, ex);
            }
        }


        public DataResult<List<ReservationDto>> GetAllLastReservation(int count)
        {
            try
            {
                var reservations = (from r in _unitOfWork.Reservations.GetAll()
                                   join c in _unitOfWork.Cars.GetAll()
                                   on r.CarId equals c.Id
                                   select new ReservationDto
                                   {
                                       Id = r.Id,
                                       RentalDate = r.RentalDate,
                                       DeliveryDate = r.DeliveryDate,
                                       StartingKm = r.StartingKm,
                                       FinishKm = r.FinishKm,
                                       Comment = r.Comment,
                                       CreatedDate = r.CreatedDate,
                                       CarId = r.CarId,
                                       Car = c.ToDto(),
                                   }).OrderByDescending(x=>x.CreatedDate).Take(count).ToList();
                return new DataResult<List<ReservationDto>>(200, reservations, new List<string> { "Başarılı" });

            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
