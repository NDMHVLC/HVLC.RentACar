using HVLC.RentACar.Data.Abstract;
using HVLC.RentACar.Entities.Concrete;
using HVLC.RentACar.Entities.Dtos;
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
                _unitOfWork.Reservations.Add(new Reservation
                {
                    RentalDate=reservationAddDto.RentalDate,
                    DeliveryDate=reservationAddDto.DeliveryDate,
                    StartingKm=reservationAddDto.StartingKm,
                    FinishKm=reservationAddDto.FinishKm,
                    Comment=reservationAddDto.Comment,
                    CarId=reservationAddDto.CarId,
                });
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

                return new Result(200, new List<string>() { "Rezervasyon kaydı başarılı bir şekilde silindi."});
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
                Reservation currentReservation = _unitOfWork.Reservations.Get(r => r.Id == reservationGetDto.Id);
                ReservationDto reservationDto = new()
                {
                    Id=currentReservation.Id,
                    RentalDate=currentReservation.RentalDate,
                    DeliveryDate=currentReservation.DeliveryDate,
                    StartingKm=currentReservation.StartingKm,
                    FinishKm=currentReservation.FinishKm,
                    Comment=currentReservation.Comment,
                    CarId=currentReservation.CarId,
                };

                return new DataResult<ReservationDto>(200, reservationDto, null);
            }
            catch (Exception ex)
            {
                return new DataResult<ReservationDto>(500, null, new List<string>() { "Teknik bir hata oluştu" }, ex);
            }
        }

        public DataResult<List<ReservationDto>> GetAll()
        {
            var reservation = _unitOfWork.Reservations.GetAll();
            if (reservation.Count>0)
            {
                List<ReservationDto> reservationDtos = new();
                foreach (var item in reservation)
                {
                    reservationDtos.Add(new ReservationDto
                    {
                        RentalDate = item.RentalDate,
                        DeliveryDate = item.DeliveryDate,
                        StartingKm = item.StartingKm,
                        FinishKm = item.FinishKm,
                        Comment = item.Comment,
                        CarId = item.CarId,
                    });
                }

                return new DataResult<List<ReservationDto>>(200, reservationDtos, null);
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
                currentReservation.DeliveryDate= reservationUpdateDto.DeliveryDate;
                currentReservation.StartingKm= reservationUpdateDto.StartingKm;
                currentReservation.FinishKm= reservationUpdateDto.FinishKm;
                currentReservation.Comment= reservationUpdateDto.Comment;
                currentReservation.CarId= reservationUpdateDto.CarId;
                currentReservation.ModifedBy = 1;
                currentReservation.ModifedDate=DateTime.Now;

                _unitOfWork.Reservations.Update(currentReservation);
                _unitOfWork.Save();

                return new Result(200, new List<string>() { "Rezervasyon kaydı başarılı bir şekilde güncellenmiştir" });

            }
            catch (Exception ex)
            {
                return new Result(200, new List<string>() { "Rezervasyon kaydı güncellenirken teknik bir hata oluştu" }, ex);
            }
        }
    }
}
